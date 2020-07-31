using System;
using Terraria;
using Terraria.ModLoader;
using Bosspocalyps.Items.MusicBoxes;

namespace Bosspocalyps.Tiles.MusicBoxes
{
    public class SkeletronMusicBoxTile : MusicBoxTile
    {
        public override string MusicBoxName => "Skeletron Music Box";
        public override int ItemType => ModContent.ItemType<SkeletronMusicBox>();
    }
}
