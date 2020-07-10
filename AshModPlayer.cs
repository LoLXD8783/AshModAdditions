using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace AshModAdditions
{
    public class AshModPlayer : ModPlayer
    {
        public bool SandStormSpiritBuff, RedashHood;

        public override void ResetEffects()
        {
            SandStormSpiritBuff = false;
            RedashHood = false;
        }

        public override bool Shoot(Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (RedashHood)
            {
                speedX *= 1.01f;
                speedY *= 1.01f;
            }
            return true;
        }

        public override void PreUpdate()
        {

        }
    }
}
