using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Bosspocalyps.Items.Materials;

namespace Bosspocalyps.Items.Armor.Combinite
{
    [AutoloadEquip(EquipType.Body)]
    public class CombiniteChestpiece : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Combinite Chestpiece");
            Tooltip.SetDefault("Boosts damage by 2%");
        }

        public override void SetDefaults()
        {
            item.defense = 28;
            item.width = 26;
            item.height = 20;
        }

        public override void UpdateEquip(Player player)
        {
            player.allDamage += 0.02f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient<CombiniteBar>(20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
