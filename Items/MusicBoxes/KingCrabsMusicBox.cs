using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Tiles.MusicBoxes;

namespace AshModAdditions.Items.MusicBoxes
{
    public class KingCrabsMusicBox : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("King Crabs Music Box");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.createTile = ModContent.TileType<KingCrabsMusicBoxTile>();
            item.consumable = true;
            item.accessory = true;
        }
    }
}
