namespace AstroClient
{
	using AstroLibrary.Console;
	using AstroClient.Extensions;
	using AstroLibrary.Finder;
	using AstroClient.Variables;

	public class TheGreatPug : GameEvents
	{
		public override void OnWorldReveal(string id, string name, string asseturl)
		{
			if (id == WorldIds.TheGreatPug)
			{
				ModConsole.Log($"Recognized {name} World, Removing Basement Door & Kitchen Door.");
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