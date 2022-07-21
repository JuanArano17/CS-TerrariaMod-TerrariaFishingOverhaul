using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrariaFishingOverhaul.Content.Projectiles
{
	public class KrakenBobber : ModBobber
	{
		public override void SetStaticDefaults()
		{
			PossibleLineColors = new Color[] {
				new Color(66, 1, 22), // Rojo oscuro
				new Color(56, 5, 133) // Violeta claro
			};
			DisplayName.SetDefault("Kraken's Bobber");
		}
	}
}