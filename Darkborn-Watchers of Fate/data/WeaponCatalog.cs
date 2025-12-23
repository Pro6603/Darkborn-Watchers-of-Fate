using game.Weapon;

public class WeaponCatalog
{
    public List<Weapon> AllWeapons = new List<Weapon>();

    // COMMON
    public readonly Weapon WoodenStick;
    public readonly Weapon DullKnife;
    public readonly Weapon RustySword;
    public readonly Weapon WoodenClub;
    public readonly Weapon BentSpear;
    public readonly Weapon CrackedMace;
    public readonly Weapon ScrapAxe;

    // UNCOMMON
    public readonly Weapon IronSword;
    public readonly Weapon IronAxe;
    public readonly Weapon BoneClub;
    public readonly Weapon SteelKnife;
    public readonly Weapon SpikeSpear;
    public readonly Weapon HeavyMace;
    public readonly Weapon DarkIronBlade;

    // RARE
    public readonly Weapon NightBlade;
    public readonly Weapon BloodKnife;
    public readonly Weapon ShadowSword;
    public readonly Weapon BlackAxe;
    public readonly Weapon BoneEdge;
    public readonly Weapon GrimBlade;
    public readonly Weapon MoonSpear;

    // EPIC
    public readonly Weapon VoidBlade;
    public readonly Weapon SoulSword;
    public readonly Weapon DreadAxe;
    public readonly Weapon DarkFang;
    public readonly Weapon BlackSteel;
    public readonly Weapon GraveBlade;
    public readonly Weapon AshSword;

    // LEGENDARY
    public readonly Weapon Nightfall;
    public readonly Weapon DoomBlade;
    public readonly Weapon BlackMoon;
    public readonly Weapon SoulEdge;
    public readonly Weapon DarkStar;
    public readonly Weapon BloodMoon;

    // MYTHIC
    public readonly Weapon Void;
    public readonly Weapon Eclipse;
    public readonly Weapon Ruin;
    public readonly Weapon Abyss;
    public readonly Weapon Null;
    public readonly Weapon End;

    public WeaponCatalog()
    {
        // COMMON
        WoodenStick = Register(new Weapon(Weapon.Rarity.COMMON, "Wooden Stick", "A weak wooden stick.", 1, 40, 3, 40, false, false));
        DullKnife = Register(new Weapon(Weapon.Rarity.COMMON, "Dull Knife", "A blunt knife.", 2, 35, 4, 35, false, false));
        RustySword = Register(new Weapon(Weapon.Rarity.COMMON, "Rusty Sword", "An old rusty sword.", 3, 45, 5, 45, false, false));
        WoodenClub = Register(new Weapon(Weapon.Rarity.COMMON, "Wooden Club", "A heavy wooden club.", 4, 50, 6, 50, false, false));
        BentSpear = Register(new Weapon(Weapon.Rarity.COMMON, "Bent Spear", "A poorly forged spear.", 5, 40, 5, 40, false, false));
        CrackedMace = Register(new Weapon(Weapon.Rarity.COMMON, "Cracked Mace", "A damaged mace.", 6, 45, 6, 45, false, false));
        ScrapAxe = Register(new Weapon(Weapon.Rarity.COMMON, "Scrap Axe", "An axe made of scrap metal.", 7, 50, 6, 50, false, false));

        // UNCOMMON
        IronSword = Register(new Weapon(Weapon.Rarity.UNCOMMON, "Iron Sword", "A solid iron sword.", 8, 70, 9, 70, false, false));
        IronAxe = Register(new Weapon(Weapon.Rarity.UNCOMMON, "Iron Axe", "A reliable iron axe.", 9, 75, 10, 75, false, false));
        BoneClub = Register(new Weapon(Weapon.Rarity.UNCOMMON, "Bone Club", "A club reinforced with bone.", 10, 65, 9, 65, false, false));
        SteelKnife = Register(new Weapon(Weapon.Rarity.UNCOMMON, "Steel Knife", "A sharp steel knife.", 11, 60, 10, 60, false, false));
        SpikeSpear = Register(new Weapon(Weapon.Rarity.UNCOMMON, "Spike Spear", "A spear with metal spikes.", 12, 70, 11, 70, false, false));
        HeavyMace = Register(new Weapon(Weapon.Rarity.UNCOMMON, "Heavy Mace", "A crushing heavy mace.", 13, 80, 12, 80, false, false));
        DarkIronBlade = Register(new Weapon(Weapon.Rarity.UNCOMMON, "Dark Iron Blade", "A blade forged from dark iron.", 14, 85, 13, 85, false, false));

        // RARE
        NightBlade = Register(new Weapon(Weapon.Rarity.RARE, "Night Blade", "A blade that thrives in darkness.", 15, 100, 16, 100, false, false));
        BloodKnife = Register(new Weapon(Weapon.Rarity.RARE, "Blood Knife", "A knife stained with blood.", 16, 90, 15, 90, false, false));
        ShadowSword = Register(new Weapon(Weapon.Rarity.RARE, "Shadow Sword", "A sword of shadows.", 17, 110, 17, 110, false, false));
        BlackAxe = Register(new Weapon(Weapon.Rarity.RARE, "Black Axe", "An axe with dark power.", 18, 115, 18, 115, false, false));
        BoneEdge = Register(new Weapon(Weapon.Rarity.RARE, "Bone Edge", "A blade made from bone.", 19, 100, 16, 100, false, false));
        GrimBlade = Register(new Weapon(Weapon.Rarity.RARE, "Grim Blade", "A blade of grim fate.", 20, 120, 18, 120, false, false));
        MoonSpear = Register(new Weapon(Weapon.Rarity.RARE, "Moon Spear", "A spear blessed by moonlight.", 21, 115, 17, 115, false, false));

        // EPIC
        VoidBlade = Register(new Weapon(Weapon.Rarity.EPIC, "Void Blade", "A blade forged from the void.", 22, 150, 22, 150, false, false));
        SoulSword = Register(new Weapon(Weapon.Rarity.EPIC, "Soul Sword", "A sword that devours souls.", 23, 155, 23, 155, false, false));
        DreadAxe = Register(new Weapon(Weapon.Rarity.EPIC, "Dread Axe", "An axe of pure dread.", 24, 160, 24, 160, false, false));
        DarkFang = Register(new Weapon(Weapon.Rarity.EPIC, "Dark Fang", "A fang of darkness.", 25, 145, 21, 145, false, false));
        BlackSteel = Register(new Weapon(Weapon.Rarity.EPIC, "Black Steel", "Forged from cursed steel.", 26, 165, 25, 165, false, false));
        GraveBlade = Register(new Weapon(Weapon.Rarity.EPIC, "Grave Blade", "A blade from the grave.", 27, 170, 26, 170, false, false));
        AshSword = Register(new Weapon(Weapon.Rarity.EPIC, "Ash Sword", "A sword of ashes.", 28, 160, 24, 160, false, false));

        // LEGENDARY
        Nightfall = Register(new Weapon(Weapon.Rarity.LEGENDARY, "Nightfall", "Darkness incarnate.", 29, 220, 32, 220, false, false));
        DoomBlade = Register(new Weapon(Weapon.Rarity.LEGENDARY, "Doom Blade", "A blade of doom.", 30, 225, 33, 225, false, false));
        BlackMoon = Register(new Weapon(Weapon.Rarity.LEGENDARY, "Black Moon", "A cursed lunar weapon.", 31, 230, 34, 230, false, false));
        SoulEdge = Register(new Weapon(Weapon.Rarity.LEGENDARY, "Soul Edge", "A blade of souls.", 32, 235, 35, 235, false, false));
        DarkStar = Register(new Weapon(Weapon.Rarity.LEGENDARY, "Dark Star", "A star forged weapon.", 33, 240, 36, 240, false, false));
        BloodMoon = Register(new Weapon(Weapon.Rarity.LEGENDARY, "Blood Moon", "A weapon of crimson night.", 34, 245, 37, 245, false, false));

        // MYTHIC
        Void = Register(new Weapon(Weapon.Rarity.MYTHIC, "Void", "The end of all things.", 35, 300, 50, 300, false, false));
        Eclipse = Register(new Weapon(Weapon.Rarity.MYTHIC, "Eclipse", "Light and dark combined.", 36, 310, 52, 310, false, false));
        Ruin = Register(new Weapon(Weapon.Rarity.MYTHIC, "Ruin", "Bringer of destruction.", 37, 320, 55, 320, false, false));
        Abyss = Register(new Weapon(Weapon.Rarity.MYTHIC, "Abyss", "Endless darkness.", 38, 330, 58, 330, false, false));
        Null = Register(new Weapon(Weapon.Rarity.MYTHIC, "Null", "Nothingness itself.", 39, 340, 60, 340, false, false));
        End = Register(new Weapon(Weapon.Rarity.MYTHIC, "End", "? The End ?", 40, 350, 65, 350, false, false));

    }

    private Weapon Register(Weapon weapon)
    {
        AllWeapons.Add(weapon);
        return weapon;
    }
}
