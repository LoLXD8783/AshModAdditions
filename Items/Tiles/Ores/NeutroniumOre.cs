using Terraria;
using Terraria.ModLoader;
using Bosspocalyps.Tiles.Ores;

namespace Bosspocalyps.Items.Tiles.Ores
{
    public class NeutroniumOre : OreItem
    {
        public override int TileType => ModContent.TileType<NeutroniumOreTile>();

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Neutronium Ore");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.width = 24;
            item.height = 36;
        }
    }
}
