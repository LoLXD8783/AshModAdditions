using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Bosspocalyps.Buffs
{
    public abstract class SandStormSpirit : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Sandstorm Spirit");
            Description.SetDefault("You have the sandstorm spirit");
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<AshModPlayer>().SandstormSpiritBuff = true;
        }
    }
}
