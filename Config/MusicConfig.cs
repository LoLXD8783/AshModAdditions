using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Microsoft.Xna.Framework;

namespace AshModAdditions.Config
{
    public class MusicConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Label("Change NightTime Hallow music")]
        [DefaultValue(true)]
        public bool HallowNightMusic;

        [Label("Change King Slime theme")]
        [DefaultValue(true)]
        public bool KingSlimeTheme;

        [Label("Change Eater of Worlds theme")]
        [DefaultValue(true)]
        public bool EaterOfWorldsTheme;

        [Label("Change Skeletron theme")]
        [DefaultValue(true)]
        public bool SkeletronTheme;

        [Label("Change Wall of Flesh theme")]
        [DefaultValue(true)]
        public bool WallOfFleshTheme;

        [Label("Change Destroyer theme")]
        [DefaultValue(true)]
        public bool DestroyerTheme;

        [Label("Change Skeletron Prime theme")]
        [DefaultValue(true)]
        public bool SkeletronPrimeTheme;

        [Label("Change Duke Fishron theme")]
        [DefaultValue(true)]
        public bool DukeFishronTheme;

        [Label("Change Lunatic Cultist theme")]
        [DefaultValue(true)]
        public bool LunaticCultistTheme;
    }
}
