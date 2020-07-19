using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Tiles.MusicBoxes;

namespace AshModAdditions.Items.MusicBoxes
{
    public class TheIceMusicBox : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Ice Music Box");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.createTile = ModContent.TileType<TheIceMusicBoxTile>();
            item.consumable = true;
            item.accessory = true;
        }
    }
}
