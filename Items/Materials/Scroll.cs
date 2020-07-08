using System;
using Terraria;
using Terraria.ModLoader;

namespace AshModAdditions.Items.Materials
{
    public class Scroll : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Scroll");
        }

        public override void SetDefaults()
        {
            item.material = true;
            item.maxStack = 999;
            item.width = 36;
            item.height = 36;
        }
    }
}
