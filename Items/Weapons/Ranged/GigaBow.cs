using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Bosspocalyps.Items.Weapons.Ranged
{
    public class GigaBow : ModItem
    {
        public override string Texture => Helpers.PLACEHOLDER;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Giga Star");
        }

        public override void SetDefaults()
        {
            item.ranged = true;
            item.noMelee = true;
            item.useTime = 10;
            item.useAnimation = 10;
            item.shoot = 10;
            item.shootSpeed = 7;
            item.useAmmo = AmmoID.Arrow;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.UseSound = SoundHelper.ItemBowShot;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.WoodenArrowFriendly)
                type = ProjectileID.JestersArrow;
            Vector2 spid = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.PiOver4);
            speedX = spid.X;
            speedY = spid.Y;
            return true;
        }
    }
}
