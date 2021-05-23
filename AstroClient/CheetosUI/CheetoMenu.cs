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
			UI.layer = LayerMask.NameToLayer("UI");

			Menu = new GameObject() { name = "CheetoMenu" };
			Menu.layer = LayerMask.NameToLayer("UiMenu");
			Menu.AddComponent<RectTransform>();
			Menu.transform.SetParent(UI.transform, false);
			Menu.GetComponent<RectTransform>().sizeDelta = new Vector2(800, 600);
			Menu.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.5f, 0.5f);
			Menu.AddComponent<GraphicRaycaster>();
			Menu.AddComponent<Canvas>();
			Menu.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
			Menu.GetComponent<Canvas>().worldCamera = Camera.current;
			Menu.AddComponent<BoxCollider>();
			Menu.GetComponent<BoxCollider>().enabled = false;

			_ = new CheetoBackground(Menu.transform);
			_ = new CheetoPage(Menu.transform);

			Menu.SetActive(false);
			Object.DontDestroyOnLoad(UI);
		}

		public override void OnUpdate()
		{
			if (Input.GetKeyDown(KeyCode.BackQuote))
			{
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
				UI.transform.position = center + (ptransform.forward * 0.30f);
				UI.transform.position += new Vector3(0, 0.05f, 0);
				UI.transform.localScale = new Vector3(0.00025f, 0.00025f, 0.00025f);
				UI.transform.LookAt(ptransform);
				UI.transform.Rotate(new Vector3(45, 180, 0));
			}
		}
	}
}