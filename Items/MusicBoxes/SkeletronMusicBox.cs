using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Tiles.MusicBoxes;

namespace AshModAdditions.Items.MusicBoxes
{
    public class SkeletronMusicBox : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Skeletron Music Box");
        }

        public override void SetDefaults()
        {
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.createTile = ModContent.TileType<SkeletronMusicBoxTile>();
            item.consumable = true;
            item.accessory = true;
            item.width = 30;
            item.height = 20;
        }
    }
}
