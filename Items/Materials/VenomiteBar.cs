using System;
using Terraria;
using Terraria.ModLoader;

namespace Bosspocalyps.Items.Materials
{
    public class VenomiteBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Venomite Bar");
        }

        public override void SetDefaults()
        {
            item.material = true;
            item.maxStack = 99;
            item.width = 30;
            item.height = 24;
        }
    }
}
