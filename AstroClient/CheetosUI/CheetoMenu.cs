namespace AstroClient
{
	#region Imports

	using AstroLibrary.Console;
	using UnityEngine;
	using UnityEngine.UI;

	#endregion Imports

	internal class CheetoMenu : GameEvents
	{
		public static GameObject UI;

		public static GameObject Menu;

		public bool IsOpen = false;

		public override void VRChat_OnUiManagerInit()
		{
			UI = new GameObject() { name = "CheetoUI" };
			UI.name = "CheetoUI";

			Menu = new GameObject() { name = "CheetoMenu" };
			Menu.transform.parent = UI.transform;
			Menu.AddComponent<Canvas>();
			Menu.AddComponent<CanvasScaler>();

			_ = new CheetoPage(Menu.transform);

			Menu.SetActive(false);
			Object.DontDestroyOnLoad(UI);
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

			if (IsOpen)
			{
				var ptransform = LocalPlayerUtils.GetSelfPlayer().transform;
				var center = LocalPlayerUtils.CenterOfPlayer();
				UI.transform.position = center + (ptransform.forward * 0.45f);
				UI.transform.localScale = new Vector3(0.005f, 0.005f, 0.005f);
				UI.transform.LookAt(ptransform);
				UI.transform.Rotate(new Vector3(-45, 0, 0));
			}
		}
	}
}