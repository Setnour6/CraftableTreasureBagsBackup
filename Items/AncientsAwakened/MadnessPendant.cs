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
	public class MadnessPendant : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Madness Pendant");
			Tooltip.SetDefault("Not Equippable"
				+ $"\nUsed to make boss treasure bags from the [c/5F5FB4:Ancients Awakened] Mod"
				+ $"\nCan be upgraded for use with hardmode treasure bags"
				+ $"\n - While in your inventory, you deal 5% more damage."
				+ $"\n - However, you take 5% more damage."
				+ $"\n'Putting this on makes you mad and hurts your neck, so it's best to just hold on to it'");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 50;
			item.maxStack = 99;
			item.value = 1000;
			item.rare = 0;
		}

		public override void UpdateInventory(Player player)
        {
			player.allDamage += 0.05f;
			player.endurance -= 0.05f;
        }

		Color[] itemNameCycleColors = new Color[]{
			new Color(95,95, 180),
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
					int index = (int)(Main.GameUpdateCount / 60 % 2);
					line2.overrideColor = Color.Lerp(itemNameCycleColors[index], itemNameCycleColors[(index + 1) % 2], fade);
				}
			}
		}

		public override void AddRecipes()
		{
			if (ModLoader.GetMod("AAMod") != null)
            {
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddRecipeGroup("CraftableTreasureBags:Gold/Platinum Pendant");
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("MadnessFragment")), 4);
				recipe.AddTile(TileID.Anvils);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}
