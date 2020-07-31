using System;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ObjectData;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Bosspocalyps.Items.Tiles;

namespace Bosspocalyps.Tiles
{
    public class UnholyResearchStationTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;

            //TileID.Sets.HasOutlines[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.newTile.Origin = new Point16(1, 1);
            TileObjectData.addTile(Type);


            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Unholy Research Station");
            AddMapEntry(Color.Purple, name);
            disableSmartCursor = true;
            adjTiles = new int[] { TileID.Furnaces };
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 32, 48, ModContent.ItemType<UnholyResearchStation>());
        }
    }
}
