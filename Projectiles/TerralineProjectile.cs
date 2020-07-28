using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace AshModAdditions.Projectiles
{
    class TerralineProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terraline");
        }

        public override void SetDefaults()
        {
            projectile.friendly = true;
            projectile.tileCollide = false;
            projectile.melee = true;
            projectile.penetrate = -1;
            projectile.width = 46;
            projectile.height = 46;
            projectile.ownerHitCheck = true;
            drawOffsetX = -10;
            drawOriginOffsetX = 10;
            drawOriginOffsetY = 10;
        }

        public override void ModifyDamageHitbox(ref Rectangle hitbox)
        {
            const int off = 20;
            hitbox.X += off / 2;
            hitbox.Width -= off;
            hitbox.Y += off / 2;
            hitbox.Height -= off;
        }

        public override void AI()
        {
            ProjectileHelpers.SpearAI(projectile, 4f, MathHelper.PiOver4, ProjectileID.TerraBeam);
        }
    }
}
