using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AshModAdditions.Items.Weapons.Melee
{
    public class GreenSwipe : ModItem // TODO: Missing projectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Green Swipe");
        }

        public override void SetDefaults()
        {
            item.damage = 90;
            item.melee = true;
            item.width = 42;
            item.height = 42;
            item.useTime = 7;
            item.useAnimation = 25;
            item.channel = true;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.useStyle = 5;
            item.knockBack = 6;
            item.value = Item.buyPrice(0, 22, 50, 0);
            item.rare = 9;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.shoot = 595;
            item.shootSpeed = 40f;

        }
    }
}
