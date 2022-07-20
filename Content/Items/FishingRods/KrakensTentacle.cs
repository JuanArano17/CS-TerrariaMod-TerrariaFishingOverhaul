using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TerrariaFishingOverhaul.Content.Items.FishingRods;

namespace TerrariaFishingOverhaul.Content.Items.FishingRods
{
	public class KrakensTentacle : ModFishingRod
	{
		public override void SetStaticDefaults() {
			base.SetStaticDefaults();
			DisplayName.SetDefault("Kraken's Tentacle");
			Tooltip.SetDefault("");
			ItemID.Sets.CanFishInLava[Item.type] = true;
		}

		public override void SetDefaults() {
			Item.CloneDefaults(ItemID.GoldenFishingRod);
			Item.fishingPole = 70; // Sets the poles fishing power
			Item.shootSpeed = 16; // Sets the speed in which the bobbers are launched. Wooden Fishing Pole is 9f and Golden Fishing Rod is 17f.
			Item.shoot = ModContent.ProjectileType<Projectiles.KrakenBobber>();
		}


		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.WoodFishingPole);
			recipe.AddIngredient(ModContent.ItemType<FrozenFishingPole>());
			recipe.AddIngredient(ModContent.ItemType<CoralFishingPole>());
			recipe.AddIngredient(ItemID.ScarabFishingRod);
			recipe.AddIngredient(ItemID.FiberglassFishingPole);
			recipe.AddIngredient(ItemID.HotlineFishingHook);
			recipe.AddIngredient(ItemID.GoldenFishingRod);
			recipe.AddTile(TileID.Furnaces);
			recipe.Register();
		}
	}
}