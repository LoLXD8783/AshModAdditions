using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Bosspocalyps.Items.Materials;
using Microsoft.Xna.Framework;
using Bosspocalyps.Projectiles;

namespace Bosspocalyps.Items.Weapons.Ranged
{
    class FrostiteBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frostite bow");
        }

        public override void SetDefaults()
        {
            item.autoReuse = true;
            item.ranged = true;
            item.noMelee = true;
            item.damage = 20;
            item.useTime = 13;
            item.useAnimation = 13;
            item.shoot = 10;
            item.shootSpeed = 8;
            item.scale = 1f;
            item.crit = 6;
            item.width = 24;
            item.height = 58;

            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAmmo = AmmoID.Arrow;

            Item c = new Item(); // TODO REMOVE THIS 
            c.CloneDefaults(ItemID.SilverBow);
            item.UseSound = c.UseSound;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int p = Projectile.NewProjectile(position, new Vector2(speedX, speedY), type, damage, knockBack, player.whoAmI);
            Main.projectile[p].GetGlobalProjectile<BGlobalProjectile>().FrostiteBowShot = true;
            return false;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(4f, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient<FrostiteBar>(30);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
