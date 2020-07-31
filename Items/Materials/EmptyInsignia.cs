using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Bosspocalyps.Items.Materials
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
            item.rare = ItemRarityID.Cyan;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}