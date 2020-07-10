using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Tiles;

namespace AshModAdditions.Items.Materials
{
    public class CrystaliteBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystalite Bar");
        }

        public override void SetDefaults()
        {
            item.material = true;
            item.maxStack = 999;
            item.width = 30;
            item.height = 24;
        }

        public override void AddRecipes()
        {
            // TODO find a better way to add this recipe
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CrystalShard, 3);
            recipe.AddIngredient(ItemID.OrichalcumBar);
            recipe.AddTile<UnholyResearchStationTile>();
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
