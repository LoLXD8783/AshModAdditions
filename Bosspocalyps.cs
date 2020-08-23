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
using Bosspocalyps.Config;
using Bosspocalyps.Items.MusicBoxes;
using Bosspocalyps.Tiles.MusicBoxes;
using Bosspocalyps.Tiles.Warped;

namespace Bosspocalyps
{
    public class Bosspocalyps : Mod
    {
        internal static Bosspocalyps instance; // this field is in case we need to access the mod instance for something, as example, UI or calling a mod instance functions, such as GetPacket

        public override void Load()
        {
            instance = this;
            if (Main.dedServ) return; // below things that shouldn't load on servers
            AddMusicBox<KingCrabsMusicBox, KingCrabsMusicBoxTile>("Crown_of_the_Crustacean_King_-_Atlantis_Mod");
            AddMusicBox<GigawormMusicBox, GigawormMusicBoxTile>("Crossout");
            AddMusicBox<TheIceMusicBox, TheIceMusicBoxTile>("The_Ice_Theme");
            AddMusicBox<OceanNightMusicBox, OceanNightMusicBoxTile>("CoolSongThatsChillAF_2");
            AddMusicBox<KingSlimeMusicBox, KingSlimeMusicBoxTile>("Spookyboiss_1");
            AddMusicBox<EaterOfWorldsMusicBox, EaterOfWorldsMusicBoxTile>("Eater_Of_Worlds_Theme");
            AddMusicBox<HallowNightMusicBox, HallowNightMusicBoxTile>("Hallow_Night_-_Ashmod_Theme");
            AddMusicBox<DukeFishronMusicBox, DukeFishronMusicBoxTile>("Duke_Fishpog_Theme");
            AddMusicBox<LunaticCultistMusicBox, LunaticCultistMusicBoxTile>("Lunatic-Cultist-Theme-Burden-of");
            AddMusicBox<SkeletronMusicBox, SkeletronMusicBoxTile>("Pretty_Gamer_Boss");
            AddMusicBox<WallOfFleshMusicBox, WallOfFleshMusicBoxTile>("Wall_Of_Flesh_Theme_-_Ashmod");
            AddMusicBox<TheDestroyerMusicBox, TheDestroyerMusicBoxTile>("Destroyer_Theme_-_");
            AddMusicBox<SkeletronPrimeMusicBox, SkeletronPrimeMusicBoxTile>("Skeletron_Prime_Is_American");
            AddMusicBox<TyphoonMusicBox, TyphoonMusicBoxTile>("Typhoon_Warning");
            AddMusicBox<KilographyMusicBox, KilographyMusicBoxTile>("Killography");
        }

        private void AddMusicBox<TItem, TTile>(string moosic, int tileFrameY = 0) where TItem : ModItem where TTile : ModTile => AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/" + moosic), ModContent.ItemType<TItem>(), ModContent.TileType<TTile>(), tileFrameY);

        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {
            if (Main.gameMenu) return;

            var config = ModContent.GetInstance<MusicConfig>();

            var modp = Main.LocalPlayer.GetModPlayer<BosspocalypsModPlayer>();
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

            if(NPC.MoonLordCountdown > 120)
            {
                music = GetMusicSoundSlot("The_Servant_Summons_1");
                priority = MusicPriority.BossMedium;
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
            try
            {
                UnloadFields(Code ?? GetType().Assembly);
            }
            catch(Exception) { }
            instance = null;
        }

        private static void UnloadFields(Assembly assembly)
        {
            foreach (var type in GetTypesSafe(assembly))
            {
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