using System;
using System.Collections.Generic;
using System.Text;
using game.Spell;
using game.Weapon;

public class Inventory
{
    public Weapon EquippedWeapon;
    public Inventory() { }

    public List<Item> OwnedItems { get; } = new List<Item>();
    public List<Weapon> OwnedWeapons { get; } = new List<Weapon>();
    public List<Spell> OwnedSpells { get; } = new List<Spell>();

    public void AddItem(Item item, int amount)
    {
        Item existing = OwnedItems.Find(i => i.ID == item.ID);

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
    }

    public void RemoveItem(Item item, int amount)
    {
        Item existing = OwnedItems.Find(i => i.ID == item.ID);

        if (existing == null)
            return;

        existing.Amount -= amount;

        if (existing.Amount <= 0)
        {
            OwnedItems.Remove(existing);
        }
    }

    public void AddWeapon(Weapon weapon, bool setOwned)
    {
        Weapon existing = OwnedWeapons.Find(w => w.ID == weapon.ID);

        if (existing != null)
        {
            existing.IsOwned = setOwned;
        }
        else
        {
            OwnedWeapons.Add(new Weapon(
                weapon.getRarity(weapon),
                weapon.Name,
                weapon.Description,
                weapon.ID,
                weapon.Durability,
                weapon.Damage,
                weapon.MaxDurability,
                weapon.IsEquipped,
                weapon.IsOwned
            ));
        }
    }

    public bool CanRemoveWeapon(Weapon weapon)
    {
        Weapon existing = OwnedWeapons.Find(w => w.ID == weapon.ID);

        if (existing == null)
            return false;

        if (existing.IsEquipped)
            return false;

        return true;
    }


    public void RemoveWeapon(Weapon weapon)
    {
        Weapon existing = OwnedWeapons.Find(w => w.ID == weapon.ID);

        if (existing == null)
            return;

        OwnedWeapons.Remove(existing);
    }

}
