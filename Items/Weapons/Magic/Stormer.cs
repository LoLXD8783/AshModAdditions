using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Bosspocalyps.Projectiles;
using Microsoft.Xna.Framework;

namespace Bosspocalyps.Items.Weapons.Magic
{
    public class Stormer : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("This is a modded magic weapon.");
        }

        public override void SetDefaults()
        {
            item.damage = 37;
            item.magic = true;
            item.mana = 5;
            item.width = 28;
            item.height = 32;
            item.useTime = 5;
            item.useAnimation = 5;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true; 
            item.value = 10000;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<StormerProjectile>();
            item.shootSpeed = 20f;
            item.UseSound = SoundID.Item13;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int p = Projectile.NewProjectile(position, new Vector2(speedX, speedY), type, damage, knockBack, player.whoAmI);
            Main.projectile[p].GetGlobalProjectile<BGlobalProjectile>().StormerProjectileShot = true;
            return false;
        }
    }
}