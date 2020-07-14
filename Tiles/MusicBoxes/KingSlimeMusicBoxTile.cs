using Terraria.ModLoader;
using AshModAdditions.Items.MusicBoxes;

namespace AshModAdditions.Tiles.MusicBoxes
{
    public class KingSlimeMusicBoxTile : MusicBoxTile
    {
        public override string MusicBoxName => "King Slime Music Box";
        public override int ItemType => ModContent.ItemType<KingSlimeMusicBox>();
    }
}
