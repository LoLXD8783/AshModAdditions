using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using AshModAdditions.Items.Tiles.Ores;

namespace AshModAdditions.Tiles.Ores
{
    public class BinariteOreTile : OreTile
    {
        public override Color TileMapColor => Color.LawnGreen;
        public override string TileName => "Binarite Ore";
        public override int ItemDropType => ModContent.ItemType<BinariteOre>();
    }
}
