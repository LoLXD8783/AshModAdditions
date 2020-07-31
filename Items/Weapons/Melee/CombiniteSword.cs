using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Bosspocalyps.Items.Materials;

namespace Bosspocalyps.Items.Weapons.Melee
{
    public class CombiniteSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Combinite Sword");
        }

        public override void SetDefaults()
        {
            item.melee = true;
            item.useTurn = true;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.scale = 1.5f;
            item.crit = 7;
            item.damage = 50;
            item.width = 60;
            item.height = 58;
            item.value = Item.sellPrice(gold: 10);

            item.UseSound = SoundID.Item18;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient<CombiniteBar>(15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
