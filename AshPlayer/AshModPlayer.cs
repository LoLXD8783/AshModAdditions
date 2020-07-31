using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Bosspocalyps.Tiles.Warped;
using Terraria.DataStructures;

namespace Bosspocalyps
{
    public partial class AshModPlayer : ModPlayer
    {
        public bool RedashHood, FrostiteEffect;
        public bool ZoneWarpedBiome;
        public int HealingAbyssKnivesCooldown;

        public override void ResetEffects()
        {
            ResetBuffs();
            RedashHood = false;
            FrostiteEffect = false;
            IceColdPotion = false;
        }

        public override void UpdateLifeRegen()
        {
            InsigniaLifeRegen();
        }

        public override void PreUpdate()
        {
            if(HealingAbyssKnivesCooldown > 0)
            {
                HealingAbyssKnivesCooldown--;
            }
        }

        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            InsigniaDamageReduction(ref damage);
            return true;
        }

        public override float MeleeSpeedMultiplier(Item item)
        {
            float speedMultiplier = 1f;
            InsigniaMeleeSpeedMultiplier(ref speedMultiplier);
            return speedMultiplier;
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (FrostiteEffect || (IceColdPotion && (item.ranged || item.melee)))
                target.AddBuff(BuffID.Frostburn, 120);
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (FrostiteEffect || (IceColdPotion && (proj.ranged || proj.melee)))
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
            //writer.Write(new BitsByte(ZoneWarpedBiome));
            writer.Write(Helpers.FlagsByte(ZoneWarpedBiome));
        }

        public override void ReceiveCustomBiomes(BinaryReader reader)
        {
            //((BitsByte)reader.ReadByte()).Retrieve(ref ZoneWarpedBiome);
            Helpers.RetrieveFlagsByte(reader.ReadByte(), ref ZoneWarpedBiome);
        }
    }
}
