using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Bosspocalyps.Items.Materials;

namespace Bosspocalyps.Items.Armor.Redash
{
    [AutoloadEquip(EquipType.Head)]
    public class RedashHood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Redash hood");
            Tooltip.SetDefault("Boosts magic damage by 4%");
        }

        public override void SetDefaults()
        {
            item.defense = 3;
            item.width = 22;
            item.height = 26;
        }

        public override void UpdateEquip(Player player)
        {
            player.magicDamage += 0.04f;
            player.GetModPlayer<BosspocalypsModPlayer>().RedashHood = true;
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
