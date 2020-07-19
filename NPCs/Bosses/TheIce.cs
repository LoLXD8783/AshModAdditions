using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AshModAdditions.Items.Materials;
using AshModAdditions.Items.Weapons.Melee;
using AshModAdditions.Items.Weapons.Ranged;

namespace AshModAdditions.NPCs.Bosses
{
    public class TheIce : ModNPC
    {
        NPC orbit0;
        NPC orbit1;
        internal Player target;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The ice");
            Main.npcFrameCount[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.boss = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.scale = 2;
            npc.lifeMax = 3000;
            npc.width = 48;
            npc.height = 174;
            npc.damage = 25;

            music = AshModAdditions.instance.GetMusicSoundSlot("The_Ice_Theme");
            musicPriority = MusicPriority.BossLow;
        }

        public override void AI()
        {
            const float distanceFromOwner = 64;
            DespawnHandler();
            if(npc.ai[0] == 0f) // First tick, for initialization
            {
                npc.ai[0] = 0.1f;

                orbit0 = Helpers.NewNPCDirect<TheIceMinion>(npc.Center, ai1: MathHelper.Pi, ai3: distanceFromOwner);
                //orbit0.position.X += distanceFromOwner; // one from one side
                if (orbit0.modNPC is TheIceMinion t) 
                    t.owner = npc;
                orbit0.position = npc.position;
                //orbit0.AI();

                orbit1 = Helpers.NewNPCDirect<TheIceMinion>(npc.Center, ai3:distanceFromOwner);
                //orbit1.position.Y -= distanceFromOwner; // one from another side
                if (orbit1.modNPC is TheIceMinion t2) 
                    t2.owner = npc;

                orbit1.position = npc.position;
                //orbit1.AI();
            }
            else if(npc.ai[0] == 0.1f) // wait
            {
                if (npc.ai[1]++ > 180)
                {
                    npc.ai[1] = 0;
                    npc.ai[0] = 0.11f; // dash
                }
                else
                    Idle();
            }
            else if(npc.ai[0] == 0.11f) // dash
            {
                Vector2 npccenter = npc.Center;
                npc.velocity = Vector2.Normalize(target.Center - npccenter) * 20f;
                npc.ai[0] = 0.115f;
                Main.PlaySound(SoundID.ForceRoar, npccenter);
            }
            else if(npc.ai[0] == 0.115f) // halfway dash
            {
                const float dashtime = 60f;
                if (npc.ai[1]++ > dashtime) // 1 second duration
                {
                    npc.ai[1] = 0;
                    npc.ai[0] = 0.1f;
                }
                else
                {
                    npc.velocity *= 0.98f;
                }
            }

            if (Main.rand.NextBool(100))
            {
                //if (HasValidTarget(target))
                //{
                    int p = Projectile.NewProjectile(npc.Center, Vector2.Normalize(target.Center - npc.Center) * 3, ProjectileID.IceBolt, 18, 0, Main.myPlayer);
                    Projectile proj = Main.projectile[p];
                    proj.friendly = false;
                    proj.hostile = true;
                    proj.netUpdate = true;
                //}
                npc.netUpdate = true;
            }
        }

        private void DespawnHandler()
        {
            if (!ValidOrFind())
            {
                npc.velocity.Y += 1;
            }
        }

        private void Idle()
        {
            if (!ValidOrFind()) return;
            Vector2 targetpos = target.Center + new Vector2(0, -400);
            npc.velocity = Vector2.SmoothStep(npc.velocity, Vector2.Normalize(targetpos - npc.Center) * 10, 0.1f);
        }

        private bool ValidOrFind() => HasValidTarget(target) || TryFindTarget();

        internal static bool HasValidTarget(Player target) => target?.active == true && !(target.dead || target.ghost);

        private bool TryFindTarget()
        {
            for(int i = 0; i < Main.player.Length; i++)
            {
                Player p = Main.player[i];
                if (HasValidTarget(p))
                {
                    target = p;
                    return true;
                }
            }
            return false;
        }

        public override void FindFrame(int frameHeight)
        {
            if(npc.frameCounter++ > 4)
            {
                npc.frameCounter = 0;
                npc.frame.Y += frameHeight;
                if (npc.frame.Y > frameHeight * 3)
                    npc.frame.Y = 0;
            }
        }

        public override void NPCLoot()
        {
            if(orbit0?.active is true && orbit0.modNPC is TheIceMinion)
            {
                orbit0.life = 0;
                orbit0.StrikeNPC(10, 0, 1);
            }
            if(orbit1?.active is true && orbit1.modNPC is TheIceMinion)
            {
                orbit1.life = 0;
                orbit1.StrikeNPC(10, 0, 1);
            }
            Rectangle r = npc.getRect();
            Item.NewItem(r, ModContent.ItemType<FrostiteBar>(), Main.rand.Next(15, 36));
            if (Main.rand.NextBool(4))
                Item.NewItem(r, ModContent.ItemType<FrostiteSpear>());
            if (Main.rand.NextBool(4))
                Item.NewItem(r, ModContent.ItemType<FrostiteBow>());
        }
    }
}