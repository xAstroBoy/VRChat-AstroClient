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
    public class TheGreatPug : Overridables
    {

        public override void OnWorldReveal()
        {
            if (WorldUtils.GetWorldID() == WorldIds.TheGreatPug)
            {
                ModConsole.Log("Recognized The Great Pug World, Removing Basement Door & Kitchen Door.");
                var BasementDoor = GameObjectFinder.Find(" - Props/Props (Static) - Hallways - First Floor/door-private");
                var Kitchen1 = GameObjectFinder.Find("great_pug/kitchen_door");
                var kitchen2 = GameObjectFinder.Find("great_pug/kitchen_door_chrome");
                var frame = GameObjectFinder.Find("great_pug/door-frame_004");
                var kitchen4 = GameObjectFinder.Find("great_pug/Cube_022  (GLASS)");
                var Signs = GameObjectFinder.Find(" - Props/Props (Static) - Global - Udon In Progress");
                var rope = GameObjectFinder.Find(" - Props/Props (Static) - Hallways - First Floor/Velvet Rope (1)");
                rope.DestroyMeLocal();
                Signs.DestroyMeLocal();
                BasementDoor.DestroyMeLocal();
                Kitchen1.DestroyMeLocal();
                kitchen2.DestroyMeLocal();
                frame.removeAllCollider();
                rope.removeAllCollider();
            }

        }
    }
}
