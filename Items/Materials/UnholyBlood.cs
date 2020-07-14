using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using AshModAdditions.Projectiles;

namespace AshModAdditions.Items.Materials
{
    public class UnholyBlood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Unholy Blood");
        }

        public override void SetDefaults()
        {
            item.material = true;
            item.consumable = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.damage = 10;
            item.maxStack = 999;
            item.useTime = 10;
            item.useAnimation = 10;
            item.shoot = ModContent.ProjectileType<BloodFirePellet>();
            item.shootSpeed = 8;
            item.UseSound = SoundID.Item18;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Projectile p = Projectile.NewProjectileDirect(position, new Vector2(speedX, speedY), type, damage, knockBack, player.whoAmI);
            if(p.modProjectile is BloodFirePellet)
            {
                p.melee = false;
                p.ranged = true;
            }
            return false;
        }
    }
}
