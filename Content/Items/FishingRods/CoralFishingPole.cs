using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TerrariaFishingOverhaul.Content.Items.FishingRods
{
    internal class CoralFishingPole : ModItem{
		public int bobberAmount = 1;
		
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Coral Fishing Pole");
			Tooltip.SetDefault("");

			// Allows the pole to fish in lava
			//ItemID.Sets.CanFishInLava[Item.type] = true;

			// Amount of items required to get unlimited GenericFishingRods in Journey
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			// These are copied through the CloneDefaults method:
			// Item.width = 24;
			// Item.height = 28;
			// Item.useStyle = ItemUseStyleID.Swing;
			// Item.useAnimation = 8;
			// Item.useTime = 8;
			// Item.UseSound = SoundID.Item1;
			Item.CloneDefaults(ItemID.WoodFishingPole);

			Item.fishingPole = 30; // Sets the poles fishing power
			Item.shootSpeed = 12f; // Sets the speed in which the bobbers are launched. Wooden Fishing Pole is 9f and Golden Fishing Rod is 17f.
			Item.shoot = ModContent.ProjectileType<Projectiles.CoralBobber>(); // The Bobber projectile.
		}

		// Grants the High Test Fishing Line bool if holding the item.
		// NOTE: Only triggers through the hotbar, not if you hold the item by hand outside of the inventory.
		public override void HoldItem(Player player)
		{
			player.accFishingLine = true;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			//int bobberAmount =  30; //Main.rand.Next(3, 6); 3 to 5 bobbers
			float spreadAmount = 75f; // how much the different bobbers are spread out.

			for (int index = 0; index < bobberAmount; ++index) {
				Vector2 bobberSpeed = velocity + new Vector2(Main.rand.NextFloat(-spreadAmount, spreadAmount) * 0.05f, Main.rand.NextFloat(-spreadAmount, spreadAmount) * 0.05f);

				// Generate new bobbers
				Projectile.NewProjectile(source, position, bobberSpeed, type, 0, 0f, player.whoAmI);
			}
			return false;
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
