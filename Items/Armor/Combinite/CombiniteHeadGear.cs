using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Items.Materials;

namespace AshModAdditions.Items.Armor.Combinite
{
    [AutoloadEquip(EquipType.Head)]
    public class CombiniteHeadGear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Combinite HeadGear");
            Tooltip.SetDefault("Boosts melee damage by 2%");
        }

        public override void SetDefaults()
        {
            item.defense = 16;
            item.width = 26;
            item.height = 20;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.02f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) => body.type == ModContent.ItemType<CombiniteChestpiece>() && legs.type == ModContent.ItemType<CombiniteLeggings>();

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
