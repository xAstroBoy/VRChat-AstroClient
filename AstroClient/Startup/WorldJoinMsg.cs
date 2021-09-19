namespace AstroClient.Startup
{
    using AstroLibrary.Console;
    using AstroLibrary.Utility;
    using System.Collections.Generic;
    using System.Linq;

    internal class WorldJoinMsg : GameEvents
    {

        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            ModConsole.Log("Joined World : " + Name, System.Drawing.Color.Goldenrod);
            if (tags != null)
            {
                if (tags.Count() != 0)
                {
                    bool isFirst = true;
                    string printtag = string.Empty;
                    for (int i = 0; i < tags.Count; i++)
                    {
                        string tag = tags[i];
                        if (isFirst)
                        {
                            printtag += $"[ {tag} ]";
                            isFirst = false;
                        }
                        else
                        {
                            printtag += $",[ {tag} ]";
                        }
                    }

                    ModConsole.Log("World Tags : " + printtag, System.Drawing.Color.Goldenrod);
                }
            }
            ModConsole.Log("World ID : " + id, System.Drawing.Color.Goldenrod);
            ModConsole.Log("World author : " + AuthorName, System.Drawing.Color.Goldenrod);
            ModConsole.Log("World Asset URL : " + AssetURL, System.Drawing.Color.Goldenrod);
            ModConsole.Log("Instance ID : " + WorldUtils.FullID, System.Drawing.Color.Goldenrod);
        }
    }
}