namespace AstroClient
{
	using AstroLibrary.Console;
	using AstroLibrary.Extensions;

	#region Imports

	using AstroLibrary.Finder;
	using UnityEngine;
	using UnityEngine.UI;

	#endregion Imports

	internal class CheetoMenu : GameEvents
	{
		public static GameObject UI;

		public static GameObject Menu;

		public static bool IsOpen = false;

		public override void VRChat_OnUiManagerInit()
		{
			try
			{
				var camera = GameObject.Find("Camera (eye)").GetComponent<Camera>();
				UI = new GameObject() { name = "CheetoUI" };
				UI.name = "CheetoUI";
				UI.layer = LayerMask.NameToLayer("UI");

				Menu = new GameObject() { name = "CheetoMenu" };
				Menu.layer = LayerMask.NameToLayer("UiMenu");
				Menu.AddComponent<RectTransform>();
				Menu.transform.SetParent(UI.transform, false);
				Menu.GetComponent<RectTransform>().sizeDelta = new Vector2(800, 600);
				Menu.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.5f, 0.5f);
				Menu.AddComponent<BoxCollider>();
				Menu.GetComponent<BoxCollider>().enabled = false;
				Menu.AddComponent<Canvas>();
				Menu.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
				Menu.GetComponent<Canvas>().worldCamera = camera;
				Menu.AddComponent<CanvasGroup>();
				Menu.AddComponent<GraphicRaycaster>();
				Menu.GetComponent<GraphicRaycaster>().enabled = true;
				Menu.GetComponent<GraphicRaycaster>().m_BlockingMask = 0;

				_ = new CheetoBackground(Menu.transform);
				_ = new CheetoPage(Menu.transform);

				Menu.SetActive(false);
				Object.DontDestroyOnLoad(UI);
			}
			catch (System.Exception e)
			{
				ModConsole.DebugError("Exception Generating CheetoMenu!");
				ModConsole.DebugErrorExc(e);
			}
		}

		public override void OnUpdate()
		{
			if (Input.GetKeyDown(KeyCode.BackQuote))
			{
				ModConsole.Log("Toggling CheetoMenu");
				ToggleMenu();
			}
		}

		public override void OnLateUpdate()
		{
			//cursorManager.field_Private_Boolean_0 = true;
			//cursorManager.field_Private_Boolean_1 = true;
			//cursorManager.field_Private_Boolean_0 = true;
			//cursorManager.field_Private_Boolean_3 = true;
			//cursorManager.field_Private_Boolean_4 = true;
			//cursorManager.field_Private_EnumNPublicSealedvaNoRiLe4vUnique_0 = VRCUiCursor.EnumNPublicSealedvaNoRiLe4vUnique.Right;
		}

		private void ToggleMenu()
		{
			IsOpen = !IsOpen;
			Menu.SetActive(IsOpen);

			if (IsOpen)
			{
				Transform ptransform = Utils.LocalPlayer.GetPlayer().transform;
				Vector3? center = Utils.LocalPlayer.GetPlayer().Get_Center_Of_Player();
				if (center != null && ptransform != null)
				{
					UI.transform.position = center.Value + (ptransform.forward * 0.30f);
					UI.transform.position += new Vector3(0, 0.05f, 0);
					UI.transform.localScale = new Vector3(0.00025f, 0.00025f, 0.00025f);
					UI.transform.LookAt(ptransform);
					UI.transform.Rotate(new Vector3(45, 180, 0));
				}
			}
		}
	}
}