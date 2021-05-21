namespace AstroClient.Startup
{
	using AstroLibrary.Console;
	using System.Collections.Generic;
	using System.Linq;

	internal class WorldJoinMsg : GameEvents
	{
		public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
		{
			ModConsole.Log("You entered this world : " + Name, System.Drawing.Color.Goldenrod);
			if (tags != null)
			{
				if (tags.Count() != 0)
				{

					ModConsole.Log("World Tags : " + string.Join(",", tags), System.Drawing.Color.Goldenrod);

				}
			}
			ModConsole.Log("World ID : " + id, System.Drawing.Color.Goldenrod);
			ModConsole.Log("World Asset URL : " + AssetURL, System.Drawing.Color.Goldenrod);
		}
	}
}