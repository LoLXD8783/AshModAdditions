using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Bosspocalyps.Projectiles;

namespace Bosspocalyps.Items.Weapons.Melee
{
    public class SpectreBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectre Blade");
        }

        public override void SetDefaults()
        {
            item.melee = true;
            item.damage = 190;
            item.width = 46;
            item.height = 44;
            item.useTime = 15;
            item.useAnimation = 15;
            item.shootSpeed = 10;
            item.shoot = ProjectileID.TerraBeam;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item18;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 spid = new Vector2() { X = speedX, Y = speedY };
            damage = 185;
            Projectile.NewProjectile(player.MountedCenter, spid, type, damage, knockBack, player.whoAmI);
            Projectile.NewProjectile(player.MountedCenter, spid, ModContent.ProjectileType<SpectreBladeProjectile>(), damage, knockBack, player.whoAmI);
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TerraBlade);
            recipe.AddIngredient(ItemID.SpectreBar, 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
