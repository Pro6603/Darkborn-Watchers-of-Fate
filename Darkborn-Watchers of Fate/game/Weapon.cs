using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using util.RenderHelper;

namespace game.Weapon
{
    public class Weapon
    {
        private readonly RenderHelper renderHelper = new RenderHelper();
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
        public int Durability { get; set; }
        public int MaxDurability { get; set; }
        public bool IsOwned { get; set; }

        private bool _isEquipped;
        public bool IsEquipped
        {
            get => _isEquipped;
            set
            {
                // only react when switching false → true
                if (!_isEquipped && value)
                {
                    renderHelper.RenderWeaponContext(this);
                }

                _isEquipped = value;
            }
        }

        public Weapon(Rarity _rarity, string name, string description, int? id, int durability, int damage, int maxDurability, bool isEquipped, bool isOwned) 
        {
            Description = description;
            Name = name;
            ID = id;
            Damage = damage;
            Durability = durability;
            MaxDurability = maxDurability;
            rarity = _rarity;
            IsEquipped = isEquipped;
            IsOwned = isOwned;
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
