using System;
using Terraria;
using Terraria.ModLoader;

namespace Bosspocalyps.Projectiles
{
    public class BloodFirePellet : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = 30;
            projectile.height = 30;
            // drawOffsetX = 1;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.width = 22;
            projectile.height = 6;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation();
        }
    }
}
