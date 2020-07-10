using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Items.Materials;

namespace AshModAdditions.Items.Armor.Redash
{
    [AutoloadEquip(EquipType.Legs)]
    public class RedashLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Redash Leggings");
            Tooltip.SetDefault("Increases movement speed by 3%");
        }

        public override void SetDefaults()
        {
            item.defense = 21;
            item.width = 20;
            item.height = 14;
        }

        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.03f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient<RedashBar>(15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
