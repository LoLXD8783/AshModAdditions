using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bosspocalyps.Items.Weapons.Ranged
{
    public class WindBreaker : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wind Breaker");
        }

        public override void SetDefaults()
        {
            item.ranged = true;
            item.noMelee = true;
            item.width = 42;
            item.height = 28;
            item.damage = 76;
            item.knockBack = 10;
            item.useTime = 20;
            item.useAnimation = 20;
            item.shoot = 10;
            item.shootSpeed = 10;
            item.useAmmo = AmmoID.Bullet;
            item.useStyle = ItemUseStyleID.HoldingOut;
            //item.UseSound = SoundID.Item98;
        }
    }
}
