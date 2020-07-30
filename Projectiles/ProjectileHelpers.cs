using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace AshModAdditions.Projectiles
{
    internal static class ProjectileHelpers
    {
        internal static bool ValidNPCTarget(NPC npc) => npc?.active is true && npc.CanBeChasedBy();

        internal static void ArrowAI(Projectile projectile, ref float existTime, float extraRotation = MathHelper.PiOver2)
        {
            projectile.rotation = projectile.velocity.ToRotation() + extraRotation;
            if (existTime++ > 15)
            {
                projectile.velocity.Y += 0.1f;
                if (projectile.velocity.Y > 16)
                    projectile.velocity.Y = 16;
            }
        }

        internal static void SpearAI(Projectile projectile, float distance, float rotation, int? halfwayprojectileshoot = null)
        {
            Player owner = Main.player[projectile.owner];
            if (owner.itemAnimation <= 0)
                projectile.Kill();
            float speedrot = projectile.velocity.ToRotation();
            projectile.rotation = speedrot + rotation;
            float progress = Helpers.Progress(owner.itemAnimationMax - owner.itemAnimation, 0, owner.itemAnimationMax);// 1f / owner.itemAnimationMax * (owner.itemAnimationMax - owner.itemAnimation);
            float progress2 = 1f - progress * 2;
            if (progress2 <= 0f && projectile.ai[1] == 0) // halfway
            {
                if (halfwayprojectileshoot is int d)
                {
                    projectile.ai[1] = 1;
                    Projectile.NewProjectile(projectile.Center, projectile.velocity, d, projectile.damage, projectile.knockBack, projectile.owner);
                }
            }
            Vector2 off = new Vector2(distance, 0).RotatedBy(speedrot);
            projectile.Center = Vector2.Lerp(owner.MountedCenter, owner.MountedCenter + off * 14, 1f - Math.Abs(progress2));
        }
    }
}
