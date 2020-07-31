using Terraria;
using Terraria.ModLoader;

namespace Bosspocalyps.Items.Materials
{
    public class BrokenMageStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Broken Mage Staff");
        }

        public override void SetDefaults()
        {
            item.material = true;
            item.width = 40;
            item.height = 38;
            item.maxStack = 99;
        }
    }
}
