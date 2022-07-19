using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using TerrariaFishingOverhaul.Content.Items.FishingRods;

namespace TerrariaFishingOverhaul.Content.Items.FishingRods
{
	public class KrakensTentacle : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Kraken's Tentacle");
			Tooltip.SetDefault("");

			ItemID.Sets.CanFishInLava[Item.type] = true;

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			// These are copied through the CloneDefaults method:
			// Item.width = 24;
			// Item.height = 28;
			// Item.useStyle = ItemUseStyleID.Swing;
			// Item.useAnimation = 8;
			// Item.useTime = 8;
			// Item.UseSound = SoundID.Item1;
			Item.CloneDefaults(ItemID.GoldenFishingRod);

			Item.fishingPole = 70; // Sets the poles fishing power
			Item.shootSpeed = 16; // Sets the speed in which the bobbers are launched. Wooden Fishing Pole is 9f and Golden Fishing Rod is 17f.
			//Item.shoot = ModContent.ProjectileType<Projectiles.KrakenBobber>(); // The Bobber projectile.
			Item.shoot = ModContent.ProjectileType<Projectiles.KrakenBobber>();
		}

		// Grants the High Test Fishing Line bool if holding the item.
		// NOTE: Only triggers through the hotbar, not if you hold the item by hand outside of the inventory.
		public override void HoldItem(Player player) {
			player.accFishingLine = true;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			int bobberAmount = 1; //Main.rand.Next(3, 6); 3 to 5 bobbers
			float spreadAmount = 75f; // how much the different bobbers are spread out.

			for (int index = 0; index < bobberAmount; ++index) {
				Vector2 bobberSpeed = velocity + new Vector2(Main.rand.NextFloat(-spreadAmount, spreadAmount) * 0.05f, Main.rand.NextFloat(-spreadAmount, spreadAmount) * 0.05f);

				// Generate new bobbers
				Projectile.NewProjectile(source, position, bobberSpeed, type, 0, 0f, player.whoAmI);
			}
			return false;
		}

		public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.WoodFishingPole);
			recipe.AddIngredient(ModContent.ItemType<IcyFishingPole>());
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