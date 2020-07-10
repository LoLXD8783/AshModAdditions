using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Items.Materials;
using Microsoft.Xna.Framework;

namespace AshModAdditions.Items.Weapons.Ranged
{
    class CombiniteBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Combinite bow");
        }

        public override void SetDefaults()
        {
            item.autoReuse = true;
            item.ranged = true;
            item.noMelee = true;
            item.damage = 30;
            item.useTime = 15;
            item.useAnimation = 15;
            item.shoot = 10;
            item.shootSpeed = 4;
            item.scale = 1.5f;

            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAmmo = AmmoID.Arrow;

            Item c = new Item(); // TODO REMOVE THIS 
            c.CloneDefaults(ItemID.SilverBow);
            item.UseSound = c.UseSound;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(4, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient<CombiniteBar>(10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
