using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Projectiles.Ammo;

namespace AshModAdditions.Items.Ammo
{
    public class MechaArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mecha Arrow");
        }

        public override void SetDefaults()
        {
            item.consumable = true;
            item.maxStack = 999;
            item.damage = 70;
            item.width = 14;
            item.height = 38;
            item.knockBack = 4f;
            item.crit = 4;
            item.shoot = ModContent.ProjectileType<MechaArrowProjectile>();
            item.ammo = AmmoID.Arrow;
        }
    }
}
