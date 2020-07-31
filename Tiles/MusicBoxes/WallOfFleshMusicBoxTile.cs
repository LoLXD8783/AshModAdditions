using System;
using Terraria;
using Terraria.ModLoader;
using Bosspocalyps.Items.MusicBoxes;

namespace Bosspocalyps.Tiles.MusicBoxes
{
    public class WallOfFleshMusicBoxTile : MusicBoxTile
    {
        public override string MusicBoxName => "Wall Of Flesh Music Box Tile";
        public override int ItemType => ModContent.ItemType<WallOfFleshMusicBox>();
    }
}
