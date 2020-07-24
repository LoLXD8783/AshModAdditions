using System;
using System.Reflection;
using System.Linq;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AshModAdditions.Config;
using AshModAdditions.Items.MusicBoxes;
using AshModAdditions.Tiles.MusicBoxes;
using AshModAdditions.Tiles.Warped;

namespace AshModAdditions
{
    public class AshModAdditions : Mod
    {
        internal static AshModAdditions instance; // this field is in case we need to access the mod instance for something, as example, UI or calling a mod instance functions, such as GetPacket

        public override void Load()
        {
            instance = this;
            if (Main.dedServ) return; // below things that shouldn't load on servers
            AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Crown_of_the_Crustacean_King_-_Atlantis_Mod"), ModContent.ItemType<KingCrabsMusicBox>(), ModContent.TileType<KingCrabsMusicBoxTile>());
            AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Crossout"), ModContent.ItemType<GigawormMusicBox>(), ModContent.TileType<GigawormMusicBoxTile>());
            AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/The_Ice_Theme"), ModContent.ItemType<TheIceMusicBox>(), ModContent.TileType<TheIceMusicBoxTile>());
            AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/CoolSongThatsChillAF_2"), ModContent.ItemType<OceanNightMusicBox>(), ModContent.TileType<OceanNightMusicBoxTile>());
            AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Spookyboiss_1"), ModContent.ItemType<KingSlimeMusicBox>(), ModContent.TileType<KingSlimeMusicBoxTile>());
            AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Eater_Of_Worlds_Theme"), ModContent.ItemType<EaterOfWorldsMusicBox>(), ModContent.TileType<EaterOfWorldsMusicBoxTile>());
            AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Hallow_Night_-_Ashmod_Theme"), ModContent.ItemType<HallowNightMusicBox>(), ModContent.TileType<HallowNightMusicBoxTile>());
            AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Duke_Fishpog_Theme"), ModContent.ItemType<DukeFishronMusicBox>(), ModContent.TileType<DukeFishronMusicBoxTile>());
            AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Lunatic-Cultist-Theme-Burden-of"), ModContent.ItemType<LunaticCultistMusicBox>(), ModContent.TileType<LunaticCultistMusicBoxTile>());
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

            var config = ModContent.GetInstance<MusicConfig>();

            var modp = Main.LocalPlayer.GetModPlayer<AshModPlayer>();
            if (modp.ZoneWarpedBiome)
            {
                music = GetMusicSoundSlot("warped_biom_theme");
                priority = MusicPriority.BiomeLow;
            }

            if (config.OceanNightMusic && !Main.dayTime && Main.LocalPlayer.ZoneBeach)
            {
                music = GetMusicSoundSlot("CoolSongThatsChillAF_2");
                priority = MusicPriority.BiomeLow;
            }

            if (config.HallowNightMusic && !Main.dayTime && Main.LocalPlayer.ZoneHoly)
            {
                music = GetMusicSoundSlot("Hallow_Night_-_Ashmod_Theme");
                priority = MusicPriority.BiomeLow;
            }

            // TODO maybe turn this into a loop and set flags on it?
            if (config.KingSlimeTheme && NPC.AnyNPCs(NPCID.KingSlime))
            {
                music = GetMusicSoundSlot("Spookyboiss_1");
                priority = MusicPriority.BossLow;
            }

            if (config.EaterOfWorldsTheme && NPC.AnyNPCs(NPCID.EaterofWorldsHead))
            {
                music = GetMusicSoundSlot("Eater_Of_Worlds_Theme");
                priority = MusicPriority.BossLow;
            }

            if (config.SkeletronTheme && NPC.AnyNPCs(NPCID.SkeletronHead))
            {
                music = GetMusicSoundSlot("Pretty_Gamer_Boss");
                priority = MusicPriority.BossLow;
            }

            if (config.WallOfFleshTheme && NPC.AnyNPCs(NPCID.WallofFlesh))
            {
                music = GetMusicSoundSlot("Wall_Of_Flesh_Theme_-_Ashmod");
                priority = MusicPriority.BossLow;
            }

            if (config.DestroyerTheme && NPC.AnyNPCs(NPCID.TheDestroyer))
            {
                music = GetMusicSoundSlot("Destroyer_Theme_-_");
                priority = MusicPriority.BossLow;
            }

            if (config.SkeletronPrimeTheme && NPC.AnyNPCs(NPCID.SkeletronPrime))
            {
                music = GetMusicSoundSlot("Skeletron_Prime_Is_American");
                priority = MusicPriority.BossLow;
            }

            if (config.DukeFishronTheme && NPC.AnyNPCs(NPCID.DukeFishron))
            {
                music = GetMusicSoundSlot("Duke_Fishpog_Theme");
                priority = MusicPriority.BossLow;
            }

            if (config.LunaticCultistTheme && NPC.AnyNPCs(NPCID.CultistBoss))
            {
                music = GetMusicSoundSlot("Lunatic-Cultist-Theme-Burden-of");
                priority = MusicPriority.BossLow;
            }
        }

        internal int GetMusicSoundSlot(string name) => GetSoundSlot(SoundType.Music, "Sounds/Music/" + name);

        public override void Unload()
        {
            UnloadFields(Code ?? GetType().Assembly);
            instance = null;
        }

        private static void UnloadFields(Assembly assembly)
        {
            foreach (var type in GetTypesSafe(assembly))
                foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static))
                {
                    if (field.IsInitOnly || field.IsLiteral)
                        continue;

                    Type fieldtype = field.FieldType;

                    if (fieldtype.IsValueType && Nullable.GetUnderlyingType(fieldtype) == null)
                        continue;

                    field.SetValue(null, null);
                }
        }

        private static Type[] GetTypesSafe(Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types;
            }
        }
    }
}