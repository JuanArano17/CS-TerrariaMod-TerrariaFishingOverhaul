using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using System.Collections.Generic;

namespace TerrariaFishingOverhaul.Content.Players{
	public class FishingPlayer : ModPlayer{
		public readonly List<Content.Items.FishingRods.BiomeFishingRod> ActiveBiomeRods = new List<Content.Items.FishingRods.BiomeFishingRod>(10);

															
		public override void ResetEffects()
		{
			ActiveBiomeRods.Clear();
		}

		public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition)
		{
			foreach (var biomeFishingRod in ActiveBiomeRods)
			{
				if (biomeFishingRod.IsInRodBiome(Player) && Main.rand.NextBool(biomeFishingRod.ConsequentChance))
				{
					itemDrop = biomeFishingRod.RodCrateType;
					npcSpawn = 0;
					return;
				}
			}
		}
	}
}

