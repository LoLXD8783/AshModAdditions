using Terraria.ModLoader;
using Bosspocalyps.Items.MusicBoxes;

namespace Bosspocalyps.Tiles.MusicBoxes
{
    public class TheIceMusicBoxTile : MusicBoxTile
    {
        public override string MusicBoxName => "The Ice Music Box";
        public override int ItemType => ModContent.ItemType<TheIceMusicBox>();
    }
}
