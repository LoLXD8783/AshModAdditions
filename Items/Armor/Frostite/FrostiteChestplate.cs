using Terraria;
using Terraria.ModLoader;

namespace Bosspocalyps.Items.Armor.Frostite
{
    [AutoloadEquip(EquipType.Body)]
    public class FrostiteChestplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("FrostiteBreastplate");
        }

        public override void SetDefaults()
        {
            item.defense = 7;
        }

        public override void UpdateEquip(Player player)
        {

        }

        public override void AddRecipes()
        {

        }
    }
}
