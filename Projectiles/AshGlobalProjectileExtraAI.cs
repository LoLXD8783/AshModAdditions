using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Bosspocalyps.Projectiles
{
    public partial class AshGlobalProjectile : GlobalProjectile
    {
        private void TerrarianBladeProjExtraAI(Projectile projectile)
        {
            if (projectile.ai[0] > 0)
            {
                NPC target = Main.npc[(int)projectile.ai[0] - 1];
                if (target.active)
                {
                    projectile.velocity = Vector2.SmoothStep(projectile.velocity, Vector2.Normalize(target.Center - projectile.Center) * 10, 0.2f);
                    return;
                }
            }
            projectile.ai[0] = Helpers.ClosestHostileNPCTo(projectile.Center, 20 * 16);
        }
    }
}
