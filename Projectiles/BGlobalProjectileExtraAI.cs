using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Bosspocalyps.Projectiles
{
    public partial class BGlobalProjectile : GlobalProjectile
    {
        //private float extraAI;

        private void ExtraAI(Projectile projectile)
        {
            switch (extraaitype)
            {
                case ExtraAIType.None:
                    break;
                case ExtraAIType.TerrarianBlade:
                    TerrarianBladeProjExtraAI(projectile);
                    break;
                case ExtraAIType.TrueTerrarianBlade:
                    TrueTerrarianBladeExtraAI(projectile);
                    break;
                case ExtraAIType.TrueTerrarianBladeChildren:
                    TrueTerrarianBladeChildren(projectile);
                    break;
                case ExtraAIType.TrueTerrarianBladeTEProj:
                    TrueTerrarianBladeTEProj(projectile);
                    break;
            }
        }

        // ----------

        private void TerrarianBladeProjExtraAI(Projectile projectile)
        {
            Homing(projectile, 10, 20);
        }

        // ----------

        private void TrueTerrarianBladeExtraAI(Projectile projectile)
        {
            if(++projectile.ai[1] > 20)
            {
                int p = Projectile.NewProjectile(projectile.Center, -projectile.velocity * 0.9f, ProjectileID.NightBeam, projectile.damage / 4, projectile.knockBack, projectile.owner);
                Main.projectile[p].timeLeft = 60;
                projectile.ai[1] = 0;
            }
        }

        private void TrueTerrarianBladeOnHit(Projectile projectile)
        {
            Vector2 pcenter = projectile.Center;
            Vector2 v = projectile.velocity * 0.9f;
            for(int i = 0; i < 5; i++)
            {
                int p = Projectile.NewProjectile(pcenter, v.RotatedByRandom(MathHelper.TwoPi * 100), projectile.type, 40, projectile.knockBack, projectile.owner);
                Projectile proj = Main.projectile[p];
                proj.scale -= 0.4f;
                proj.penetrate = 1;
                proj.timeLeft = 90;
                proj.GetGlobalProjectile<BGlobalProjectile>().extraaitype = ExtraAIType.TrueTerrarianBladeChildren;
            }
            projectile.Kill();
        }

        // ---------

        private void TrueTerrarianBladeChildren(Projectile projectile)
        {
            Homing(projectile, 16, 20, 0.3f);
        }

        // ---------

        private void TrueTerrarianBladeTEProj(Projectile projectile)
        {
            Player owner = Main.player[projectile.owner];
            var modplayer = owner.GetModPlayer<BosspocalypsModPlayer>();
            int count = modplayer.SurroundingTEProjs.Count;
            float rot = modplayer.TTBTEPCRotation;

            float rot2 = ((MathHelper.TwoPi / count) * projectile.ai[0]) + rot;

            projectile.Center = owner.MountedCenter + new Vector2(160, 0).RotatedBy(rot2);
            projectile.rotation = rot2 + MathHelper.PiOver4 + MathHelper.PiOver2;
        }


        private void Homing(Projectile projectile, float speed, float range, float t = 0.2f)
        {
            if (projectile.ai[0] > 0)
            {
                NPC target = Main.npc[(int)projectile.ai[0] - 1];
                if (target.active && !target.friendly)
                {
                    projectile.velocity = Vector2.SmoothStep(projectile.velocity, Vector2.Normalize(target.Center - projectile.Center) * speed, t);
                    return;
                }
            }
            projectile.ai[0] = Helpers.ClosestHostileNPCTo(projectile.Center, range * 16);
        }
    }

    enum ExtraAIType : byte
    {
        None,
        TerrarianBlade,
        TrueTerrarianBlade,
        TrueTerrarianBladeChildren,
        TrueTerrarianBladeTEProj
    }
}
