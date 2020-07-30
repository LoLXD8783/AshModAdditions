using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AshModAdditions
{
    public static class Helpers
    {
        // constants
        internal const string PLACEHOLDER = nameof(AshModAdditions) + "/placeholder";
        public const byte BYTE_FLAG1 = 1 << 0;
        public const byte BYTE_FLAG2 = 1 << 1;
        public const byte BYTE_FLAG3 = 1 << 2;
        public const byte BYTE_FLAG4 = 1 << 3;
        public const byte BYTE_FLAG5 = 1 << 4;
        public const byte BYTE_FLAG6 = 1 << 5;
        public const byte BYTE_FLAG7 = 1 << 6;
        public const byte BYTE_FLAG8 = 1 << 7;

        public static bool Chance1Over2 => Main.rand.NextBool();

        // meht
        public static float Progress1toM11(float progress) => 1f - Math.Abs(1f - progress * 2f);
        public static float Progress(float val, float max) => 1f / max * val;
        public static float Progress(float val, float min, float max) => 1f / (max - min) * (val - min);
        public static float Progress(float val, float min, float max, float progressScale) => progressScale / (max - min) * (val - min);

        // a
        public static byte FlagsByte(bool flag0 = false, bool flag1 = false, bool flag2 = false, bool flag3 = false, bool flag4 = false, bool flag5 = false, bool flag6 = false, bool flag7 = false) => (byte)((flag0 ? BYTE_FLAG1 : 0) | (flag1 ? BYTE_FLAG2 : 0) | (flag2 ? BYTE_FLAG3 : 0) | (flag3 ? BYTE_FLAG4 : 0) | (flag5 ? BYTE_FLAG5 : 0) | (flag6 ? BYTE_FLAG7 : 0) | (flag7 ? BYTE_FLAG8 : 0));
        public static void RetrieveFlagsByte(byte b, ref bool flag0) => flag0 = b == 1;
        public static void RetrieveFlagsByte(byte b, out bool flag0, out bool flag1)
        {
            flag0 = (b & BYTE_FLAG1) != 0;
            flag1 = (b & BYTE_FLAG2) != 0;
        }
        public static void RetrieveFlagsByte(byte b, out bool flag0, out bool flag1, out bool flag2, out bool flag3, out bool flag4, out bool flag5, out bool flag6, out bool flag7)
        {
            flag0 = (b & BYTE_FLAG1) != 0;
            flag1 = (b & BYTE_FLAG2) != 0;
            flag2 = (b & BYTE_FLAG3) != 0;
            flag3 = (b & BYTE_FLAG4) != 0;
            flag4 = (b & BYTE_FLAG5) != 0;
            flag5 = (b & BYTE_FLAG6) != 0;
            flag6 = (b & BYTE_FLAG7) != 0;
            flag7 = (b & BYTE_FLAG8) != 0;
        }

        // Code from absolute aquarian
        public static bool InForest(this Player player) => player.ZoneOverworldHeight &&
            !(player.ZoneDungeon ||
            player.ZoneCorrupt ||
            player.ZoneCrimson ||
            player.ZoneHoly ||
            player.ZoneSnow ||
            player.ZoneUndergroundDesert ||
            player.ZoneGlowshroom ||
            player.ZoneMeteor ||
            player.ZoneBeach ||
            player.ZoneDesert);

        // projectile and NPC helpers
        /// <summary>
        /// Finds the closest npc to the specified position
        /// </summary>
        /// <param name="position"></param>
        /// <returns>The NPC index + 1, if no NPC is found, 0 is returned</returns>
        public static int ClosestHostileNPCTo(Vector2 position, float minDistance = -1, bool ignoreDontTakeDamage = false)
        {
            int npcs = Main.npc.Length - 1;
            float closestDistance = -1;
            int npct = 0;
            for (int i = 0; i < npcs; i++)
            {
                NPC npc = Main.npc[i];

                float distSQ = npc.DistanceSQ(position);
                if (!(npc?.active is true && npc.CanBeChasedBy(ignoreDontTakeDamage: ignoreDontTakeDamage) && (minDistance == -1 || npc.WithinRange(position, minDistance))))
                    continue;

                if (closestDistance == -1 || distSQ < closestDistance)
                {
                    closestDistance = distSQ;
                    npct = npc.whoAmI + 1;
                }
            }
            return npct;
        }

        public static int NewNPC<T>(int X, int Y, int Start = 0, float ai0 = 0, float ai1 = 0, float ai2 = 0, float ai3 = 0, int Target = 255) where T : ModNPC => NPC.NewNPC(X, Y, ModContent.NPCType<T>(), Start, ai0, ai1, ai2, ai3, Target);
        public static int NewNPC<T>(out T modnpc, int X, int Y, int Start = 0, float ai0 = 0, float ai1 = 0, float ai2 = 0, float ai3 = 0, int Target = 255) where T : ModNPC
        {
            int npc = NPC.NewNPC(X, Y, ModContent.NPCType<T>(), Start, ai0, ai1, ai2, ai3, Target);
            modnpc = Main.npc[npc].modNPC as T;
            return npc;

        }

        public static NPC NewNPCDirect<T>(Point position, int Start = 0, float ai0 = 0, float ai1 = 0, float ai2 = 0, float ai3 = 0, int Target = 255) where T : ModNPC => Main.npc[NPC.NewNPC(position.X, position.Y, ModContent.NPCType<T>(), Start, ai0, ai1, ai2, ai3, Target)];
        public static NPC NewNPCDirect<T>(Vector2 position, int Start = 0, float ai0 = 0, float ai1 = 0, float ai2 = 0, float ai3 = 0, int Target = 255) where T : ModNPC => Main.npc[NPC.NewNPC((int)position.X, (int)position.Y, ModContent.NPCType<T>(), Start, ai0, ai1, ai2, ai3, Target)];
        public static NPC NewNPCDirect<T>(int X, int Y, int Start = 0, float ai0 = 0, float ai1 = 0, float ai2 = 0, float ai3 = 0, int Target = 255) where T : ModNPC => Main.npc[NPC.NewNPC(X, Y, ModContent.NPCType<T>(), Start, ai0, ai1, ai2, ai3, Target)];
        public static NPC NewNPCDirect<T>(out T modNPC, Point position, int Start = 0, float ai0 = 0, float ai1 = 0, float ai2 = 0, float ai3 = 0, int Target = 255) where T : ModNPC => NewNPCDirect(out modNPC, position.X, position.Y, Start, ai0, ai1, ai2, ai3, Target);
        public static NPC NewNPCDirect<T>(out T modNPC, Vector2 position, int Start = 0, float ai0 = 0, float ai1 = 0, float ai2 = 0, float ai3 = 0, int Target = 255) where T : ModNPC => NewNPCDirect(out modNPC, (int)position.X, (int)position.Y, Start, ai0, ai1, ai2, ai3, Target);
        public static NPC NewNPCDirect<T>(out T modNPC, int X, int Y, int Start = 0, float ai0 = 0, float ai1 = 0, float ai2 = 0, float ai3 = 0, int Target = 255) where T : ModNPC
        {
            NPC npc = Main.npc[NPC.NewNPC(X, Y, ModContent.NPCType<T>(), Start, ai0, ai1, ai2, ai3, Target)];
            modNPC = npc.modNPC as T;
            return npc;
        }

        public static Projectile NewProjectileDirect<T>(Vector2 position, Vector2 velocity, int Damage, float KnockBack, int Owner = 255, float ai0 = 0, float ai1 = 0) where T : ModProjectile => Main.projectile[Projectile.NewProjectile(position, velocity, ModContent.ProjectileType<T>(), Damage, KnockBack, Owner, ai0, ai1)];
        public static int NewProjectile<T>(Vector2 position, Vector2 velocity, int Damage, float KnockBack, int Owner = 255, float ai0 = 0, float ai1 = 0) where T : ModProjectile => Projectile.NewProjectile(position, velocity, ModContent.ProjectileType<T>(), Damage, KnockBack, Owner, ai0, ai1);

        // misc?
        public static bool TimerHit(ref int timer, int hitmark = 60)
        {
            if(timer++ > hitmark)
            {
                timer = 0;
                return true;
            }
            return false;
        }

        // recipe
        public static void AddIngredient<T>(this ModRecipe recipe, int stack = 1) where T : ModItem
        {
            recipe.AddIngredient(ModContent.ItemType<T>(), stack);
        }

        public static void AddTile<T>(this ModRecipe recipe) where T : ModTile
        {
            recipe.AddTile(ModContent.TileType<T>());
        }
    }
}
