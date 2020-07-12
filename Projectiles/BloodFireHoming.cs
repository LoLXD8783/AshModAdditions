using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace AshModAdditions.Projectiles
{
    public class BloodFireHoming : ModProjectile
    {
        public NPC target;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BloodFire Homing");
        }

        public override void SetDefaults()
        {
            projectile.friendly = true;
            projectile.magic = true;
            projectile.height = 32;
            projectile.width = 37;
        }

        public override void AI()
        {
            if (!IsValidTarget(target)) // when there's no target
            {
                if (!TryFindTarget()) // try to find a target again, and if there's not one, stop the method here
                    return;
            }
            projectile.rotation = projectile.velocity.ToRotation();
            // when there IS a target
            Vector2 distance = target.Center - projectile.Center; // this vector has a speed towards the target, which is needed for homing
            // but the further they are the bigger this vector is, so it's normalized for making sure the length is always 1 while still pointing to the target
            // once the vector is normalized it can be multiplied for getting a different length, while still keeping the direction or where it's pointing
            projectile.velocity = Vector2.SmoothStep(projectile.velocity, Vector2.Normalize(distance) * 12, 0.2f);
        }

        private bool IsValidTarget(NPC npc) => npc != null && npc.active && !npc.friendly && npc.CanBeChasedBy(); // CanBeChasedBy contains some things for what it says

        private bool TryFindTarget()
        {
            NPC npc;
            for(int i = 0; i < Main.npc.Length - 1; i++) // -1 because the last element is a target dummy or something
            {
                npc = Main.npc[i]; // current NPC
                if(IsValidTarget(npc))
                {
                    target = npc; // set the current target
                    return true; // success trying to find an NPC
                }
            }
            target = null;
            return false;
        }
    }
}
