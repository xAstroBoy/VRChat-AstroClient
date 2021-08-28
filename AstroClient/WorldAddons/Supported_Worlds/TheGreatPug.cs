namespace AstroClient
{
    using AstroClient.Variables;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using System.Collections.Generic;

    public class TheGreatPug : GameEvents
    {
        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
            if (id == WorldIds.TheGreatPug)
            {
                ModConsole.Log($"Recognized {Name} World, Removing Basement Door & Kitchen Door.");
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
                frame.RemoveAllColliders();
                rope.RemoveAllColliders();
            }
        }
    }
}