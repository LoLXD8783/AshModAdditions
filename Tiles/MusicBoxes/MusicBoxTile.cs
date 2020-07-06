using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ObjectData;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace AshModAdditions.Tiles.MusicBoxes
{
    public abstract class MusicBoxTile : ModTile
    {
        public virtual string MusicBoxName => GetType().Name;
        public abstract int ItemType { get; }
        public virtual TileObjectData TileObjectdata => TileObjectData.Style2x2;

        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileObsidianKill[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectdata);
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.DrawYOffset = 2; // 2
            TileObjectData.addTile(Type);
            disableSmartCursor = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault(MusicBoxName);
            AddMapEntry(new Color(200, 200, 200), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(i * 16, j * 16, 16, 48, ItemType);
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.showItemIcon = true;
            player.showItemIcon2 = ItemType;
        }
    }
}
