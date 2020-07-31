using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Bosspocalyps.Items.Materials;

namespace Bosspocalyps.Items.Armor.Combinite
{
    [AutoloadEquip(EquipType.Head)]
    public class CombiniteHeadPiece : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Combinite Headpiece");
            Tooltip.SetDefault("Boosts magic damage by 3%");
        }

        public override void SetDefaults()
        {
            item.defense = 12;
            item.width = 22;
            item.height = 22;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) => body.type == ModContent.ItemType<CombiniteChestpiece>() && legs.type == ModContent.ItemType<CombiniteLeggings>();

        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.03f;
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
