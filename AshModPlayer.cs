using System;
using Terraria;
using Terraria.ModLoader;

namespace AshModAdditions
{
    public class AshModPlayer : ModPlayer
    {
        public bool SandStormSpiritBuff;

        public override void ResetEffects()
        {
            SandStormSpiritBuff = false;
        }

        public override void PreUpdate()
        {

        }
    }
}
