using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Items.Materials;

namespace AshModAdditions.Items.Tools
{
    public class RedashHammaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Redash Hammaxe");
        }

        public override void SetDefaults()
        {
            item.melee  = true;
            item.autoReuse = true;
            item.damage = 20;
            item.axe = 30;
            item.hammer = 200;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item18;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<RedashBar>(), 18);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
