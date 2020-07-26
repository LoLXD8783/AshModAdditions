using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace AshModAdditions.Items.Weapons.Magic
{
    public class Stormer : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("This is a modded magic weapon.");
        }

        public override void SetDefaults()
        {
            item.damage = 27;
            item.magic = true;
            item.mana = 5;
            item.width = 28;
            item.height = 32;
            item.useTime = 5;
            item.useAnimation = 5;
            item.useStyle = 5;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 5;
            item.value = 10000;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("StormProj");
            item.shootSpeed = 20f;
            item.UseSound = SoundID.Item13;
        }

        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<ExampleItem>(), 10);
            recipe.AddTile(TileType<ExampleWorkbench>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        } */
    }
}