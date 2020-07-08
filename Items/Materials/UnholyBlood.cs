using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using AshModAdditions.Projectiles;

namespace AshModAdditions.Items.Materials
{
    public class UnholyBlood : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Unholy Blood");
        }

        public override void SetDefaults()
        {
            item.material = true;
            item.consumable = true;
            item.maxStack = 999;
            item.shoot = ModContent.ProjectileType<BloodFirePellet>();
            item.shootSpeed = 8;
        }
    }
}
