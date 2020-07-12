using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace AshModAdditions
{
    public class AshModPlayer : ModPlayer
    {
        public bool SandStormSpiritBuff, RedashHood, FrostiteEffect;

        public override void ResetEffects()
        {
            SandStormSpiritBuff = false;
            RedashHood = false;
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (FrostiteEffect)
                target.AddBuff(BuffID.Frostburn, 120);
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (FrostiteEffect)
                target.AddBuff(BuffID.Frostburn, 120);
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
