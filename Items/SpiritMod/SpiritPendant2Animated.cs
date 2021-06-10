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
	public class SpiritPendant2Animated : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spirit Pendant");
			Tooltip.SetDefault("Not Equippable"
				+ $"\nUsed to make Hardmode boss treasure bags from the [c/6E8CB4:Spirit] Mod"
				+ $"\n - While favorited in your inventory, your critical strike chance increases by 4%, and movement speed by 6%."
				+ $"\n - However, enemies are way more likely to target you."
				+ $"\n'Putting this on makes your own spirit buzz, so it's best to just hold on to it'");

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
				player.meleeCrit += 4;
				player.rangedCrit += 4;
				player.magicCrit += 4;
				player.thrownCrit += 4;
				player.moveSpeed += 0.06f;
				player.aggro += 8000;
			}
			else
            {
				player.aggro += 0;
			}
		}

		Color[] itemNameCycleColors = new Color[]{
			new Color(0, 230, 245),
			new Color(0, 145, 235),
			new Color(0, 185, 240),
			new Color(150, 145, 180),
			new Color(0, 80, 230)

		};

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			// This code shows using Color.Lerp,  Main.GameUpdateCount, and the modulo operator (%) to do a neat effect cycling between 4 custom colors.
			foreach (TooltipLine line2 in tooltips)
			{
				if (line2.mod == "Terraria" && line2.Name == "ItemName")
				{
					float fade = Main.GameUpdateCount % 120 / 120f;
					int index = (int)(Main.GameUpdateCount / 120 % 5);
					line2.overrideColor = Color.Lerp(itemNameCycleColors[index], itemNameCycleColors[(index + 1) % 5], fade);
				}
			}
		}

		public override void AddRecipes()
		{
			if (ModLoader.GetMod("SpiritMod") != null)
            {
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ModContent.ItemType<BismitePendant>());
				recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("SoulShred")), 5);
				recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("SpiritBar")), 2);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}
