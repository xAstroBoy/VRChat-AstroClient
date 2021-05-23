namespace AstroClient
{
	#region Imports

	using AstroLibrary.Console;
	using AstroLibrary.Finder;
	using System;
	using UnityEngine;
	using Color = System.Drawing.Color;

	#endregion Imports

	public class CheetoMenu : GameEventsBehaviour
	{
		public static CheetoMenu Instance;

		public static GameObject Menu;

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
				var ui = GameObjectFinder.Find("UserInterface");
				Menu = GameObject.CreatePrimitive(PrimitiveType.Plane);
				Menu.transform.parent = ui.transform;
				Menu.SetActive(false);
				Instance = Menu.AddComponent<CheetoMenu>();
				DontDestroyOnLoad(Menu);
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