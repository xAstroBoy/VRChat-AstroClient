namespace AstroTestModule
{
	using AstroLibrary;
	using AstroLibrary.Console;
	using System.Web.UI.WebControls;

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

		public override void VRChat_OnUiManagerInit()
		{
			ModConsole.Log("TestModule VRChat_OnUiManagerInit()");
		}
	}
}