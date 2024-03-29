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

namespace CraftableTreasureBags.Items.AncientsAwakened
{
	public class MadnessPendant3Animated : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Soulful Pendant");
			Tooltip.SetDefault("Not Equippable"
				+ $"\n[c/FF8F00:Not to be confused with the Soul Pendant for the Mod of Redemption]"
				+ $"\nUsed to make Post-Moon Lord boss treasure bags from the [c/6E8CB4:Ancients Awakened] Mod"
				+ $"\n - While favorited in your inventory, you deal 20% more damage and gain 12% of critical strike chance."
				//+ $"\n - However, you take 15% more damage, and your health is lowered by one tenth of your max life (1 � 10)."
				+ $"\n - However, you take 15% more damage, your health is lowered by 50, and mana cost is 10% higher."
				+ $"\n'Putting this on makes you even madder, and your soul enraged, and hurts your neck even more, so it's best to just hold on to it'");

			Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(8, 6));

		}

		public override void SetDefaults()
		{
			item.width = 26;
			item.height = 50;
			item.maxStack = 99;
			item.value = 1000;
			item.rare = 11;
		}

		public override void UpdateInventory(Player player)
        {
			if (item.favorited)
            {
				player.allDamage += 0.1f;
				player.endurance -= 0.15f;
				player.meleeCrit += 12;
				player.rangedCrit += 12;
				player.magicCrit += 12;
				player.thrownCrit += 12;
				player.manaCost -= 0.1f;
				//player.statLifeMax2 /= 10;
				player.statLifeMax2 -= 50;
			}
		}

		public override bool PreDrawTooltipLine(DrawableTooltipLine line, ref int yOffset)
		{
			if (line.mod == "Terraria" && line.Name == "ItemName")
			{
				Main.spriteBatch.End(); //end and begin main.spritebatch to apply a shader
				Main.spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, Main.UIScaleMatrix);
				var lineshader = GameShaders.Misc["PulseCircle"].UseColor(new Color(255, 255, 60)).UseSecondaryColor(new Color(80, 150, 0));
				lineshader.Apply(null);
				Utils.DrawBorderString(Main.spriteBatch, line.text, new Vector2(line.X, line.Y), new Color(255, 169, 240), 1); //draw the tooltip manually
				Main.spriteBatch.End(); //then end and begin again to make remaining tooltip lines draw in the default way
				Main.spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, Main.UIScaleMatrix);
				return false;
			}
			return true;
		}

		public override void AddRecipes()
		{
			if (ModLoader.GetMod("AAMod") != null)
            {
				ModRecipe recipe = new ModRecipe(mod);
				recipe.AddIngredient(ModContent.ItemType<MadnessPendant2Animated>());
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("DragonSpirit")), 3);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("SoulFragment")), 8);
				recipe.AddTile(TileID.MythrilAnvil);
				recipe.SetResult(this);
				recipe.AddRecipe();
			}
		}
	}
}
