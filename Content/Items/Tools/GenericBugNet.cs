using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace TerrariaFishingOverhaul.Content.Items.Tools
{
	// This is an example bug net designed to demonstrate the use cases for various hooks related to catching NPCs such as critters with items.
	public class GenericBugNet : ModItem
	{
		public override string Texture => $"Terraria/Images/Item_{ItemID.BugNet}";

		public override void SetStaticDefaults() {
			// This set is needed to define an item as a tool for catching NPCs at all.
			// An additional set exists called LavaproofCatchingTool which will allow your item to freely catch the Underworld's lava critters. Use it accordingly.
			ItemID.Sets.CatchingTool[Item.type] = true;

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			// These are, with a few modifications, the properties applied to the base Bug Net; they're provided here so that you can mess with them as you please.
			// Explanations on them will be glossed over here, as they're not the primary point of the lesson.
			// Common Properties
			Item.width = 24;
			Item.height = 28;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.buyPrice(0, 0, 40);

			// Use Properties
			Item.useAnimation = 25;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.UseSound = SoundID.Item1;
		}

		public override bool? CanCatchNPC(NPC target, Player player) {
			// This hook is used to determine whether or not your catching tool can catch a given NPC.
			// This returns null by default, which allows vanilla to decide whether or not the NPC should be caught.
			// Returning true forces the NPC to be caught, while returning false forces the NPC to not be caught.
			// If you're unsure what to return, return null.
			// For this example, we'll give our example bug net a 20% chance to catch lava critters successfully (50% with a Warmth Potion buff active).
			if (ItemID.Sets.IsLavaBait[target.catchItem]) {
				if (Main.rand.NextBool(player.resistCold ? 2 : 5)) {
					return true;
				}
			}

			// For all cases where true isn't explicitly returned, we'll return null so that vanilla catching rules and effects can take place.
			return null;
		}
		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.Furnaces);
			recipe.Register();
		}
	}
}