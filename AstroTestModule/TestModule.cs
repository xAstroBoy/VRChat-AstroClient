namespace AstroTestModule
{
	using AstroClient.ConsoleUtils;
	using AstroClient.Modules;

	public class TestModule : BaseModule
	{
		public TestModule()
		{
			ModConsole.Log("TestModule Works!");
		}

		public override void VRChat_OnUiManagerInit()
		{
			ModConsole.Log("TestModule: OnUiManagerInit()");
		}
	}
}
