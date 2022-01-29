namespace AstroClient.WorldModifications.WorldHacks
{
    using System.Collections.Generic;
    using Tools.Extensions;
    using WorldsIds;
    using xAstroBoy;

    internal class SmashContest : AstroEvents
    {
        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.SmashContest)
            {
                ModConsole.DebugLog($"Recognized {Name} World, Searching For Sandbag");
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