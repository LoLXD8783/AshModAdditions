using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Items.Materials;

namespace AshModAdditions.Items.Armor.Combinite
{
    [AutoloadEquip(EquipType.Head)]
    public class CombiniteMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Combinite Mask");
            Tooltip.SetDefault("Increases summon damage by 3%\nIncreases maximum number of minions by 1");
        }

        public override void SetDefaults()
        {
            item.defense = 10;
            item.width = 22;
            item.height = 22;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) => body.type == ModContent.ItemType<CombiniteChestpiece>() && legs.type == ModContent.ItemType<CombiniteLeggings>();

        public override void UpdateEquip(Player player)
        {
            player.minionDamage += 0.03f;
            player.maxMinions++;
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
