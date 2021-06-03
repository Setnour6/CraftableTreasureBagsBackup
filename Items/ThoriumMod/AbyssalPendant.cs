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
using Terraria.Enums;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;
using System.Runtime.InteropServices;
using ReLogic.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.UI;
using Terraria.ModLoader.Exceptions;
using Terraria.GameInput;

namespace CraftableTreasureBags.Items.ThoriumMod
{
	public class AbyssalPendant : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Abyssal Pendant");
			Tooltip.SetDefault("Not Equippable"
				+ $"\nUsed to make Hardmode boss treasure bags from the [c/6E8CB4:Thorium] Mod"
				+ $"\n - While favorited in your inventory, you are faster in water, mana regenerates faster, and you breathe better in liquid."
				+ $"\n - However, you're slower on land, and you breathe worse out of water"
				+ $"\n'Putting this on makes your lungs feel boundless, so it's best to just hold on to it'");
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
				player.manaRegen += 1;
				if (player.wet) // if (!inLiquid)
				{
					player.breath += 1;
					player.moveSpeed += 0.5f;
				}
				else
				{
					player.breath -= 3;
					player.moveSpeed -= 0.1f;
				}
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
					float fade = Main.GameUpdateCount % 120 / 120f;
					int index = (int)(Main.GameUpdateCount / 120 % 3);
					line2.overrideColor = Color.Lerp(itemNameCycleColors[index], itemNameCycleColors[(index + 1) % 3], fade);
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
