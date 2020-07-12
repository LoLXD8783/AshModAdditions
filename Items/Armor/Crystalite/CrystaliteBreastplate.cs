using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Items.Materials;

namespace AshModAdditions.Items.Armor.Crystalite
{
    [AutoloadEquip(EquipType.Body)]
    public class CrystaliteBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystalite Breastplate");
        }

        public override void SetDefaults()
        {
            item.defense = 15;
            item.width = 30;
            item.height = 18;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient<CrystaliteBar>(21);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
