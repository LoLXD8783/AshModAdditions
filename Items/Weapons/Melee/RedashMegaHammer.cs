using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Items.Materials;

namespace AshModAdditions.Items.Weapons.Melee
{
    public class RedashMegaHammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Redash MegaHammer");
            Tooltip.SetDefault("pat was here");
        }

        public override void SetDefaults()
        {
            item.autoReuse = true;
            item.melee = true;
            item.damage = 80;
            item.width = 122;
            item.height = 122;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.crit = 13;
            item.knockBack = 4;

            item.UseSound = SoundID.Item18;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<RedashBar>(), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
