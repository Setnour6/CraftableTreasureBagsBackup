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
	public class SoulPendant2Animated : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Charged Soul Pendant");
			Tooltip.SetDefault("Not Equippable"
				+ $"\n[c/FF8F00:Not to be confused with the Soulful Pendant for the Ancients Awakened Mod]"
				+ $"\nUsed to make hardmode boss treasure bags from the [c/6E8CB4:Mod of Redemption]"
				+ $"\n - While favorited in your inventory, you take 4% less damage, and jump slightly higher."
				+ $"\n - However, you receive mild xenomite infection if you have more than 75% health."
				+ $"\nCan be upgraded for use with Post-Moon Lord treasure bags"
				+ $"\n'Putting this on makes you're own soul float quickly, so it's best to just hold on to it'");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 4));

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
				player.endurance += 0.04f;
				player.jumpSpeedBoost += 1.2f;
				if (player.statLife > player.statLifeMax2 * 0.75)
					player.AddBuff((ModLoader.GetMod("Redemption").BuffType("XenomiteDebuff")), 1);
			}
		}

		Color[] itemNameCycleColors = new Color[]{
			new Color(85, 125, 120),
			new Color(250, 100, 100),
			new Color(0, 180, 20),
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
					int index = (int)(Main.GameUpdateCount / 120 % 4);
					line2.overrideColor = Color.Lerp(itemNameCycleColors[index], itemNameCycleColors[(index + 1) % 4], fade);
				}
			}
		}

		public override void AddRecipes()
		{
			if (ModLoader.GetMod("Redemption") != null)
			{
				var recipe = new ModRecipe(mod);
				recipe.AddIngredient(ModContent.ItemType<SoulPendantAnimated>());
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("LostSoul")), 2);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("MoonflareFragment")), 2);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("Xenomite")), 2);
				recipe.AddTile((ModLoader.GetMod("Redemption").TileType("DruidicAltarTile")));
				//recipe.AddTile(TileID.Anvils);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}