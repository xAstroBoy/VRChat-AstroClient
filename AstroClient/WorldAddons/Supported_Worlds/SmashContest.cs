namespace AstroClient
{
	using AstroClient.Variables;
	using AstroLibrary.Console;
	using AstroLibrary.Extensions;
	using AstroLibrary.Finder;
	using System.Collections.Generic;

	public class SmashContest : GameEvents
    {
        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
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