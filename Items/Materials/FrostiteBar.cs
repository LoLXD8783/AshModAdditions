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

namespace AshModAdditions.Items.Materials
{
    public class FrostiteBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frostite Bar");
        }

        public override void SetDefaults()
        {
            item.material = true;
            item.width = 30;
            item.height = 24;
            item.maxStack = 99;
        }
    }
}
