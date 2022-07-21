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
	public class CoralBobber : ModBobber
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Coral Bobber");
		}
	}
}