using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrariaFishingOverhaul.Content.Items.Accessories
{
    public class SkilledWidget : ModItem
	{
		private int amountOfLines = 20;	// The amount of fishing lines added.

		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("1 amount of fishing lines");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.maxStack = 1;
			Item.width = 40;
			Item.height = 40;
			Item.accessory = true;
			Item.defense = 4;
			Item.vanity = true;
			Item.rare = ItemRarityID.Green;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<Common.Players.FishingPlayer>().getBobberAmount() += amountOfLines;
		}
		public override void AddRecipes()
		{
			Recipe recipe1 = CreateRecipe();
			recipe1.AddIngredient(ItemID.IronBar, 8);
			recipe1.AddIngredient(ItemID.HighTestFishingLine);
			recipe1.AddIngredient(ItemID.Hook);
			recipe1.AddTile(TileID.WorkBenches);
			recipe1.Register();
			
			Recipe recipe2 = CreateRecipe();
			recipe2.AddIngredient(ItemID.LeadBar, 8);
			recipe2.AddIngredient(ItemID.HighTestFishingLine);
			recipe2.AddIngredient(ItemID.Hook);
			recipe2.AddTile(TileID.WorkBenches);
			recipe2.Register();
		}
	}
}
