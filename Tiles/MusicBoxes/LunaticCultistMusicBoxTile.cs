using System;
using Terraria;
using Terraria.ModLoader;
using Bosspocalyps.Items.MusicBoxes;

namespace Bosspocalyps.Tiles.MusicBoxes
{
    public class LunaticCultistMusicBoxTile : MusicBoxTile
    {
        public override string MusicBoxName => "Lunatic Cultist Music Box";
        public override int ItemType => ModContent.ItemType<LunaticCultistMusicBox>();
    }
}
