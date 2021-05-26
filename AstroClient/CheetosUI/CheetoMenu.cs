﻿namespace AstroClient
{
	#region Imports

	using AstroLibrary.Finder;
	using System.ServiceModel.Channels;
	using UnityEngine;
	using UnityEngine.EventSystems;
	using UnityEngine.UI;

	#endregion Imports

	internal class CheetoMenu : GameEvents
	{
		public static GameObject UI;

		public static GameObject Menu;

		public static bool IsOpen = false;

		private VRCStandaloneInputModule standaloneInputModule;

		private VRCUiCursorManager cursorManager;

		public override void VRChat_OnUiManagerInit()
		{
			var camera = GameObjectFinder.Find("_Application/TrackingVolume/TrackingSteam(Clone)/SteamCamera/[CameraRig]/Neck/Camera (head)/Camera (eye)").GetComponent<Camera>();
			standaloneInputModule = GameObjectFinder.Find("_Application/UiEventSystem").GetComponent<VRCStandaloneInputModule>();
			cursorManager = GameObjectFinder.Find("_Application/CursorManager").GetComponent<VRCUiCursorManager>();
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

		public override void OnUpdate()
		{
			if (Input.GetKeyDown(KeyCode.BackQuote))
			{
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