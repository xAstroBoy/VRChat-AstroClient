namespace AstroTestModule
{
	using AstroClientCore;
	using AstroLibrary.Console;

	class TestEvents : GameEvents
	{
		public override void OnWorldReveal(string id, string Name, string AssetURL)
		{
			ModConsole.Log("TestEvents OnWorldReveal()");
		}
	}
}
