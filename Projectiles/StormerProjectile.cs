using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace AshModAdditions.Projectiles
{
    public class StormerProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stormer Projectile");
        }

        public override void SetDefaults()
        {
            projectile.magic = true;
            projectile.width = 8;
            projectile.height = 8;
            projectile.timeLeft = 300;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation();
        }
    }
}
