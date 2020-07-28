using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AshModAdditions.Projectiles;
using AshModAdditions.Buffs.Debuffs;

namespace AshModAdditions.Projectiles.Ammo
{
    public class MechaArrowProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mecha Arrow");
        }

        public override void SetDefaults()
        {
            projectile.friendly = true;
            projectile.arrow = true;
            projectile.ranged = true;
            projectile.width = 14;
            projectile.height = 38;
            projectile.aiStyle = 1;
            aiType = 1;
        }

        public override void AI()
        {
            //ProjectileHelpers.ArrowAI(projectile, ref projectile.ai[0], MathHelper.PiOver2 + MathHelper.Pi);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(ModContent.BuffType<VirusDebuff>(), 120);
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(ModContent.BuffType<VirusDebuff>(), 120);
        }

        public override void OnHitPvp(Player target, int damage, bool crit)
        {
            target.AddBuff(ModContent.BuffType<VirusDebuff>(), 120);
        }
    }
}
