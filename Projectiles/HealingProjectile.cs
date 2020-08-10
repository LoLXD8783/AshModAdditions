using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Bosspocalyps.Projectiles
{
    public class HealingProjectile : ModProjectile
    {
        public static int SpawnFor(Player player, Vector2 position, Vector2 initialVelocity = default, int heal = 1, int dustammount = 3, int dustSpawnRate = 1, float projectilevelocity = 5, Color dustcolor = default)
        {
            var p = Helpers.NewProjectile<HealingProjectile>(position, initialVelocity, 1, 0, player.whoAmI);
            Projectile proj = Main.projectile[p];
            if (proj.modProjectile is HealingProjectile d)
            {
                d.heal = heal;
                d.dustammount = dustammount;
                d.dustspawnrate = dustSpawnRate;
                d.projectilevelocity = projectilevelocity;
                d.dustcolor = dustcolor;
            }
            return p;
        }

        int dustspawnrate;
        int dusttimer;
        int dustammount;
        int heal;
        float projectilevelocity = 5;
        Color dustcolor;

        public override string Texture => Helpers.PLACEHOLDER;

        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            projectile.friendly = false;
            projectile.hostile = false;
            projectile.damage = 1;
            projectile.width = 2;
            projectile.height = 2;
            projectile.timeLeft = 300;
            projectile.tileCollide = false;
            projectile.hide = true;
            projectile.extraUpdates = 10;
        }

        public override void AI()
        {
            if (targetplayer is Player target && (target.active && !(target.dead || target.ghost)))
            {
                projectile.velocity = Vector2.SmoothStep(projectile.velocity, Vector2.Normalize(target.MountedCenter - projectile.Center) * projectilevelocity, 0.1f);
                if (Helpers.CounterHit(ref dusttimer, dustspawnrate))
                {
                    for (int i = 0; i < dustammount; i++)
                    {
                        int d = Dust.NewDust(projectile.Center, 4, 4, 14, 0, 0, 0, dustcolor, 1f);
                        Dust dust = Main.dust[d];
                        dust.noGravity = true;
                    }
                }
                if (target.Hitbox.Intersects(projectile.Hitbox))
                {
                    target.statLife += heal;
                    target.HealEffect(heal);
                    projectile.Kill();
                }
            }
            else
            {
                projectile.Kill();
            }
        }

        public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
        {
        }

        private Player targetplayer => Main.player[projectile.owner];
    }
}
