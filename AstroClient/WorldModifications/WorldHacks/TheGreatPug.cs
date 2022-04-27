using AstroClient.ClientActions;

namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections.Generic;
    using Tools.Extensions;
    using WorldsIds;
    using xAstroBoy;

    internal class TheGreatPug : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.Event_OnWorldReveal += OnWorldReveal;
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.TheGreatPug)
            {
                Log.Write($"Recognized {Name} World, Removing Basement Door & Kitchen Door.");
                var BasementDoor = GameObjectFinder.Find(" - Props/Props (Static) - Hallways - First Floor/door-private");
                var Kitchen1 = GameObjectFinder.Find("great_pug/kitchen_door");
                var kitchen2 = GameObjectFinder.Find("great_pug/kitchen_door_chrome");
                var frame = GameObjectFinder.Find("great_pug/door-frame_004");
                var kitchen4 = GameObjectFinder.Find("great_pug/Cube_022  (GLASS)");
                var Signs = GameObjectFinder.Find(" - Props/Props (Static) - Global - Udon In Progress");
                var rope = GameObjectFinder.Find(" - Props/Props (Static) - Hallways - First Floor/Velvet Rope (1)");
                rope.IgnoreLocalPlayerCollision();
                Signs.IgnoreLocalPlayerCollision();
                BasementDoor.IgnoreLocalPlayerCollision();
                Kitchen1.IgnoreLocalPlayerCollision();
                kitchen2.IgnoreLocalPlayerCollision();
                frame.IgnoreLocalPlayerCollision();
                rope.IgnoreLocalPlayerCollision();
            }
        }
    }
}