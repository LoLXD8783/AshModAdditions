using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Items.Materials;

namespace AshModAdditions.Items.Weapons.Melee
{
    public class RedashSaber : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Redash Saber");
            Tooltip.SetDefault("It has a blue banner on it that says, \"pats blessing\"");
        }

        public override void SetDefaults()
        {
            item.melee = true;
            item.autoReuse = true;
            item.damage = 70;
            item.useTime = 15;
            item.useAnimation = 15;
            item.crit = 17;
            item.width = 76;
            item.height = 76;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item18;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient<RedashBar>(19);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
