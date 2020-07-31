using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bosspocalyps.Items.Weapons.Melee
{
    public class Firewhacker : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Firewacker");
        }

        public override void SetDefaults()
        {
            item.damage = 12;
            item.width = 50;
            item.height = 38;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item18;
        }
    }
}
