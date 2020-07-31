using Terraria.ModLoader;
using Bosspocalyps.Items.MusicBoxes;

namespace Bosspocalyps.Tiles.MusicBoxes
{
    public class GigawormMusicBoxTile  : MusicBoxTile
    {
        public override string MusicBoxName => "Gigaworm Music Box";
        public override int ItemType => ModContent.ItemType<GigawormMusicBox>();
    }
}
