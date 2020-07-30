using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AshModAdditions.Projectiles;
using AshModAdditions.Tiles;

namespace AshModAdditions.Items.Weapons.Ranged
{
    public class AbyssKnives : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Abyss Knives");
        }

        public override void SetDefaults()
        {
            item.autoReuse = true;
            item.melee = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.damage = 50;
            item.knockBack = 2f;
            item.useTime = 15;
            item.useAnimation = 15;
            item.shootSpeed = 15f;
            item.shoot = ModContent.ProjectileType<AbyssKnivesProjectile>();
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item39;
        }

        // adapted from vanilla
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int projectiles = 4;
            if (Main.rand.NextBool(2)) projectiles++;
            if (Main.rand.NextBool(4)) projectiles++;
            if (Main.rand.NextBool(8)) projectiles++;
            if (Main.rand.NextBool(16)) projectiles++;

            for(int i = 0; i < projectiles; i++)
            {
                Projectile.NewProjectile(position, new Vector2(speedX, speedY).RotatedByRandom(MathHelper.PiOver4 / 2), type, damage, knockBack, player.whoAmI);
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.VampireKnives);
            recipe.AddIngredient(ItemID.BeetleHusk, 10);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 10);
            recipe.AddIngredient(ItemID.LunarBar, 5);
            recipe.AddTile<LuminiteAnvilTile>();
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
