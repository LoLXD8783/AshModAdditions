using System;
using Terraria;
using Terraria.ModLoader;
using Bosspocalyps.Tiles.Ores;

namespace Bosspocalyps.Items.Tiles.Ores
{
    public class BinariteOre : OreItem
    {
        public override int TileType => ModContent.TileType<BinariteOreTile>();
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Binarite Ore");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.width = 24;
            item.height = 24;
        }
    }
}
