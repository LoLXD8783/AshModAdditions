using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AshModAdditions.Tiles.Warped
{
    public class WarpedSoilTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;

            AddMapEntry(new Color(177, 255, 253));
        }
    }
}
