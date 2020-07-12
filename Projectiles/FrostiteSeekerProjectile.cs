using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace AshModAdditions.Projectiles
{
    public class FrostiteSeekerProjectile : ModProjectile
    {
        public NPC target;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frostite Seeker Projectile");
        }

        public override void SetDefaults()
        {
            projectile.friendly = true;
            projectile.minion = true;
            projectile.width = 14;
            projectile.height = 14;
        }

        public override void AI()
        {

        }
    }
}
