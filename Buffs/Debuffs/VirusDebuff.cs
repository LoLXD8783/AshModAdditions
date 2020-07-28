using Terraria;
using Terraria.ModLoader;
using AshModAdditions.NPCs;

namespace AshModAdditions.Buffs.Debuffs
{
    public class VirusDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Virus");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<AshGlobalNPC>().VirusDebuff = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<AshModPlayer>().VirusDebuff = true;
        }
    }
}
