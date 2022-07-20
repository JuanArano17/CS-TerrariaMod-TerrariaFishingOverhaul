using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TerrariaFishingOverhaul.Content.Items.FishingRods
{
	public class CopperFishingPole : ModFishingRod
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Copper Fishing Pole");
			Tooltip.SetDefault("Simple but better than the Wood Fishing Pole.");
		}

		public override void SetDefaults() {
			base.SetDefaults();
			Item.fishingPole = 10; 
			Item.shoot = ModContent.ProjectileType<Projectiles.CopperBobber>(); // The Bobber projectile.
			Item.shootSpeed = 10f;
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CopperBar, 8);
			recipe.AddTile(TileID.Furnaces);
			recipe.Register();
		}
	}
}