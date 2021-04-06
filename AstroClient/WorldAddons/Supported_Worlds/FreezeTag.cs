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
    public class FreezeTag : Overridables
    {

        public override void OnWorldReveal(string id, string name, string asseturl)
        {
            if (id == WorldIds.FreezeTag)
            {
                ModConsole.Log($"Recognized {name} World, removing anti-cheat mechanism!");
                var SpawnRoof = GameObjectFinder.Find("spawn/mainroom 2/ceiling");
                var Barriers = GameObjectFinder.Find("packmanmap/barriors");
                var OutsideMazePlane = GameObjectFinder.Find("packmanmap/Plane (4)");
                var InternalMazePlane = GameObjectFinder.Find("packmanmap/Plane (3)");
                var possiblenaticheatplane = GameObjectFinder.Find("packmanmap/Plane (2)");
                SpawnRoof.DestroyMeLocal();
                Barriers.DestroyMeLocal();
                OutsideMazePlane.DestroyMeLocal();
                InternalMazePlane.DestroyMeLocal();
                possiblenaticheatplane.DestroyMeLocal();

            }
        }
    }
}
