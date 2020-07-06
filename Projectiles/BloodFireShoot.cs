using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace AshModAdditions.Projectiles
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
            projectile.width = 34;
            projectile.height = 12;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation(); // face where it's going
        }
    }
}
