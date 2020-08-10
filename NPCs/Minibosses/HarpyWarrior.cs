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
using Bosspocalyps.Projectiles.NPCs.Minibosses;

namespace Bosspocalyps.NPCs.Minibosses
{
    public class HarpyWarrior : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Harpy Warrior");
            Main.npcFrameCount[npc.type] = 8;
        }

        public override void SetDefaults()
        {
            npc.width = 78;
            npc.height = 52;
            npc.damage = 25;
            npc.defense = 8;
            npc.lifeMax = 1000;
            npc.HitSound = SoundID.NPCHit1;
            npc.knockBackResist = 0.6f;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.value = 300f;
            npc.aiStyle = -1;
            aiType = -1;
            music = Bosspocalyps.instance.GetMusicSoundSlot("BumpindatBEEET");
        }

        public override void AI() // adapted from vanilla's code, harpy AI
        {
            npc.noGravity = true;

            // colliding 
            if (npc.collideX)
            {
                npc.velocity.X = npc.oldVelocity.X * -0.5f;
                if (npc.direction == -1 && npc.velocity.X > 0f && npc.velocity.X < 2f)
                    npc.velocity.X = 2f;

                if (npc.direction == 1 && npc.velocity.X < 0f && npc.velocity.X > -2f)
                    npc.velocity.X = -2f;
            }

            if (npc.collideY)
            {
                npc.velocity.Y = npc.oldVelocity.Y * -0.5f;
                if (npc.velocity.Y > 0f && npc.velocity.Y < 1f)
                    npc.velocity.Y = 1f;

                if (npc.velocity.Y < 0f && npc.velocity.Y > -1f)
                    npc.velocity.Y = -1f;
            }

            npc.TargetClosest(true);
            if (npc.direction == -1 && npc.velocity.X > -4f)
            {
                npc.velocity.X -= 0.1f;
                if (npc.velocity.X > 4f)
                    npc.velocity.X -= 0.1f;
                else if (npc.velocity.X > 0f)
                    npc.velocity.X += 0.05f;

                if (npc.velocity.X < -4f)
                    npc.velocity.X = -4f;
            }
            else if (npc.direction == 1 && npc.velocity.X < 4f)
            {
                npc.velocity.X += 0.1f;
                if (npc.velocity.X < -4f)
                    npc.velocity.X += 0.1f;
                else if (npc.velocity.X < 0f)
                    npc.velocity.X -= 0.05f;

                if (npc.velocity.X > 4f)
                    npc.velocity.X = 4f;
            }

            if (npc.directionY == -1 && npc.velocity.Y > -1.5f)
            {
                npc.velocity.Y -= 0.04f;
                if (npc.velocity.Y > 1.5f)
                    npc.velocity.Y -= 0.05f;
                else if (npc.velocity.Y > 0f)
                    npc.velocity.Y += 0.03f;

                if (npc.velocity.Y < -1.5f)
                    npc.velocity.Y = -1.5f;
            }
            else if (npc.directionY == 1 && npc.velocity.Y < 1.5f)
            {
                npc.velocity.Y += 0.04f;
                if (npc.velocity.Y < -1.5f)
                    npc.velocity.Y += 0.05f;
                else if (npc.velocity.Y < 0f)
                    npc.velocity.Y -= 0.03f;

                if (npc.velocity.Y > 1.5f)
                    npc.velocity.Y = 1.5f;
            }

            if (npc.wet)
            {
                if (npc.velocity.Y > 0f)
                    npc.velocity.Y *= 0.95f;

                npc.velocity.Y -= 0.5f;
                if (npc.velocity.Y < -4f)
                    npc.velocity.Y = -4f;

                npc.TargetClosest();
            }

            npc.ai[1] += 1f;

            if (npc.ai[1] > 200f)
            {
                Player target = Main.player[npc.target];
                if (!target.wet && Collision.CanHit(npc.position, npc.width, npc.height, target.position, target.width, target.height))
                    npc.ai[1] = 0f;

                float num208 = 0.12f;
                float num209 = 0.07f;
                float num210 = 3f;
                float num211 = 1.25f;

                if (npc.ai[1] > 1000f)
                    npc.ai[1] = 0f;

                npc.ai[2] += 1f;
                if (npc.ai[2] > 0f)
                {
                    if (npc.velocity.Y < num211)
                        npc.velocity.Y += num209;
                }
                else if (npc.velocity.Y > 0f - num211)
                {
                    npc.velocity.Y -= num209;
                }

                if (npc.ai[2] < -150f || npc.ai[2] > 150f)
                {
                    if (npc.velocity.X < num210)
                        npc.velocity.X += num208;
                }
                else if (npc.velocity.X > 0f - num210)
                {
                    npc.velocity.X -= num208;
                }

                if (npc.ai[2] > 300f)
                    npc.ai[2] = -300f;

            }

            npc.spriteDirection = npc.direction;
            if (Main.netMode == NetmodeID.MultiplayerClient)
                return;

            // attack
            npc.ai[0] += 1f;
            float dd = npc.ai[0];
            if (dd < 150 && dd % 30 == 0)
            {
                Player target = Main.player[npc.target];
                if (Collision.CanHit(npc.position, npc.width, npc.height, target.position, target.width, target.height))
                {
                    Vector2 toplayer = target.MountedCenter - npc.Center;
                    for(int i = 0; i < 4; i++)
                    {
                        Projectile.NewProjectile(npc.Center, Vector2.Normalize(toplayer + Main.rand.NextVector2Circular(100, 100)).RotatedBy(MathHelper.TwoPi / 5 * (i+1)) * 4, ModContent.ProjectileType<HarpyWarriorProjectile>(), 5, 0f, Main.myPlayer);
                    }
                    Projectile.NewProjectile(npc.Center, Vector2.Normalize(toplayer + Main.rand.NextVector2Circular(100, 100)) * 4, ModContent.ProjectileType<HarpyWarriorProjectile>(), 7, 0f, Main.myPlayer);
                    ////Projectile.NewProjectileDirect(npc.Center, Vector2.Normalize(target.Center - npc.Center + Utils.NextVector2Circular(Main.rand, 100, 100)) * 6, ProjectileID.HarpyFeather, 15, 0f, Main.myPlayer).timeLeft = 300;
                    //float speed = 6f;
                    //Vector2 npccenter = npc.Center;
                    //float x = target.Center.X - npccenter.X + (float)Main.rand.Next(-100, 101);
                    //float y = target.Center.Y - npccenter.Y + (float)Main.rand.Next(-100, 101);
                    //float length = (float)Math.Sqrt(x * x + y * y);
                    //length = speed / length;
                    //x *= length;
                    //y *= length;
                    //int damage = 15;
                    //int type = 38;
                    //int projectile = Projectile.NewProjectile(npccenter.X, npccenter.Y, x, y, type, damage, 0f, Main.myPlayer);
                    //Main.projectile[projectile].timeLeft = 300;
                }
            }
            else if (npc.ai[0] >= (200f + Main.rand.Next(400)))
            {
                npc.ai[0] = 0f;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            if(Helpers.CounterHit(ref npc.frameCounter, 3))
            {
                npc.frame.Y += frameHeight;
                if (npc.frame.Y > frameHeight * 7)
                    npc.frame.Y = 0;
            }
        }
    }
}
