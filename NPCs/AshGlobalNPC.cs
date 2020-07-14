using System;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Items.Equippables;
using AshModAdditions.Items.Materials;

namespace AshModAdditions.NPCs
{
    public class AshGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            switch (npc.type)
            {
                case NPCID.UndeadMiner:
                    if (Main.rand.NextBool(50)) // 2% (100 / 2 == 50 / 1)
                        Item.NewItem(npc.getRect(), ModContent.ItemType<SafetyGlove>());
                    break;

                case NPCID.Mummy:
                case NPCID.DarkMummy:
                case NPCID.LightMummy:
                    if(Main.rand.NextBool(5)) // 20% or 1/5
                        Item.NewItem(npc.getRect(), ModContent.ItemType<Scroll>());
                    break;

                case NPCID.BloodZombie:
                case NPCID.Drippler:
                case NPCID.TheGroom:
                case NPCID.TheBride:
                    if (Main.hardMode)
                        Item.NewItem(npc.getRect(), ModContent.ItemType<UnholyBlood>(), Main.rand.Next(5, 11));
                    break;

                case NPCID.WallofFlesh:
                        Item.NewItem(npc.getRect(), ModContent.ItemType<CombiniteBar>(), Main.rand.Next(6, 11));
                    break;

                case NPCID.Retinazer:
                case NPCID.Spazmatism:
                    Item.NewItem(npc.getRect(), ModContent.ItemType<UnholiteBar>(), Main.rand.Next(5, 8));
                    break;
            }
        }
    }
}
