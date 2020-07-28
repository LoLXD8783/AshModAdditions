using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AshModAdditions.Items.Weapons.Melee
{
    public class FrozenHeroBlade : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frozen Hero Blade");
        }

        public override void SetDefaults()
        {
            item.damage = 100;
            item.knockBack = 3;
            item.crit = 9;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.UseSound = SoundHelper.ItemSwing;
        }
    }
}
