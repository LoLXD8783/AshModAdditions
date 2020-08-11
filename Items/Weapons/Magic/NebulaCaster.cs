using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Bosspocalyps.Projectiles;
using Microsoft.Xna.Framework;

namespace Bosspocalyps.Items.Weapons.Magic
{
    public class NebulaCaster : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nebula Caster");
            Tooltip.SetDefault("Its light shines beyond the sun, a journey in the book");
        }

        public override void SetDefaults()
        {
            item.damage = 56;
            item.magic = true;
            item.mana = 2;
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
            item.shoot = 348;
            item.shootSpeed = 12f;
            item.UseSound = SoundID.Item13;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile.NewProjectile(position, new Vector2(speedX, speedY), ProjectileID.BallofFrost, damage, knockBack, player.whoAmI);
            Projectile.NewProjectile(position, new Vector2(speedX, speedY), ProjectileID.ShadowBeamFriendly, damage, knockBack, player.whoAmI);
            Projectile.NewProjectile(position, new Vector2(speedX, speedY), ProjectileID.GoldenShowerFriendly, damage, knockBack, player.whoAmI);
            return false;
        }
    }
}