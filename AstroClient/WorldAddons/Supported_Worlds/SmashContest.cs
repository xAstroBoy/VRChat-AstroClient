using AstroClient.ConsoleUtils;
using AstroClient.extensions;
using AstroClient.Finder;
using AstroClient.Variables;

namespace AstroClient
{
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