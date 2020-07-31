using Terraria;
using Terraria.ModLoader;

namespace Bosspocalyps.Items.Armor.Frostite
{
    [AutoloadEquip(EquipType.Head)]
    public class FrostiteHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("FrostiteHelmet");
        }

        public override void SetDefaults()
        {
            item.defense = 6;
        }

        public override void UpdateEquip(Player player)
        {

        }

        public override bool IsArmorSet(Item head, Item body, Item legs) => body.type == ModContent.ItemType<FrostiteChestplate>() && legs.type == ModContent.ItemType <FrostiteLeggings>();

        public override void UpdateArmorSet(Player player)
        {
            player.GetModPlayer<AshModPlayer>().FrostiteEffect = true;
        }

        public override void AddRecipes()
        {

        }
    }
}
