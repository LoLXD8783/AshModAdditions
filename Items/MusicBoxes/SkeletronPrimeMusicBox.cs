using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Tiles.MusicBoxes;

namespace AshModAdditions.Items.MusicBoxes
{
    public class SkeletronPrimeMusicBox : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Skeletron Prime Music Box");
        }

        public override void SetDefaults()
        {
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.createTile = ModContent.TileType<SkeletronPrimeMusicBoxTile>();
            item.consumable = true;
            item.accessory = true;
            item.width = 30;
            item.height = 20;
        }
    }
}
