using Terraria;
using Terraria.ModLoader;

namespace AshModAdditions.Buffs
{
    public class FrozenPotionBuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Ice Cold");
            Description.SetDefault("Ice debuff on enemies when hit with melee or ranged weapons");
            Main.debuff[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<AshModPlayer>().IceColdPotion = true;
        }
    }
}
