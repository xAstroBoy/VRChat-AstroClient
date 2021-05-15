namespace AstroClient.Startup
{
	using AstroLibrary.Console;

	internal class WorldJoinMsg : GameEvents
	{
		public override void OnWorldReveal(string id, string name, string asseturl)
		{
			ModConsole.Log("You entered this world : " + name, System.Drawing.Color.Goldenrod);
			ModConsole.Log("World ID : " + id, System.Drawing.Color.Goldenrod);
			ModConsole.Log("World Asset URL : " + asseturl, System.Drawing.Color.Goldenrod);
		}
	}
}