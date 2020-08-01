using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using Terraria.GameContent.Events;
namespace AshModAdditions.Items.Equippables
{
    public class HallowInsignia : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("The first of the many, mighty Insignias.");

            //   + "\n" + Language.GetTextValue("CommonItemTooltip.PercentIncreasedDamage", 1900)
            //  + "\nOnly equip if your character's name is bluemagic123");
        }

        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 28;
            item.value = 10000; // pls change
            item.rare = ItemRarityID.Red;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (player.ZoneHoly == true)
            {
                player.allDamage += 0.05f; // increase all damage by 1900%
                player.moveSpeed += 0.4f; 
                player.meleeSpeed += 0.2f;                     
                player.lifeRegen += 3;                         
                player.endurance = 3f - 0.1f * (1f - player.endurance); // dmg reduction?? 
                player.statDefense += 20;
            }
        }

        /*public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<EquipMaterial>(), 60);
            recipe.AddTile(TileType<ExampleWorkbench>());
            recipe.SetResult(this);
            recipe.AddRecipe();
        }*/

    } 
}