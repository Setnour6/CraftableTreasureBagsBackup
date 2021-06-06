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
				+ $"\n - While favorited in your inventory, mana regenerates faster on land, and you move faster in water."
				+ $"\n - However, you're slower on land, mana regenerates slower in water, and you're breath does not regenerate."
				+ $"\n [c/FF8A6D:- due to exploitations, life regeneration is also lowered in water if 1/4 of breath is used up.]"
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
				
				if (player.wet && !player.lavaWet && !player.honeyWet) // (player.wet) means all liquids. player.wet && !player.lavaWet && !player.honeyWet means only water but not honey or lava.
				{
					//player.breath += 1;
					player.moveSpeed += 0.5f;
					player.manaRegenBonus -= 15;
				}
				else
				{
					player.breath -= 3;
					player.moveSpeed -= 0.25f;
					player.manaRegenBonus += 15;
				}
				if (player.wet && !player.lavaWet && !player.honeyWet && player.breath <= 150)
                {
					player.lifeRegen -= 2;
                }
				if (player.breath <= 0)
                {
					player.suffocating = true;
				}
			}
		}
		Color[] itemNameCycleColors = new Color[]{
			new Color(70, 200, 160),
			new Color(230, 170, 50)
		};

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			// This code shows using Color.Lerp,  Main.GameUpdateCount, and the modulo operator (%) to do a neat effect cycling between 4 custom colors.
			foreach (TooltipLine line2 in tooltips)
			{
				if (line2.mod == "Terraria" && line2.Name == "ItemName")
				{
					float fade = Main.GameUpdateCount % 120 / 120f;
					int index = (int)(Main.GameUpdateCount / 120 % 2);
					line2.overrideColor = Color.Lerp(itemNameCycleColors[index], itemNameCycleColors[(index + 1) % 2], fade);
				}
			}
		}

		public override void AddRecipes()
		{
			var recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DangerPendant>());
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("AbyssalChitin")), 5);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("SpiritDroplet")), 1);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("DepthScale")), 2);
			recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("FishScale")), 1);
			//recipe.AddTile((ModLoader.GetMod("ThoriumMod").TileType("ArcaneArmorFabricator")));
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
