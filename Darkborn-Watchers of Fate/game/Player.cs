using System;
using System.Collections.Generic;
using System.Text;
using game.Weapon;
using util.RenderHelper;


internal class randomutil
{
    public static Random random = new Random();
}

public class Player(string name)
{
    private RenderHelper helper = new RenderHelper();
    private WeaponCatalog weaponcatalog = new WeaponCatalog();

    private int _hp = 100;
    public int _stamina = 25;

    public int STAMINA
    {
        get => _stamina;
        set
        {
            if (_stamina != value)
            {
                _stamina = value;
                OnStaminaChanged();
            }
        }
    }

    public int HP
    {
        get => _hp;
        set
        {
            if (_hp != value)
            {
                _hp = value;
                OnHPChanged();
            }
        }
    }

    public string Name { get; } = name;

    public int AGE { get; set; } = randomutil.random.Next(46);

    private void OnStaminaChanged()
    {
        helper.RenderStamina(this);
    }

    private void OnHPChanged()
    {
        helper.RenderHP(this);
    }

    public void UnequipWeapon(Weapon? exeption)
    {
        foreach (var w in weaponcatalog.AllWeapons)
        {
            if (w.Name != exeption.Name)
            {
                w.IsEquipped = false;
            }
        }
    }

    public void EquipWeapon(Weapon weapon)
    {
        UnequipWeapon(weapon);
        weapon.IsEquipped = true;
    }
}