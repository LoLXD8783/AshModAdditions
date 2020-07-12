using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Items.Materials;

namespace AshModAdditions.Items.Armor.Crystalite
{
    [AutoloadEquip(EquipType.Head)]
    public class CrystaliteHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystalite Helmet");
        }

        public override void SetDefaults()
        {
            item.defense = 21;
            item.width = 28;
            item.height = 24;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "All damage +7%\n+ 20 max HP\n+20 maximum mana";
            player.allDamage += 0.07f;
            player.statLifeMax2 += 20;
            player.statManaMax2 += 20;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) => body.type == ModContent.ItemType<CrystaliteBreastplate>() && legs.type == ModContent.ItemType<CrystaliteLeggings>();

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient<CrystaliteBar>(12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
