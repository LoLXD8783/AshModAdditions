using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AshModAdditions.Items.Materials
{
    public class TerraBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terra Bar");
        }

        public override void SetDefaults()
        {
            item.material = true;
            item.width = 30;
            item.height = 24;
            item.maxStack = 99;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DemoniteBar);
            recipe.AddIngredient(ItemID.CrimtaneBar);
            recipe.AddIngredient<TerraShard>();
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
