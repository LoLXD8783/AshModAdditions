using System;
using Terraria;
using Terraria.ModLoader;
using AshModAdditions.Items.MusicBoxes;

namespace AshModAdditions.Tiles.MusicBoxes
{
    public class WallOfFleshMusicBoxTile : MusicBoxTile
    {
        public override string MusicBoxName => "Wall Of Flesh Music Box Tile";
        public override int ItemType => ModContent.ItemType<WallOfFleshMusicBox>();
    }
}
