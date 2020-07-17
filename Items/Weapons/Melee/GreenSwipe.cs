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
            item.melee = true;
            item.useTime = 15;
            item.useAnimation = 15;
            item.width = 42;
            item.height = 42;
            item.damage = 90;
            item.knockBack = 4f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item18;
            item.value = Item.buyPrice(gold: 30);
        }
    }
}
