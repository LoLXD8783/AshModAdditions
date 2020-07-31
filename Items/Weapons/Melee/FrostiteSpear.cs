﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Bosspocalyps.Items.Materials;
using Bosspocalyps.Projectiles;
using Microsoft.Xna.Framework;

namespace Bosspocalyps.Items.Weapons.Melee
{
    public class FrostiteSpear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("FrostiteSpear");
        }

        public override void SetDefaults()
        {
            item.melee = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<FrostiteSpearProjectile>();
            item.shootSpeed = 4;
            item.useTime = 40;
            item.useAnimation = 40;
            item.width = 90;
            item.height = 90;
            item.damage = 31;
            item.knockBack = 10;
            item.useStyle = ItemUseStyleID.HoldingOut;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectileDirect(position, new Vector2(speedX, speedY), type, damage, knockBack, player.whoAmI).damage = 16;
            return false;
        }

        public override bool CanUseItem(Player player) => player.ownedProjectileCounts[item.shoot] < 1;

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient<FrostiteBar>(30);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
