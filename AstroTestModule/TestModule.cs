namespace AstroTestModule
{
	using AstroClient.ConsoleUtils;
	using AstroClient.Modules;
	using System;

	public class TestModule : BaseModule
	{
		public TestModule(IntPtr obj0) : base(obj0)
		{
		}

		public override void OnLevelLoaded()
		{
			ModConsole.Log("TestModule Works!");
		}
	}
}
