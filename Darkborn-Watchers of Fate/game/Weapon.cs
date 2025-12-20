using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace game.Weapon
{
    public class Weapon
    {
        public enum Rarity
        {
            COMMON,
            UNCOMMON,
            RARE,
            EPIC,
            LEGENDARY,
            MYTHIC
        }

        public Rarity rarity { get; }
        public string Name { get; }
        public string Description { get; set; }
        public int? ID { get; }
        public int Damage { get; }
        public int? Cooldown { get; }

        public Weapon(Rarity _rarity, string name, string description, int? id, int damage, int? cooldown) 
        {
            Description = description;
            Name = name;
            ID = id;
            Damage = damage;
            Cooldown = cooldown;
            rarity = _rarity;
        }

        public bool isWeaponContextComplete(Weapon weapon)
        {
            // cooldown not required
            if (rarity != null && Name != null && Description != null && ID != null || ID != 0 || ID != 00 && Damage > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Rarity getRarity(Weapon weapon)
        {
            return weapon.rarity;
        }
    }
}
