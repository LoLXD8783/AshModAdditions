using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace AshModAdditions.Projectiles
{
    public class FrostWave : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("FrostWave");
        }

        public override void SetDefaults()
        {
            projectile.timeLeft = 60; // 1 second
            projectile.tileCollide = false;
            projectile.width = 30;
            projectile.height = 30;
            projectile.friendly = true;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }
    }
}
