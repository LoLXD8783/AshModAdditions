using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Tiles.MusicBoxes;

namespace AshModAdditions.Items.MusicBoxes
{
    public class TheDestroyerMusicBox : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("The Destroyer Music Box");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 26;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.createTile = ModContent.TileType<TheDestroyerMusicBoxTile>();
            item.consumable = true;
            item.accessory = true;
            item.width = 30;
            item.height = 20;
        }
    }
}
