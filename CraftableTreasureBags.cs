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
using CraftableTreasureBags.Items;
using Terraria.ModLoader.Exceptions;

namespace CraftableTreasureBags
{
	public class CraftableTreasureBags : Mod
	{
		public CraftableTreasureBags()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true,
			};
		}

		public static Mod Instance;
		public static string GithubUserName { get { return "Setnour6"; } }
		public static string GithubProjectName { get { return "CraftableTreasureBags"; } }

		public override void AddRecipeGroups()
		{
			RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Gold/Platinum Pendant", new int[]
			{
				ItemType("GoldPendant"),
				ItemType("PlatinumPendant")

			});
			RecipeGroup.RegisterGroup("CraftableTreasureBags:Gold/Platinum Pendant", group);
		}

		public override void Load()
		{
			if (Main.netMode != NetmodeID.Server)
			{
				#region shaders

				//loading refs for shaders
				Ref<Effect> textRef = new Ref<Effect>(GetEffect("Effects/TextShader"));

				//loading shaders from refs
				GameShaders.Misc["PulseUpwards"] = new MiscShaderData(textRef, "PulseUpwards");
				GameShaders.Misc["PulseDiagonal"] = new MiscShaderData(textRef, "PulseDiagonal");
				GameShaders.Misc["PulseCircle"] = new MiscShaderData(textRef, "PulseCircle");

				#endregion shaders
			}
		}

		public override void AddRecipes()
		{
			#region 50,000 downloads celebration

			ModRecipe recipe = new ModRecipe(this);
			recipe.AddIngredient(this.GetItem("CelebratoryPendant"));
			recipe.SetResult(ItemID.KingSlimeBossBag);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(this.GetItem("CelebratoryPendant"));
			recipe.SetResult(ItemID.EyeOfCthulhuBossBag);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(this.GetItem("CelebratoryPendant"));
			recipe.SetResult(ItemID.EaterOfWorldsBossBag);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(this.GetItem("CelebratoryPendant"));
			recipe.SetResult(ItemID.BrainOfCthulhuBossBag);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(this.GetItem("CelebratoryPendant"));
			recipe.SetResult(ItemID.QueenBeeBossBag);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(this.GetItem("CelebratoryPendant"));
			recipe.SetResult(ItemID.SkeletronBossBag);
			recipe.AddRecipe();

			#endregion 50,000 downloads celebration

			#region Vanilla boss treasure bags

			recipe = new ModRecipe(this);
			//ModRecipe recipe = new ModRecipe(this);
			recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
			recipe.AddRecipeGroup("CraftableTreasureBags:Gold/Platinum Pendant");
			//if (ModLoader.GetMod("CalamityMod") != null) || (ModLoader.GetMod("Fargowiltas") != null)
			//{
			//recipe.AddIngredient(ItemID.SlimeCrown, 2);
			//}
			//else
			//{
			recipe.AddIngredient(ItemID.SlimeCrown, 1);
			recipe.AddIngredient(ItemID.Blinkroot, 2);
			//}
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				recipe.AddIngredient(ItemID.Gel, 600);
			}
			else
			{
				recipe.AddIngredient(ItemID.Gel, 400);
			}
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeKingSlime")), 1);
			}
			recipe.AddIngredient(ItemID.KingSlimeMask, 1);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.KingSlimeBossBag);
			recipe.AddRecipe();
			//recipe = new ModRecipe(this);
			//recipe.AddIngredient(ItemID.Gel, 1);
			//recipe.SetResult(ItemID.KingSlimeBossBag);
			//recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
			recipe.AddRecipeGroup("CraftableTreasureBags:Gold/Platinum Pendant");
			//if (ModLoader.GetMod("CalamityMod") != null) || (ModLoader.GetMod("Fargowiltas") != null)
			//{
			//recipe.AddIngredient(ItemID.SuspiciousLookingEye, 2);
			//}
			//else
			//{
			recipe.AddIngredient(ItemID.SuspiciousLookingEye, 1);
			//}
			recipe.AddIngredient(ItemID.DemoniteOre, 75);
			recipe.AddIngredient(ItemID.Deathweed, 3);
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeEyeofCthulhu")), 1);
			}
			recipe.AddIngredient(ItemID.EyeMask, 1);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.EyeOfCthulhuBossBag);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
			recipe.AddRecipeGroup("CraftableTreasureBags:Gold/Platinum Pendant");
			recipe.AddIngredient(ItemID.SuspiciousLookingEye, 1);
			recipe.AddIngredient(ItemID.CrimtaneOre, 75);
			recipe.AddIngredient(ItemID.Deathweed, 3);
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeEyeofCthulhu")), 1);
			}
			recipe.AddIngredient(ItemID.EyeMask, 1);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.EyeOfCthulhuBossBag);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
			recipe.AddRecipeGroup("CraftableTreasureBags:Gold/Platinum Pendant");
			recipe.AddIngredient(ItemID.WormFood, 1);
			recipe.AddIngredient(ItemID.DemoniteOre, 100);
			recipe.AddIngredient(ItemID.Deathweed, 5);
			recipe.AddIngredient(ItemID.Blinkroot, 2);
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeEaterofWorlds")), 1);
			}
			recipe.AddIngredient(ItemID.ShadowScale, 50);
			recipe.AddIngredient(ItemID.EaterMask, 1);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.EaterOfWorldsBossBag);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
			recipe.AddRecipeGroup("CraftableTreasureBags:Gold/Platinum Pendant");
			recipe.AddIngredient(ItemID.BloodySpine, 1);
			recipe.AddIngredient(ItemID.CrimtaneOre, 100);
			recipe.AddIngredient(ItemID.TissueSample, 50);
			recipe.AddIngredient(ItemID.Deathweed, 5);
			recipe.AddIngredient(ItemID.Blinkroot, 2);
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeBrainofCthulhu")), 1);
			}
			recipe.AddIngredient(ItemID.BrainMask, 1);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.BrainOfCthulhuBossBag);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
			recipe.AddRecipeGroup("CraftableTreasureBags:Gold/Platinum Pendant");
			recipe.AddIngredient(ItemID.Abeemination, 1);
			recipe.AddIngredient(ItemID.BeeWax, 20);
			recipe.AddIngredient(ItemID.BottledHoney, 10);
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeQueenBee")), 1);
			}
			recipe.AddIngredient(ItemID.BeeMask, 1);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.QueenBeeBossBag);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
			recipe.AddRecipeGroup("CraftableTreasureBags:Gold/Platinum Pendant");
			recipe.AddIngredient(ItemID.ClothierVoodooDoll, 1);
			recipe.AddIngredient(ItemID.Bone, 100);
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeSkeletron")), 1);

			}
			recipe.AddIngredient(ItemID.SkeletronMask, 1);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.SkeletronBossBag);
			recipe.AddRecipe();
			if (ModLoader.GetMod("BossExpertise") != null)
			{
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddRecipeGroup("CraftableTreasureBags:Gold/Platinum Pendant");
				recipe.AddIngredient(ItemID.GuideVoodooDoll, 1);
				recipe.AddIngredient(ItemID.FleshBlock, 50);
				recipe.AddIngredient(ItemID.Pwnhammer, 1);
				recipe.AddIngredient(ItemID.Fireblossom, 3);
				if (ModLoader.GetMod("CalamityMod") != null)
				{
					recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
					recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeWallofFlesh")), 1);
				}
				recipe.AddIngredient(ItemID.FleshMask, 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult(ItemID.WallOfFleshBossBag);
				recipe.AddRecipe();
			}
			recipe = new ModRecipe(this);
			recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
			recipe.AddRecipeGroup("CraftableTreasureBags:Gold/Platinum Pendant");
			recipe.AddIngredient(ItemID.MechanicalWorm, 1);
			recipe.AddIngredient(ItemID.SoulofMight, 25);
			recipe.AddIngredient(ItemID.HallowedBar, 15);
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeDestroyer")), 1);
			}
			recipe.AddIngredient(ItemID.DestroyerMask, 1);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.DestroyerBossBag);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
			recipe.AddRecipeGroup("CraftableTreasureBags:Gold/Platinum Pendant");
			recipe.AddIngredient(ItemID.MechanicalEye, 1);
			recipe.AddIngredient(ItemID.SoulofSight, 25);
			recipe.AddIngredient(ItemID.HallowedBar, 15);
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeTwins")), 1);
			}
			recipe.AddIngredient(ItemID.TwinMask, 1);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.TwinsBossBag);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
			recipe.AddRecipeGroup("CraftableTreasureBags:Gold/Platinum Pendant");
			recipe.AddIngredient(ItemID.MechanicalSkull, 1);
			recipe.AddIngredient(ItemID.SoulofFright, 25);
			recipe.AddIngredient(ItemID.HallowedBar, 15);
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeSkeletronPrime")), 1);
			}
			recipe.AddIngredient(ItemID.SkeletronPrimeMask, 1);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.SkeletronPrimeBossBag);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
			recipe.AddRecipeGroup("CraftableTreasureBags:Gold/Platinum Pendant");
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("BulbofDoom")), 1);
			}
			else if (ModLoader.GetMod("Fargowiltas") != null)
			{
				recipe.AddIngredient((ModLoader.GetMod("Fargowiltas").ItemType("PlanterasFruit")), 1);
			}
			recipe.AddIngredient(ItemID.TempleKey, 1);
			recipe.AddIngredient(ItemID.PygmyStaff, 1);
			recipe.AddIngredient(ItemID.PygmyNecklace, 1);
			recipe.AddIngredient(ItemID.ChlorophyteOre, 50);
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgePlantera")), 1);
			}
			recipe.AddIngredient(ItemID.PlanteraMask, 1);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.PlanteraBossBag);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
			recipe.AddRecipeGroup("CraftableTreasureBags:Gold/Platinum Pendant");
			recipe.AddIngredient(ItemID.LihzahrdPowerCell, 5);
			recipe.AddIngredient(ItemID.BeetleHusk, 5);
			recipe.AddIngredient(ItemID.SolarTablet, 1);
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeGolem")), 1);
			}
			recipe.AddIngredient(ItemID.GolemMask, 1);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.GolemBossBag);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
			recipe.AddRecipeGroup("CraftableTreasureBags:Gold/Platinum Pendant");
			recipe.AddIngredient(ItemID.TruffleWorm, 1);
			recipe.AddIngredient(ItemID.FishronWings, 1);
			recipe.AddIngredient(ItemID.Moonglow, 3);
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				recipe.AddIngredient(ItemID.Bacon, 5);
			}
			else
			{
				recipe.AddIngredient(ItemID.Bacon, 2);
			}
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeDukeFishron")), 1);
			}
			recipe.AddIngredient(ItemID.DukeFishronMask, 1);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.FishronBossBag);
			recipe.AddRecipe();
			recipe = new ModRecipe(this);
			recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
			recipe.AddRecipeGroup("CraftableTreasureBags:Gold/Platinum Pendant");
			recipe.AddIngredient(ItemID.CelestialSigil, 1);
			recipe.AddIngredient(ItemID.LunarOre, 75);
			recipe.AddIngredient(ItemID.PortalGun, 1);
			recipe.AddIngredient(ItemID.Moonglow, 5);
			recipe.AddIngredient(ItemID.Blinkroot, 5);
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeMoonLord")), 1);
			}
			recipe.AddIngredient(ItemID.BossMaskMoonlord, 1);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(ItemID.MoonLordBossBag);
			recipe.AddRecipe();

			#endregion Vanilla boss treasure bags

			// Modded Treasure Bags: AlchemistNPC
			if (ModLoader.GetMod("AlchemistNPC") != null)
			{
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("AlchemistNPC").ItemType("DimensionalRift")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AlchemistNPC").ItemType("GoldenKnuckles")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AlchemistNPC").ItemType("LaserCannon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AlchemistNPC").ItemType("GrapplingHookGunItem")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AlchemistNPC").ItemType("BillSoul")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AlchemistNPC").ItemType("WrathOfTheCelestial")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("AlchemistNPC").ItemType("BillCipherBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("AlchemistNPC").ItemType("KnucklesUgandaDoll")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AlchemistNPC").ItemType("EdgeOfChaos")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AlchemistNPC").ItemType("LastTantrum")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AlchemistNPC").ItemType("ChaosBomb")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AlchemistNPC").ItemType("BreathOfTheVoid")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AlchemistNPC").ItemType("UgandanTotem")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("AlchemistNPC").ItemType("KnucklesBag")), 1);
				recipe.AddRecipe();
			}
			// Modded Treasure Bags: JoostMod
			if (ModLoader.GetMod("JoostMod") != null)
			{
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("JoostMod").ItemType("CactusBait")), 1);
				recipe.AddIngredient((ModLoader.GetMod("JoostMod").ItemType("LusciousCactus")), 12);
				recipe.AddIngredient(ItemID.RestorationPotion, 10);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("JoostMod").ItemType("GrandCactusWormBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("JoostMod").ItemType("Cactusofdoom")), 3);
				recipe.AddIngredient((ModLoader.GetMod("JoostMod").ItemType("Cactustoken")), 2);
				recipe.AddIngredient((ModLoader.GetMod("JoostMod").ItemType("DecisiveBattleMusicBox")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("JoostMod").ItemType("JumboCactuarBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("JoostMod").ItemType("InfectedArmCannon")), 15);
				recipe.AddIngredient((ModLoader.GetMod("JoostMod").ItemType("IceCoreX")), 2);
				recipe.AddIngredient((ModLoader.GetMod("JoostMod").ItemType("SAXMusicBox")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Joostmod").ItemType("XBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("JoostMod").ItemType("Excalipoor")), 15);
				recipe.AddIngredient((ModLoader.GetMod("JoostMod").ItemType("GenjiToken")), 2);
				recipe.AddIngredient((ModLoader.GetMod("JoostMod").ItemType("COTBBMusicBox")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("JoostMod").ItemType("GilgBag")), 1);
				recipe.AddRecipe();
			}
			// Modded Treasure Bags: Ancients Awakened || AAMod
			if (ModLoader.GetMod("AAMod") != null)
			{
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("MadnessPendant"));
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("IntimidatingMushroom")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("SporeSac")), 30);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("Mushium")), 30);
				recipe.AddIngredient(ItemID.Mushroom, 30);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("AAMod").ItemType("MonarchBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("MadnessPendant"));
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("ConfusingMushroom")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("SporeSac")), 50);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("GlowingMushium")), 30);
				recipe.AddIngredient(ItemID.GlowingMushroom, 40);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("AAMod").ItemType("FungusBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("MadnessPendant"));
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("CuriousClaw")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("Incinerite")), 30);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("Abyssium")), 30);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("HydraClaw")), 50);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("DragonClaw")), 50);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("AAMod").ItemType("GripBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("MadnessPendant"));
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("InterestingClaw")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("Incinerite")), 30);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("Abyssium")), 30);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("HydraClaw")), 20);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("DragonClaw")), 20);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("AAMod").ItemType("GripBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("MadnessPendant"));
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("Toadstool")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("Mushium")), 10);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("GlowingMushium")), 50);
				recipe.AddIngredient(ItemID.Mushroom, 10);
				recipe.AddIngredient(ItemID.GlowingMushroom, 20);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("AAMod").ItemType("ToadBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("MadnessPendant"));
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("DragonBell")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("Incinerite")), 90);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("BroodScale")), 80);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("DragonClaw")), 50);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("AAMod").ItemType("BroodBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("MadnessPendant"));
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("HydraChow")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("Abyssium")), 90);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("HydraHide")), 75);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("HydraClaw")), 50);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("AAMod").ItemType("HydraBag")), 1);
				recipe.AddRecipe();
				// Subzero Serpent loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("MadnessPendant"));
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("SubzeroCrystal")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("SnowMana")), 16);
				recipe.AddIngredient(ItemID.SnowBlock, 50);
				recipe.AddIngredient(ItemID.Shiverthorn, 5);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("Torchice")), 10);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("IndigoIce")), 10);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("AAMod").ItemType("SerpentBag")), 1);
				recipe.AddRecipe();
				// Subzero Serpent loot recipes end here
				// Desert Djinn loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("MadnessPendant"));
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("DjinnLamp")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("DesertMana")), 16);
				recipe.AddIngredient(ItemID.SandBlock, 50);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("Torchsand")), 6);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("Torchsandstone")), 4);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("Depthsand")), 6);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("Depthsandstone")), 4);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("AAMod").ItemType("DjinnBag")), 1);
				recipe.AddRecipe();
				// Desert Djinn loot recipes end here
				// Sagittarius loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("MadnessPendant"));
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("Lifescanner")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("Doomite")), 45);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("DoomiteScrap")), 25);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("OroborosWood")), 50);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("Razewood")), 20);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("Bogwood")), 20);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("AAMod").ItemType("SagBag")), 1);
				recipe.AddRecipe();
				// Sagittarius loot recipes end here
				// HARDMODE LOOT RECIPES START HERE!!!
				// Anubis loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("MadnessPendant2Animated"));
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("Scepter")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("ForsakenFragment")), 12);
				recipe.AddIngredient(ItemID.AntlionMandible, 5);
				recipe.AddIngredient(ItemID.SandBlock, 100);
				recipe.AddIngredient(ItemID.AncientBattleArmorMaterial, 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("AAMod").ItemType("AnubisBag")), 1);
				recipe.AddRecipe();
				// Anubis loot recipes end here
				// Athena loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("MadnessPendant2Animated"));
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("Owl")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("GoddessFeather")), 22);
				recipe.AddIngredient(ItemID.Feather, 11);
				recipe.AddIngredient(ItemID.Cloud, 20);
				recipe.AddIngredient(ItemID.RainCloud, 20);
				recipe.AddIngredient(ItemID.SnowCloudBlock, 10);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("AAMod").ItemType("AthenaBag")), 1);
				recipe.AddRecipe();
				// Athena loot recipes end here

				// Gold Dust Recipes


				// Greed loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("MadnessPendant2Animated"));
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("GoldenGrub")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("StoneShell")), 22);
				recipe.AddIngredient(ItemID.GreedyRing);
				recipe.AddIngredient(ItemID.ReflectiveGoldDye, 3);
				recipe.AddIngredient(ItemID.FlaskofGold);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("AAMod").ItemType("GreedBag")), 1);
				recipe.AddRecipe();
				// Greed loot recipes end here
				// Rajah Rabbit loot recipes start here (Golden Carrot)
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("MadnessPendant2Animated"));
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("GoldenCarrot")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("RajahPelt")), 32);
				recipe.AddIngredient(ItemID.Bunny, 10);
				recipe.AddIngredient(ItemID.GoldBunny);
				recipe.AddIngredient(ItemID.BunnyHood);
				recipe.AddIngredient(ItemID.BunnyBanner);
				recipe.AddIngredient(ItemID.CorruptBunnyBanner, 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("AAMod").ItemType("RajahBag")), 1);
				recipe.AddRecipe();
				// Rajah Rabbit loot recipes start here (Platinum Carrot)
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("MadnessPendant2Animated"));
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("PlatinumCarrot")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("RajahPelt")), 32);
				recipe.AddIngredient(ItemID.Bunny, 10);
				recipe.AddIngredient(ItemID.GoldBunny);
				recipe.AddIngredient(ItemID.BunnyHood);
				recipe.AddIngredient(ItemID.BunnyBanner);
				recipe.AddIngredient(ItemID.CorruptBunnyBanner, 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("AAMod").ItemType("RajahBag")), 1);
				recipe.AddRecipe();
				// Rajah Rabbit loot recipes end here
				// POST-MOON LORD LOOT RECIPES START HERE!!!
				// Anubis (Awakened) loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("MadnessPendant3Animated"));
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("Scepter")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("SoulFragment")), 12);
				recipe.AddIngredient(ItemID.AntlionMandible, 10);
				recipe.AddIngredient(ItemID.SandBlock, 200);
				recipe.AddIngredient(ItemID.AncientBattleArmorMaterial, 2);
				recipe.AddIngredient(ItemID.SoulofLight, 20);
				recipe.AddIngredient(ItemID.SoulofNight, 20);
				recipe.AddIngredient(ItemID.SoulofFlight, 10);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("SoulOfSmite")), 20);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("SoulOfSpite")), 20);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("AAMod").ItemType("FAnubisBag")), 1);
				recipe.AddRecipe();
				// Anubis (Awakened) loot recipes end here
				// Athena (Awakened) loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("MadnessPendant3Animated"));
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("Owl")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("GoddessFeather")), 22);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("SkyCrystal")), 30);
				recipe.AddIngredient(ItemID.Feather, 22);
				recipe.AddIngredient(ItemID.Cloud, 40);
				recipe.AddIngredient(ItemID.RainCloud, 30);
				recipe.AddIngredient(ItemID.SnowCloudBlock, 20);
				recipe.AddIngredient(ItemID.SoulofFlight, 10);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("AAMod").ItemType("AthenaABag")), 1);
				recipe.AddRecipe();
				// Athena (Awakened) loot recipes end here
				// Greed (Awakened) loot recipes start here???
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("MadnessPendant3Animated"));
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("GoldenGrub")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("StoneShell")), 22);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("CovetiteOre")), 30);
				recipe.AddIngredient(ItemID.FlaskofGold, 2);
				recipe.AddIngredient(ItemID.CoinGun);
				recipe.AddIngredient(ItemID.GoldenFishingRod);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("AAMod").ItemType("GreedABag")), 1);
				recipe.AddRecipe();
				// The Equinox Worms loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("MadnessPendant3Animated"));
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("EquinoxWorm")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("Stardust")), 60);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("RadiumOre")), 30);
				recipe.AddIngredient(ItemID.SoulofLight, 50);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("AAMod").ItemType("EquinoxBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("MadnessPendant3Animated"));
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("EquinoxWorm")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("DarkEnergy")), 60);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("DarkmatterOre")), 30);
				recipe.AddIngredient(ItemID.SoulofNight, 50);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("AAMod").ItemType("EquinoxBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("MadnessPendant3Animated"));
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("EquinoxWorm")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("Stardust")), 30);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("RadiumOre")), 15);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("DarkEnergy")), 30);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("DarkmatterOre")), 15);
				recipe.AddIngredient(ItemID.SoulofLight, 25);
				recipe.AddIngredient(ItemID.SoulofNight, 25);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("AAMod").ItemType("EquinoxBag")), 1);
				recipe.AddRecipe();
				// The Equinox Worms loot recipes end here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("MadnessPendant3Animated"));
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("FlamesOfAnarchy")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("SoulOfSmite")), 50);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("SoulOfSpite")), 50);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("DaybreakIncinerite")), 4);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("EventideAbyssium")), 4);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("AAMod").ItemType("AHBag")), 1);
				recipe.AddRecipe();
				// Yamata loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("MadnessPendant3Animated"));
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("DreadSigil")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("DreadScale")), 25);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("TerrorSoul")), 10);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("SoulOfSpite")), 50);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("AAMod").ItemType("YamataBag")), 1);
				recipe.AddRecipe();
				// Yamata loot recipes end here
				// Akuma loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("MadnessPendant3Animated"));
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("DraconianSigil")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("CrucibleScale")), 25);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("SearingSpark")), 10);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("SoulOfSmite")), 50);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("AAMod").ItemType("AkumaBag")), 1);
				recipe.AddRecipe();
				// Akuma loot recipes end here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("MadnessPendant3Animated"));
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("ZeroTesseract")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("UnstableSingularity")), 25);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("ApocalyptitePlate")), 25);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("Discordium")), 4);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("Doomite")), 60);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("DoomiteScrap")), 40);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("AAMod").ItemType("ZeroBag")), 1);
				recipe.AddRecipe();
				// Rajah Rabbit (Awakened) loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("MadnessPendant3Animated"));
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("DiamondCarrot")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("ChampionPlate")), 22);
				recipe.AddIngredient(ItemID.Bunny, 30);
				recipe.AddIngredient(ItemID.GoldBunny, 2);
				recipe.AddIngredient(ItemID.BunnyHood, 2);
				recipe.AddIngredient(ItemID.BunnyBanner, 2);
				recipe.AddIngredient(ItemID.CorruptBunnyBanner, 2);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("AAMod").ItemType("RajahCache")), 1);
				recipe.AddRecipe();
				// Shen Doragon loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("MadnessPendant3Animated"));
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("ChaosSigil")), 1);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("ChaosScale")), 40);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("Discordium")), 15);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("SoulOfSmite")), 100);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("SoulOfSpite")), 100);
				recipe.AddIngredient((ModLoader.GetMod("AAMod").ItemType("SoulFragment")), 20);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("AAMod").ItemType("ShenCache")), 1);
				recipe.AddRecipe();
				// Shen Doragon loot recipes end here
			}
			// Modded Treasure Bags: Azercadmium
			if (ModLoader.GetMod("Azercadmium") != null)
			{
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Azercadmium").ItemType("CreepyMud")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Azercadmium").ItemType("DirtyMedal")), 1);
				recipe.AddIngredient(ItemID.CopperBar, 5);
				recipe.AddIngredient(ItemID.DirtBlock, 15);
				recipe.AddIngredient(ItemID.MudBlock, 15);
				recipe.AddIngredient(ItemID.Lens, 3);
				recipe.AddIngredient(ItemID.Gel, 15);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Azercadmium").ItemType("DirtballBag")), 1);
				recipe.AddRecipe();
				// Titan Tankorb loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Azercadmium").ItemType("AdamantiteEnergyCore")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Azercadmium").ItemType("TitanicEnergy")), 135);
				recipe.AddIngredient(ItemID.SoulofLight, 15);
				recipe.AddIngredient(ItemID.SoulofNight, 15);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Azercadmium").ItemType("TitanBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Azercadmium").ItemType("TitaniumEnergyCore")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Azercadmium").ItemType("TitanicEnergy")), 135);
				recipe.AddIngredient(ItemID.SoulofLight, 15);
				recipe.AddIngredient(ItemID.SoulofNight, 15);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Azercadmium").ItemType("TitanBag")), 1);
				recipe.AddRecipe();
				// Titan Tankorb loot recipes end here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Azercadmium").ItemType("FloppyDisc")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Azercadmium").ItemType("SoulofByte")), 30);
				recipe.AddIngredient((ModLoader.GetMod("Azercadmium").ItemType("DarkronBar")), 25);
				recipe.AddIngredient(ItemID.HallowedBar, 25);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Azercadmium").ItemType("ScavengerBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Azercadmium").ItemType("EmpressChalice")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Azercadmium").ItemType("ElementalGel")), 45);
				recipe.AddIngredient((ModLoader.GetMod("Azercadmium").ItemType("EmpressShard")), 14);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Azercadmium").ItemType("EmpressBag")), 1);
				recipe.AddRecipe();
			}
			// Modded Treasure Bags: Spirit Mod
			if (ModLoader.GetMod("SpiritMod") != null)
			{
				// Scarabeus loot recipes start here 
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("BismitePendant"));
				recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("ScarabIdol")), 1);
				recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("Chitin")), 30);
				recipe.AddIngredient(ItemID.AntlionMandible, 15);
				recipe.AddIngredient(ItemID.SandBlock, 25);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("SpiritMod").ItemType("BagOScarabs")), 1);
				recipe.AddRecipe();
				// Scarabeus loot recipes end here
				// Moon Jelly Wizard loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("BismitePendant"));
				recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("DreamlightJellyItem")), 1);
				recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("MoonJelly")), 10);
				recipe.AddIngredient(ItemID.Moonglow, 10);
				recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("Moonshot")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("SpiritMod").ItemType("MJWBag")), 1);
				recipe.AddRecipe();
				// Moon Jelly Wizard loot recipes end here
				// Vinewrath Bane loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("BismitePendant"));
				recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("ReachBossSummon")), 1);
				recipe.AddIngredient(ItemID.Vine, 50);
				recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("EnchantedLeaf")), 20);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("SpiritMod").ItemType("ReachBossBag")), 1);
				recipe.AddRecipe();
				// Vinewrath Bane loot recipes end here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("BismitePendant"));
				recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("JewelCrown")), 1);
				recipe.AddIngredient(ItemID.Feather, 10);
				recipe.AddIngredient(ItemID.Bone, 50);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("SpiritMod").ItemType("FlyerBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("BismitePendant"));
				recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("StarWormSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("AsteroidBlock")), 20);
				recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("CosmiliteShard")), 8);
				recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("SpaceJunkItem")), 20);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("SpiritMod").ItemType("SteamRaiderBag")), 1);
				recipe.AddRecipe();
				// HARDMODE LOOT RECIPES START HERE!!!
				// Infernus loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("SpiritPendant2Animated"));
				recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("CursedCloth")), 1);
				recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("InfernalAppendage")), 30);
				recipe.AddIngredient(ItemID.Fireblossom, 10);
				recipe.AddIngredient(ItemID.LivingFireBlock, 50);
				recipe.AddIngredient(ItemID.Hellstone, 100);
				recipe.AddIngredient(ItemID.LavaBucket);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("SpiritMod").ItemType("InfernonBag")), 1);
				recipe.AddRecipe();
				// Infernus loot recipes end here
				// Dusking loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("SpiritPendant2Animated"));
				recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("DuskCrown")), 1);
				recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("DuskStone")), 30);
				recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("MagalaScale")), 10);
				recipe.AddIngredient(ItemID.SoulofNight, 50);
				recipe.AddIngredient(ItemID.NightKey, 1);
				recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("ShadowflameSword")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("SpiritMod").ItemType("DuskingBag")), 1);
				recipe.AddRecipe();
				// Dusking loot recipes end here
				// Atlas loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient(this.GetItem("SpiritPendant2Animated"));
				recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("StoneSkin")), 1);
				recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("ArcaneGeyser")), 38);
				recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("SpiritBar")), 20);
				recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("SoulShred")), 10);
				recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("MoonStone")), 14);
				recipe.AddIngredient((ModLoader.GetMod("SpiritMod").ItemType("SynthMaterial")), 2);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("SpiritMod").ItemType("AtlasBag")), 1);
				recipe.AddRecipe();
				// Atlas loot recipes end here
			}
			// Modded Treasure Bags: Thorium Mod
			if (ModLoader.GetMod("ThoriumMod") != null)
			{
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("StrongFlareGun")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("StormFlare")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("SandStone")), 18);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ThoriumMod").ItemType("ThunderBirdBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("JellyfishResonator")), 1);
				recipe.AddIngredient(ItemID.PinkGel, 10);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("QueensGlowstick")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ThoriumMod").ItemType("JellyFishBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("UnholyShards")), 10);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("GrimPointer")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ThoriumMod").ItemType("CountBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("UnstableCore")), 1);
				recipe.AddIngredient(ItemID.Granite, 100);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ThoriumMod").ItemType("GraniteBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("AncientBlade")), 1);
				recipe.AddIngredient(ItemID.Marble, 100);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ThoriumMod").ItemType("HeroBag")), 1);
				recipe.AddRecipe();
				// Star Scouter loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("StarCaller")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("StarTrail")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ThoriumMod").ItemType("ScouterBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("StarCaller")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("GaussSpark")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ThoriumMod").ItemType("ScouterBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("StarCaller")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("HitScanner")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ThoriumMod").ItemType("ScouterBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("StarCaller")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("DistressCaller")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ThoriumMod").ItemType("ScouterBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("StarCaller")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("GaussKnife")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ThoriumMod").ItemType("ScouterBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("StarCaller")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("StarRod")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ThoriumMod").ItemType("ScouterBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("StarCaller")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("Roboboe")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ThoriumMod").ItemType("ScouterBag")), 1);
				recipe.AddRecipe();
				// Star Scouter loot recipes end here
				// HARDMODE LOOT RECIPES START HERE!!!
				// Borean Strider loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("StriderTear")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("GlacialSting")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ThoriumMod").ItemType("BoreanBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("StriderTear")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("GlacierFang")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ThoriumMod").ItemType("BoreanBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("StriderTear")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("FrostFang")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ThoriumMod").ItemType("BoreanBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("StriderTear")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("FreezeRay")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ThoriumMod").ItemType("BoreanBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("StriderTear")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("CryoFang")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ThoriumMod").ItemType("BoreanBag")), 1);
				recipe.AddRecipe();
				// Borean Strider loot recipes end here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("VoidLens")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("EyeofBeholder")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ThoriumMod").ItemType("BeholderBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("CursedCloth")), 22);
				recipe.AddIngredient(ItemID.PumpkinMoonMedallion, 1);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("TheLostCross")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ThoriumMod").ItemType("LichBag")), 1);
				recipe.AddRecipe();
				// Abyssion, The Forgotten One loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("AbyssalShadow2")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("TheIncubator")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ThoriumMod").ItemType("AbyssionBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("AbyssalShadow2")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("MantisPunch")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ThoriumMod").ItemType("AbyssionBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("AbyssalShadow2")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("TrenchSpitter")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ThoriumMod").ItemType("AbyssionBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("AbyssalShadow2")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("OldGodGrasp")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ThoriumMod").ItemType("AbyssionBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("AbyssalShadow2")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("SirensAllure")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ThoriumMod").ItemType("AbyssionBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("AbyssalShadow2")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("WhisperingHood")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("WhisperingTabard")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("WhisperingLeggings")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ThoriumMod").ItemType("AbyssionBag")), 1);
				recipe.AddRecipe();
				// Abyssion, The Forgotten One loot recipes end here
				// POST-MOON LORD LOOT RECIPES START HERE!!!
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("RagSymbol")), 2);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("OceanEssence")), 16);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("DeathEssence")), 16);
				recipe.AddIngredient((ModLoader.GetMod("ThoriumMod").ItemType("InfernoEssence")), 16);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ThoriumMod").ItemType("RagBag")), 1);
				recipe.AddRecipe();
			}
			// Modded Treasure Bags: Mod of Redemption
			if (ModLoader.GetMod("Redemption") != null)
			{
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("EggCrown")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("ChickenEgg")), 30);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("Grain")), 2);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Redemption").ItemType("KingChickenBag")), 1);
				recipe.AddRecipe();
				// Thorn, Bane of the Forest loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("HeartOfTheThorns")), 1);
				recipe.AddIngredient(ItemID.JungleSpores, 10);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("CursedGrassSword")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Redemption").ItemType("ThornBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("HeartOfTheThorns")), 1);
				recipe.AddIngredient(ItemID.JungleSpores, 10);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("CursedThornBow")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Redemption").ItemType("ThornBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("HeartOfTheThorns")), 1);
				recipe.AddIngredient(ItemID.JungleSpores, 10);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("RootTendril")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Redemption").ItemType("ThornBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("HeartOfTheThorns")), 1);
				recipe.AddIngredient(ItemID.JungleSpores, 10);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("ThornSeedBag")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Redemption").ItemType("ThornBag")), 1);
				recipe.AddRecipe();
				// Thorn, Bane of the Forest loot recipes end here
				// The Keeper loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("MysteriousTabletCrimson")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("DarkShard")), 4);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("OldGathicWaraxe")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Redemption").ItemType("TheKeeperBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("MysteriousTabletCorrupt")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("DarkShard")), 4);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("OldGathicWaraxe")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Redemption").ItemType("TheKeeperBag")), 1);
				recipe.AddRecipe();
				// The Keeper loot recipes end here
				// Seed of Infection loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("GeigerCounter")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("XenomiteShard")), 30);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("XenomiteGlaive")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Redemption").ItemType("XenomiteCrystalBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("GeigerCounter")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("XenomiteShard")), 30);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("XenomiteYoyo")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Redemption").ItemType("XenomiteCrystalBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("GeigerCounter")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("XenomiteShard")), 30);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("XenoCanister")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Redemption").ItemType("XenomiteCrystalBag")), 1);
				recipe.AddRecipe();
				// Seed of Infection loot recipes end here
				// HARDMODE LOOT RECIPES START HERE!!!
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("XenoEye")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("AntiXenomiteApplier")), 6);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("Xenomite")), 15);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Redemption").ItemType("InfectedEyeBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("KingSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("CyberPlating")), 14);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("KingCore")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("SlayerMedal")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("Holokey")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Redemption").ItemType("SlayerBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("CorruptedHeroSword")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("CorruptedXenomite")), 18);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("VlitchBattery")), 2);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Redemption").ItemType("VlitchCleaverBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("CorruptedWormMedallion")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("CorruptedXenomite")), 24);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("VlitchBattery")), 3);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("CorruptedStarliteBar")), 24);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("VlitchScale")), 30);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Redemption").ItemType("VlitchGigipedeBag")), 1);
				recipe.AddRecipe();
				// POST-MOON LORD LOOT RECIPES START HERE!!!
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("OmegaRadar")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("CorruptedXenomite")), 50);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("VlitchBattery")), 10);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("OblitBrain")), 24);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Redemption").ItemType("OmegaOblitBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("MedicKit1")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("BluePrints")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("Xenomite")), 30);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("AntiXenomiteApplier")), 10);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Redemption").ItemType("PZBag")), 1);
				recipe.AddRecipe();
				// Ancient Deity loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("SigilOfThorns")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("TuhonAura")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("Verenhimo")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("CursedThorns")), 20);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Redemption").ItemType("AkkaBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("SigilOfThorns")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("ViisaanKantele")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("UkonRuno")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Redemption").ItemType("AncientPowerCore")), 20);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Redemption").ItemType("UkkoBag")), 1);
				recipe.AddRecipe();
				// Ancient Deity loot recipes end here
			}
			// Modded Treasure Bags: Elements Awoken
			if (ModLoader.GetMod("ElementsAwoken") != null)
			{
				// Wasteland loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("WastelandSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("DesertEssence")), 12);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("Pincer")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("WastelandBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("WastelandSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("DesertEssence")), 12);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("ChitinStaff")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("WastelandBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("WastelandSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("DesertEssence")), 12);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("ScorpionBlade")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("WastelandBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("WastelandSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("DesertEssence")), 12);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("Pincer")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("Stinger")), 1);
				recipe.AddRecipe();
				// Wasteland loot recipes end here
				// Infernace loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("InfernaceSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("FireEssence")), 12);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("FlareSword")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("InfernaceBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("InfernaceSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("FireEssence")), 12);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("FireBlaster")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("InfernaceBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("InfernaceSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("FireEssence")), 12);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("InfernoVortex")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("InfernaceBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("InfernaceSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("FireEssence")), 12);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("FireHarpyStaff")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("InfernaceBag")), 1);
				recipe.AddRecipe();
				// Infernace loot recipes end here
				// HARDMODE LOOT RECIPES START HERE!!!
				// Scourge Fighter loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("ScourgeFighterSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("ScourgeSword")), 1);
				recipe.AddIngredient(ItemID.SoulofNight, 5);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("ScourgeFighterBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("ScourgeFighterSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("SignalBooster")), 1);
				recipe.AddIngredient(ItemID.SoulofNight, 5);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("ScourgeFighterBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("ScourgeFighterSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("ScourgeFighterMachineGun")), 1);
				recipe.AddIngredient(ItemID.SoulofNight, 5);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("ScourgeFighterBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("ScourgeFighterSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("ScourgeFighterRocketLauncher")), 1);
				recipe.AddIngredient(ItemID.RocketI, 100);
				recipe.AddIngredient(ItemID.SoulofNight, 5);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("ScourgeFighterBag")), 1);
				recipe.AddRecipe();
				// Scourge Fighter loot recipes end here
				// Regaroth loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("RegarothSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("SkyEssence")), 12);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("EyeOfRegaroth")), 1);
				recipe.AddIngredient(ItemID.SoulofLight, 5);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("RegarothBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("RegarothSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("SkyEssence")), 12);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("Starstruck")), 1);
				recipe.AddIngredient(ItemID.SoulofLight, 5);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("RegarothBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("RegarothSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("SkyEssence")), 12);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("TheSilencer")), 1);
				recipe.AddIngredient(ItemID.SoulofLight, 5);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("RegarothBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("RegarothSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("SkyEssence")), 12);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("EnergyStaff")), 1);
				recipe.AddIngredient(ItemID.SoulofLight, 5);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("RegarothBag")), 1);
				recipe.AddRecipe();
				// Regaroth loot recipes end here
				// Permafrost loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("PermafrostSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("FrostEssence")), 12);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("IceReaver")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("PermafrostBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("PermafrostSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("FrostEssence")), 12);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("Snowdrift")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("PermafrostBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("PermafrostSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("FrostEssence")), 12);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("IceWrath")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("PermafrostBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("PermafrostSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("FrostEssence")), 12);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("Flurry")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("PermafrostBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("PermafrostSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("FrostEssence")), 12);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("Frigidblaster")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("PermafrostBag")), 1);
				recipe.AddRecipe();
				// Permafrost loot recipes end here
				// Obsidious loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("ObsidiousSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("Magmarox")), 1);
				recipe.AddIngredient(ItemID.SoulofFright, 5);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("ObsidiousBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("ObsidiousSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("TerreneScepter")), 1);
				recipe.AddIngredient(ItemID.SoulofFright, 5);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("ObsidiousBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("ObsidiousSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("Ultramarine")), 1);
				recipe.AddIngredient(ItemID.SoulofFright, 5);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("ObsidiousBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("ObsidiousSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("VioletEdge")), 1);
				recipe.AddIngredient(ItemID.SoulofFright, 5);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("ObsidiousBag")), 1);
				recipe.AddRecipe();
				// Obsidious loot recipes end here
				// Aqueous loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("AqueousSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("WaterEssence")), 12);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("BrinyBuster")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("AqueousBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("AqueousSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("WaterEssence")), 12);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("BubblePopper")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("AqueousBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("AqueousSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("WaterEssence")), 12);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("HighTide")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("AqueousBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("AqueousSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("WaterEssence")), 12);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("OceansRazor")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("AqueousBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("AqueousSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("WaterEssence")), 12);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("TheWave")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("AqueousBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("AqueousSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("WaterEssence")), 12);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("Varee")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("AqueousBag")), 1);
				recipe.AddRecipe();
				// Aqueous loot recipes end here
				// POST-MOON LORD LOOT RECIPES START HERE!!!
				// The Temple Keepers loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("AncientDragonSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("WyrmClaw")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("TempleKeepersBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("AncientDragonSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("TemplesCrystal")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("TempleKeepersBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("AncientDragonSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("GazeOfInferno")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("TempleKeepersBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("AncientDragonSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("TheAllSeer")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("TempleKeepersBag")), 1);
				recipe.AddRecipe();
				// The Temple Keepers loot recipes end here
				// The Guardian loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("GuardianSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("Godslayer")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("GuardianBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("GuardianSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("InfernoStorm")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("GuardianBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("GuardianSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("TemplesWrath")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("GuardianBag")), 1);
				recipe.AddRecipe();
				// The Guardian loot recipes end here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("VolcanoxSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("Pyroplasm")), 35);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("VolcanicStone")), 18);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("VolcanoxBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("VoidLeviathanSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("VoidLeviathanHeart")), 4);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("VoidEssence")), 10);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("VoidLeviathanBag")), 1);
				recipe.AddRecipe();
				// Azana loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("AzanaSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("DiscordantOre")), 60);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("GleamOfAnnhialation")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("AzanaBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("AzanaSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("DiscordantOre")), 60);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("Pandemonium")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("AzanaBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("AzanaSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("DiscordantOre")), 60);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("PurgeRifle")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("AzanaBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("AzanaSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("DiscordantOre")), 60);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("Anarchy")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("AzanaBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("AzanaSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("DiscordantOre")), 60);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("ChaoticImpaler")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("AzanaBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("AzanaSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("DiscordantOre")), 60);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("AzanaMinionStaff")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("AzanaBag")), 1);
				recipe.AddRecipe();
				// Azana loot recipes end here
				// The Ancients loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("AncientsSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("AncientShard")), 6);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("Chromacast")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("AncientsBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("AncientsSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("AncientShard")), 6);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("TheFundamentals")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("AncientsBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("AncientsSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("AncientShard")), 6);
				recipe.AddIngredient((ModLoader.GetMod("ElementsAwoken").ItemType("Shimmerspark")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("ElementsAwoken").ItemType("AncientsBag")), 1);
				recipe.AddRecipe();
				// The Ancients loot recipes end here
			}
			// Modded Treasure Bags: PINKYMOD
			if (ModLoader.GetMod("pinkymod") != null)
			{
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("STItemMerchant")), 1);
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("SunsweptFeather")), 1);
				recipe.AddIngredient(ItemID.FlyingCarpet, 1);
				recipe.AddIngredient(ItemID.Feather, 10);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("pinkymod").ItemType("STBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("HOTCItem")), 1);
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("LavaRune")), 1);
				recipe.AddIngredient(ItemID.RecallPotion, 1);
				recipe.AddIngredient(ItemID.StoneBlock, 20);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("pinkymod").ItemType("HOTCTreasureBag")), 1);
				recipe.AddRecipe();
				// Heart of the Cavern summon item recipe
				recipe = new ModRecipe(this);
				recipe.AddIngredient(ItemID.StoneBlock, 10);
				recipe.AddIngredient(ItemID.Sapphire, 1);
				recipe.AddIngredient(ItemID.Ruby, 1);
				recipe.AddIngredient(ItemID.Emerald, 1);
				recipe.AddIngredient(ItemID.Topaz, 1);
				recipe.AddIngredient(ItemID.Amethyst, 1);
				recipe.AddIngredient(ItemID.Diamond, 1);
				recipe.AddIngredient(ItemID.Amber, 1);
				recipe.AddIngredient(ItemID.Compass, 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("pinkymod").ItemType("HOTCItem")), 1);
				recipe.AddRecipe();
				// HARDMODE LOOT RECIPES START HERE!!!
				// Mythril Slime loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("MythrilGel")), 1);
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("EnhancedGel")), 40);
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("MythofStars")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("pinkymod").ItemType("MythrilBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("MythrilGel")), 1);
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("EnhancedGel")), 40);
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("MythrilFlamethrower")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("pinkymod").ItemType("MythrilBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("MythrilGel")), 1);
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("EnhancedGel")), 40);
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("MythrilFlames")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("pinkymod").ItemType("MythrilBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("MythrilGel")), 1);
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("EnhancedGel")), 40);
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("MythrilSceptre")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("pinkymod").ItemType("MythrilBag")), 1);
				recipe.AddRecipe();
				// Mythril Slime loot recipes end here
				// Valdaris, the Harpy Aegis loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("ValdarisItem")), 1);
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("PandaenBar")), 20);
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("Shadelight")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("pinkymod").ItemType("Valdabag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("ValdarisItem")), 1);
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("PandaenBar")), 20);
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("StormKnife")), 500);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("pinkymod").ItemType("Valdabag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("ValdarisItem")), 1);
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("PandaenBar")), 20);
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("Infinitarian")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("pinkymod").ItemType("Valdabag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("ValdarisItem")), 1);
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("PandaenBar")), 20);
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("DaedalusRepeater")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("pinkymod").ItemType("Valdabag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("ValdarisItem")), 1);
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("PandaenBar")), 20);
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("ShardofLaputa")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("pinkymod").ItemType("Valdabag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("ValdarisItem")), 1);
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("PandaenBar")), 20);
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("BulwarkoftheWeak")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("pinkymod").ItemType("Valdabag")), 1);
				recipe.AddRecipe();
				// Valdaris, the Harpy Aegis loot recipes end here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("DCItem")), 1);
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("ConstructorSeal")), 1);
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("RogueMemory")), 30);
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("StaveoftheDungeonConstructor")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("pinkymod").ItemType("DCBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("MindGodItem")), 1);
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("Dissonance")), 10);
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("VoidTitanite")), 100);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("pinkymod").ItemType("GatekeeperTreasureBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("MindGodItem")), 1);
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("Dissonance")), 5);
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("VoidTitanite")), 20);
				recipe.AddIngredient((ModLoader.GetMod("pinkymod").ItemType("FabricofReality")), 25);
				recipe.AddIngredient(ItemID.FragmentVortex, 3);
				recipe.AddIngredient(ItemID.FragmentNebula, 3);
				recipe.AddIngredient(ItemID.FragmentSolar, 3);
				recipe.AddIngredient(ItemID.FragmentStardust, 3);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("pinkymod").ItemType("MindGodTreasureBag")), 1);
				recipe.AddRecipe();
			}
			// Modded Treasure Bags: Qwerty's Bosses and Items Mod
			if (ModLoader.GetMod("QwertysRandomContent") != null)
			{
				recipe = new ModRecipe(this);
				recipe.AddIngredient(ItemID.Compass, 1);
				recipe.AddIngredient(ItemID.IceBlock, 50);
				recipe.AddTile(TileID.WorkBenches);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("FrostCompass")), 1);
				recipe.AddRecipe();
				// Polar Exterminator loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("FrostCompass")), 1);
				recipe.AddIngredient(ItemID.Penguin, 60);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("PenguinClub")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("TundraBossBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("FrostCompass")), 1);
				recipe.AddIngredient(ItemID.Penguin, 60);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("PenguinLauncher")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("TundraBossBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("FrostCompass")), 1);
				recipe.AddIngredient(ItemID.Penguin, 60);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("PenguinWhistle")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("TundraBossBag")), 1);
				recipe.AddRecipe();
				// Polar Exterminator loot recipes end here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("FortressBossSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("CaeliteBar")), 20);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("CaeliteCore")), 10);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("FortressBossBag")), 1);
				recipe.AddRecipe();
				// Ancient Machine loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("AncientEmblem")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("AncientBlade")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("AncientMachineBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("AncientEmblem")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("AncientSniper")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("AncientMachineBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("AncientEmblem")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("AncientWave")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("AncientMachineBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("AncientEmblem")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("AncientThrow")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("AncientMachineBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("AncientEmblem")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("AncientMinionStaff")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("AncientMachineBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("AncientEmblem")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("AncientMissileStaff")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("AncientMachineBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("AncientEmblem")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("AncientLongbow")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("AncientMachineBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("AncientEmblem")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("AncientNuke")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("AncientMachineBag")), 1);
				recipe.AddRecipe();
				// Ancient Machine loot recipes end here
				// Noehtnap loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("RitualInterupter")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("EtimsMaterial")), 20);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("EyeOfDarkness")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("NoehtnapBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("RitualInterupter")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("EtimsMaterial")), 20);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("NoScope")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("NoehtnapBag")), 1);
				recipe.AddRecipe();
				// Noehtnap loot recipes end here
				// HARDMODE LOOT RECIPES START HERE!!!
				// The Hydra loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("HydraSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("HydraScale")), 25);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("HydraBarrage")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("HydraBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("HydraSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("HydraScale")), 25);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("HydraBeam")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("HydraBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("HydraSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("HydraScale")), 25);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("HydraCannon")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("HydraBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("HydraSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("HydraScale")), 25);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("HydraHeadStaff")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("HydraBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("HydraSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("HydraScale")), 25);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("HydraJavelin")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("HydraBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("HydraSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("HydraScale")), 25);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("Hydrent")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("HydraBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("HydraSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("HydraScale")), 25);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("Hydrill")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("HydraBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("HydraSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("HydraScale")), 25);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("HydraMissileStaff")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("HydraBag")), 1);
				recipe.AddRecipe();
				// The Hydra loot recipes end here
				// Imperious loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("BladeBossSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("SwordStormStaff")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("BladeBossBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("BladeBossSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("ImperiousTheIV")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("BladeBossBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("BladeBossSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("FlailSword")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("BladeBossBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("BladeBossSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("SwordMinionStaff")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("BladeBossBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("BladeBossSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("Arsenal")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("BladeBossBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("BladeBossSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("BladedArrowShaft")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("BladeBossBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("BladeBossSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("Imperium")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("BladeBossBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("BladeBossSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("Swordquake")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("BladeBossBag")), 1);
				recipe.AddRecipe();
				// Imperious loot recipes end here
				// Rune Ghost loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("SummoningRune")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("CraftingRune")), 25);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("IceScroll")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("RuneGhostBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("SummoningRune")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("CraftingRune")), 25);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("AggroScroll")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("RuneGhostBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("SummoningRune")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("CraftingRune")), 25);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("LeechScroll")), 25);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("RuneGhostBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("SummoningRune")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("CraftingRune")), 25);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("PursuitScroll")), 25);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("RuneGhostBag")), 1);
				recipe.AddRecipe();
				// Rune Ghost loot recipes end here
				// O.L.O.R.D loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("B4Summon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("B4Bow")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("B4Bag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("B4Summon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("B4GiantBow")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("B4Bag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("B4Summon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("DreadnoughtStaff")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("B4Bag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("B4Summon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("BlackHoleStaff")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("B4Bag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("B4Summon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("Jabber")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("B4Bag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("B4Summon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("QwertysRandomContent").ItemType("ExplosivePierce")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("QwertysRandomContent").ItemType("B4Bag")), 1);
				recipe.AddRecipe();
				// O.L.O.R.D loot recipes end here
			}
			if (ModLoader.GetMod("Laugicality") != null)
			{
				// Dune Sharkron loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Laugicality").ItemType("TastyMorsel")), 1);
				recipe.AddIngredient(ItemID.FlyingCarpet, 1);
				recipe.AddIngredient(ItemID.SandstorminaBottle, 1);
				recipe.AddIngredient((ModLoader.GetMod("Laugicality").ItemType("AncientShard")), 3);
				recipe.AddIngredient((ModLoader.GetMod("Laugicality").ItemType("Crystilla")), 12);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Laugicality").ItemType("DuneSharkronTreasureBag")), 1);
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Laugicality").ItemType("TastyMorsel")), 1);
				recipe.AddIngredient(ItemID.PharaohsMask, 1);
				recipe.AddIngredient(ItemID.SandstorminaBottle, 1);
				recipe.AddIngredient((ModLoader.GetMod("Laugicality").ItemType("AncientShard")), 3);
				recipe.AddIngredient((ModLoader.GetMod("Laugicality").ItemType("Crystilla")), 12);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Laugicality").ItemType("DuneSharkronTreasureBag")), 1);
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Laugicality").ItemType("TastyMorsel")), 1);
				recipe.AddIngredient(ItemID.PharaohsRobe, 1);
				recipe.AddIngredient(ItemID.SandstorminaBottle, 1);
				recipe.AddIngredient((ModLoader.GetMod("Laugicality").ItemType("AncientShard")), 3);
				recipe.AddIngredient((ModLoader.GetMod("Laugicality").ItemType("Crystilla")), 12);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Laugicality").ItemType("DuneSharkronTreasureBag")), 1);
				// Dune Sharkron loot recipes end here
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Laugicality").ItemType("ChilledMesh")), 1);
				recipe.AddIngredient(ItemID.IceBoomerang, 1);
				recipe.AddIngredient(ItemID.IceBlade, 1);
				recipe.AddIngredient(ItemID.SnowBlock, 75);
				recipe.AddIngredient(ItemID.IceBlock, 75);
				recipe.AddIngredient((ModLoader.GetMod("Laugicality").ItemType("FrostShard")), 3);
				recipe.AddIngredient((ModLoader.GetMod("Laugicality").ItemType("ChilledBar")), 30);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Laugicality").ItemType("HypothemaTreasureBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Laugicality").ItemType("MoltenMess")), 1);
				recipe.AddIngredient(ItemID.LavaCharm, 1);
				recipe.AddIngredient((ModLoader.GetMod("Laugicality").ItemType("DarkShard")), 3);
				recipe.AddIngredient((ModLoader.GetMod("Laugicality").ItemType("ObsidiumChunk")), 3);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Laugicality").ItemType("RagnarTreasureBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Laugicality").ItemType("AncientAwakener")), 1);
				recipe.AddIngredient(ItemID.Granite, 30);
				recipe.AddIngredient(ItemID.Marble, 30);
				recipe.AddIngredient((ModLoader.GetMod("Laugicality").ItemType("AndesiaCore")), 3);
				recipe.AddIngredient((ModLoader.GetMod("Laugicality").ItemType("DioritusCore")), 3);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Laugicality").ItemType("AnDioTreasureBag")), 1);
				recipe.AddRecipe();
				// HARDMODE LOOT RECIPES START HERE!!!
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Laugicality").ItemType("MechanicalMonitor")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Laugicality").ItemType("SteamBar")), 30);
				recipe.AddIngredient((ModLoader.GetMod("Laugicality").ItemType("SoulOfThought")), 30);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Laugicality").ItemType("AnnihilatorTreasureBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Laugicality").ItemType("SteamCrown")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Laugicality").ItemType("SteamBar")), 35);
				recipe.AddIngredient((ModLoader.GetMod("Laugicality").ItemType("SoulOfFraught")), 35);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Laugicality").ItemType("SlybertronTreasureBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Laugicality").ItemType("SuspiciousTrainWhistle")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Laugicality").ItemType("SteamBar")), 40);
				recipe.AddIngredient((ModLoader.GetMod("Laugicality").ItemType("SoulOfWrought")), 35);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Laugicality").ItemType("SteamTrainTreasureBag")), 1);
				recipe.AddRecipe();
			}
			if (ModLoader.GetMod("SacredTools") != null)
			{
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("DecreeSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("ArcticFur")), 20);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("DecreeMask")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("SacredTools").ItemType("DecreeBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("PumpkinLantern")), 1);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("PumpkinFlame")), 10);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("FlamingPumpkinMask")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("SacredTools").ItemType("PumpkinBag")), 1);
				recipe.AddRecipe();
				// Zombie Piglin Brute loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("PigmanBanner")), 1);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("GoldNugget")), 20);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("MissingFury")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("SacredTools").ItemType("BruteBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("PigmanBanner")), 1);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("GoldNugget")), 20);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("Sausbow")), 1);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("FlareBolt")), 75);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("SacredTools").ItemType("BruteBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("PigmanBanner")), 1);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("GoldNugget")), 20);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("DeadVoxel")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("SacredTools").ItemType("BruteBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("PigmanBanner")), 1);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("GoldNugget")), 20);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("Ribarang")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("SacredTools").ItemType("BruteBag")), 1);
				recipe.AddRecipe();
				// Zombie Piglin Brute loot recipes end here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("HarpySummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("HarpyDrop")), 10);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("HarpyMask")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("SacredTools").ItemType("HarpyBag")), 1);
				recipe.AddRecipe();
				// HARDMODE LOOT RECIPES START HERE!!!
				// Araneas loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("VenomSample")), 15);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("AraneasMask")), 1);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("HoariHemonga")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("SacredTools").ItemType("AraneasBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("VenomSample")), 15);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("AraneasMask")), 1);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("ArachnesGaze")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("SacredTools").ItemType("AraneasBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("VenomSample")), 15);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("AraneasMask")), 1);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("SanguineumVirgam")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("SacredTools").ItemType("AraneasBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("VenomSample")), 15);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("AraneasMask")), 1);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("RazorfangDagger")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("SacredTools").ItemType("AraneasBag")), 1);
				recipe.AddRecipe();
				// Araneas loot recipes end here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("HarpySummon2")), 1);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("GoldenFeather")), 10);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("HarpyMask2")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("SacredTools").ItemType("HarpyBag2")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("PrimordiaSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("PrimordialRune")), 20);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("PrimordiaMask")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("SacredTools").ItemType("PrimordiaBag")), 1);
				recipe.AddRecipe();
				// POST-MOON LORD LOOT RECIPES START HERE!!!
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("ShadowWrathSummonItem")), 1);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("TrueOblivionBar")), 30);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("OblivionMask")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("SacredTools").ItemType("OblivionBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("SerpentSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("VialFlame")), 35);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("SerpentMask")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("SacredTools").ItemType("SerpentBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("MoonEmblem")), 1);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("LunaticEssence")), 45);
				recipe.AddIngredient((ModLoader.GetMod("SacredTools").ItemType("TrophyLunarians")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("SacredTools").ItemType("LunarBag")), 1);
				recipe.AddRecipe();
			}
			if (ModLoader.GetMod("Ultranium") != null)
			{
				// Zephyr Squid loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("CoralBait")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("OceanScale")), 10);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("ZephyrBlade")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("SquidBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("CoralBait")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("OceanScale")), 10);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("ZephyrKnife")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("SquidBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("CoralBait")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("OceanScale")), 10);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("ZephyrTrident")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("SquidBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("CoralBait")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("OceanScale")), 10);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("ZephyrScepter")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("SquidBag")), 1);
				recipe.AddRecipe();
				// Zephyr Squid loot recipes end here
				// Glacieron loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("IceFood")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("IcePelt")), 15);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("GlacialFlail")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("IceDragonBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("IceFood")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("IcePelt")), 15);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("GlacialGun")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("IceDragonBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("IceFood")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("IcePelt")), 15);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("GlacialWand")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("IceDragonBag")), 1);
				recipe.AddRecipe();
				// Glacieron loot recipes end here
				// HARDMODE LOOT RECIPES START HERE!!!
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("DreadBeacon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("DreadFlame")), 20);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("DreadScale")), 15);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("DreadTooth")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("DreadBag")), 1);
				recipe.AddRecipe();
				// Xenanis loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("EtherealLantern")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("XenanisFlesh")), 20);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("EtherealBow")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("EtherealBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("EtherealLantern")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("XenanisFlesh")), 20);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("EtherealSword")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("EtherealBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("EtherealLantern")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("XenanisFlesh")), 20);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("EtherealTome")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("EtherealBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("EtherealLantern")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("XenanisFlesh")), 15);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("EtherealSummon")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("EtherealBag")), 1);
				recipe.AddRecipe();
				// Xenanis loot recipes end here
				// Ultrum summon item
				recipe = new ModRecipe(this);
				recipe.AddRecipeGroup("IronBar", 5);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("UltrumRockItem")), 50);
				recipe.AddTile(TileID.Anvils);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("BrokenUltrumSummon")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddRecipeGroup("IronBar", 5);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("UltrumRockItem")), 50);
				recipe.AddIngredient(ItemID.LunarBar, 5);
				recipe.AddTile(TileID.Anvils);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("UltrumSummon")), 1);
				recipe.AddRecipe();
				// Ultrum loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("UltrumSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("UltrumShard")), 28);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("UltraniumSword")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("UltrumBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("UltrumSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("UltrumShard")), 28);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("UltraniumStaff")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("UltrumBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("UltrumSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("UltrumShard")), 28);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("UltraTome")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("UltrumBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("UltrumSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("UltrumShard")), 28);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("UltraniumKunai")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("UltrumBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("UltrumSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("UltrumShard")), 28);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("UltraniumBow")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("UltrumBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("UltrumSummon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("UltrumShard")), 28);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("UltraFlail")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("UltrumBag")), 1);
				recipe.AddRecipe();
				// Ultrum loot recipes end here
				// Ignodium summon item
				recipe = new ModRecipe(this);
				recipe.AddRecipeGroup("IronBar", 5);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("IgnodiumRockItem")), 50);
				recipe.AddTile(TileID.Anvils);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("BrokenIgnodiumSummon")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddRecipeGroup("IronBar", 5);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("IgnodiumRockItem")), 50);
				recipe.AddIngredient(ItemID.LunarBar, 5);
				recipe.AddTile(TileID.Anvils);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("NetherBeacon")), 1);
				recipe.AddRecipe();
				// Ignodium loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("NetherBeacon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("HellShard")), 28);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("HellThrow")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("IgnodiumBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("NetherBeacon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("HellShard")), 28);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("HellFlail")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("IgnodiumBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("NetherBeacon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("HellShard")), 28);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("HellTome")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("IgnodiumBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("NetherBeacon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("HellShard")), 28);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("HellGun")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("IgnodiumBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("NetherBeacon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("HellShard")), 28);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("HellStaff")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("IgnodiumBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("NetherBeacon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("HellShard")), 28);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("HellJavelin")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("IgnodiumBag")), 1);
				recipe.AddRecipe();
				// Ignodium loot recipes end here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("DreadBeacon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("DreadFlame")), 20);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("DreadScale")), 15);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("DreadTooth")), 2);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("NightmareFuel")), 20);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("ExistentialDread")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("TrueDreadBag")), 1);
				recipe.AddRecipe();
				// Erebus loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("ErebusFood")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("NightmareScale")), 28);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("Caliginus")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("ErebusBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("ErebusFood")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("NightmareScale")), 28);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("CavumNigrum")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("ErebusBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("ErebusFood")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("NightmareScale")), 28);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("Crepus")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("ErebusBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("ErebusFood")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("NightmareScale")), 28);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("ErebusGuitar")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("ErebusBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("ErebusFood")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("NightmareScale")), 28);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("Exitium")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("ErebusBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("ErebusFood")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("NightmareScale")), 28);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("Inanis")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("ErebusBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("ErebusFood")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("NightmareScale")), 28);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("Nihil")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("ErebusBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("ErebusFood")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("NightmareScale")), 28);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("Noctis")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("ErebusBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("ErebusFood")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("NightmareScale")), 28);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("SolibusOrba")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("ErebusBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("ErebusFood")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("NightmareScale")), 28);
				recipe.AddIngredient((ModLoader.GetMod("Ultranium").ItemType("Umbra")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Ultranium").ItemType("ErebusBag")), 1);
				recipe.AddRecipe();
				// Erebus loot recipes end here
			}
			if (ModLoader.GetMod("Split") != null)
			{
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Split").ItemType("ShadowLocket")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Split").ItemType("SkullHeart")), 2);
				recipe.AddIngredient(ItemID.StrangeBrew, 16);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Split").ItemType("TheSpiritBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Split").ItemType("SnowBeacon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Split").ItemType("AmplifierItem")), 2);
				recipe.AddIngredient((ModLoader.GetMod("Split").ItemType("Sparky")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Split").ItemType("ElementOfIce")), 3);
				recipe.AddIngredient(ItemID.StrangeBrew, 20);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Split").ItemType("OneShotBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Split").ItemType("ElementOfWind")), 5);
				recipe.AddIngredient((ModLoader.GetMod("Split").ItemType("HailBow")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Split").ItemType("Stella")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Split").ItemType("AstralMayhem")), 1);
				recipe.AddIngredient(ItemID.Cloud, 30);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Split").ItemType("MenaceBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Split").ItemType("SinisterCandle")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Split").ItemType("ParaffinsBox")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Split").ItemType("GreaterStrangeBrew")), 16);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Split").ItemType("ParaffinBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Split").ItemType("AmberMirror")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Split").ItemType("ElementOfAncient")), 5);
				recipe.AddIngredient((ModLoader.GetMod("Split").ItemType("GreaterStrangeBrew")), 20);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Split").ItemType("MirageBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Split").ItemType("TrustedKey")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Split").ItemType("ElementOfPain")), 5);
				recipe.AddIngredient((ModLoader.GetMod("Split").ItemType("GreaterStrangeBrew")), 30);
				recipe.AddIngredient((ModLoader.GetMod("Split").ItemType("EtherealFeather")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Split").ItemType("InsurgentBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("Split").ItemType("BoxOfDesired")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Split").ItemType("ElementOfFire")), 5);
				recipe.AddIngredient((ModLoader.GetMod("Split").ItemType("GreatestStrangeBrew")), 16);
				recipe.AddIngredient((ModLoader.GetMod("Split").ItemType("RingOfSun")), 1);
				recipe.AddIngredient((ModLoader.GetMod("Split").ItemType("DragonShield")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("Split").ItemType("SethBag")), 1);
				recipe.AddRecipe();
			}
			if (ModLoader.GetMod("CalamityMod") != null)
			{
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("DriedSeafood")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictideBar")), 10);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient(ItemID.SandBlock, 50);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("SandCloak")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeDesertScourge")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("CalamityMod").ItemType("DesertScourgeBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("DecapoditaSprout")), 1);
				recipe.AddIngredient(ItemID.GlowingMushroom, 75);
				recipe.AddIngredient(ItemID.MushroomGrassSeeds, 10);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeCrabulon")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("CalamityMod").ItemType("CrabulonBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("Teratoma")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("TrueShadowScale")), 28);
				recipe.AddIngredient(ItemID.RottenChunk, 15);
				recipe.AddIngredient(ItemID.DemoniteBar, 10);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("FilthyGlove")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeHiveMind")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("CalamityMod").ItemType("HiveMindBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("BloodyWormFood")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("BloodSample")), 28);
				recipe.AddIngredient(ItemID.Vertebrae, 15);
				recipe.AddIngredient(ItemID.CrimtaneBar, 10);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("BloodstainedGlove")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgePerforators")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("CalamityMod").ItemType("PerforatorBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("OverloadedSludge")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("PurifiedGel")), 50);
				recipe.AddIngredient(ItemID.Gel, 500);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeSlimeGod")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("CalamityMod").ItemType("SlimeGodBag")), 1);
				recipe.AddRecipe();
				// HARDMODE LOOT RECIPES START HERE!!!
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("CryoKey")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("CryoBar")), 20);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("EssenceofEleum")), 10);
				recipe.AddIngredient(ItemID.FrostCore, 2);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("CryoStone")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeCryogen")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("CalamityMod").ItemType("CryogenBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("Seafood")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictideBar")), 15);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 10);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("SulphurousSand")), 50);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("SandCloak")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeAquaticScourge")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("CalamityMod").ItemType("AquaticScourgeBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("CharredIdol")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("EssenceofChaos")), 10);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("RoseStone")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeBrimstoneElemental")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("CalamityMod").ItemType("BrimstoneWaifuBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("BlightedEyeball")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("Calamitydust")), 12);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("EssenceofChaos")), 15);
				recipe.AddIngredient(ItemID.BrokenHeroSword, 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("ChaosStone")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeCalamitasClone")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("CalamityMod").ItemType("CalamitasBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("LureofEnthrallment")), 1);
				recipe.AddIngredient(ItemID.CratePotion, 5);
				recipe.AddIngredient(ItemID.SonarPotion, 5);
				recipe.AddIngredient(ItemID.FishingPotion, 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeLeviathanandSiren")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("CalamityMod").ItemType("LeviathanBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("AstralChunk")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("Stardust")), 50);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("AstralJelly")), 10);
				recipe.AddIngredient(ItemID.FallenStar, 50);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeAstrumAureus")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("CalamityMod").ItemType("AstrageldonBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("Abomination")), 1);
				recipe.AddIngredient(ItemID.Stinger, 20);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("PlagueCellCluster")), 12);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("InfectedArmorPlating")), 15);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgePlaguebringerGoliath")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("CalamityMod").ItemType("PlaguebringerGoliathBag")), 1);
				recipe.AddRecipe();
				// Ravager loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("AncientMedallion")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("FleshyGeodeT1")), 2);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("BloodPact")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("FleshTotem")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeRavager")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("CalamityMod").ItemType("RavagerBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("AncientMedallion")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("BarofLife")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("CoreofCalamity")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("BloodPact")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("FleshTotem")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeRavager")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("CalamityMod").ItemType("RavagerBag")), 1);
				recipe.AddRecipe();
				// Ravager loot recipes end here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("Starcore")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("Stardust")), 100);
				recipe.AddIngredient(ItemID.FallenStar, 120);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("GalacticaSingularity")), 20);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("ChromaticOrb")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeAstrumDeus")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("CalamityMod").ItemType("AstrumDeusBag")), 1);
				recipe.AddRecipe();
				// POST-MOON LORD LOOT RECIPES START HERE!!!
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("BirbPheromones")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("EffulgentFeather")), 25);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("BirdSeed")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeBumblebirb")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("CalamityMod").ItemType("BumblebirbBag")), 1);
				recipe.AddRecipe();
				// Providence loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("ProfanedCore")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("UnholyEssence")), 50);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("DivineGeode")), 20);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("ElysianAegis")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("ElysianWings")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("ProfanedMoonlightDye")), 3);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeProvidence")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("CalamityMod").ItemType("ProvidenceBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("NecroplasmicBeacon")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("RuinousSoul")), 15);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("Phantoplasm")), 80);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgePolterghast")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("CalamityMod").ItemType("PolterghastBag")), 1);
				recipe.AddRecipe();
				// Old Duke loot recipes start here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("BloodwormItem")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("SulphurousSand")), 100);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("DukeScales")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeOldDuke")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("CalamityMod").ItemType("OldDukeBag")), 1);
				recipe.AddRecipe();
				recipe = new ModRecipe(this);
				recipe.AddIngredient(ItemID.FishronBossBag, 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("BloodwormItem")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("DukeScales")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeOldDuke")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("CalamityMod").ItemType("OldDukeBag")), 1);
				recipe.AddRecipe();
				// Old Duke loot recipes end here
				recipe = new ModRecipe(this);
				recipe.AddIngredient(this.GetItem("EmptyTreasureBag"));
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("CosmicWorm")), 1);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("CosmiliteBar")), 30);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("CosmiliteBrick")), 210);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("VictoryShard")), 5);
				recipe.AddIngredient((ModLoader.GetMod("CalamityMod").ItemType("KnowledgeDevourerofGods")), 1);
				recipe.AddTile(TileID.DemonAltar);
				recipe.SetResult((ModLoader.GetMod("CalamityMod").ItemType("DevourerofGodsBag")), 1);
				recipe.AddRecipe();
				// Note: Add Yharon boss treasure bag recipe when phases aren't bugged.
			}
		}
	}
}