using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AshModAdditions.Items.Materials
{
    public class BrokenHeroShard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Broken Hero Shard");
        }

        public override void SetDefaults()
        {
            item.material = true;
            item.width = 26;
            item.height = 34;
            item.maxStack = 99;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(this, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.BrokenHeroSword);
            recipe.AddRecipe();
        }
    }
}
