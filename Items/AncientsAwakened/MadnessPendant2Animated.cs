using System;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.UI;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;
using System.Runtime.InteropServices;
using ReLogic.Graphics;
using Terraria.GameContent.UI;
using Terraria.ModLoader.Exceptions;

namespace CraftableTreasureBags.Items.AncientsAwakened
{
	public class MadnessPendant2Animated : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Forsaken Pendant");
			Tooltip.SetDefault("Not Equippable"
				+ $"\nUsed to make Hardmode boss treasure bags from the [c/6E8CB4:Ancients Awakened] Mod"
				+ $"\nCan be upgraded for use with Post-Moon Lord treasure bags"
				+ $"\n - While favorited in your inventory, you deal 10% more damage."
				+ $"\n - However, you take 10% more damage."
				+ $"\n'Putting this on makes you madder and hurts your neck more, so it's best to just hold on to it'");
			
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 6));

		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 50;
			item.maxStack = 99;
			item.value = 1000;
			item.rare = 4;
		}

		public override void UpdateInventory(Player player)
        {
			if (item.favorited)
            {
				player.allDamage += 0.1f;
				player.endurance -= 0.1f;
			}
        }

		Color[] itemNameCycleColors = new Color[]{
			new Color(230, 200, 40),
			new Color(45, 210, 200),
			new Color(95, 95, 180),
			new Color(215, 160, 175)
		};

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			// This code shows using Color.Lerp,  Main.GameUpdateCount, and the modulo operator (%) to do a neat effect cycling between 4 custom colors.
			foreach (TooltipLine line2 in tooltips)
			{
				if (line2.mod == "Terraria" && line2.Name == "ItemName")
				{
					float fade = Main.GameUpdateCount % 60 / 60f;
					int index = (int)(Main.GameUpdateCount / 60 % 4);
					line2.overrideColor = Color.Lerp(itemNameCycleColors[index], itemNameCycleColors[(index + 1) % 4], fade);
				}
			}
		}

		public override void AddRecipes()
		{
			if (ModLoader.GetMod("AAMod") != null)
            {
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ModContent.ItemType<MadnessPendant>());
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("DragonSpirit")), 5);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("ForsakenFragment")), 6);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}
