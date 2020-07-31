using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bosspocalyps.Items.Weapons.Melee
{
    public class DiamondScyth : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Diamond Scyth");
        }

        public override void SetDefaults()
        {
            item.melee = true;
            item.useTime = 15;
            item.useAnimation = 15;
            item.damage = 15;
            item.width = 44;
            item.height = 40;
            item.knockBack = 8f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item18;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Diamond, 15);
            recipe.AddIngredient(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
