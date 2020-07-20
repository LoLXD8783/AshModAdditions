using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AshModAdditions.Items.Weapons.Melee
{
    public class KingsMace : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Kings Mace");
        }

        public override void SetDefaults()
        {
            item.damage = 15;
            item.scale = 2f;
            item.width = 50;
            item.height = 50;
            item.useTime = 40;
            item.useAnimation = 40;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item18;
        }
    }
}
