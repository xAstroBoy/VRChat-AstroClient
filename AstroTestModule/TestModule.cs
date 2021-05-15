namespace AstroTestModule
{
	using AstroLibrary;
	using AstroLibrary.Console;

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