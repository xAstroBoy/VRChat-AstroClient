namespace AstroClient.Startup
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Hooks;
    using UnityEngine.Playables;
    using xAstroBoy.Utility;

    internal class WorldJoinMsg : AstroEvents
    {
        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            ModConsole.Log("Joined World : " + Name, System.Drawing.Color.Goldenrod);
            if (tags != null)
            {
                if (!RiskyFunctionHook.IsWorldTagPatched)
                {
                    ModConsole.Log("World Tags : " + CurrentWorldTags(tags), System.Drawing.Color.Goldenrod);
                }
                else
                {
                    ModConsole.Log("[P]: World Tags : " + CurrentWorldTags(RiskyFunctionHook.OriginalWorldTags), System.Drawing.Color.Goldenrod);
                }
            }
            ModConsole.Log("World ID : " + id, System.Drawing.Color.Goldenrod);
            ModConsole.Log("World author : " + AuthorName, System.Drawing.Color.Goldenrod);
            ModConsole.Log("World Asset URL : " + AssetURL, System.Drawing.Color.Goldenrod);
            ModConsole.Log("Instance ID : " + WorldUtils.FullID, System.Drawing.Color.Goldenrod);
        }

        private string CurrentWorldTags(List<string> Tags)
        {
            if (Tags.Count() != 0)
            {
                bool isFirst = true;
                StringBuilder printtag = new StringBuilder();
                for (int i = 0; i < Tags.Count; i++)
                {
                    string tag = Tags[i];
                    if (isFirst)
                    {
                        printtag.Append($"[ {tag} ]");
                        isFirst = false;
                    }
                    else
                    {
                        printtag.Append($",[ {tag} ]");
                    }
                }

                return printtag.ToString();
            }

            return null;
        }
    }
}