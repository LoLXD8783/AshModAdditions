using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AshModAdditions.Items.Tiles.Ores
{
    public abstract class OreItem : ModItem
    {
        public abstract int TileType { get; }

        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            item.material = true;
            item.useTurn = true;
            item.autoReuse = true;
            item.consumable = true;
            item.maxStack = 999;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.createTile = TileType;
        }
    }
}
