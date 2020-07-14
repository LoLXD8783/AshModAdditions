using Terraria.ModLoader;
using AshModAdditions.Items.MusicBoxes;

namespace AshModAdditions.Tiles.MusicBoxes
{
    public class EaterOfWorldsMusicBoxTile : MusicBoxTile
    {
        public override string MusicBoxName => "Eater of Worlds Music Box";
        public override int ItemType => ModContent.ItemType<EaterOfWorldsMusicBox>();
    }
}
