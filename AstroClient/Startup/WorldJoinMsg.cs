using AstroClient.ConsoleUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroClient.Startup
{
    class WorldJoinMsg : GameEvents
    {

        public override void OnWorldReveal(string id, string name, string asseturl)
        {
            ModConsole.Log("You entered this world : " + name, System.Drawing.Color.Goldenrod);
            ModConsole.Log("World ID : " + id, System.Drawing.Color.Goldenrod);
            ModConsole.Log("World Asset URL : " + asseturl, System.Drawing.Color.Goldenrod);
        }

    }
}
