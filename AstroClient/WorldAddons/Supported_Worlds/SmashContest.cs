﻿namespace AstroClient
{
	using AstroLibrary.Console;
	using AstroClient.Extensions;
	using AstroLibrary.Finder;
	using AstroClient.Variables;

	public class SmashContest : GameEvents
	{
		public override void OnWorldReveal(string id, string name, string asseturl)
		{
			if (id == WorldIds.SmashContest)
			{
				ModConsole.DebugLog("Recognized Smash Contest, Searching For Sandbag");
				var sandbag = GameObjectFinder.Find("SandBag");
				if (sandbag != null)
				{
					ModConsole.Log("Registered Sandbag To World objects!");
					sandbag.AddToWorldUtilsMenu();
				}
			}
		}
	}
}