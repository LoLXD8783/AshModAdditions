using Terraria;
using Terraria.ModLoader;

namespace AshModAdditions.Items.Materials
{
    public class TerraShard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terra Shard");
        }

        public override void SetDefaults()
        {
            item.material = true;
            item.width = 22;
            item.height = 22;
            item.maxStack = 99;
        }
    }
}
