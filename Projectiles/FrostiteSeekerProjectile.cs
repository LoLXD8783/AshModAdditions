using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace AshModAdditions.Projectiles
{
    public class FrostiteSeekerProjectile : ModProjectile
    {
        private NPC Target => projectile.ai[1] > 0 ? Main.npc[(int)projectile.ai[1]-1] : null;
        private float timer;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frostite Seeker Projectile");
        }

        public override void SetDefaults()
        {
            projectile.friendly = true;
            projectile.minion = true;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.minionSlots = 1;
            projectile.width = 14;
            projectile.height = 14;

            drawOffsetX = -15;

            //projectile.gfxOffY = 15;
            //drawOffsetX = -15;
            //drawOffsetX = -10;
            //drawOriginOffsetX = 10;
            //drawOriginOffsetY = -10;
        }

        public override void AI()
        {
            Player owner = Main.player[projectile.owner];
            projectile.timeLeft = 2;
            if (!HasOrFindTarget())
                Idle(owner);
            else
                Attack();
        }

        private void Attack()
        {
            FaceDirection();
            // ai 0 state
            if(projectile.ai[0] == 0) // going to dash
            {
                Dash(Target.Center, 10f);
                projectile.ai[0] = 1;
            }
            else if(projectile.ai[0] == 1) // dash cooldown
            {
                if(timer++ > 30)
                {
                    projectile.ai[0] = 0;
                    timer = 0;
                }
            }
        }
        private void Dash(Vector2 to, float velocity) => projectile.velocity = Vector2.Normalize(to - projectile.Center) * velocity;

        private bool ValidTarget(NPC npc) => npc?.active is true && !npc.friendly && npc.CanBeChasedBy();
        private bool HasTarget => projectile.ai[1] != 0 && ValidTarget(Target);
        private bool FindTarget()
        {
            projectile.ai[1] = Helpers.ClosestHostileNPCTo(projectile.Center, 16 * 20);
            return false;
        }
        private bool HasOrFindTarget() => HasTarget || FindTarget();

        //private void FaceTowards(Vector2 to) => projectile.rotation = (to - projectile.Center).ToRotation();
        private void FaceDirection() => projectile.rotation = projectile.velocity.ToRotation();

        private void Idle(Player owner)
        {
            if (!projectile.WithinRange(owner.MountedCenter, 10 * 16))
                projectile.velocity = Vector2.Lerp(projectile.velocity, Vector2.Normalize(owner.MountedCenter - projectile.Center) * 10, 0.01f);
            Separate();
            FaceDirection();
        }

        private void Separate()
        {
            int type = projectile.type;
            int projectiles = Main.projectile.Length - 1;
            for(int i = 0; i < projectiles; i++)
            {
                Projectile p = Main.projectile[i];
                if(p.active && p.whoAmI != projectile.whoAmI && p.type == type)
                {
                    if(p.Hitbox.Intersects(projectile.Hitbox))
                    {
                        Vector2 v = (p.Size - (projectile.Center - p.Center)) / 100;
                        projectile.velocity -= v;
                        p.velocity += v;
                    }
                }
            }
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(timer);
        }
        public override void ReceiveExtraAI(BinaryReader reader)
        {
            timer = reader.ReadSingle();
        }
    }
}
