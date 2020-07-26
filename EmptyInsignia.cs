using System;
using Terraria;
using Terraria.ModLoader;

namespace AshModAdditions.Items.Materials
{
    public class EmptyInsignia : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Empty Insignia");
            Tooltip.SetDefault("Tell Pyro what to put in here");
        }

        public override void SetDefaults()
        {
            item.material = true;
            item.width = 30;
            item.height = 28;
            item.maxStack = 99;
            item.value = Item.sellPrice(gold: 1);
            item.rare = 9;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(3467, 10);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}