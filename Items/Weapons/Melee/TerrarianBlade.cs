using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Bosspocalyps.Projectiles;

namespace Bosspocalyps.Items.Weapons.Melee
{
    public class TerrarianBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terrarian Blade");
        }

        public override void SetDefaults()
        {
            item.melee = true;
            item.autoReuse = true;
            item.damage = 190;
            item.width = 50;
            item.height = 48;
            item.useTime = 15;
            item.useAnimation = 15;
            item.shootSpeed = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.shoot = ProjectileID.TerraBeam;
            item.UseSound = SoundHelper.ItemSwing;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 speed = new Vector2(speedX, speedY);
            Projectile.NewProjectileDirect(position, speed, type, damage, knockBack, player.whoAmI).GetGlobalProjectile<AshGlobalProjectile>().TerrarianBladeShot = true;
            Projectile.NewProjectileDirect(position, speed.RotatedByRandom(MathHelper.PiOver4/2), type, damage, knockBack, player.whoAmI).GetGlobalProjectile<AshGlobalProjectile>().TerrarianBladeShot = true;
            Projectile.NewProjectileDirect(position, speed.RotatedByRandom(MathHelper.PiOver4/2), type, damage, knockBack, player.whoAmI).GetGlobalProjectile<AshGlobalProjectile>().TerrarianBladeShot = true;
            
            return false;
        }
    }
}
