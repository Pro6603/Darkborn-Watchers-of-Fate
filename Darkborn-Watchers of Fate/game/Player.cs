using System;
using game.Weapon;
using util.RenderHelper;

internal class randomutil
{
    public static Random random = new Random();
}

public class Player
{
    private static WeaponCatalog weaponcatalog;

    private RenderHelper helper;

    public string Name { get; }

    private int _hp = 100;
    private int _stamina = 25;

    public int AGE { get; set; }

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

    public Player(string name)
    {
        Name = name;
        weaponcatalog = WeaponCatalog.Main;
        helper = new RenderHelper();
        AGE = randomutil.random.Next(46);
    }

    private void OnStaminaChanged() => helper.RenderStamina(this);
    private void OnHPChanged() => helper.RenderHP(this);
}
