using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace Bosspocalyps.Backgrounds
{
    public class WarpedBiomBGStyle : ModSurfaceBgStyle
    {
        public override bool ChooseBgStyle()
        {
            return !Main.gameMenu && Main.LocalPlayer.GetModPlayer<BosspocalypsModPlayer>().ZoneWarpedBiome;
        }

        public override void ModifyFarFades(float[] fades, float transitionSpeed)
        {
            for(int i = 0; i < fades.Length; i++)
            {
                if(i == Slot)
                {
                    fades[i] = Math.Min(fades[i] + transitionSpeed, 1f);
                }
                else
                {
                    fades[i] = Math.Max(fades[i] - transitionSpeed, 0f);
                }
            }
        }

        public override int ChooseFarTexture()
        {
            return mod.GetBackgroundSlot("Backgrounds/Warped_Biom_Far");
        }
        public override int ChooseMiddleTexture()
        {
            return mod.GetBackgroundSlot("Backgrounds/Warped_Biom_Middle");
        }
        public override int ChooseCloseTexture(ref float scale, ref double parallax, ref float a, ref float b)
        {
            return mod.GetBackgroundSlot("Backgrounds/Warped_Biom_Close");
        }
    }
}
