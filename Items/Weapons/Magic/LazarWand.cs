using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Bosspocalyps.Projectiles;

namespace Bosspocalyps.Items.Weapons.Magic

{
    public class LazarWand : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Purple Caster");
        }

        public override void SetDefaults()
        {
            item.magic = true;
            item.autoReuse = true;

            item.damage = 89;
            item.width = 30;
            item.height = 35;
            item.mana = 8;
            item.useTime = 33;
            item.useAnimation = 34;
            item.noMelee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shoot = ProjectileID.AncientDoomProjectile;
            item.shootSpeed = 16;
            item.UseSound = new Terraria.Audio.LegacySoundStyle(2, 72);

        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int p = Projectile.NewProjectile(position, new Vector2(speedX, speedY), type, damage, knockBack, player.whoAmI);
            Projectile projectile = Main.projectile[p];
            projectile.hostile = false; // damages players
            projectile.friendly = true; // damages enemies
            return false;
        }
    }
}