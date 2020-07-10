using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AshModAdditions
{
    public static class Helpers
    {
        public static void AddIngredient<T>(this ModRecipe recipe, int stack = 1) where T : ModItem
        {
            recipe.AddIngredient(ModContent.ItemType<T>(), stack);
        }

        public static void AddTile<T>(this ModRecipe recipe) where T : ModTile
        {
            recipe.AddTile(ModContent.TileType<T>());
        }
    }
}
