using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace AshModAdditions.Projectiles
{
    class FrostiteSpearProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frostite Spear");
        }

        public override void SetDefaults()
        {
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.melee = true;
            projectile.penetrate = -1;
            projectile.width = 90;
            projectile.height = 90;
            projectile.ownerHitCheck = true;
        }

        public override void AI()
        {
            ProjectileHelpers.SpearAI(projectile, 4f, MathHelper.PiOver2 + MathHelper.PiOver4, ModContent.ProjectileType<FrostWave>());
        }
    }
}
