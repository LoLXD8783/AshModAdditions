using Terraria.ModLoader;
using Bosspocalyps.Items.MusicBoxes;

namespace Bosspocalyps.Tiles.MusicBoxes
{
    class KingCrabsMusicBoxTile : MusicBoxTile
    {
        public override string MusicBoxName => "King Crabs Music Box";
        public override int ItemType => ModContent.ItemType<KingCrabsMusicBox>();
    }
}
