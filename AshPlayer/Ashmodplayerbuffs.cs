using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AshModAdditions
{
    public partial class AshModPlayer
    {
        public bool IceColdPotion, SandstormSpiritBuff;
        public bool VirusDebuff, JellyfishedDebuff;

        public override void UpdateBadLifeRegen()
        {
            if (VirusDebuff)
            {
                player.lifeRegen -= 20 * 2;
            }

            if (JellyfishedDebuff)
            {
                if (player.velocity.X != 0)
                    player.lifeRegen -= 30 * 2;
                else
                    player.lifeRegen -= 10 * 2;
            }
        }

        private void ResetBuffs() => IceColdPotion = SandstormSpiritBuff = VirusDebuff = JellyfishedDebuff = false;
    }
}
