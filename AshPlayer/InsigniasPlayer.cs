using Terraria;
using Terraria.ModLoader;

namespace AshModAdditions
{
    public partial class AshModPlayer : ModPlayer
    {
        public bool PureInsignia, FrigidInsignia, OvergrownInsignia;
        private void InsigniaLifeRegen()
        {
            if (PureInsignia)
                player.lifeRegen += 3;

            if (FrigidInsignia)
                player.lifeRegen += 3;

            if (OvergrownInsignia)
                player.lifeRegen += 3;
        }

        private void InsigniaMeleeSpeedMultiplier(ref float speed)
        {
            if (PureInsignia)
                speed += 0.2f;

            if (FrigidInsignia)
                speed += 0.2f;

            if (OvergrownInsignia)
                speed += 0.2f;
        }

        private void InsigniaDamageReduction(ref int damage)
        {
            if (PureInsignia)
                damage = (int)(damage * 0.97);

            if (FrigidInsignia)
                damage = (int)(damage * 0.97);

            if (OvergrownInsignia)
                damage = (int)(damage * 0.97);
        }
    }
}
