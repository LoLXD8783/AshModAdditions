using System;
using Terraria;
using Terraria.ModLoader;

namespace Bosspocalyps.Items.Materials
{
    public class HeroFrags : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hero Fragment");
            Tooltip.SetDefault("Tell Pyro what to put in here");
        }

        public override void SetDefaults()
        {
            item.material = true;
            item.width = 34;
            item.height = 38;
            item.maxStack = 99;
            item.value = Item.sellPrice(gold: 1);
            item.rare = 6;
        }
    }
}