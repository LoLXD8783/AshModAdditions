using Terraria.ModLoader;
using Bosspocalyps.Items.MusicBoxes;

namespace Bosspocalyps.Tiles.MusicBoxes
{
    public class KingSlimeMusicBoxTile : MusicBoxTile
    {
        public override string MusicBoxName => "King Slime Music Box";
        public override int ItemType => ModContent.ItemType<KingSlimeMusicBox>();
    }
}
