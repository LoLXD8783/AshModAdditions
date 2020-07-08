using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using AshModAdditions.Items.MusicBoxes;

namespace AshModAdditions.Tiles.MusicBoxes
{
    public class TheDestroyerMusicBoxTile : MusicBoxTile
    {
        public override string MusicBoxName => "The Destroyer Music Box Tile";
        public override int ItemType => ModContent.ItemType<TheDestroyerMusicBox>();
    }
}
