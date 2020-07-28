using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AshModAdditions.Projectiles
{
    public abstract class MushorStaffProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mushor Staff Projectile");
        }

        public override void SetDefaults()
        {
            projectile.friendly = true;
            projectile.width = 22;
            projectile.height = 24;
        }

        public override void AI()
        {

        }
    }
}
