using System;
using System.Collections.Generic;
using System.Linq;
using game.Spell;
using game.Weapon;

public class Inventory
{
    public Weapon EquippedWeapon { get; private set; }

    private WeaponCatalog weaponcatalog;

    public List<Item> OwnedItems { get; } = new List<Item>();
    public List<Weapon> OwnedWeapons { get; } = new List<Weapon>();
    public List<Spell> OwnedSpells { get; } = new List<Spell>();

    public event Action OnInventoryChanged;

    public Inventory()
    {
        weaponcatalog = WeaponCatalog.Main;
    }

    private void NotifyInventoryChanged() => OnInventoryChanged?.Invoke();

    #region Item Management

    public void AddItem(Item item, int amount)
    {
        if (item == null || amount <= 0) return;

        var existing = OwnedItems.Find(i => i.ID == item.ID);
        if (existing != null)
        {
            existing.Amount += amount;
        }
        else
        {
            OwnedItems.Add(new Item(
                item.ID,
                item.Name,
                item.Description,
                amount,
                item.Icon
            ));
        }

        NotifyInventoryChanged();
    }

    public void RemoveItem(Item item, int amount)
    {
        if (item == null || amount <= 0) return;

        var existing = OwnedItems.Find(i => i.ID == item.ID);
        if (existing == null) return;

        existing.Amount -= amount;
        if (existing.Amount <= 0)
            OwnedItems.Remove(existing);

        NotifyInventoryChanged();
    }

    #endregion

    #region Weapon Management

    public void AddWeapon(Weapon weapon, bool setOwned = true)
    {
        if (weapon == null) return;

        var existing = OwnedWeapons.Find(w => w.ID == weapon.ID);
        if (existing != null)
        {
            existing.IsOwned = setOwned;
            NotifyInventoryChanged();
            return;
        }

        OwnedWeapons.Add(new Weapon(
            weapon.getRarity(),
            weapon.Name,
            weapon.Description,
            weapon.ID,
            weapon.Durability,
            weapon.Damage,
            weapon.MaxDurability,
            weapon.IsEquipped,
            setOwned,
            weaponcatalog
        ));

        NotifyInventoryChanged();
    }

    public bool CanRemoveWeapon(Weapon weapon)
    {
        if (weapon == null) return false;

        var existing = OwnedWeapons.Find(w => w.ID == weapon.ID);
        return existing != null && !existing.IsEquipped;
    }

    public void RemoveWeapon(Weapon weapon)
    {
        if (!CanRemoveWeapon(weapon)) return;

        var existing = OwnedWeapons.Find(w => w.ID == weapon.ID);
        if (existing != null)
        {
            OwnedWeapons.Remove(existing);
            NotifyInventoryChanged();
        }
    }

    public bool EquipWeapon(Weapon weapon)
    {
        if (weapon == null) return false;

        var existing = OwnedWeapons.Find(w => w.ID == weapon.ID && w.IsOwned);
        if (existing == null) return false;

        foreach (var w in OwnedWeapons)
            w.IsEquipped = false;

        existing.IsEquipped = true;
        EquippedWeapon = existing;

        NotifyInventoryChanged();
        return true;
    }

    #endregion

    /*
    #region Spell Management

    public void AddSpell(Spell spell)
    {
        if (spell == null) return;

        if (!OwnedSpells.Any(s => s.ID == spell.ID))
        {
            OwnedSpells.Add(spell);
            NotifyInventoryChanged();
        }
    }

    public void RemoveSpell(Spell spell)
    {
        if (spell == null) return;

        OwnedSpells.RemoveAll(s => s.ID == spell.ID);
        NotifyInventoryChanged();
    }

    #endregion
    */
}
