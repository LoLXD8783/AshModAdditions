using System;
using Terraria;
using Terraria.ModLoader;
using Bosspocalyps.Items.MusicBoxes;

namespace Bosspocalyps.Tiles.MusicBoxes
{
    public class TyphoonMusicBoxTile : MusicBoxTile
    {
        public override string MusicBoxName => "Typhoon Music Box";
        public override int ItemType => ModContent.ItemType<TyphoonMusicBox>();
    }
}
