using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TerrariaFishingOverhaul.Content.Items.CraftingItems
{
	public class BasicFishingLine : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("A crafting ingredient for fishing things."); // The (English) text shown below your item's name
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 100; // How many items are needed in order to research duplication of this item in Journey mode. See https://terraria.gamepedia.com/Journey_Mode/Research_list for a list of commonly used research amounts depending on item type.
		}

		public override void SetDefaults()
		{
			Item.width = 20; // The item texture's width
			Item.height = 20; // The item texture's height

			Item.maxStack = 999; // The item's max stack value
			Item.value = Item.buyPrice(copper: 3); // The value of the item in copper coins. Item.buyPrice & Item.sellPrice are helper methods that returns costs in copper coins based on platinum/gold/silver/copper arguments provided to it.
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ItemID.Cobweb, 24);
			recipe1.AddTile(TileID.Loom);
			recipe1.Register();
		}

		// Researching the Example item will give you immediate access to the torch, block, wall and workbench!
		public override void OnResearched(bool fullyResearched)
		{
			if (fullyResearched)
			{
				CreativeUI.ResearchItem(ItemID.Torch);
				CreativeUI.ResearchItem(ItemID.RichMahoganySword);

			}
		}
	}
}
