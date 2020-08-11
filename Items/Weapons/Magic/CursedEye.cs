using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Bosspocalyps.Projectiles;

namespace Bosspocalyps.Items.Weapons.Magic
{
    public class CursedEye : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Eye");
        }

        public override void SetDefaults()
        {
            item.magic = true;
            item.autoReuse = true;

            item.damage = 70;
            item.width = 30;
            item.height = 3;
            item.mana = 7;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shoot = ProjectileID.EyeFire;
            item.shootSpeed = 8f;

            item.UseSound = SoundID.Item21;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int p = Projectile.NewProjectile(position, new Vector2(speedX, speedY), type, damage, knockBack, player.whoAmI);
            Projectile projectile = Main.projectile[p];
            projectile.hostile = false; // damages players
            projectile.friendly = true; // damages enemies
            return false;
        }
    }
}