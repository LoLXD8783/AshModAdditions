using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AshModAdditions.Items.Weapons.Melee
{
    public class RoseSaber : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rose Saber");
        }

        public override void SetDefaults()
        {
            item.melee = true;
            item.width = 48;
            item.height = 48;
            item.damage = 29;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item18;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            target.AddBuff(BuffID.Confused, 60);
        }
    }
}
