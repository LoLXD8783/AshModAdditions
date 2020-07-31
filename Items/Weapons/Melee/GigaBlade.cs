using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bosspocalyps.Items.Weapons.Melee
{
    public class GigaBlade : ModItem
    {
        public override string Texture => Helpers.PLACEHOLDER;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Giga blade");
        }

        public override void SetDefaults()
        {
            item.melee = true;
            item.damage = 156;
            item.useTime = 25;
            item.useAnimation = 25;
            item.knockBack = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundHelper.ItemSwing;
        }
    }
}
