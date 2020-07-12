using Terraria;
using Terraria.ModLoader;
using AshModAdditions.Items.MusicBoxes;

namespace AshModAdditions.Tiles.MusicBoxes
{
    public class HallowNightMusicBoxTile : MusicBoxTile
    {
        public override string MusicBoxName => "Hallow Night Music Box";
        public override int ItemType => ModContent.ItemType<HallowNightMusicBox>();
    }
}
