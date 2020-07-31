using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Bosspocalyps.Items.MusicBoxes;

namespace Bosspocalyps.Tiles.MusicBoxes
{
    public class TheDestroyerMusicBoxTile : MusicBoxTile
    {
        public override string MusicBoxName => "The Destroyer Music Box Tile";
        public override int ItemType => ModContent.ItemType<TheDestroyerMusicBox>();
    }
}
