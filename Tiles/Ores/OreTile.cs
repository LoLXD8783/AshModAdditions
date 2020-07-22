using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AshModAdditions.Tiles.Ores
{
    public abstract class OreTile : ModTile
    {
        public abstract int ItemDropType { get; }
        public virtual string TileName => GetType().Name;
        public virtual Color TileMapColor => Color.Red;

        public override void SetDefaults()
        {
            TileID.Sets.Ore[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileSolid[Type] = true;

            ModTranslation name = CreateMapEntryName();
            name.SetDefault(TileName);
            AddMapEntry(TileMapColor, name);

            drop = ItemDropType;
        }
    }
}
