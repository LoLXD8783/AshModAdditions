using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Items.Materials;

namespace AshModAdditions.Items.Weapons.Melee
{
    public class CombiniteSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Combinite Sword");
        }

        public override void SetDefaults()
        {
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.scale = 1.5f;
            item.crit = 7;
            item.damage = 42;
            item.width = 36;
            item.height = 34;
            item.value = Item.sellPrice(gold: 10);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<CombiniteBar>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
