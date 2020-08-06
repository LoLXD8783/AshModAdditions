using Terraria;
using Terraria.ModLoader;
using Bosspocalyps.NPCs;

namespace Bosspocalyps.Buffs.Debuffs
{
    public class JellyfishedDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Jellyfished");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<BGlobalNPC>().JellyfishedDebuff = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<BosspocalypsModPlayer>().JellyfishedDebuff = true;
        }
    }
}
