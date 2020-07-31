using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Bosspocalyps.Items.Tiles.Ores;

namespace Bosspocalyps.Tiles.Ores
{
    public class IridiumOreTile : OreTile
    {
        public override Color TileMapColor => Color.DarkGreen;
        public override string TileName => "Iridium Ore";
        public override int ItemDropType => ModContent.ItemType<IridiumOre>();

        public override void SetDefaults()
        {
            base.SetDefaults();
            minPick = 255;
        }
    }
}
