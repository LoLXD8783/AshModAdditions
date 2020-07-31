using Terraria;
using Terraria.ModLoader;
using Bosspocalyps.Items.MusicBoxes;

namespace Bosspocalyps.Tiles.MusicBoxes
{
    public class HallowNightMusicBoxTile : MusicBoxTile
    {
        public override string MusicBoxName => "Hallow Night Music Box";
        public override int ItemType => ModContent.ItemType<HallowNightMusicBox>();
    }
}
