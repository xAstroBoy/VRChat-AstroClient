namespace AstroTestModule
{
	using AstroClientCore;
	using AstroLibrary.Console;

	class InfoBarTextChanger : GameEvents
	{
		public override void OnWorldReveal(string id, string Name, string AssetURL)
		{
			ModConsole.Log("InfoBarTextChanger OnWorldReveal()");
		}
	}
}
