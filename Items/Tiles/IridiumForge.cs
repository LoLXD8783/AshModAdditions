using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Items.Tiles.Ores;
using AshModAdditions.Tiles;

namespace AshModAdditions.Items.Tiles
{
    public class IridiumForge : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Iridium Forge");
        }

        public override void SetDefaults()
        {
            item.useTime = 10;
            item.useAnimation = 10;
            item.width = 48;
            item.height = 34;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.createTile = ModContent.TileType<IridiumForgeTile>();
            item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient<IridiumOre>(10);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
