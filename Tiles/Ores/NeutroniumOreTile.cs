using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Bosspocalyps.Items.Tiles.Ores;

namespace Bosspocalyps.Tiles.Ores
{
    public class NeutroniumOreTile : OreTile
    {
        public override int ItemDropType => ModContent.ItemType<NeutroniumOre>();
        public override string TileName => "Neutronium Ore";
        public override Color TileMapColor => Color.SkyBlue;

        public override void SetDefaults()
        {
            base.SetDefaults();
        }
    }
}
