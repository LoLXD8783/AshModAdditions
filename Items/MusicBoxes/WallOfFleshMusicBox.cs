using Terraria.ID;
using Terraria.ModLoader;
using Bosspocalyps.Tiles.MusicBoxes;

namespace Bosspocalyps.Items.MusicBoxes
{
    public class WallOfFleshMusicBox : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Wall Of Flesh Music Box");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.createTile = ModContent.TileType<WallOfFleshMusicBoxTile>();
            item.consumable = true;
            item.accessory = true;
            item.width = 30;
            item.height = 20;
        }
    }
}
