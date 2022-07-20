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
        // Bobber Management
        public int bobberAmount = 1;

        public ref int getBobberAmount() {
            return ref bobberAmount;
        }

        public override void ResetEffects()
        {
            base.ResetEffects();
            bobberAmount = 1;
            HoldingCoralFishingPole = false;
            HoldingFisherBee = false;
        }

        // CatchFish Management
        public bool HoldingCoralFishingPole;
        public bool HoldingFisherBee;

        public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar, ref Vector2 sonarPosition)
        {
            if (HoldingCoralFishingPole && Player.ZoneBeach && Main.rand.NextBool(18))
            {
                itemDrop = ItemID.OceanCrate;
                npcSpawn = 0;
            }
        }
        public int calculateFishingPower(int power)
        {
            return (int)(power * 1.25f);
        }
    }
}
