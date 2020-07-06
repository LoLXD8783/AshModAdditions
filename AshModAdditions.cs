using Terraria.ModLoader;

namespace AshModAdditions
{
	public class AshModAdditions : Mod
	{
        internal static AshModAdditions instance; // this field is in case we need to access the mod instance for something, as example, UI or calling a mod instance functions, such as GetPacket
        
        public override void Load()
        {
            instance = this;
        }

        public override void Unload()
        {
            instance = null;
        }
    }
}