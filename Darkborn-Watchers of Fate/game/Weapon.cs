using System;
using util.RenderHelper;

namespace game.Weapon
{
    public class Weapon
    {
        private static WeaponCatalog weaponCatalog;

        private RenderHelper renderHelper;

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
                if (!_isEquipped && value)
                    renderHelper.RenderWeaponContext(this);
                _isEquipped = value;
            }
        }

        public Weapon(Rarity _rarity, string name, string description, int? id, int durability, int damage, int maxDurability, bool isEquipped, bool isOwned, WeaponCatalog catalog)
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

            weaponCatalog = catalog;
            renderHelper = new RenderHelper();
        }

        public bool isWeaponContextComplete()
        {
            return !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Description) && ID.HasValue && ID != 0 && Damage > 0;
        }

        public Rarity getRarity()
        {
            return rarity;
        }
    }
}
