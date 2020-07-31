﻿using Terraria.ID;
using Terraria.ModLoader;
using Bosspocalyps.Tiles.MusicBoxes;

namespace Bosspocalyps.Items.MusicBoxes
{
    public class OceanNightMusicBox : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ocean Night Music Box");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.createTile = ModContent.TileType<OceanNightMusicBoxTile>();
            item.consumable = true;
            item.accessory = true;
        }
    }
}
