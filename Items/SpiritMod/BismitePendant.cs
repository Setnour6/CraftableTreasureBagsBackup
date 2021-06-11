using System;
using System.IO;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.UI;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.GameInput;
using Terraria.Graphics;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using static Terraria.ModLoader.ModContent;
using System.Runtime.InteropServices;
using ReLogic.Graphics;
using Terraria.GameContent.UI;
using Terraria.ObjectData;
using Terraria.Social;
using Terraria.ModLoader.Exceptions;

namespace CraftableTreasureBags.Items.SpiritMod
{
	public class BismitePendant : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bismite Pendant");
			Tooltip.SetDefault("Not Equippable"
				+ $"\nUsed to make boss treasure bags from the [c/6E8CB4:Spirit] Mod"
				+ $"\nCan be upgraded for use with hardmode treasure bags"
				+ $"\n - While favorited in your inventory, your critical strike chance increases by 2%, and movement speed by 3%."
				+ $"\n - However, enemies are slightly more likely to target you."
				+ $"\n'Putting this on makes you one of those discord kids, so it's best to just hold on to it'");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 50;
			item.maxStack = 99;
			item.value = 1000;
			item.rare = 1;
		}

		public override void UpdateInventory(Player player)
        {
			if (item.favorited)
            {
				player.meleeCrit += 2;
				player.rangedCrit += 2;
				player.magicCrit += 2;
				player.thrownCrit += 2;
				player.moveSpeed += 0.03f;
				player.aggro += 100;
			}
        }

		Color[] itemNameCycleColors = new Color[]{
			new Color(160, 200, 95),
			new Color(100, 110, 85)
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
			if (ModLoader.GetMod("SpiritMod") != null)
            {
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddRecipeGroup("CraftableTreasureBags:Gold/Platinum Pendant");
				recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("BismiteCrystal")), 4);
				recipe.AddTile(TileID.Anvils);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}
