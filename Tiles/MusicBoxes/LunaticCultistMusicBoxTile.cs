using System;
using Terraria;
using Terraria.ModLoader;
using AshModAdditions.Items.MusicBoxes;

namespace AshModAdditions.Tiles.MusicBoxes
{
    public class LunaticCultistMusicBoxTile : MusicBoxTile
    {
        public override string MusicBoxName => "Lunatic Cultist Music Box";
        public override int ItemType => ModContent.ItemType<LunaticCultistMusicBox>();
    }
}
