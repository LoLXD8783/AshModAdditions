using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AshModAdditions.Items.Weapons.Ranged
{
    public class StaticBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Static Bow");
            Tooltip.SetDefault("Tell Pyro what to put in here." +
                "Arrows cause Slow Debuff for 5 seconds");
        }

        public override void SetDefaults()
        {
            item.damage = 57;
            item.ranged = true;
            item.width = 20;
            item.height = 40;
            item.maxStack = 1;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = 5;
            item.knockBack = 1;
            item.value = 12000;
            item.rare = 2;
            item.UseSound = SoundID.Item5;
            item.noMelee = true;
            item.shoot = mod.ProjectileType("SlowingArrow");
            item.useAmmo = AmmoID.Arrow;
            item.shootSpeed = 10f;
            item.autoReuse = false;
        }
    }
}