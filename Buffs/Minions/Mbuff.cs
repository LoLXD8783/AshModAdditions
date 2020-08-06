using System;
using Terraria;
using Terraria.ModLoader;

namespace Bosspocalyps.Buffs.Minions
{
    public abstract class Mbuff<T> : ModBuff where T : ModProjectile
    {
        public override void SetDefaults()
        {
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            if(player.ownedProjectileCounts[ModContent.ProjectileType<T>()] > 0)
            {
                player.buffTime[buffIndex] = 18000;
            }
            else
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
        }
    }
}
