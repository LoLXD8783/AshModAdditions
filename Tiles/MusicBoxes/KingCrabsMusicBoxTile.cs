using Terraria.ModLoader;
using AshModAdditions.Items.MusicBoxes;

namespace AshModAdditions.Tiles.MusicBoxes
{
    class KingCrabsMusicBoxTile : MusicBoxTile
    {
        public override string MusicBoxName => "King Crabs Music Box";
        public override int ItemType => ModContent.ItemType<KingCrabsMusicBox>();
    }
}
