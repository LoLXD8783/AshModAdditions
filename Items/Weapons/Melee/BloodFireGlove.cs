using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AshModAdditions.Items.Materials;
using AshModAdditions.Projectiles;

namespace AshModAdditions.Items.Weapons.Melee
{
    public class BloodFireGlove : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BloodfireGlove");
        }

        public override void SetDefaults()
        {
            item.melee = true;
            item.damage = 10;

            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTime = 10;
            item.useAnimation = 10;
            item.shoot = ModContent.ProjectileType<BloodFirePellet>();
            item.shootSpeed = 5;
            item.width = 120;
            item.height = 110;

            item.UseSound = SoundID.Item18;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<UnholiteBar>(), 15);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }
    }
}
