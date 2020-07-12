using Terraria;
using Terraria.ModLoader;
using AshModAdditions.Items.MusicBoxes;

namespace AshModAdditions.Tiles.MusicBoxes
{
    public class DukeFishronMusicBoxTile : MusicBoxTile
    {
        public override string MusicBoxName => "Duke Fishron Music Box";
        public override int ItemType => ModContent.ItemType<DukeFishronMusicBox>();
    }
}
