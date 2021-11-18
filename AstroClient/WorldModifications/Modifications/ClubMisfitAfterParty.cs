namespace AstroClient.WorldModifications.Modifications
{
    using System.Collections.Generic;
    using Tools.Extensions;
    using WorldsIds;
    using xAstroBoy;

    internal class ClubMisfitAfterParty : AstroEvents
    {
        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
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