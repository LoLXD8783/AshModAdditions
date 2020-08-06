using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Bosspocalyps.Projectiles;

namespace Bosspocalyps.Items.Weapons.Melee
{
    class TrueTerrarianBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Terrarian Blade");
        }

        public override void SetDefaults()
        {
            item.melee = true;
            item.autoReuse = true;
            item.useTurn = true;
            item.damage = 105;
            item.width = 62;
            item.height = 64;
            item.knockBack = 2;
            item.useTime = 15;
            item.useAnimation = 15;
            item.shoot = ProjectileID.TerraBeam;
            item.shootSpeed = 12f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundHelper.ItemSwing;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 speed = new Vector2(speedX, speedY);
            Projectile.NewProjectileDirect(position, speed.RotatedByRandom(MathHelper.PiOver4 - MathHelper.PiOver4/2), type, damage, knockBack, player.whoAmI).GetGlobalProjectile<BGlobalProjectile>().extraaitype = ExtraAIType.TrueTerrarianBlade;
            Projectile.NewProjectileDirect(position, speed.RotatedByRandom(MathHelper.PiOver4 - MathHelper.PiOver4/2), type, damage, knockBack, player.whoAmI).GetGlobalProjectile<BGlobalProjectile>().extraaitype = ExtraAIType.TrueTerrarianBlade;
            Projectile.NewProjectileDirect(position, speed.RotatedByRandom(MathHelper.PiOver4 - MathHelper.PiOver4/2), type, damage, knockBack, player.whoAmI).GetGlobalProjectile<BGlobalProjectile>().extraaitype = ExtraAIType.TrueTerrarianBlade;
            var modplayer = player.GetModPlayer<BosspocalypsModPlayer>();
            var projs = modplayer.SurroundingTEProjs;
            if (projs.Count < 3)
            {
                int p = Projectile.NewProjectile(position, default, ProjectileID.LightBeam, damage, knockBack, player.whoAmI, projs.Count);
                Projectile proj = Main.projectile[p];
                proj.timeLeft = 180;
                proj.tileCollide = false;
                proj.GetGlobalProjectile<BGlobalProjectile>().extraaitype = ExtraAIType.TrueTerrarianBladeTEProj;
                projs.AddLast(p);
            }
            return false;
        }
    }
}
