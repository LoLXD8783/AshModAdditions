using Terraria;
using Terraria.ModLoader;
using Bosspocalyps.Projectiles;

namespace Bosspocalyps.Buffs.Minions
{
    class IceCrystalBuff : Mbuff<IceCrystalStaffProjectile>
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Ice Crystal");
            Description.SetDefault("Cold and heartless, how i like my coffee");
            base.SetDefaults();
        }
    }
}
