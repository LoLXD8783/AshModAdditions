using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AshModAdditions.Tiles.Warped;

namespace AshModAdditions
{
    public class AshModPlayer : ModPlayer
    {
        public bool RedashHood, FrostiteEffect;
        public bool IceColdPotion, SandStormSpiritBuff;
        public bool ZoneWarpedBiome;

        public override void ResetEffects()
        {
            SandStormSpiritBuff = false;
            RedashHood = false;
            FrostiteEffect = false;
            IceColdPotion = false;
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (FrostiteEffect || (IceColdPotion && (item.ranged || item.melee)))
                target.AddBuff(BuffID.Frostburn, 120);
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (FrostiteEffect || (IceColdPotion && proj.ranged || proj.melee))
                target.AddBuff(BuffID.Frostburn, 120);
        }

        public override bool Shoot(Item item, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (RedashHood)
            {
                speedX *= 1.01f;
                speedY *= 1.01f;
            }
            return true;
        }

        public override Texture2D GetMapBackgroundImage()
        {
            if (ZoneWarpedBiome)
                return mod.GetTexture("Backgrounds/Warped_Biom");
            return null;
        }

        public override void UpdateBiomes()
        {
            ZoneWarpedBiome = AshWorld.WarpedTiles > 50;
        }

        public override bool CustomBiomesMatch(Player other)
        {
            var modp = other.GetModPlayer<AshModPlayer>();
            return ZoneWarpedBiome == modp.ZoneWarpedBiome;
        }

        public override void CopyCustomBiomesTo(Player other)
        {
            var modp = other.GetModPlayer<AshModPlayer>();
            modp.ZoneWarpedBiome = ZoneWarpedBiome;
        }

        public override void SendCustomBiomes(BinaryWriter writer)
        {
            writer.Write(new BitsByte(ZoneWarpedBiome));
        }

        public override void ReceiveCustomBiomes(BinaryReader reader)
        {
            ((BitsByte)reader.ReadByte()).Retrieve(ref ZoneWarpedBiome);
        }
    }
}
