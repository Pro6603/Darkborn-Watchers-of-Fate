public class ItemCatalog
{
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
        LongStick = new Item(41, "Long Stick", "A long stick.", 0, "long_stick_icon");
        ShortStick = new Item(42, "Short Stick", "A short stick.", 0, "short_stick_icon");

        Torch = new Item(1, "Torch", "Provides light in dark areas.", 0, "torch_icon");
        Rope = new Item(2, "Rope", "Useful for climbing or crafting.", 0, "rope_icon");
        WoodPlank = new Item(3, "Wood Plank", "Basic crafting material.", 0, "wood_plank_icon");
        StoneBlock = new Item(4, "Stone Block", "Rough stone used in crafting.", 0, "stone_block_icon");
        IronOre = new Item(5, "Iron Ore", "Unrefined iron material.", 0, "iron_ore_icon");

        IronIngot = new Item(6, "Iron Ingot", "Refined iron used for crafting weapons.", 0, "iron_ingot_icon");
        SteelIngot = new Item(7, "Steel Ingot", "Strong metal for advanced gear.", 0, "steel_ingot_icon");
        Leather = new Item(8, "Leather", "Treated animal hide.", 0, "leather_icon");
        Cloth = new Item(9, "Cloth", "Soft fabric used in armor crafting.", 0, "cloth_icon");
        Thread = new Item(10, "Thread", "Used to stitch leather and cloth.", 0, "thread_icon");

        Bone = new Item(11, "Bone", "Animal bone used in crafting.", 0, "bone_icon");
        Fang = new Item(12, "Fang", "Sharp animal fang.", 0, "fang_icon");
        Feather = new Item(13, "Feather", "Light material for arrows and gear.", 0, "feather_icon");
        Resin = new Item(14, "Resin", "Sticky substance used as adhesive.", 0, "resin_icon");
        Charcoal = new Item(15, "Charcoal", "Fuel for smelting ores.", 0, "charcoal_icon");

        Flint = new Item(16, "Flint", "Used to create sparks.", 0, "flint_icon");
        LeatherStrap = new Item(17, "Leather Strap", "Binding material for weapons.", 0, "leather_strap_icon");
        MetalScrap = new Item(18, "Metal Scrap", "Leftover metal pieces.", 0, "metal_scrap_icon");
        WoodenHandle = new Item(19, "Wooden Handle", "Handle for weapons.", 0, "wooden_handle_icon");
        GripWrap = new Item(20, "Grip Wrap", "Improves weapon handling.", 0, "grip_wrap_icon");

        GemShard = new Item(21, "Gem Shard", "Fragment of a magical gem.", 0, "gem_shard_icon");
        MagicDust = new Item(22, "Magic Dust", "Used to enchant items.", 0, "magic_dust_icon");
        CrystalCore = new Item(23, "Crystal Core", "Powerful crafting component.", 0, "crystal_core_icon");
        OilFlask = new Item(24, "Oil Flask", "Used for torches or crafting.", 0, "oil_flask_icon");
        Wax = new Item(25, "Wax", "Used for sealing and crafting.", 0, "wax_icon");

        Hide = new Item(26, "Animal Hide", "Untreated leather material.", 0, "hide_icon");
        Sand = new Item(27, "Sand", "Fine grains used in crafting.", 0, "sand_icon");
        GlassShard = new Item(28, "Glass Shard", "Sharp piece of glass.", 0, "glass_shard_icon");
        Ash = new Item(29, "Ash", "Remains from burnt materials.", 0, "ash_icon");
        Coal = new Item(30, "Coal", "Efficient smelting fuel.", 0, "coal_icon");

        Nails = new Item(31, "Nails", "Used to bind materials together.", 0, "nails_icon");
        Glue = new Item(32, "Glue", "Strong adhesive for crafting.", 0, "glue_icon");
        LeatherPadding = new Item(33, "Leather Padding", "Adds comfort to armor.", 0, "leather_padding_icon");
        MetalPlate = new Item(34, "Metal Plate", "Flat metal used in armor crafting.", 0, "metal_plate_icon");
        SharpeningStone = new Item(35, "Sharpening Stone", "Used to maintain weapon edges.", 0, "sharpening_stone_icon");

        BlueprintFragment = new Item(36, "Blueprint Fragment", "Part of a crafting blueprint.", 0, "blueprint_fragment_icon");
        BindingPowder = new Item(37, "Binding Powder", "Magical binding agent.", 0, "binding_powder_icon");
        ReinforcedFiber = new Item(38, "Reinforced Fiber", "Durable crafting fiber.", 0, "reinforced_fiber_icon");
        MetalRod = new Item(39, "Metal Rod", "Structural crafting component.", 0, "metal_rod_icon");
        TorchOil = new Item(40, "Torch Oil", "Fuel used to keep torches burning.", 0, "torch_oil_icon");
    }
}
