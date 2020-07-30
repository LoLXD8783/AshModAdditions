using AshModAdditions.Items.Weapons.Melee;
using AshModAdditions.Items.Weapons.Ranged;
using AshModAdditions.NPCs.Bosses.GigaWorm.KiloWorm;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AshModAdditions.NPCs.Bosses.GigaWorm
{
    [AutoloadBossHead]
    public class GigaWormH : ModNPC
    {
        public bool isVomiting = false;
        public bool isFiring = false;
        public bool isAggrivated = false;
        public bool isEnraged = false;
        public bool initialize = false;
        public bool hasCharged = false;
        public bool displayDeathMessage = false;
        public int reducedCooldown = 0;
        public int chargeDuration = 0;
        public int flyVelocity = 0;
        public float gigaWormSpeed;
        public float gigaWormAcceleration;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Gigaworm");
        }

        public override void SetDefaults()
        {
            npc.lifeMax = 150000;
            npc.damage = 160;
            npc.defense = 25;
            npc.knockBackResist = 0f;
            npc.width = 130;
            npc.height = 170;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.HitSound = SoundID.NPCHit7;
            npc.DeathSound = SoundID.NPCDeath10;
            npc.behindTiles = true;
            Main.npcFrameCount[npc.type] = 1;
            npc.value = Item.buyPrice(0, 0, 2, 10);
            npc.npcSlots = 1f;
            npc.netAlways = true;
            //Currently it's only immune to Confused. If you want it to be immune to more debuffs, please put them here.
            npc.buffImmune[BuffID.Confused] = true;
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Crossout");
            musicPriority = MusicPriority.BossLow;
        }
        //When you are adding loot to this boss, please put it in the CheckDead hook, because a custom death message is used for this boss.
        //Issues:
        //Gore has not been added yet
        //Segment Issues related with spacing and detaching
        //The boss will rarely forget it's target, and despawn when it's too far.
        public float Timer
        {
            get => npc.ai[0];
            set => npc.ai[0] = value;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 1.25f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.85f);
        }
        //public override void BossLoot(ref string name, ref int potionType)
        /*
         * This hook is irrelevant due to the requirement of a custom death message. Put all loot code into the CheckDead Hook.
        {
        }*/


        public override bool PreAI()
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                if (npc.ai[0] == 0)
                {
                    npc.realLife = npc.whoAmI;
                    int latestNPC = npc.whoAmI;
                    int randomWormLength = 80;
                    for (int i = 0; i < randomWormLength; ++i)
                    {
                        //Spawns 80 of these
                        latestNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<GigaWormB>(), npc.whoAmI, 0, latestNPC);
                        Main.npc[latestNPC].realLife = npc.whoAmI;
                        Main.npc[latestNPC].ai[3] = npc.whoAmI;
                    }
                    //Spawns the tail
                    latestNPC = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<GigaWormT>(), npc.whoAmI, 0, latestNPC);
                    Main.npc[latestNPC].realLife = npc.whoAmI;
                    Main.npc[latestNPC].ai[3] = npc.whoAmI;

                    npc.ai[0] = 1;
                    npc.netUpdate = true;
                }
            }

            int minTilePosX = (int)(npc.position.X / 16.0) - 1;
            int maxTilePosX = (int)((npc.position.X + npc.width) / 16.0) + 2;
            int minTilePosY = (int)(npc.position.Y / 16.0) - 1;
            int maxTilePosY = (int)((npc.position.Y + npc.height) / 16.0) + 2;
            if (minTilePosX < 0)
                minTilePosX = 0;
            if (maxTilePosX > Main.maxTilesX)
                maxTilePosX = Main.maxTilesX;
            if (minTilePosY < 0)
                minTilePosY = 0;
            if (maxTilePosY > Main.maxTilesY)
                maxTilePosY = Main.maxTilesY;

            bool collision = false;
            for (int i = minTilePosX; i < maxTilePosX; ++i)
            {
                for (int j = minTilePosY; j < maxTilePosY; ++j)
                {
                    Tile tile = Main.tile[i, j];
                    if (tile != null && (tile.nactive() && (Main.tileSolid[tile.type] || Main.tileSolidTop[tile.type] && tile.frameY == 0) || tile.liquid > 64))
                    {
                        Vector2 vector2;
                        vector2.X = i * 16;
                        vector2.Y = j * 16;
                        if (npc.position.X + npc.width > vector2.X && npc.position.X < vector2.X + 16.0 && (npc.position.Y + npc.height > (double)vector2.Y && npc.position.Y < vector2.Y + 16.0))
                        {
                            collision = true;
                            if (Main.rand.Next(100) == 0 && tile.nactive())
                                WorldGen.KillTile(i, j, true, true, false);
                        }
                    }
                }
            }
            if (!collision)
            {
                Rectangle rectangle1 = new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height);
                int maxDistance = 1000;
                bool playerCollision = true;
                for (int index = 0; index < 255; ++index)
                {
                    Player p = Main.player[index];
                    if (p.active)
                    {
                        Rectangle rectangle2 = new Rectangle((int)p.position.X - maxDistance, (int)p.position.Y - maxDistance, maxDistance * 2, maxDistance * 2);
                        if (rectangle1.Intersects(rectangle2))
                        {
                            playerCollision = false;
                            break;
                        }
                    }
                }
                if (playerCollision)
                    collision = true;
            }
            Random randGen = new Random();

            npc.ai[0]++;
            Player P = Main.player[npc.target];
            if (npc.target < 0 || npc.target == 255 || P.dead || !P.active)
            {
                npc.TargetClosest(false);
                P = Main.player[npc.target];
                if (!P.active || P.dead)
                {
                    npc.active = false;
                }
            }
            npc.netUpdate = true;
            {
                if (!initialize)
                {
                    gigaWormSpeed += 15f;
                    gigaWormAcceleration += 0.25f;
                    initialize = true;
                }
                Timer++;
                npc.ai[1]++;
                npc.ai[1] += 0;
                if (npc.life < npc.lifeMax * 0.50)
                {
                    Timer++;
                    if (Timer > 0 && !isAggrivated)
                    {
                        //Phase 2
                        gigaWormSpeed += 10f;
                        gigaWormAcceleration += 0.15f;
                        isAggrivated = true;
                        Main.NewText("[c/7E95AC:The Gigaworm is starting to become agitated!]");
                        Main.PlaySound(SoundID.Roar);
                    }
                }
                if (npc.life < npc.lifeMax * 0.17)
                {
                    Timer++;
                    if (Timer > 0 && !isEnraged)
                    {
                        //Phase 3
                        isEnraged = true;
                        Main.PlaySound(SoundID.NPCDeath10);
                        Main.NewText("[c/9C0101:The Gigaworm has been enraged!]");
                    }
                }
                if (npc.life < 1)
                {
                    //Check Dead
                    npc.life = 0;
                    npc.checkDead();
                }
                if (isEnraged && !displayDeathMessage == true)
                {
                    //Enrage buffs
                    gigaWormSpeed = 25f;
                    gigaWormAcceleration = 0.45f;
                    reducedCooldown = 150;
                }
                if (Timer > 600 - reducedCooldown && !displayDeathMessage == true)
                {
                    //Charging
                    int randomBool = randGen.Next(0, 2);
                    if (randomBool == 0)
                    {
                        isVomiting = true;
                        isFiring = false;

                    }
                    else
                    {
                        isVomiting = false;
                        isFiring = true;
                    }
                    Timer = 2;
                }

                if (Main.rand.Next(1299) == 0 && !isEnraged)
                {
                    if (hasCharged == false && !displayDeathMessage == true)
                    {
                        chargeDuration++;
                        gigaWormSpeed += 25f;
                        gigaWormAcceleration += 0.45f;
                        Main.PlaySound(SoundID.NPCDeath10);
                        hasCharged = true;
                    }
                }
                if (hasCharged && !displayDeathMessage == true)
                {
                    chargeDuration++;

                    Color color = new Color();
                    Rectangle rectangle = new Rectangle((int)npc.position.X, (int)(npc.position.Y + ((npc.height - npc.width) / 2)), npc.width, npc.width);
                    int count = 5;
                    for (int i = 1; i <= count; i++)
                    {
                        Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 6, 0, 0, 100, color, 0.8f);
                    }
                }

                if (chargeDuration > 600 && !displayDeathMessage == true)
                {
                    gigaWormSpeed -= 30f;
                    gigaWormAcceleration -= 0.5f;
                    chargeDuration = 0;
                    hasCharged = false;
                }
                if (isFiring)
                {
                    if (Timer < 900 + reducedCooldown && !displayDeathMessage == true)
                    {
                        //Laser Stream
                        if (Timer < 180)
                        {
                            float Speed = 18f;
                            Vector2 vector8 = npc.BottomRight;
                            int damage = 60;
                            int type = 83;
                            float rotation = npc.rotation + 90;
                            int num54 = Projectile.NewProjectile(vector8.X, vector8.Y, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), type, damage, 0f, 0);
                            npc.ai[1] = 0;
                        }
                    }
                }
                if (isVomiting)
                {
                    if (Timer < 900 - reducedCooldown && !displayDeathMessage == true)
                    {
                        //Minion summon
                        if (Timer == 50)
                        {
                            Main.PlaySound(SoundID.NPCDeath13);
                            NPC.NewNPC((int)npc.position.X, (int)npc.position.Y, ModContent.NPCType<KiloWormH>());

                            Color color = new Color();
                            Rectangle rectangle = new Rectangle((int)npc.position.X, (int)(npc.position.Y + ((npc.height - npc.width) / 2)), npc.width, npc.width);
                            int count = 15;
                            for (int i = 1; i <= count; i++)
                            {
                                Dust.NewDust(npc.position, rectangle.Width, rectangle.Height, 40, 0, 0, 100, color, 1.5f);
                            }
                        }
                    }
                }
                if (displayDeathMessage == true)
                {
                    flyVelocity += 40;
                    npc.damage = 0;
                    npc.position.X = Main.player[npc.target].position.X + flyVelocity;
                    npc.position.Y = Main.player[npc.target].position.Y + 200;
                }
            }
            //speed an acceleration float is dependant on these two custom floats.
            float speed = gigaWormSpeed;
            float acceleration = gigaWormAcceleration;

            Vector2 npcCenter = npc.Center;
            Vector2 targetCenter = Main.player[npc.target].MountedCenter;
            float targetXPos = targetCenter.X; //Main.player[npc.target].position.X + (Main.player[npc.target].width / 2);
            float targetYPos = targetCenter.Y; //Main.player[npc.target].position.Y + (Main.player[npc.target].height / 2);

            float targetRoundedPosX = (float)((int)(targetXPos / 16.0) * 16);
            float targetRoundedPosY = (float)((int)(targetYPos / 16.0) * 16);
            npcCenter.X = (float)((int)(npcCenter.X / 16.0) * 16);
            npcCenter.Y = (float)((int)(npcCenter.Y / 16.0) * 16);
            float dirX = targetRoundedPosX - npcCenter.X;
            float dirY = targetRoundedPosY - npcCenter.Y;

            float length = (float)Math.Sqrt(dirX * dirX + dirY * dirY);
            if (!collision)
            {
                npc.TargetClosest(true);
                npc.velocity.Y = npc.velocity.Y + 0.11f;
                if (npc.velocity.Y > speed)
                    npc.velocity.Y = speed;
                if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < speed * 0.4)
                {
                    if (npc.velocity.X < 0.0)
                        npc.velocity.X = npc.velocity.X - acceleration * 1.1f;
                    else
                        npc.velocity.X = npc.velocity.X + acceleration * 1.1f;
                }
                else if (npc.velocity.Y == speed)
                {
                    if (npc.velocity.X < dirX)
                        npc.velocity.X = npc.velocity.X + acceleration;
                    else if (npc.velocity.X > dirX)
                        npc.velocity.X = npc.velocity.X - acceleration;
                }
                else if (npc.velocity.Y > 4.0)
                {
                    if (npc.velocity.X < 0.0)
                        npc.velocity.X = npc.velocity.X + acceleration * 0.9f;
                    else
                        npc.velocity.X = npc.velocity.X - acceleration * 0.9f;
                }
            }
            else
            {
                if (npc.soundDelay == 0)
                {
                    float num1 = length / 40f;
                    if (num1 < 10.0)
                        num1 = 10f;
                    if (num1 > 20.0)
                        num1 = 20f;
                    npc.soundDelay = (int)num1;
                    Main.PlaySound(SoundID.Roar, (int)npc.position.X, (int)npc.position.Y, 1);
                }
                float absDirX = Math.Abs(dirX);
                float absDirY = Math.Abs(dirY);
                float newSpeed = speed / length;
                dirX *= newSpeed;
                dirY *= newSpeed;
                if (npc.velocity.X > 0.0 && dirX > 0.0 || npc.velocity.X < 0.0 && dirX < 0.0 || (npc.velocity.Y > 0.0 && dirY > 0.0 || npc.velocity.Y < 0.0 && dirY < 0.0))
                {
                    if (npc.velocity.X < dirX)
                        npc.velocity.X += acceleration;
                    else if (npc.velocity.X > dirX)
                        npc.velocity.X -= acceleration;
                    if (npc.velocity.Y < dirY)
                        npc.velocity.Y += acceleration;
                    else if (npc.velocity.Y > dirY)
                        npc.velocity.Y -= acceleration;
                    if (Math.Abs(dirY) < speed * 0.2 && (npc.velocity.X > 0.0 && dirX < 0.0 || npc.velocity.X < 0.0 && dirX > 0.0))
                    {
                        if (npc.velocity.Y > 0.0)
                            npc.velocity.Y += acceleration * 2f;
                        else
                            npc.velocity.Y -= acceleration * 2f;
                    }
                    if (Math.Abs(dirX) < speed * 0.2 && (npc.velocity.Y > 0.0 && dirY < 0.0 || npc.velocity.Y < 0.0 && dirY > 0.0))
                    {
                        if (npc.velocity.X > 0.0)
                            npc.velocity.X += acceleration * 2f;
                        else
                            npc.velocity.X -= acceleration * 2f;
                    }
                }
                else if (absDirX > absDirY)
                {
                    if (npc.velocity.X < dirX)
                        npc.velocity.X += acceleration * 1.1f;
                    else if (npc.velocity.X > dirX)
                        npc.velocity.X -= acceleration * 1.1f;
                    if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < speed * 0.5)
                    {
                        if (npc.velocity.Y > 0.0)
                            npc.velocity.Y += acceleration;
                        else
                            npc.velocity.Y -= acceleration;
                    }
                }
                else
                {
                    if (npc.velocity.Y < dirY)
                        npc.velocity.Y += acceleration * 1.1f;
                    else if (npc.velocity.Y > dirY)
                        npc.velocity.Y -= acceleration * 1.1f;
                    if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < speed * 0.5)
                    {
                        if (npc.velocity.X > 0.0)
                            npc.velocity.X += acceleration;
                        else
                            npc.velocity.X -= acceleration;
                    }
                }
            }
            // Set the correct rotation for this NPC.
            npc.rotation = npc.velocity.ToRotation() + MathHelper.PiOver2;

            // Some netupdate stuff (multiplayer compatibility).
            if (collision)
            {
                if (npc.localAI[0] != 1)
                    npc.netUpdate = true;
                npc.localAI[0] = 1f;
            }
            else
            {
                if (npc.localAI[0] != 0.0)
                    npc.netUpdate = true;
                npc.localAI[0] = 0.0f;
            }
            if ((npc.velocity.X > 0.0 && npc.oldVelocity.X < 0.0 || npc.velocity.X < 0.0 && npc.oldVelocity.X > 0.0 || (npc.velocity.Y > 0.0 && npc.oldVelocity.Y < 0.0 || npc.velocity.Y < 0.0 && npc.oldVelocity.Y > 0.0)) && !npc.justHit)
                npc.netUpdate = true;

            return false;
        }

        public override void BossHeadRotation(ref float rotation)
        {
            rotation = npc.rotation;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture = Main.npcTexture[npc.type];
            Vector2 origin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
            Main.spriteBatch.Draw(texture, npc.Center - Main.screenPosition, new Rectangle?(), drawColor, npc.rotation, origin, npc.scale, SpriteEffects.None, 0);
            return false;
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.9f;
            return null;
        }

        public override bool CheckDead()
        {
            //check dead
            npc.life = npc.lifeMax;
            Timer++;
            if (Timer > 0)
            {
                if (!displayDeathMessage)
                {
                    npc.life = npc.lifeMax;
                    //Custom Death Message
                    //To not display more than once.
                    displayDeathMessage = true;
                    //Below this comment, put all of the loot code here (it doesn't matter what kind, it will still work the same way.
                    //Death Sound
                    //npc.position.Y = Main.player[npc.target].position.Y + flyVelocity;
                    Main.NewText("[c/4b1267:The Gigaworm soars to the right, leaving objects behind...]");
                }
            }
            return false;
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            int item = 0;
            switch (Main.rand.Next(3))
            {
                case 0: item = ModContent.ItemType<GigaBlade>(); break;
                case 1: item = ModContent.ItemType<WormGun>(); break;
                case 2: item = ModContent.ItemType<GigaBow>(); break;
            }
            potionType = ItemID.GreaterHealingPotion;
            DropItem(item);
            DropItem(item, 30, 70);
        }

        public override void NPCLoot()
        {
        }

        private void DropItem(int type, int stackmin, int stackmax) => Item.NewItem(npc.getRect(), type, Main.rand.Next(stackmin, stackmax + 1));
        private void DropItem(int type, int stack = 1) => Item.NewItem(npc.getRect(), type, stack);
    }
}