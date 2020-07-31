using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Bosspocalyps.Items.Materials;

namespace Bosspocalyps.Items.Tools
{
    public class CombiniteHammaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Combinite Hammaxe");
        }

        public override void SetDefaults()
        {
            item.melee = true;
            item.autoReuse = true;
            item.damage = 15;
            item.axe = 28;
            item.hammer = 190;
            item.useAnimation = 20;
            item.useTime = 20;
            item.knockBack = 4f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundHelper.ItemSwing;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient<CombiniteBar>(16);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
