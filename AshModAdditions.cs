using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Items.MusicBoxes;
using AshModAdditions.Tiles.MusicBoxes;

namespace AshModAdditions
{
	public class AshModAdditions : Mod
	{
        internal static AshModAdditions instance; // this field is in case we need to access the mod instance for something, as example, UI or calling a mod instance functions, such as GetPacket

        public override void Load()
        {
            instance = this;
            if (Main.dedServ) return; // below things that shouldn't load on servers
            AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Pretty_Gamer_Boss"), ModContent.ItemType<SkeletronMusicBox>(), ModContent.TileType<SkeletronMusicBoxTile>());
            AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Wall_Of_Flesh_Theme_-_Ashmod"), ModContent.ItemType<WallOfFleshMusicBox>(), ModContent.TileType<WallOfFleshMusicBoxTile>());
            AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Destroyer_Theme_-_"), ModContent.ItemType<TheDestroyerMusicBox>(), ModContent.TileType<TheDestroyerMusicBoxTile>());
            AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Skeletron_Prime_Is_American"), ModContent.ItemType<SkeletronPrimeMusicBox>(), ModContent.TileType<SkeletronPrimeMusicBoxTile>());
            AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Typhoon_Warning"), ModContent.ItemType<TyphoonMusicBox>(), ModContent.TileType<TyphoonMusicBoxTile>());
            AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Killography"), ModContent.ItemType<KilographyMusicBox>(), ModContent.TileType<KilographyMusicBoxTile>());
        }

        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            if (Main.gameMenu) return;

            if (NPC.AnyNPCs(NPCID.SkeletronHead))
            {
                music = GetMusicSoundSlot("Pretty_Gamer_Boss");
                priority = MusicPriority.BossLow;
            }

            if (NPC.AnyNPCs(NPCID.WallofFlesh))
            {
                music = GetMusicSoundSlot("Wall_Of_Flesh_Theme_-_Ashmod");
                priority = MusicPriority.BossLow;
            }

            if (NPC.AnyNPCs(NPCID.TheDestroyer))
            {
                music = GetMusicSoundSlot("Destroyer_Theme_-_");
                priority = MusicPriority.BossLow;
            }

            if (NPC.AnyNPCs(NPCID.SkeletronPrime))
            {
                music = GetMusicSoundSlot("Skeletron_Prime_Is_American");
                priority = MusicPriority.BossLow;
            }
        }

        private int GetMusicSoundSlot(string name) => GetSoundSlot(SoundType.Music, "Sounds/Music/" + name);

        public override void Unload()
        {
            instance = null;
        }
    }
}