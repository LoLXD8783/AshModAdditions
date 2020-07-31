using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Bosspocalyps
{
    public static class SoundHelper
    {
        public static LegacySoundStyle ItemSwing = new LegacySoundStyle(2, 1);
        public static LegacySoundStyle ItemEat = new LegacySoundStyle(2, 2);
        public static LegacySoundStyle ItemSwallowDrink = new LegacySoundStyle(2, 3);
        public static LegacySoundStyle LifeCrystalPing = new LegacySoundStyle(2, 4);
        public static LegacySoundStyle ItemBowShot = new LegacySoundStyle(2, 5);
        public static LegacySoundStyle ItemMagicMirror = new LegacySoundStyle(2, 6);
        public static LegacySoundStyle ItemQuietSlowSwing = new LegacySoundStyle(2, 7);
        public static LegacySoundStyle ItemMagicCast = new LegacySoundStyle(2, 8);
        public static LegacySoundStyle AstralMagicNoise = new LegacySoundStyle(2, 9); // like the magic missile sound
        public static LegacySoundStyle BulletImpactOrHarpoon = new LegacySoundStyle(2, 10);
        public static LegacySoundStyle ItemBasicGunShot = new LegacySoundStyle(2, 11);
        // ---
        public static LegacySoundStyle BossLaserBeam = new LegacySoundStyle(2, 33); // like WoF
        // ---
        public static LegacySoundStyle Shotgun = new LegacySoundStyle(2, 36);
        // -
        public static LegacySoundStyle HeavyShot = new LegacySoundStyle(2, 38);
        // -
        public static LegacySoundStyle SniperShot = new LegacySoundStyle(2, 40);
        public static LegacySoundStyle RevolverShot = new LegacySoundStyle(2, 41);
        // -
        public static LegacySoundStyle StaffMagicCast = new LegacySoundStyle(2, 43);
        public static LegacySoundStyle SummonMinion = new LegacySoundStyle(2, 44);
        // ---
        public static LegacySoundStyle SummonHornet = new LegacySoundStyle(2, 76);
        public static LegacySoundStyle SummonImp = new LegacySoundStyle(2, 77);
        public static LegacySoundStyle SummonCrystal = new LegacySoundStyle(2, 78);

        public static LegacySoundStyle Roar = new LegacySoundStyle(15, 0); // like when a boss is summoned
    }
}
