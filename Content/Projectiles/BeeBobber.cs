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
	public class BeeBobber : ModBobber
	{
		public override void SetStaticDefaults()
		{
			PossibleLineColors = new Color[] 
			{ 
				new Color(209, 202, 25) 
			};
			DisplayName.SetDefault("Bee Bobber");
		}

	}
}