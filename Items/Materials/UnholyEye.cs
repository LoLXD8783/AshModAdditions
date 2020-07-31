using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Bosspocalyps.Items.Materials
{
    class UnholyEye : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Unholy Eye");
        }

        public override void SetDefaults()
        {
            item.material = true;
            item.maxStack = 999;
            item.width = 42;
            item.height = 26;
        }
    }
}
