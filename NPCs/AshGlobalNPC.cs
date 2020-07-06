using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Items.Materials;

namespace AshModAdditions.NPCs
{
    public class AshGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if(npc.type == NPCID.WallofFlesh)
            {
                Item.NewItem(npc.getRect(), ModContent.ItemType<CombiniteBar>(), Main.rand.Next(6, 10));
            }
        }
    }
}
