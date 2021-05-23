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

		public void Update()
		{
			if (Input.GetKeyDown(KeyCode.Tilde))
			{
				ToggleMenu();
			}
		}

		private void ToggleMenu()
		{
			IsOpen = !IsOpen;
			Menu.SetActive(IsOpen);
		}

		public static void MakeInstance()
		{
			if (Instance == null)
			{
				Menu = GameObject.CreatePrimitive(PrimitiveType.Plane);
				Menu.name = "CheetoMenu";
				Menu.SetActive(false);
				Instance = Menu.AddComponent<CheetoMenu>();
				DontDestroyOnLoad(Menu);
				if (Instance != null)
				{
					ModConsole.DebugLog("[ " + Menu.name.ToUpper() + " STATUS ] : READY", Color.LawnGreen);
				}
				else
				{
					ModConsole.DebugLog("[ " + Menu.name.ToUpper() + " STATUS ] : ERROR", Color.OrangeRed);
				}
			}
		}
	}
}