using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Bosspocalyps.Items.Materials
{
    public class CombiniteBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 10));
            DisplayName.SetDefault("Combinite Bar");
        }

        public override void SetDefaults()
        {
            item.material = true;
            item.width = 30;
            item.height = 26;
            item.maxStack = 999;
            item.value = Item.sellPrice(gold: 1);
        }
    }
}
