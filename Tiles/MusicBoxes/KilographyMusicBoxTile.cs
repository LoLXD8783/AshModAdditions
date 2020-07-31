using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ObjectData;
using Terraria.ModLoader;
using Bosspocalyps.Items.MusicBoxes;
using Microsoft.Xna.Framework;

namespace Bosspocalyps.Tiles.MusicBoxes
{
    public class KilographyMusicBoxTile : MusicBoxTile
    {
        public override string MusicBoxName => "Kilography Music Box";
        public override int ItemType => ModContent.ItemType<KilographyMusicBox>();
    }
}