using game.Weapon;

public class ItemCatalog
{
    public List<Item> AllItems = new List<Item>();

    public readonly Item LongStick;
    public readonly Item ShortStick;
    public readonly Item Torch;
    public readonly Item Rope;
    public readonly Item WoodPlank;
    public readonly Item StoneBlock;
    public readonly Item IronOre;

    public readonly Item IronIngot;
    public readonly Item SteelIngot;
    public readonly Item Leather;
    public readonly Item Cloth;
    public readonly Item Thread;

    public readonly Item Bone;
    public readonly Item Fang;
    public readonly Item Feather;
    public readonly Item Resin;
    public readonly Item Charcoal;

    public readonly Item Flint;
    public readonly Item LeatherStrap;
    public readonly Item MetalScrap;
    public readonly Item WoodenHandle;
    public readonly Item GripWrap;

    public readonly Item GemShard;
    public readonly Item MagicDust;
    public readonly Item CrystalCore;
    public readonly Item OilFlask;
    public readonly Item Wax;

    public readonly Item Hide;
    public readonly Item Sand;
    public readonly Item GlassShard;
    public readonly Item Ash;
    public readonly Item Coal;

    public readonly Item Nails;
    public readonly Item Glue;
    public readonly Item LeatherPadding;
    public readonly Item MetalPlate;
    public readonly Item SharpeningStone;

    public readonly Item BlueprintFragment;
    public readonly Item BindingPowder;
    public readonly Item ReinforcedFiber;
    public readonly Item MetalRod;
    public readonly Item TorchOil;

    public ItemCatalog()
    {
        LongStick = Register(new Item(41, "Long Stick", "A long stick.", 0, "long_stick_icon"));
        ShortStick = Register(new Item(42, "Short Stick", "A short stick.", 0, "short_stick_icon"));

        Torch = Register(new Item(1, "Torch", "Provides light in dark areas.", 0, "torch_icon"));
        Rope = Register(new Item(2, "Rope", "Useful for climbing or crafting.", 0, "rope_icon"));
        WoodPlank = Register(new Item(3, "Wood Plank", "Basic crafting material.", 0, "wood_plank_icon"));
        StoneBlock = Register(new Item(4, "Stone Block", "Rough stone used in crafting.", 0, "stone_block_icon"));
        IronOre = Register(new Item(5, "Iron Ore", "Unrefined iron material.", 0, "iron_ore_icon"));

        IronIngot = Register(new Item(6, "Iron Ingot", "Refined iron used for crafting weapons.", 0, "iron_ingot_icon"));
        SteelIngot = Register(new Item(7, "Steel Ingot", "Strong metal for advanced gear.", 0, "steel_ingot_icon"));
        Leather = Register(new Item(8, "Leather", "Treated animal hide.", 0, "leather_icon"));
        Cloth = Register(new Item(9, "Cloth", "Soft fabric used in armor crafting.", 0, "cloth_icon"));
        Thread = Register(new Item(10, "Thread", "Used to stitch leather and cloth.", 0, "thread_icon"));

        Bone = Register(new Item(11, "Bone", "Animal bone used in crafting.", 0, "bone_icon"));
        Fang = Register(new Item(12, "Fang", "Sharp animal fang.", 0, "fang_icon"));
        Feather = Register(new Item(13, "Feather", "Light material for arrows and gear.", 0, "feather_icon"));
        Resin = Register(new Item(14, "Resin", "Sticky substance used as adhesive.", 0, "resin_icon"));
        Charcoal = Register(new Item(15, "Charcoal", "Fuel for smelting ores.", 0, "charcoal_icon"));

        Flint = Register(new Item(16, "Flint", "Used to create sparks.", 0, "flint_icon"));
        LeatherStrap = Register(new Item(17, "Leather Strap", "Binding material for weapons.", 0, "leather_strap_icon"));
        MetalScrap = Register(new Item(18, "Metal Scrap", "Leftover metal pieces.", 0, "metal_scrap_icon"));
        WoodenHandle = Register(new Item(19, "Wooden Handle", "Handle for weapons.", 0, "wooden_handle_icon"));
        GripWrap = Register(new Item(20, "Grip Wrap", "Improves weapon handling.", 0, "grip_wrap_icon"));

        GemShard = Register(new Item(21, "Gem Shard", "Fragment of a magical gem.", 0, "gem_shard_icon"));
        MagicDust = Register(new Item(22, "Magic Dust", "Used to enchant items.", 0, "magic_dust_icon"));
        CrystalCore = Register(new Item(23, "Crystal Core", "Powerful crafting component.", 0, "crystal_core_icon"));
        OilFlask = Register(new Item(24, "Oil Flask", "Used for torches or crafting.", 0, "oil_flask_icon"));
        Wax = Register(new Item(25, "Wax", "Used for sealing and crafting.", 0, "wax_icon"));

        Hide = Register(new Item(26, "Animal Hide", "Untreated leather material.", 0, "hide_icon"));
        Sand = Register(new Item(27, "Sand", "Fine grains used in crafting.", 0, "sand_icon"));
        GlassShard = Register(new Item(28, "Glass Shard", "Sharp piece of glass.", 0, "glass_shard_icon"));
        Ash = Register(new Item(29, "Ash", "Remains from burnt materials.", 0, "ash_icon"));
        Coal = Register(new Item(30, "Coal", "Efficient smelting fuel.", 0, "coal_icon"));

        Nails = Register(new Item(31, "Nails", "Used to bind materials together.", 0, "nails_icon"));
        Glue = Register(new Item(32, "Glue", "Strong adhesive for crafting.", 0, "glue_icon"));
        LeatherPadding = Register(new Item(33, "Leather Padding", "Adds comfort to armor.", 0, "leather_padding_icon"));
        MetalPlate = Register(new Item(34, "Metal Plate", "Flat metal used in armor crafting.", 0, "metal_plate_icon"));
        SharpeningStone = Register(new Item(35, "Sharpening Stone", "Used to maintain weapon edges.", 0, "sharpening_stone_icon"));

        BlueprintFragment = Register(new Item(36, "Blueprint Fragment", "Part of a crafting blueprint.", 0, "blueprint_fragment_icon"));
        BindingPowder = Register(new Item(37, "Binding Powder", "Magical binding agent.", 0, "binding_powder_icon"));
        ReinforcedFiber = Register(new Item(38, "Reinforced Fiber", "Durable crafting fiber.", 0, "reinforced_fiber_icon"));
        MetalRod = Register(new Item(39, "Metal Rod", "Structural crafting component.", 0, "metal_rod_icon"));
        TorchOil = Register(new Item(40, "Torch Oil", "Fuel used to keep torches burning.", 0, "torch_oil_icon"));
    }

    private Item Register(Item item)
    {
        AllItems.Add(item);
        return item;
    }
}
