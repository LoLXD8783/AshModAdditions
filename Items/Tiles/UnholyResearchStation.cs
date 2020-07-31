using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Bosspocalyps.Items.Materials;
using Bosspocalyps.Tiles;

namespace Bosspocalyps.Items.Tiles
{
    public class UnholyResearchStation : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Unholy Research Station");
            Tooltip.SetDefault("A table used to create horrible things of destruction");
        }

        public override void SetDefaults()
        {
            item.useTime = 10;
            item.useAnimation = 10;
            item.width = 48;
            item.height = 32;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.createTile = ModContent.TileType<UnholyResearchStationTile>();
            item.consumable = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient<UnholiteBar>(10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
