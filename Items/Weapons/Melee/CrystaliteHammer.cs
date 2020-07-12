using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Items.Materials;

namespace AshModAdditions.Items.Weapons.Melee
{
    public class CrystaliteHammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystalite Hammer");
        }

        public override void SetDefaults()
        {
            item.autoReuse = true;
            item.melee = true;
            item.damage = 46;
            item.width = 92;
            item.height = 92;
            item.useAnimation = 30;
            item.useTime = 30;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.crit = 19;
            item.knockBack = 9;
            item.hammer = 200;

            item.UseSound = SoundID.Item18;
        }

        public override void AddRecipes()
        {

        }
    }
}
