using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AshModAdditions.NPCs.Bosses;

namespace AshModAdditions.NPCs.Enemys
{
    public class TheIceMinion : ModNPC
    {
        internal NPC owner;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice minion");
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.friendly = false;
            npc.noGravity = true;
            npc.boss = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.scale = 1.5f;
            npc.lifeMax = 1000;
            npc.width = 17;
            npc.height = 17;
            npc.boss = false;
        }

        public override void AI()
        {
            // ai 0 = progress
            // ai 1 = offset
            // ai 2 = attack state (positive is towards the player, negative is returning)
            // ai 3 = distance
            if(owner?.active != true || !(owner.modNPC is TheIce))
            {
                npc.active = false;
            }

            const float returntime = 60f;
            npc.ai[0] += 0.35f;
            if(npc.ai[2] > 0)
            {
                npc.ai[2]--;
                //npc.velocity *= 0.97f; // slowdown
                if(npc.ai[2] == 0)
                {
                    npc.ai[2] = -returntime;
                }
                return;
            }

            TheIce ownr = (TheIce)owner.modNPC;
            Vector2 ownercenter = owner.Center;
            float val = npc.ai[0] + npc.ai[1];
            Vector2 targetpos = new Vector2()
            {
                X = ownercenter.X + (float)Math.Sin(val) * npc.ai[3],
                Y = ownercenter.Y + (float)Math.Cos(val) * npc.ai[3]
            };
            if(npc.ai[2] < 0)
            {
                npc.ai[2]++;
                float p = (1 / returntime) * Math.Abs(npc.ai[2]);
                npc.position = Vector2.Lerp(npc.Center, targetpos, 1-p);
                return;
            }
            else
                npc.position = targetpos;

            bool validtarget = TheIce.HasValidTarget(ownr.target);

            if (validtarget)
                npc.rotation = (ownr.target.MountedCenter - npc.Center).ToRotation() + MathHelper.Pi;
            else
                npc.rotation = (owner.Center - npc.position).ToRotation() + MathHelper.Pi + MathHelper.PiOver2;

            //if (TheIce.HasValidTarget(ownr.target))
            //Main.NewText(npc.whoAmI + ": " + Vector2.Distance(ownr.target.Center, npc.Center));


            if (Main.rand.NextBool(300))
            {
                npc.ai[2] = 60;
                if (validtarget)
                    npc.velocity = Vector2.Normalize(ownr.target.MountedCenter - npc.Center) * 20f;
                npc.netUpdate = true;
            }

            if (Main.rand.NextBool(200))
            {
                if (validtarget)
                {
                    var proj = Projectile.NewProjectileDirect(npc.Center, Vector2.Normalize(ownr.target.MountedCenter - npc.Center) * 3, ProjectileID.IceBolt, 18, 0, Main.myPlayer);
                    proj.friendly = false;
                    proj.hostile = true;
                    proj.netUpdate = true;
                }
                npc.netUpdate = true;
            }
        }
    }
}
