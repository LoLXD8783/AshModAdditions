using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace AshModAdditions.Projectiles
{
    class FrostiteSpearProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frostite Spear");
        }

        public override void SetDefaults()
        {
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.melee = true;
            projectile.penetrate = -1;
            projectile.width = 90;
            projectile.height = 90;
            // projectile.hide = true;
            projectile.ownerHitCheck = true;
        }

        public override void AI()
        {
            Player owner = Main.player[projectile.owner];
            if (owner.itemAnimation <= 0)
                projectile.Kill();
            float speedrot = projectile.velocity.ToRotation();
            projectile.rotation = speedrot + MathHelper.Pi * 3/4;
            float progress = 1f / owner.itemAnimationMax * (owner.itemAnimationMax - owner.itemAnimation);
            float progress2 = 1f - progress * 2;
            if (progress2 <= 0f && projectile.ai[1] == 0) // halfway
            {
                projectile.ai[1] = 1;
                Projectile.NewProjectile(projectile.Center, projectile.velocity, ModContent.ProjectileType<FrostWave>(), projectile.damage, projectile.knockBack, projectile.owner);
            }
            Vector2 off = new Vector2(4, 0).RotatedBy(speedrot);
            projectile.Center = Vector2.Lerp(owner.MountedCenter, owner.MountedCenter + off * 14, 1f-Math.Abs(progress2));
        }
    }
}
