using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bosspocalyps.Projectiles
{
    public class SpectreBladeProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spectre Blade Projectile");
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.TerraBeam);
            projectile.width = 40;
            projectile.height = 40;
            aiType = ProjectileID.TerraBeam;
        }
    }
}
