using System;
using Terraria;
using Terraria.ModLoader;

namespace Bosspocalyps.Projectiles
{
    public class BloodFireShoot : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BloodFire shoot");
        }

        public override void SetDefaults()
        {
            projectile.friendly = true; // hurting NPCs
            projectile.magic = true;
            projectile.width = 34;
            projectile.height = 12;
            projectile.timeLeft = 240;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation(); // face where it's going
        }
    }
}
