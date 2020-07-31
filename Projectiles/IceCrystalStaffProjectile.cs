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

namespace Bosspocalyps.Projectiles
{
    public class IceCrystalStaffProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[projectile.type] = 8;
            Main.projPet[projectile.type] = true;
            ProjectileID.Sets.MinionSacrificable[projectile.type] = true;
            ProjectileID.Sets.Homing[projectile.type] = true;
            ProjectileID.Sets.MinionTargettingFeature[projectile.type] = true;
            DisplayName.SetDefault("Ice Crystal Staff Projectile");
        }

        public override void SetDefaults()
        {
            projectile.width = 22;
            projectile.height = 46;
            projectile.penetrate = -1;
            projectile.minionSlots = 1f;
            projectile.minion = true;
            projectile.tileCollide = false;
            projectile.friendly = true;
        }

        public override void ModifyDamageHitbox(ref Rectangle hitbox)
        {
            int off = 10;
            hitbox.Y += off / 2;
            hitbox.Height -= off / 2;
        }

        public override bool? CanCutTiles() => false;
        public override bool MinionContactDamage() => true;

        public override void AI()
        {
            Animation();

            Player owner = Main.player[projectile.owner];
            if(!owner.active || owner.dead)
            {
                projectile.Kill();
                return;
            }
            projectile.timeLeft = 2;

            int l = Main.projectile.Length - 1;
            int t = projectile.type;
            for(int i = 0; i < l; i++)
            {
                Projectile p = Main.projectile[i];
                if (!p.active || p.type != t) continue;
            }


            //Player owner = Main.player[projectile.owner];
            //// TODO: Buff
            //if (!owner.active || owner.dead)
            //{
            //    projectile.Kill();
            //    return;
            //}
            //projectile.timeLeft = 2;
            //NPC target = projectile.OwnerMinionAttackTargetNPC;
            //if (target is null || !target.active)
            //{
            //    if(!projectile.WithinRange(owner.Center, 5*16))
            //        projectile.velocity = Vector2.SmoothStep(projectile.velocity, projectile.DirectionTo(owner.MountedCenter) * 10, 0.08f);
            //}
            //else
            //    projectile.velocity = Vector2.SmoothStep(projectile.velocity, projectile.DirectionTo(target.Center) * 10, 0.1f);
            //projectile.rotation = projectile.velocity.ToRotation();
            //if (projectile.direction == -1)
            //    projectile.rotation += MathHelper.Pi;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Frostburn, 30);
        }

        private void Animation()
        {
            if(projectile.frameCounter++ > 7)
            {
                projectile.frameCounter = 0;
                if (projectile.frame++ > 6)
                    projectile.frame = 0;
            }
        }
    }
}
