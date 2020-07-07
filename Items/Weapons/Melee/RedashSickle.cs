using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Items.Materials;

namespace AshModAdditions.Items.Weapons.Melee
{
    class RedashSickle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Redash Sickle");
        }

        public override void SetDefaults()
        {
            item.damage = 16;
            item.knockBack = 8;
            item.useTime = 13;
            item.useAnimation = 13;
            item.width = 68;
            item.height = 68;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.autoReuse = true;
            item.useTurn = true;

            item.UseSound = SoundID.Item18;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<RedashBar>());
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
