using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ObjectData;
using Terraria.ModLoader;
using AshModAdditions.Items.MusicBoxes;
using Microsoft.Xna.Framework;

namespace AshModAdditions.Tiles.MusicBoxes
{
    public class KilographyMusicBoxTile : MusicBoxTile
    {
        public override string MusicBoxName => "Kilography Music Box";
        public override int ItemType => ModContent.ItemType<KilographyMusicBox>();
    }
}