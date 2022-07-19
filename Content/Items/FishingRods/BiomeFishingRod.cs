using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;

namespace TerrariaFishingOverhaul.Content.Items.FishingRods{
	public abstract class BiomeFishingRod : ModItem{
		public abstract int RodCrateType { 
			get; 
		}

		public virtual int ConsequentChance => 5;

		public override void HoldItem(Player player){
			player.GetModPlayer<Players.FishingPlayer>().ActiveBiomeRods.Add(this);
		}

		public abstract bool IsInRodBiome(Player player);
	}
}

