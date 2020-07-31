using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Bosspocalyps.Items.Materials;

namespace Bosspocalyps.Items.Armor.Combinite
{
    [AutoloadEquip(EquipType.Head)]
    public class CombiniteHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Combinite Helmet");
            Tooltip.SetDefault("Boosts ranged damage by 3%");
        }

        public override void SetDefaults()
        {
            item.defense = 14;
            item.width = 28;
            item.height = 24;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) => body.type == ModContent.ItemType<CombiniteChestpiece>() && legs.type == ModContent.ItemType<CombiniteLeggings>();

        public override void UpdateEquip(Player player)
        {
            player.rangedDamage += 0.03f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient<CombiniteBar>(10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
