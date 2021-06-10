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
	public class XeniumPendantAnimated : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Xenium Pendant");
			Tooltip.SetDefault("Not Equippable"
				+ $"\n[c/FF8F00:Not to be confused with the Soulful Pendant for the Ancients Awakened Mod]"
				+ $"\nUsed to make hardmode boss treasure bags from the [c/6E8CB4:Mod of Redemption]"
				+ $"\n - While favorited in your inventory, you deal 5% more damage, take 5% less damage, your mana cost is lowered by 5%, and you slightly regenerate more mana."
				+ $"\n - However, you receive heavy xenomite infection if you have more than 80% health."
				+ $"\n'Putting this on makes you're soul turn green and infect you within, so it's best to just hold on to it'");
			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(6, 6));

		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 50;
			item.maxStack = 99;
			item.value = 1000;
			item.rare = 12;
		}

		public override void UpdateInventory(Player player)
		{
			if (item.favorited)
			{
				player.endurance += 0.05f;
                player.jumpSpeedBoost += 1.2f;
				player.allDamage += 0.05f;
				player.manaRegenBonus += 3;
			//	player.buffImmune((ModLoader.GetMod("Redemption").BuffType("XenomiteDebuff"))) = true;
			//	player.AddBuff((ModLoader.GetMod("Redemption").BuffType("XenomiteDebuff2")), 1);
				if (player.statLife > player.statLifeMax2 * 0.8)
                {
					player.AddBuff((ModLoader.GetMod("Redemption").BuffType("XenomiteDebuff2")), 1);
				}
				player.manaCost -= 0.05f;
			}
		}

		public override bool PreDrawTooltipLine(DrawableTooltipLine line, ref int yOffset)
		{
			if (line.mod == "Terraria" && line.Name == "ItemName")
			{
				Main.spriteBatch.End(); //end and begin main.spritebatch to apply a shader
				Main.spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Main.UIScaleMatrix);
				var lineshader = GameShaders.Misc["PulseUpwards"].UseColor(new Color(30, 60, 30)).UseSecondaryColor(CraftableTreasureBags.XeniumColor());
				lineshader.Apply(null);
				Utils.DrawBorderString(Main.spriteBatch, line.text, new Vector2(line.X, line.Y), Color.White, 1); //draw the tooltip manually
				Main.spriteBatch.End(); //then end and begin again to make remaining tooltip lines draw in the default way
				Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Main.UIScaleMatrix);
				return false;
			}
			return true;
		}

		public override void AddRecipes()
		{
			if (ModLoader.GetMod("Redemption") != null)
			{
				var recipe = new ModRecipe(mod);
				recipe.AddIngredient(ModContent.ItemType<SoulPendant2Animated>());
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("LargeLostSoul")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("XeniumBar")), 4);
				recipe.AddTile((ModLoader.GetMod("Redemption").TileType("XenoTank1")));
				//recipe.AddTile(TileID.Anvils);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}