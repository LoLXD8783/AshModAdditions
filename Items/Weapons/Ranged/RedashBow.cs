using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Bosspocalyps.Items.Materials;
using Microsoft.Xna.Framework;

namespace Bosspocalyps.Items.Weapons.Ranged
{
    class RedashBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Redash bow");
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
            item.shootSpeed = 8;
            item.scale = 0.55f;
            item.crit = 6;
            item.width = 58;
            item.height = 98;

            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAmmo = AmmoID.Arrow;

            Item c = new Item(); // TODO REMOVE THIS 
            c.CloneDefaults(ItemID.SilverBow);
            item.UseSound = c.UseSound;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(4f, 0);
        }

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
