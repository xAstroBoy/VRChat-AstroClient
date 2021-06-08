namespace AstroClient
{
	using AstroLibrary;
	using AstroLibrary.Extensions;
	using System.Collections.Generic;

	internal class Welcome : GameEvents
    {
        internal static bool booleanhere = false;

        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
            if (!booleanhere)
            {
                CheetosHelpers.SendHudNotification($"Welcome Back <Color=#c242f5>{ LocalPlayerUtils.GetSelfPlayer().DisplayName()}</color> \n 	<color=#42f5f2>AstroClient</color> Made By\n <color=#2A3EBF>AstroBoy</color> and <color=#F79239>Cheetos</color>");
                booleanhere = true;
            }
        }
    }
}