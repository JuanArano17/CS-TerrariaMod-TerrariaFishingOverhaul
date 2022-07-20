using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TerrariaFishingOverhaul.Content.Items.FishingRods
{
    public class CoralFishingPole : ModFishingRod
	{
		// Methods 
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Coral Fishing Pole");
			//Tooltip.SetDefault("");
		}

		public override void SetDefaults()
		{
			base.SetDefaults();
			Item.fishingPole = 30; // Sets the poles fishing power
			Item.shootSpeed = 13f; // Sets the speed in which the bobbers are launched. Wooden Fishing Pole is 9f and Golden Fishing Rod is 17f.
			Item.shoot = ModContent.ProjectileType<Projectiles.CoralBobber>(); 
		}

		public override void HoldItem(Player player)
		{
			base.HoldItem(player);
			player.GetModPlayer<Common.Players.FishingPlayer>().HoldingCoralFishingPole = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CopperBar, 15);
			recipe.AddTile(TileID.Furnaces);
			recipe.Register();
		}
	}
}
