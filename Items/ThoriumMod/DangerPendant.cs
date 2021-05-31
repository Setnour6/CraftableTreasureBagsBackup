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

namespace CraftableTreasureBags.Items.ThoriumMod
{
	public class DangerPendant : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Danger Pendant");
			Tooltip.SetDefault("Not Equippable"
				+ $"\nUsed to make boss treasure bags from the [c/6E8CB4:Thorium] Mod"
				+ $"\nCan be upgraded for use with hardmode treasure bags"
				+ $"\n - While favorited in your inventory, you are immune to Poisoned."
				+ $"\n - However, life regeneration lowers over time, possibly to 0."
				+ $"\n'Putting this on makes you in danger, so it's best to just hold on to it'");
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
			if (item.favorited)
			{
				player.buffImmune[20] = true;
				player.lifeRegenTime -= 1;
			}
		}

		Color[] itemNameCycleColors = new Color[]{
			new Color(145, 170, 60),
			new Color(145, 170, 60),
			new Color(250, 20, 110)
		};

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			// This code shows using Color.Lerp,  Main.GameUpdateCount, and the modulo operator (%) to do a neat effect cycling between 4 custom colors.
			foreach (TooltipLine line2 in tooltips)
			{
				if (line2.mod == "Terraria" && line2.Name == "ItemName")
				{
					float cross = Main.GameUpdateCount % 120 / 120f;
					int index = (int)(Main.GameUpdateCount / 120 % 3);
					line2.overrideColor = Color.Lerp(itemNameCycleColors[index], itemNameCycleColors[(index + 1) % 3], cross);
				}
			}
		}

		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("CraftableTreasureBags:Gold/Platinum Pendant");
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("DangerShard")), 4);
			recipe.AddTile((ModLoader.GetMod("ThoriumMod").TileType("ArcaneArmorFabricator")));
			//recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
