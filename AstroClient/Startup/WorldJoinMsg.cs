namespace AstroClient.Startup
{
	using AstroLibrary.Console;

	internal class WorldJoinMsg : GameEvents
	{
		public override void OnWorldReveal(string id, string Name, string tags, string AssetURL)
		{
			ModConsole.Log("You entered this world : " + Name, System.Drawing.Color.Goldenrod);
			ModConsole.Log("World Tags : " + tags, System.Drawing.Color.Goldenrod);
			ModConsole.Log("World ID : " + id, System.Drawing.Color.Goldenrod);
			ModConsole.Log("World Asset URL : " + AssetURL, System.Drawing.Color.Goldenrod);
		}
	}
}