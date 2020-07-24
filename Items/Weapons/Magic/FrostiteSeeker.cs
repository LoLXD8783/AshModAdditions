using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Projectiles;

namespace AshModAdditions.Items.Weapons.Magic
{
    public class FrostiteSeeker : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frostite Seeker");
        }

        public override void SetDefaults()
        {
            item.magic = true;
            item.mana = 20 / 3;
            item.width = 28;
            item.height = 32;
            item.damage = 29;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.shoot = ModContent.ProjectileType<FrostiteSeekerProjectile>();
            item.shootSpeed = 10;
        }
    }
}
