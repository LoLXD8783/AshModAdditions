using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Bosspocalyps.Items.Materials;

namespace Bosspocalyps.Items.Armor.Redash
{
    [AutoloadEquip(EquipType.Head)]
    public class RedashHeadgear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Redash headgear");
        }

        public override void SetDefaults()
        {
            item.defense = 18;
            item.width = 26;
            item.height = 20;
        }

        public override void UpdateEquip(Player player)
        {
            player.meleeDamage += 0.04f;
            player.meleeSpeed += 0.05f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) => body.type == ModContent.ItemType<RedashChestpiece>() && legs.type == ModContent.ItemType<RedashLeggings>();

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient<RedashBar>(15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
