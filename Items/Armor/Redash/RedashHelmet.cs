using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Items.Materials;

namespace AshModAdditions.Items.Armor.Redash
{
    [AutoloadEquip(EquipType.Head)]
    public class RedashHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Redash Helmet");
        }

        public override void SetDefaults()
        {
            item.defense = 23;
            item.width = 26;
            item.height = 22;
        }

        public override void UpdateEquip(Player player)
        {
            player.rangedDamage += 0.03f;
            // player.rangedspeed // 5%
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) => body.type == ModContent.ItemType<RedashChestpiece>() && legs.type == ModContent.ItemType <RedashLeggings>();

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient<RedashBar>(10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
