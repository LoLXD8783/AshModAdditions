using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Projectiles;

namespace AshModAdditions.Items.Weapons.Melee
{
    public class FrostiteSpear : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("FrostiteSpear");
        }

        public override void SetDefaults()
        {
            item.melee = true;
            item.noMelee = true;
            item.noUseGraphic = true;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<FrostiteSpearProjectile>();
            item.shootSpeed = 4;
            item.useTime = 40;
            item.useAnimation = 40;
            item.width = 90;
            item.height = 90;
            item.damage = 10;
            item.knockBack = 10;
            item.useStyle = ItemUseStyleID.HoldingOut;
        }

        public override bool CanUseItem(Player player) => player.ownedProjectileCounts[item.shoot] < 1;

        public override void AddRecipes()
        {

        }
    }
}
