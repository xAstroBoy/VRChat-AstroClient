using System;
using AstroClient.Cheetos;
using DayClientML2.Utility.Extensions;

namespace AstroClient
{
    class welcome : GameEvents
    {

        internal static bool booleanhere = false;
        public override void OnWorldReveal(string id, string name, string asseturl)
        {

            if (!booleanhere)
            {
                
                CheetosHelpers.SendHudNotification($"Welcome Back {LocalPlayerUtils.GetSelfPlayer().DisplayName()} \n AstroClient Made By\n AstroBoy, Cheetos, Mora");
                booleanhere = true;
            }
        }
    }
}
