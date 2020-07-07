using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Tiles;

namespace AshModAdditions.Items
{
    public class UnholyResearchStation : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Unholy Research Station");
        }

        public override void SetDefaults()
        {
            item.useTime = 10;
            item.useAnimation = 10;
            item.width = 48;
            item.height = 32;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.createTile = ModContent.TileType<UnholyResearchStationTile>();
            item.consumable = true;
        }
    }
}
