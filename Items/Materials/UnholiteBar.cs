using System;
using Terraria;
using Terraria.ModLoader;

namespace Bosspocalyps.Items.Materials
{
    public class UnholiteBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Unholite Bar");
        }

        public override void SetDefaults()
        {
            item.material = true;
            item.maxStack = 99;
            item.width = 60;
            item.height = 48;
        }
    }
}
