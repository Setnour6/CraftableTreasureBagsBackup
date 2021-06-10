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

namespace CraftableTreasureBags.Items.ModOfRedemption
{
	public class SoulPendantAnimated : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soul Pendant");
			Tooltip.SetDefault("Not Equippable"
				+ $"\n[c/FF8F00:Not to be confused with the Soulful Pendant for the Ancients Awakened Mod]"
				+ $"\nUsed to make boss treasure bags from the [c/6E8CB4:Mod of Redemption]"
				+ $"\n - While favorited in your inventory, you take 2% less damage, and jump slightly higher."
				+ $"\n - However, you're movement speed is reduced by 2.5%, and run acceleration is lowered by 25%"
				+ $"\nCan be upgraded for use with hardmode treasure bags"
				+ $"\n'Putting this on makes you're own soul float, so it's best to just hold on to it'");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 6));

		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 50;
			item.maxStack = 99;
			item.value = 1000;
			item.rare = 2;
		}

		public override void UpdateInventory(Player player)
		{
			if (item.favorited)
			{
				player.endurance += 0.02f;
				player.moveSpeed -= 0.025f;
				player.jumpSpeedBoost += 0.6f;
				player.runAcceleration -= 0.02f;
			}
		}

		Color[] itemNameCycleColors = new Color[]{
			new Color(85, 125, 120),
			new Color(255, 255, 255)
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
			if (ModLoader.GetMod("Redemption") != null)
			{
				var recipe = new ModRecipe(mod);
				recipe.AddRecipeGroup("CraftableTreasureBags:Gold/Platinum Pendant");
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("SmallLostSoul")), 8);
				recipe.AddTile((ModLoader.GetMod("Redemption").TileType("DruidicAltarTile")));
				//recipe.AddTile(TileID.Anvils);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}