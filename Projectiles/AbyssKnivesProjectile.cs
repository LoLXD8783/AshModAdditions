using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Bosspocalyps.Projectiles
{
    class AbyssKnivesProjectile : ModProjectile
    {
        const float Range = 20 * 16;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Abyss Knives");
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.VampireKnife);
            projectile.aiStyle = -1;
            projectile.penetrate = 1;
            projectile.alpha = 0;
        }

        public override void AI()
        {
            if (!IsChildren) // normal one
            {
                if(projectile.alpha > 0)
                {
                    projectile.alpha--;
                }
                const int waitTime = 10;
                if (projectile.ai[0] <= waitTime)
                {
                    projectile.alpha = (int)MathHelper.Lerp(255, 0, Helpers.Progress(projectile.ai[0], 0, waitTime));
                    projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
                    projectile.ai[0]++;
                    return;
                }
                if (ValidOrTarget())
                {
                    Target();
                    return;
                }
                else
                {
                    Idle();
                }

            }
            else
            {
                Whenchildren();
            }
            if (projectile.velocity.Y > 16)
                projectile.velocity.Y = MathHelper.Lerp(projectile.velocity.Y, 16, 0.1f);
        }

        private bool IsChildren => projectile.ai[0] > 100;

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (IsChildren)
            {
                Player player = Main.player[projectile.owner];
                BosspocalypsModPlayer ashmodplayer = player.GetModPlayer<BosspocalypsModPlayer>();
                if (!player.moonLeech && !target.immortal && ashmodplayer.HealingAbyssKnivesCooldown <= 0 && player.lifeSteal > 0)
                {
                    int heal = Main.rand.Next(5) + 1;
                    player.lifeSteal -= heal;
                    ashmodplayer.HealingAbyssKnivesCooldown = 6;
                    HealingProjectile.SpawnFor(player, projectile.Center, default, heal, dustammount: 3, dustSpawnRate: 1, projectilevelocity: 4, dustcolor: Color.White);
                }
            }
            else
            {
                Vector2 v = projectile.velocity / 2;
                for(int i = 0; i < 5; i++)
                {
                    Helpers.NewProjectile<AbyssKnivesProjectile>(projectile.position, v.RotatedByRandom(MathHelper.TwoPi * 100), projectile.damage, projectile.knockBack, projectile.owner, 101);
                }
            }
            projectile.Kill();
        }

        private NPC NPCTarget => projectile.ai[1] > 0 ? Main.npc[(int)projectile.ai[1] - 1] : null;

        private bool FindTarget() => (projectile.ai[1] = Helpers.ClosestHostileNPCTo(projectile.Center, Range)) > 0;

        private bool Valid(NPC npc) => ProjectileHelpers.ValidNPCTarget(npc) && npc.WithinRange(projectile.Center, Range);

        private bool ValidOrTarget() => Valid(NPCTarget) || FindTarget();

        private void Target()
        {
            projectile.velocity = Vector2.SmoothStep(projectile.velocity, Vector2.Normalize(NPCTarget.Center - projectile.Center) * 16, 0.2f);
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }

        private void Idle()
        {
            projectile.rotation += Main.rand.NextFloat(0.5f) + 0.1f;
            projectile.velocity.Y += 0.2f;
            projectile.velocity.X *= 0.98f;
        }

        private void Whenchildren()
        {
            projectile.rotation += 0.2f;

            if (projectile.alpha < 255)
            {
                projectile.alpha += 4;
                if (projectile.alpha > 255)
                {
                    projectile.alpha = 255;
                }
            }
            else
                projectile.Kill();
            
            projectile.velocity.X *= 0.97f;
            projectile.velocity.Y += 0.2f;
        }
    }
}
