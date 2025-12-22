using System;
using System.Collections.Generic;
using System.Text;
using game.Spell;
using game.Weapon;

public class Inventory
{
    public Weapon EquippedWeapon;
    public Inventory() { }

    public List<Weapon> OwnedWeapons { get; } = new List<Weapon>();
    public List<Item> OwnedItems { get; } = new List<Item>();
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

    
}
