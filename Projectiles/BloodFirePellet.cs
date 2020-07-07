using System;
using Terraria;
using Terraria.ModLoader;

namespace AshModAdditions.Projectiles
{
    public class BloodFirePellet : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            // drawOffsetX = 1;
            projectile.friendly = true;
            projectile.width = 110;
            projectile.height = 30;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation();
        }
    }
}
