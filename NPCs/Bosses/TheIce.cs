using System;
using System.ComponentModel;
using System.Diagnostics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AshModAdditions.NPCs.Bosses
{
	public class TheIce : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("The Ice");
			Main.npcFrameCount[npc.type] = 4;

		}

		public override void SetDefaults()
		{
			npc.width = 80;
			npc.height = 80;
			npc.damage = 25;
			npc.defense = 5;
			npc.lifeMax = 3200;
			npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = SoundID.NPCDeath1;
			npc.value = 60f;
			npc.knockBackResist = 0f;
			npc.aiStyle = 22;
			aiType = NPCID.IceElemental;
			animationType = NPCID.IceElemental;

		}

		public override void NPCLoot()
		{
			Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Item"));
		}
	}
}
