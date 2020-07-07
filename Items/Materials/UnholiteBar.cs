using System;
using Terraria;
using Terraria.ModLoader;

namespace AshModAdditions.Items.Materials
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
            item.maxStack = 999;
            item.width = 60;
            item.height = 48;
        }
    }
}
