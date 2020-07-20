using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AshModAdditions.Items.Materials;

namespace AshModAdditions.Items.Weapons.Melee
{
    public class TerraKnife : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terra Knife");
        }

        public override void SetDefaults()
        {
            item.damage = 98;
            item.width = 50;
            item.height = 48;
            item.useTime = 13;
            item.useAnimation = 13;
            item.shootSpeed = 10;
            item.knockBack = 4f;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.shoot = ProjectileID.TerraBeam;
            item.UseSound = SoundID.Item18;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe  = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BrokenHeroSword);
            recipe.AddIngredient<TerraBar>(5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
