using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Bosspocalyps.Items.Equippables
{
    public class SafetyGlove : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Safety Glove");
            Tooltip.SetDefault("Immunity to poison");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 26;
            item.height = 22;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.poisoned = false;
        }
    }
}
