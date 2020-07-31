using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bosspocalyps.Items.Weapons.Ranged
{
    public class WormGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("WormGun");
            Tooltip.SetDefault("Shoots 13 bullets like a shotgun");
        }

        public override void SetDefaults()
        {
            item.ranged = true;
            item.noMelee = true;
            item.damage = 40;
            item.useTime = 45;
            item.useAnimation = 45;
            item.knockBack = 3;
            item.shoot = 10;
            item.shootSpeed = 7;
            item.width = 44;
            item.height = 22;
            item.useAmmo = AmmoID.Bullet;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.UseSound = SoundHelper.Shotgun;
        }


        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            for (int i = 0; i < 13; i++)
            {
                float d = Main.rand.NextFloat(0.5f, 1f); 
                Vector2 spid = new Vector2(speedX * d, speedY * d).RotatedByRandom(MathHelper.PiOver4 / 2);
                Projectile.NewProjectile(position, spid, type, damage, knockBack, player.whoAmI);
            }
            return false;
        }
    }
}
