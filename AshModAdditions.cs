using Terraria;
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
            AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Typhoon_Warning"), ModContent.ItemType<TyphoonMusicBox>(), ModContent.TileType<TyphoonMusicBoxTile>());
            AddMusicBox(GetSoundSlot(SoundType.Music, "Sounds/Music/Killography"), ModContent.ItemType<KilographyMusicBox>(), ModContent.TileType<KilographyMusicBoxTile>());
        }

        public override void Unload()
        {
            instance = null;
        }
    }
}