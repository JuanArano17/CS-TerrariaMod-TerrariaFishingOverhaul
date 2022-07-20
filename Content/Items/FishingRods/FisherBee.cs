using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TerrariaFishingOverhaul.Content.Items.FishingRods
{
	public class FisherBee : ModFishingRod
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Fisher Bee");
			Tooltip.SetDefault("");
		}

		public override void SetDefaults()
		{
			base.SetDefaults();
			Item.fishingPole = 25; // Sets the poles fishing power
			Item.shootSpeed = 15f; // Sets the speed in which the bobbers are launched. Wooden Fishing Pole is 9f and Golden Fishing Rod is 17f.
			Item.shoot = ModContent.ProjectileType<Projectiles.BeeBobber>(); // The Bobber projectile.
		}

		// Grants the High Test Fishing Line bool if holding the item.
		// NOTE: Only triggers through the hotbar, not if you hold the item by hand outside of the inventory.
		public override void HoldItem(Player player)
		{
			base.HoldItem(player);
			player.GetModPlayer<Common.Players.FishingPlayer>().HoldingFisherBee = true;
			if (player.ZoneHive) 
			{
				player.fishingSkill += player.GetModPlayer<Common.Players.FishingPlayer>().calculateFishingPower(20); 
			}
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
