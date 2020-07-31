using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Generation;
using Terraria.World.Generation;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Microsoft.Xna.Framework;
using Bosspocalyps.Tiles;
using Bosspocalyps.Tiles.Ores;
using Bosspocalyps.Tiles.Warped;

namespace Bosspocalyps 
{
    public class AshWorld : ModWorld
    {
        public static int WarpedTiles;
        public static bool IridiumGen;

        private static bool generatedIridium;

        public override void TileCountsAvailable(int[] tileCounts)
        {
            WarpedTiles = tileCounts[ModContent.TileType<WarpedSoilTile>()];
        }

        public override void PreUpdate()
        {
            if (IridiumGen)
            {
                IridiumGen = false;
                if (!generatedIridium)
                {
                    generatedIridium = true;
                    GenerateOre(ModContent.TileType<IridiumOreTile>(), Main.maxTilesX * Main.maxTilesY / 10000, new Rectangle(0, Main.maxTilesY - 120, Main.maxTilesX, 120));
                }
            }
        }

        public override TagCompound Save()
        {
            List<string> boolflags = new List<string>();

            if (generatedIridium)
                boolflags.Add("IridiumGen");

            return new TagCompound
            {
                ["bools"] = boolflags
            };
        }

        public override void Load(TagCompound tag)
        {
            var boolflags = tag.GetList<string>("bools");

            generatedIridium = boolflags.Contains("IridiumGen");
        }

        public static void GenerateOre(int type, int ammount, Rectangle oreSpawnArea)
        {
            for(int i = 0; i < ammount; i++)
            {
                int oreX = Main.rand.Next(oreSpawnArea.X, oreSpawnArea.X + oreSpawnArea.Width);
                int oreY = Main.rand.Next(oreSpawnArea.Y, oreSpawnArea.Y + oreSpawnArea.Height);
                WorldGen.TileRunner(oreX, oreY, Main.rand.NextFloat(20), Main.rand.Next(4), type, false, Main.rand.NextFloat(4), Main.rand.NextFloat(4), false, true);
            }
        }

        //// Code by Starfish
        //public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        //{
        //    int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
        //    if (genIndex == -1)
        //    {
        //        return;
        //    }
        //    tasks.Insert(genIndex + 1, new PassLegacy("Warped Biome", delegate (GenerationProgress progress)
        //    {
        //        progress.Message = "Warped Biome Progress";
        //        for (int i = 0; i < Main.maxTilesX / 900; i++)       //900 is how many biomes. the bigger is the number = less biomes
        //        {
        //            int X = WorldGen.genRand.Next(1, Main.maxTilesX - 300);
        //            int Y = WorldGen.genRand.Next((int)WorldGen.rockLayer - 200, Main.maxTilesY - 200);
        //            int TileType = ModContent.TileType<WarpedSoilTile>(); // mod.TileType("CustomTileBlock");     //this is the tile u want to use for the biome , if u want to use a vanilla tile then its int TileType = 56; 56 is obsidian block
        //            WorldGen.TileRunner(X, Y, 350, WorldGen.genRand.Next(100, 200), TileType, false, 0f, 0f, true, true);  //350 is how big is the biome     100, 200 this changes how random it looks.
        //            progress.Set(1f / (Main.maxTilesX / 900) * i);
        //        }
        //    }));
        //}
    }
}