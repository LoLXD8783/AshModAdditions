using Terraria;
using Terraria.ModLoader;

namespace AshModAdditions.Items.Armor.Frostite
{
    [AutoloadEquip(EquipType.Legs)]
    public class FrostiteLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("FrostiteLeggings");
        }

        public override void SetDefaults()
        {
            item.defense = 5;
        }

        public override void UpdateEquip(Player player)
        {

        }

        public override void AddRecipes()
        {

        }
    }
}
