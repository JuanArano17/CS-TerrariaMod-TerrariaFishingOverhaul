using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace TerrariaFishingOverhaul.Content.Items.Accessories
{
	public class ExampleAccessory : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("25% increased damage, this is an additive multiplier with other damage bonuses\n"
							 + "12% increased multiplicative damage multiplier; this is multiplicative with other damage bonuses\n"
							 + "Increases base damage for all weapons by 4\n"
							 + "Increases total damage for all weapons by 5\n"
							 + "10% increased melee crit chance\n"
							 + "100% increased example knockback\n"
							 + "Magic attacks ignore an additional 5 defense points\n"
							 + "Increases ranged firing speed by 15%");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.maxStack = 1;
			Item.width = 40;
			Item.height = 40;
			Item.accessory = true;
			Item.defense = 10;
			//Item.masterOnly = true;
			Item.vanity = true;
			Item.rare = ItemRarityID.Master;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetModPlayer<Common.Players.FishingPlayer>().getBobberAmount() = +4;
			player.GetDamage(DamageClass.Melee).Flat += 7000;
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
