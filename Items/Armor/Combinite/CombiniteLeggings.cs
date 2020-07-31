using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Bosspocalyps.Items.Materials;

namespace Bosspocalyps.Items.Armor.Combinite
{
    [AutoloadEquip(EquipType.Legs)]
    public class CombiniteLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Combinite Leggings");
            Tooltip.SetDefault("Boosts damage by 2%");
        }

        public override void SetDefaults()
        {
            item.defense = 19;
            item.width = 18;
            item.height = 16;
        }

        public override void UpdateEquip(Player player)
        {
            player.allDamage += 0.02f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient<CombiniteBar>(15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
