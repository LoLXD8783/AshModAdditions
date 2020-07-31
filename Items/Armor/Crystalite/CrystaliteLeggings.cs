using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Bosspocalyps.Items.Materials;

namespace Bosspocalyps.Items.Armor.Crystalite
{
    [AutoloadEquip(EquipType.Legs)]
    public class CrystaliteLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystalite Leggings");
        }

        public override void SetDefaults()
        {
            item.defense = 11;
            item.width = 20;
            item.height = 14;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient<CrystaliteBar>(16);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
