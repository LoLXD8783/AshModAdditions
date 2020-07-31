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
    class FrigidInsignia : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frigid Insignia");
            Tooltip.SetDefault(@"+5% all damage when in the Snow Biome
20 defense when in the Snow Biome
+3% damage reduction when in the Snow Biome
+40% running speed when in the Snow Biome
+20% melee speed when in the Snow Biome
+3 life regen when in the Snow Biome");
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
            if (player.ZoneSnow)
            {
                player.GetModPlayer<AshModPlayer>().FrigidInsignia = true;
                player.allDamage += 0.05f;
                player.statDefense += 20;
                player.accRunSpeed += 0.4f;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient<EmptyInsignia>();
            recipe.AddIngredient(ItemID.SnowBlock, 15);
            recipe.AddIngredient(ItemID.IceBlock, 15);
            recipe.AddIngredient<FrozenHeroBlade>();
            recipe.AddTile<LuminiteAnvilTile>();
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
