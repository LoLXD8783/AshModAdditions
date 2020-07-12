using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Items.Materials;

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
            item.defense = 12;
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
            recipe.AddIngredient<RedashBar>(25);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
