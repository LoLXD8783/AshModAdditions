using Terraria;
using Terraria.ModLoader;

namespace Bosspocalyps.Items.Materials
{
    public class BinariteBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Binarite Bar");
        }

        public override void SetDefaults()
        {
            item.material = true;
            item.width = 30;
            item.height = 24;
            item.maxStack = 999;
            item.value = Item.sellPrice(gold: 1);
        }
    }
}
