namespace AstroClient
{
	#region Imports

	using AstroClient.ConsoleUtils;
	using System;
	using static AstroClient.variables.InstanceBuilder;
	using Color = System.Drawing.Color;

	#endregion Imports

	public class CheetoMenu : GameEventsBehaviour
	{
		public static CheetoMenu Instance;

		public bool IsOpen = false;

		public CheetoMenu(IntPtr obj0) : base(obj0)
		{
		}

		public void Start()
		{
			Instance = this;
		}

		public static void MakeInstance()
		{
			if (Instance == null)
			{
				string name = "CheetoMenu";
				var gameobj = GetInstanceHolder(name);
				Instance = gameobj.AddComponent<CheetoMenu>();
				DontDestroyOnLoad(gameobj);
				if (Instance != null)
				{
					ModConsole.DebugLog("[ " + name.ToUpper() + " STATUS ] : READY", Color.LawnGreen);
				}
				else
				{
					ModConsole.DebugLog("[ " + name.ToUpper() + " STATUS ] : ERROR", Color.OrangeRed);
				}
			}
		}
	}
}