namespace AstroClient
{
    using System.Collections.Generic;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using Variables;

    internal class SmashContest : GameEvents
    {
        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
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