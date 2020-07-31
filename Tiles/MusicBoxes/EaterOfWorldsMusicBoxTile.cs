using Terraria.ModLoader;
using Bosspocalyps.Items.MusicBoxes;

namespace Bosspocalyps.Tiles.MusicBoxes
{
    public class EaterOfWorldsMusicBoxTile : MusicBoxTile
    {
        public override string MusicBoxName => "Eater of Worlds Music Box";
        public override int ItemType => ModContent.ItemType<EaterOfWorldsMusicBox>();
    }
}
