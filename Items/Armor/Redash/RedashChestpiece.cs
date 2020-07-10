using Terraria;
using Terraria.ModLoader;

namespace AshModAdditions.Items.Armor.Redash
{
    [AutoloadEquip(EquipType.Body)]
    public class RedashChestpiece : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Redash Breastplate");
            Tooltip.SetDefault("Increases movement speed by 3%");
        }

        public override void SetDefaults()
        {
            item.defense = 38;
            item.width = 28;
            item.height = 18;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.03f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            // Add ingredients and tiles
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
