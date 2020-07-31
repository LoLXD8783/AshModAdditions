using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Bosspocalyps.Tiles.Warped;

namespace Bosspocalyps.Items.Tiles.Warped
{
    public class WarpedSoil : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Warped Soil");
        }

        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.useTime = 10;
            item.useAnimation = 10;
            item.maxStack = 999;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.createTile = ModContent.TileType<WarpedSoilTile>();
            item.autoReuse = true;
            item.consumable = true;
        }
    }
}
