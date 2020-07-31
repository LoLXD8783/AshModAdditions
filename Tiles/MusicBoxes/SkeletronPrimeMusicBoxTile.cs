using System;
using Terraria;
using Terraria.ModLoader;
using Bosspocalyps.Items.MusicBoxes;

namespace Bosspocalyps.Tiles.MusicBoxes
{
    public class SkeletronPrimeMusicBoxTile : MusicBoxTile
    {
        public override string MusicBoxName => "Skeletron Prime Music Box Tile";
        public override int ItemType => ModContent.ItemType<SkeletronPrimeMusicBox>();
    }
}
