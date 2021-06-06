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

namespace CraftableTreasureBags.Items
{
	public class Gemstar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gemstar");
			Tooltip.SetDefault("Text effect testing"
				+ $"\n[c/FF38A5:Test Item]"
				+ $"\nYou're not supposed to have this in your inventory");

			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 16));
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
				player.allDamage += 0.05f;
				player.endurance -= 0.05f;
			}
        }

		//Color[] itemNameCycleColors = new Color[]{
		//	new Color(115, 30, 175),
		//	new Color(90, 200, 160),
		//	new Color(190, 125, 35),
		//	new Color(25, 35, 195),
		//	new Color(150, 20, 25),
		//	new Color(210, 190, 220),
		//	new Color(200, 150, 20)
		//
		//		};

		//public override void ModifyTooltips(List<TooltipLine> tooltips)
		//{
		// This code shows using Color.Lerp,  Main.GameUpdateCount, and the modulo operator (%) to do a neat effect cycling between 4 custom colors.
		//	foreach (TooltipLine line2 in tooltips)
		//{
		//	if (line2.mod == "Terraria" && line2.Name == "ItemName")
		//	{
		//		float fade = Main.GameUpdateCount % 60 / 60f;
		//			int index = (int)(Main.GameUpdateCount / 60 % 7);
		//			line2.overrideColor = Color.Lerp(itemNameCycleColors[index], itemNameCycleColors[(index + 1) % 7], fade);
		//		}
		//	}
		//}

		public override bool PreDrawTooltipLine(DrawableTooltipLine line, ref int yOffset)
		{
			if (line.mod == "Terraria" && line.Name == "ItemName")
			{
				Main.spriteBatch.End(); //end and begin main.spritebatch to apply a shader
				Main.spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Main.UIScaleMatrix);
				GameShaders.Armor.Apply(GameShaders.Armor.GetShaderIdFromItemId(ItemID.VortexDye), item, null); //use living rainbow dye shader
				Utils.DrawBorderString(Main.spriteBatch, line.text, new Vector2(line.X, line.Y), Color.GreenYellow, 1); //draw the tooltip manually, and also, after color.something, using 2 makes the text larger. lower number = smaller, but use f so it's like color.red, 0.5f, or else it's an error.
				Main.spriteBatch.End(); //then end and begin again to make remaining tooltip lines draw in the default way
				Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Main.UIScaleMatrix);
				return false;
			}
			return true;
		}
	}
}
