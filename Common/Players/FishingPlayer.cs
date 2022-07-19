using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrariaFishingOverhaul.Common.Players
{
    public class FishingPlayer: ModPlayer
    {
        public int bobberAmount = 1;

        public ref int getBobberAmount() {
            return ref bobberAmount;
        }

        public override void ResetEffects()
        {
            base.ResetEffects();
            bobberAmount = 1;
        }

    }
}
