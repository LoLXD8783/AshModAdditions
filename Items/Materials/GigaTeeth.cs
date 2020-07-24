using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AshModAdditions.Items.Materials
{
    public class GigaTeeth : ModItem
    {
        public override string Texture => Helpers.PLACEHOLDER;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Giga Teeth");
        }

        public override void SetDefaults()
        {
            item.material = true;
            item.maxStack = 99;
        }
    }
}
