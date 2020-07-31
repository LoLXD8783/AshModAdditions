using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Bosspocalyps.Projectiles;

namespace Bosspocalyps.Items.Weapons.Magic
{
    public class EnchantedBloodFire : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Enchanted Bloodfire");
        }

        public override void SetDefaults()
        {
            item.magic = true;
            item.autoReuse = true;

            item.damage = 15;
            item.width = 35;
            item.height = 38;
            item.mana = 4;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shoot = ModContent.ProjectileType<BloodFireShoot>();
            item.shootSpeed = 8f;

            item.UseSound = SoundID.Item21;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (Main.rand.NextBool(10))
            {
                Projectile.NewProjectile(position, new Vector2(speedX, speedY), ModContent.ProjectileType<BloodFireHoming>(), damage, knockBack, player.whoAmI);
            }
            return true;
        }
    }
}
