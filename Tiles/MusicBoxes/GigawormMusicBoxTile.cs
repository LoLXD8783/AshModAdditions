using Terraria.ModLoader;
using AshModAdditions.Items.MusicBoxes;

namespace AshModAdditions.Tiles.MusicBoxes
{
    public class GigawormMusicBoxTile  : MusicBoxTile
    {
        public override string MusicBoxName => "Gigaworm Music Box";
        public override int ItemType => ModContent.ItemType<GigawormMusicBox>();
    }
}
