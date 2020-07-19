using Terraria.ModLoader;
using AshModAdditions.Items.MusicBoxes;

namespace AshModAdditions.Tiles.MusicBoxes
{
    public class TheIceMusicBoxTile : MusicBoxTile
    {
        public override string MusicBoxName => "The Ice Music Box";
        public override int ItemType => ModContent.ItemType<TheIceMusicBox>();
    }
}
