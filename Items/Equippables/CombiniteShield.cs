using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Items.Materials;

namespace AshModAdditions.Items.Equippables
{
    public class CombiniteShield : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 9));
            DisplayName.SetDefault("Combinite Shield");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 32;
            item.height = 36;
            item.defense = 6;
            item.value = Item.sellPrice(gold: 5);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.noKnockback = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.CobaltShield);
            recipe.AddIngredient(ModContent.ItemType<CombiniteBar>(), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
