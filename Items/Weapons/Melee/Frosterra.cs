using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bosspocalyps.Items.Weapons.Melee
{
    public class Frosterra : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frosterra");
        }

        public override void SetDefaults()
        {
            item.melee = true;
            item.useTime = 16;
            item.useAnimation = 15;
            item.damage = 95;
            item.width = 44;
            item.height = 40;
            item.knockBack = 6.5f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundHelper.ItemSwing;
            item.shoot = ProjectileID.TerraBeam;
            item.shootSpeed = 15;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TrueNightsEdge, 1);
            recipe.AddIngredient(ItemID.TrueExcalibur, 1);
            recipe.AddIngredient<FrozenHeroBlade>(1);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}