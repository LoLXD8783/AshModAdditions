using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AshModAdditions.Items.Weapons.Ranged
{
    public class WormGun : ModItem
    {
        public override string Texture => Helpers.PLACEHOLDER;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("WormGun");
            Tooltip.SetDefault("Shoots 13 bullets like a shotgun");
        }

        public override void SetDefaults()
        {
            item.ranged = true;
            item.noMelee = true;
            item.damage = 17;
            item.useTime = 45;
            item.useAnimation = 45;
            item.knockBack = 3;
            item.shoot = 10;
            item.shootSpeed = 7;
            item.useAmmo = AmmoID.Bullet;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.UseSound = SoundHelper.Shotgun;
        }


        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for(int i = 0; i < 13; i++)
            {
                float d = Main.rand.NextFloat(0.5f, 1f); // Main.rand.NextFloat(1f, 2);
                Vector2 spid = new Vector2 { X = speedX * d, Y = speedY * d }.RotatedByRandom(MathHelper.PiOver4/2);
                Projectile.NewProjectile(position, spid, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}
