using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Tiles.MusicBoxes;

namespace AshModAdditions.Items.MusicBoxes
{
    public class TyphoonMusicBox : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Typhoon Music Box");
        }

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 22;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.createTile = ModContent.TileType<TyphoonMusicBoxTile>();
            item.consumable = true;
            item.accessory = true;
        }
    }
}
