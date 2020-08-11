using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Bosspocalyps.Projectiles;

namespace Bosspocalyps.Items.Weapons.Melee
{
    class Sunflare : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sunflare");
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
            item.shoot = 467;
            item.shootSpeed = 12f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundHelper.ItemSwing;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int p = Projectile.NewProjectile(position, new Vector2(speedX, speedY), type, damage, knockBack, player.whoAmI);
            Projectile projectile = Main.projectile[p];
            projectile.hostile = false; // damages players
            projectile.friendly = true; // damages enemies
            return false;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FragmentSolar, 7);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}