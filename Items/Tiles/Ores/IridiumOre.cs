using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using AshModAdditions.Tiles.Ores;

namespace AshModAdditions.Items.Tiles.Ores
{
    public class IridiumOre : OreItem
    {
        public override int TileType => ModContent.TileType<IridiumOreTile>();

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Iridium Ore");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.width = 22;
            item.height = 22;
        }
    }
}
