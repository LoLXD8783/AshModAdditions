using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AshModAdditions.Projectiles
{
    public partial class AshGlobalProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public override bool CloneNewInstances => true;

        public bool FrostiteBowShot;
        public bool StormerProjectileShot;
        public bool TerrarianBladeShot;

        public override void AI(Projectile projectile)
        {
            if(projectile.type == ProjectileID.TerraBeam && TerrarianBladeShot)
            {
                TerrarianBladeProjExtraAI(projectile);
            }
        }

        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            if (FrostiteBowShot)
                target.AddBuff(BuffID.Frozen, 60);

            if (StormerProjectileShot)
                target.AddBuff(BuffID.Slow, 60);
        }
    }
}
