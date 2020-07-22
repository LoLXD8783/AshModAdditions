using System;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Items.Equippables;
using AshModAdditions.Items.Materials;
using AshModAdditions.Items.Weapons.Melee;
using AshModAdditions.Items.Weapons.Ranged;

namespace AshModAdditions.NPCs
{
    public class AshGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            switch (npc.type)
            {
                case NPCID.EyeofCthulhu:
                    if (Main.rand.NextBool(5)) // 20%
                        Item.NewItem(npc.getRect(), ModContent.ItemType<WindBreaker>());
                    break;

                case NPCID.EaterofWorldsHead:
                case NPCID.EaterofWorldsBody:
                case NPCID.EaterofWorldsTail:
                    break;

                case NPCID.Hellbat:
                    if (Main.rand.NextBool(50)) // 2%
                        Item.NewItem(npc.getRect(), ModContent.ItemType<Firewhacker>());
                    break;

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

                case NPCID.BrainofCthulhu:
                    if (Main.rand.Next(100) <= 12) // 12%
                        Item.NewItem(npc.getRect(), ModContent.ItemType<RoseSaber>());
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

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            switch (type)
            {
                case NPCID.Cyborg:
                    shop.item[nextSlot++].SetDefaults(ModContent.ItemType<RoseSaber>());
                    break;
            }
        }
    }
}
