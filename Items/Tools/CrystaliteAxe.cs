using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AshModAdditions.Items.Tools
{
    class CrystaliteAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystalite Axe");
            Tooltip.SetDefault("it smells like pat");
        }

        public override void SetDefaults()
        {
            item.melee = true;
            item.autoReuse = true;
            item.axe = 40;
            item.damage = 67;
            item.crit = 14;
            item.width = 84;
            item.height = 62;
            item.useTime = 20;
            item.useAnimation = 20;
            item.knockBack = 4f;
            item.useStyle = ItemUseStyleID.SwingThrow;

            item.UseSound = SoundHelper.ItemSwing;
        }
    }
}
