namespace AstroTestModule
{
	using AstroClientCore.Console;
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