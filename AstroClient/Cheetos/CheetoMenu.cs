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

			if (IsOpen)
			{
				var ptransform = LocalPlayerUtils.GetSelfPlayer().transform;
				var center = LocalPlayerUtils.CenterOfPlayer();
				Menu.transform.position = center + (ptransform.forward * 0.5f);
				Menu.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
				Menu.transform.LookAt(ptransform);
				Menu.transform.Rotate(new Vector3(45, 0, 0));
			}
		}
	}
}