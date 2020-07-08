using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AshModAdditions.Items.Materials
{
    public class RedashBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 17));
            DisplayName.SetDefault("Radash Bar");
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
            recipe.AddIngredient(ItemID.HellstoneBar);
            recipe.AddIngredient(ModContent.ItemType<CombiniteBar>());
            recipe.AddTile(TileID.Furnaces);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
