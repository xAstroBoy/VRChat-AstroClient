namespace AstroTestModule
{
	using AstroClientCore.ConsoleUtils;
	using AstroLibrary;

	public class TestModule : BaseModule
	{
		public TestModule() : base()
		{
			ModConsole.Log("TestModule Works!");
		}

		public override void Start()
		{
			ModConsole.Log("TestModule Started.");
		}
	}
}