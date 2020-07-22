using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.NPCs.Bosses.TheIce;

namespace AshModAdditions.Items
{
    public class AncientIceShard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient ice shard");
        }

        public override void SetDefaults()
        {
            item.consumable = true;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.width = 18;
            item.height = 60;
        }

        public override bool CanUseItem(Player player) => !NPC.AnyNPCs(ModContent.NPCType<TheIce>());

        public override bool UseItem(Player player)
        {
            int ice = ModContent.NPCType<TheIce>();
            if (!NPC.AnyNPCs(ice))
            {
                NPC.SpawnOnPlayer(player.whoAmI, ice);
                return true;
            }
            return false;
        }
    }
}
