using Terraria;
using Terraria.ModLoader;
using Bosspocalyps.Items.MusicBoxes;

namespace Bosspocalyps.Tiles.MusicBoxes
{
    public class DukeFishronMusicBoxTile : MusicBoxTile
    {
        public override string MusicBoxName => "Duke Fishron Music Box";
        public override int ItemType => ModContent.ItemType<DukeFishronMusicBox>();
    }
}
