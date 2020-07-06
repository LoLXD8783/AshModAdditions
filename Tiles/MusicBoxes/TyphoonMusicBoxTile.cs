using System;
using Terraria;
using Terraria.ModLoader;
using AshModAdditions.Items.MusicBoxes;

namespace AshModAdditions.Tiles.MusicBoxes
{
    public class TyphoonMusicBoxTile : MusicBoxTile
    {
        public override string MusicBoxName => "Typhoon Music Box";
        public override int ItemType => ModContent.ItemType<TyphoonMusicBox>();
    }
}
