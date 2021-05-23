namespace AstroClient
{
	using AstroLibrary.Console;
	#region Imports

	using UnityEngine;

	#endregion Imports

	internal class CheetoMenu : GameEvents
	{
		public static GameObject Menu;

		public bool IsOpen = false;

		public override void VRChat_OnUiManagerInit()
		{
			Menu = GameObject.CreatePrimitive(PrimitiveType.Plane);
			Menu.name = "CheetoMenu";
			Menu.SetActive(false);
			Object.DontDestroyOnLoad(Menu);
		}

		public override void OnUpdate()
		{
			if (Input.GetKeyDown(KeyCode.BackQuote))
			{
				ModConsole.Log("Attempting to toggle CheetoMenu");
				ToggleMenu();
			}
		}

		private void ToggleMenu()
		{
			IsOpen = !IsOpen;
			Menu.SetActive(IsOpen);
			Menu.transform.position = LocalPlayerUtils.GetSelfPlayer().transform.position;
		}
	}
}