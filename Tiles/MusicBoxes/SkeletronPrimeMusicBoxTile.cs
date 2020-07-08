using System;
using Terraria;
using Terraria.ModLoader;
using AshModAdditions.Items.MusicBoxes;

namespace AshModAdditions.Tiles.MusicBoxes
{
    public class SkeletronPrimeMusicBoxTile : MusicBoxTile
    {
        public override string MusicBoxName => "Skeletron Prime Music Box Tile";
        public override int ItemType => ModContent.ItemType<SkeletronPrimeMusicBox>();
    }
}
