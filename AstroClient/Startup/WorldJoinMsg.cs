namespace AstroClient.Startup
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine.Playables;
    using xAstroBoy.Utility;

    internal class WorldJoinMsg : AstroEvents
    {
        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            ModConsole.Log("Joined World : " + Name, System.Drawing.Color.Goldenrod);
            if (tags != null)
            {
                if (tags.Count() != 0)
                {
                    bool isFirst = true;
                    StringBuilder printtag = new StringBuilder();
                    for (int i = 0; i < tags.Count; i++)
                    {
                        string tag = tags[i];
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

                    ModConsole.Log("World Tags : " + printtag.ToString(), System.Drawing.Color.Goldenrod);
                }
            }
            ModConsole.Log("World ID : " + id, System.Drawing.Color.Goldenrod);
            ModConsole.Log("World author : " + AuthorName, System.Drawing.Color.Goldenrod);
            ModConsole.Log("World Asset URL : " + AssetURL, System.Drawing.Color.Goldenrod);
            ModConsole.Log("Instance ID : " + WorldUtils.FullID, System.Drawing.Color.Goldenrod);
        }
    }
}