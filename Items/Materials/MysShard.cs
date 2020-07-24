using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace AshModAdditions.Items.Materials
{
    public class MysShard : ModItem
    {
        public override void SetStaticDefaults()
        {
            //Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 10));
            DisplayName.SetDefault("Mysterious Crystal");
        }

        public override void SetDefaults()
        {
            item.material = true;
            item.width = 40;
            item.height = 56;
            item.maxStack = 999;
            item.value = Item.sellPrice(gold: 1);
        }
    }
}
