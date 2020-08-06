using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Bosspocalyps.Projectiles;

namespace Bosspocalyps.Buffs.Minions
{
    public class FrostiteSeekerBuff : Mbuff<FrostiteSeekerProjectile>
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Frostite Seeker");
            Description.SetDefault("The frositite seeker protects you");
            base.SetDefaults();
        }
    }
}
