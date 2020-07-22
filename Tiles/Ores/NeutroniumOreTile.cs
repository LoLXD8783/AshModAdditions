using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using AshModAdditions.Items.Tiles.Ores;

namespace AshModAdditions.Tiles.Ores
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
