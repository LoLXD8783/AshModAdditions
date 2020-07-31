using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Bosspocalyps.Tiles;

namespace Bosspocalyps.Items.Tiles
{
    class LuminiteAnvil : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Luminite Anvil");
        }

        public override void SetDefaults()
        {
            item.useTime = 10;
            item.useAnimation = 10;
            item.width = 48;
            item.height = 34;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.createTile = ModContent.TileType<LuminiteAnvilTile>();
            item.consumable = true;
        }
    }
}
