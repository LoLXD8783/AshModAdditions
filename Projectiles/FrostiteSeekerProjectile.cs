using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Bosspocalyps.Buffs;
using Bosspocalyps.Buffs.Minions;

namespace Bosspocalyps.Projectiles
{
    public class FrostiteSeekerProjectile : ModProjectile
    {
        private NPC Target => projectile.ai[1] > 0 ? Main.npc[(int)projectile.ai[1] - 1] : null;
        private float timer;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frostite Seeker");
        }

        public override void SetDefaults()
        {
            projectile.friendly = true;
            projectile.minion = true;
            projectile.tileCollide = false;
            projectile.penetrate = -1;
            projectile.minionSlots = 0;
            projectile.width = 14;
            projectile.height = 14;

            //drawOffsetX = -15;
            //drawOffsetX = 5;
            // drawOriginOffsetY = 10;
            projectile.gfxOffY = 5;
            drawOffsetX = -15;
            drawOriginOffsetX = 10;
        }

        public override void AI()
        {
            Player owner = Main.player[projectile.owner];
            if (!owner.IsAlive())
            {
                owner.ClearBuff(ModContent.BuffType<FrostiteSeekerBuff>());
                projectile.Kill();
                return;
            }

            if (!owner.HasBuff<FrostiteSeekerBuff>())
            {
                projectile.Kill();
                return;
            }

            projectile.timeLeft = 2;
            if (!HasOrFindTarget())
                Idle(owner);
            else
                Attack();
            TeleportIfTooFar(owner);
        }

        private void TeleportIfTooFar(Player player)
        {
            Vector2 v = player.MountedCenter;
            if (!projectile.WithinRange(v, 100 * 16f))
                projectile.position = v;
        }

        private void Attack()
        {
            FaceDirection();
            // ai 0 state
            if (projectile.ai[0] == 0) // going to dash
            {
                Dash(Target.Center, 20f);
                Separate();
                projectile.ai[0] = 1;
            }
            else if (projectile.ai[0] == 1) // dash cooldown
            {
                if (timer++ > 30)
                {
                    projectile.ai[0] = 0;
                    timer = 0;
                }
                else
                {
                    projectile.velocity = Vector2.Lerp(projectile.velocity, Vector2.Normalize(Target.Center - projectile.Center) * 4, 0.1f);
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
            for (int i = 0; i < projectiles; i++)
            {
                Projectile p = Main.projectile[i];
                if (p.active && p.type == type && p.owner == Main.myPlayer)
                    if (p.Hitbox.Intersects(projectile.Hitbox))
                    {
                        Vector2 v = (p.Size - (projectile.Center - p.Center)) / 100;
                        projectile.velocity -= v;
                        p.velocity += v;
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
