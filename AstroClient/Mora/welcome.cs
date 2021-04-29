using AstroClient.Cheetos;
using DayClientML2.Utility.Extensions;

namespace AstroClient
{
	internal class Welcome : GameEvents
	{
		internal static bool booleanhere = false;

		public override void OnWorldReveal(string id, string name, string asseturl)
		{
			if (!booleanhere)
			{
				CheetosHelpers.SendHudNotification($"Welcome Back <Color=#c242f5>{ LocalPlayerUtils.GetSelfPlayer().DisplayName()}</color> \n 	<color=#42f5f2>AstroClient</color> Made By\n <color=#2A3EBF>AstroBoy</color>, <color=#F79239>Cheetos</color>, <color=#b619ff>Mora</color>");
				booleanhere = true;
			}
		}
	}
}