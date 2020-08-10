using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Bosspocalyps.Projectiles.NPCs.Minibosses
{
    public class HarpyWarriorProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Harpy Warrior Feather");
        }

        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 14;
            projectile.timeLeft = 300;
            projectile.hostile = true;
        }

        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }
    }
}
