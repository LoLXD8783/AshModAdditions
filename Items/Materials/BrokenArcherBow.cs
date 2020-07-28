using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AshModAdditions.Items.Materials
{
    public class BrokenArcherBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Broken Archer Bow");
        }

        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 36;
            item.material = true;
            item.maxStack = 99;
        }
    }
}
