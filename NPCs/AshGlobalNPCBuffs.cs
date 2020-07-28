using Terraria;
using Terraria.ModLoader;

namespace AshModAdditions.NPCs
{
    public partial class AshGlobalNPC : GlobalNPC
    {
        public bool VirusDebuff, JellyfishedDebuff;

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (VirusDebuff)
            {
                npc.lifeRegen -= 20 * 2;
            }
            if (JellyfishedDebuff)
            {
                if (npc.velocity.X != 0)
                    npc.lifeRegen -= 30 * 2;
                else
                    npc.lifeRegen -= 10 * 2;
            }
        }

        private void ResetDebuffs() => VirusDebuff = false;
    }
}
