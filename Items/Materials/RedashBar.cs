using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace AshModAdditions.Items.Materials
{
    public class RedashBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(10, 17));
            DisplayName.SetDefault("Radash Bar");
        }

        public override void SetDefaults()
        {
            item.material = true;
            item.width = 54;
            item.height = 43;
            item.maxStack = 999;
        }
    }
}
