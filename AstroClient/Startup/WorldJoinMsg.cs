namespace AstroClient.Startup
{
	using AstroLibrary.Console;
	using System.Collections.Generic;
	using System.Linq;

	internal class WorldJoinMsg : GameEvents
    {
        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
            ModConsole.Log("Joined World : " + Name, System.Drawing.Color.Goldenrod);
            if (tags != null)
            {
                if (tags.Count() != 0)
                {
                    bool isFirst = true;
                    string printtag = string.Empty;
                    foreach (var tag in tags)
                    {
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
            ModConsole.Log("World Asset URL : " + AssetURL, System.Drawing.Color.Goldenrod);
        }
    }
}