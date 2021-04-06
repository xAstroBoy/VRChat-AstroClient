using AstroClient.ConsoleUtils;
using AstroClient.extensions;
using AstroClient.Finder;
using AstroClient.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroClient
{
    public class SmashContest : Overridables
    {

        public override void OnWorldReveal()
        {
            if (WorldUtils.GetWorldID() == WorldIds.SmashContest)
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
