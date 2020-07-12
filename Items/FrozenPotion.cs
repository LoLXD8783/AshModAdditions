using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using AshModAdditions.Buffs;

namespace AshModAdditions.Items
{
    public class FrozenPotion : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frozen potion");
            DisplayName.AddTranslation(GameCulture.Spanish, "Poción congelada");

            Tooltip.SetDefault("Causes ice debuff on enemies when hit with melee or ranged weapons");
        }

        public override void SetDefaults()
        {
            item.consumable = true;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useTime = 10;
            item.useAnimation = 10;
            item.width = 20;
            item.height = 30;
            item.maxStack = 30;
            item.buffType = ModContent.BuffType<FrozenPotionBuff>();
            item.buffTime = 7200; // 2 minutes
        }
    }
}
