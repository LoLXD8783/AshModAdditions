using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Bosspocalyps.Items.Materials;
using Bosspocalyps.Tiles;
using Bosspocalyps.Items.Weapons.Melee;

namespace Bosspocalyps.Items.Insignias
{
    class OvergrownInsignia : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Overgrown Insignia");
            Tooltip.SetDefault(@"+5% all damage when in the Jungle
20 defense when in the Jungle
+3% damage reduction when in the Jungle
+40% running speed when in the Jungle
+20% melee speed when in the Jungle
+3 life regen when in the Jungle");
        }

        public override void SetDefaults()
        {
            item.material = true;
            item.accessory = true;
            item.width = 30;
            item.height = 28;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.ZoneJungle)
            {
                player.GetModPlayer<BosspocalypsModPlayer>().OvergrownInsignia = true;
                player.allDamage += 0.05f;
                player.statDefense += 20;
                player.accRunSpeed += 0.4f;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient<EmptyInsignia>();
            recipe.AddIngredient(ItemID.MudBlock, 10);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 5);
            recipe.AddRecipeGroup(RecipeGroupID.Wood, 5);
            recipe.AddIngredient(ItemID.JungleSpores, 6);
            recipe.AddTile<LuminiteAnvilTile>();
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
