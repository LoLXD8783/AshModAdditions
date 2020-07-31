using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Bosspocalyps.Items.Materials;

namespace Bosspocalyps.Items.Tools
{
    public class CombinitePick : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Combinite Pick");
        }

        public override void SetDefaults()
        {
            item.damage = 10;
            item.useTime = 15;
            item.useAnimation = 15;
            item.pick = 130;
            item.width = 32;
            item.height = 32;
            item.knockBack = 3f;
            item.autoReuse = true;
            item.useTurn = true;

            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundHelper.ItemSwing;

            item.value = Item.sellPrice(gold: 16);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient<CombiniteBar>(20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
