namespace AstroClient
{
	using AstroClient.Variables;
	using AstroLibrary.Console;
	using AstroLibrary.Extensions;
	using AstroLibrary.Finder;
	using System.Collections.Generic;

	public class ClubMisfitAfterParty : GameEvents
    {
        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
            if (id == WorldIds.ClubMisfitAfterParty)
            {
                ModConsole.Log($"Recognized {Name} World, Removing Anti-Client user mechanism And Blacklist.");
                var avatar = GameObjectFinder.Find("Godseye");
                if (avatar != null)
                {
                    avatar.DestroyMeLocal();
                }

                var AntiClientUserCanvas1 = GameObjectFinder.Find("Map/Scripts/BlacklistCanvas");
                if (AntiClientUserCanvas1 != null)
                {
                    AntiClientUserCanvas1.DestroyMeLocal();
                }

                var AntiClientUserCanvas2 = GameObjectFinder.Find("Map/Scripts/Canvas");
                if (AntiClientUserCanvas2 != null)
                {
                    AntiClientUserCanvas2.DestroyMeLocal();
                }
            }
        }
    }
}