using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Generation;
using Terraria.World.Generation;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace AshModAdditions // Code by Starfish
{
    public class ModNameWorld : ModWorld
    {

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (genIndex == -1)
            {
                return;
            }
            tasks.Insert(genIndex + 1, new PassLegacy("Custom Biome", delegate (GenerationProgress progress)
            {
                progress.Message = "Custom Biome Progress";
                for (int i = 0; i < Main.maxTilesX / 900; i++)       //900 is how many biomes. the bigger is the number = less biomes
                {
                    int X = WorldGen.genRand.Next(1, Main.maxTilesX - 300);
                    int Y = WorldGen.genRand.Next((int)WorldGen.rockLayer - 200, Main.maxTilesY - 200);
                    int TileType = TileID.Stone; // mod.TileType("CustomTileBlock");     //this is the tile u want to use for the biome , if u want to use a vanilla tile then its int TileType = 56; 56 is obsidian block
                    WorldGen.TileRunner(X, Y, 350, WorldGen.genRand.Next(100, 200), TileType, false, 0f, 0f, true, true);  //350 is how big is the biome     100, 200 this changes how random it looks.
                }
            }));
        }
    }
}