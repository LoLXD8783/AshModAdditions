using System;
using Terraria;
using Terraria.ModLoader;
using AshModAdditions.Items.MusicBoxes;

namespace AshModAdditions.Tiles.MusicBoxes
{
    public class SkeletronMusicBoxTile : MusicBoxTile
    {
        public override string MusicBoxName => "Skeletron Music Box";
        public override int ItemType => ModContent.ItemType<SkeletronMusicBox>();
    }
}
