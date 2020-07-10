using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AshModAdditions.Items.Materials;
using AshModAdditions.Projectiles;
using AshModAdditions.Tiles;

namespace AshModAdditions.Items.Weapons.Melee
{
    public class BloodFireGlove : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BloodfireGlove");
        }

        public override void SetDefaults()
        {
            item.melee = true;
            item.autoReuse = true;
            item.damage = 35;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 10;
            item.useAnimation = 10;
            item.shoot = ModContent.ProjectileType<BloodFirePellet>();
            item.shootSpeed = 8;
            item.width = 120;
            item.height = 110;

            item.UseSound = SoundID.Item21;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient<UnholiteBar>(15);
            recipe.AddTile<UnholyResearchStationTile>();
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
