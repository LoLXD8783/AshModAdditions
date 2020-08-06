using System;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bosspocalyps.Projectiles
{
    public partial class BGlobalProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public override bool CloneNewInstances => true;

        public bool FrostiteBowShot;
        public bool StormerProjectileShot;

        internal ExtraAIType extraaitype;

        public override void AI(Projectile projectile)
        {
            if (projectile.type == ProjectileID.TerraBeam || projectile.type == ProjectileID.LightBeam)
            {
                ExtraAI(projectile);
            }
        }

        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            if (FrostiteBowShot)
                target.AddBuff(BuffID.Frozen, 60);

            if (StormerProjectileShot)
                target.AddBuff(BuffID.Slow, 60);

            if (projectile.type == ProjectileID.TerraBeam)
            {
                if (extraaitype == ExtraAIType.TrueTerrarianBlade)
                    TrueTerrarianBladeOnHit(projectile);
            }
        }
    }
}
