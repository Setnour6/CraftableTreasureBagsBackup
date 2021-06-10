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
//using CraftableTreasureBags.Items;
using Terraria.ModLoader.Exceptions;

namespace CraftableTreasureBags.Items
{
	public class CelebratoryPendant : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Celebratory Pendant");
			Tooltip.SetDefault("Not Equippable"
				+ $"\nThis was used to make any pre-hardmode boss treasure bag of your choice"
				+ $"\nThis is no longer the case, as the event has ended");
				//+ $"\n[i/s1:29] Thank you for 50,000 Downloads! [i/s1:29]");
		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 50;
			item.maxStack = 99;
			item.value = 1000;
			item.rare = -12;
		}

		public override bool PreDrawTooltipLine(DrawableTooltipLine line, ref int yOffset)
		{
			if (line.mod == "Terraria" && line.Name == "ItemName")
			{
				Main.spriteBatch.End(); //end and begin main.spritebatch to apply a shader
				Main.spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Main.UIScaleMatrix);
				GameShaders.Armor.Apply(GameShaders.Armor.GetShaderIdFromItemId(ItemID.LivingRainbowDye), item, null); //use living rainbow dye shader
				Utils.DrawBorderString(Main.spriteBatch, line.text, new Vector2(line.X, line.Y), Color.Yellow, 1); //draw the tooltip manually
				Main.spriteBatch.End(); //then end and begin again to make remaining tooltip lines draw in the default way
				Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Main.UIScaleMatrix);
				return false;
			}
			return true;
		}

		//public override void AddRecipes()
		//{
		//	ModRecipe recipe = new ModRecipe(mod);
		//	recipe.AddIngredient(ItemID.Silk, 10);
		//	recipe.AddIngredient(ItemID.BlackString);
		//	recipe.SetResult(this);
		//	recipe.AddRecipe();
		//}
	}
}
