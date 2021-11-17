namespace AstroClient.CheetosUI
{
    #region Imports

    using UnityEngine;
    using xAstroBoy.Utility;

    #endregion Imports

    internal class CheetoMenu : AstroEvents
    {
        internal static GameObject UI;

        internal static GameObject Menu;

        internal static bool IsOpen = false;

        internal override void VRChat_OnQuickMenuInit()
        {
            //try
            //{
            //	var camera = GameObject.Find("Camera (eye)").GetComponent<Camera>();
            //	UI = new GameObject() { name = "CheetoUI" };
            //	UI.name = "CheetoUI";
            //	UI.layer = LayerMask.NameToLayer("UI");

            //	Menu = new GameObject() { name = "CheetoMenu" };
            //	Menu.layer = LayerMask.NameToLayer("UiMenu");
            //	Menu.AddComponent<RectTransform>();
            //	Menu.transform.SetParent(UI.transform, false);
            //	Menu.GetComponent<RectTransform>().sizeDelta = new Vector2(800, 600);
            //	Menu.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.5f, 0.5f);
            //	Menu.AddComponent<BoxCollider>();
            //	Menu.GetComponent<BoxCollider>().enabled = false;
            //	Menu.AddComponent<Canvas>();
            //	Menu.GetComponent<Canvas>().renderMode = RenderMode.WorldSpace;
            //	Menu.GetComponent<Canvas>().worldCamera = camera;
            //	Menu.AddComponent<CanvasGroup>();
            //	Menu.AddComponent<GraphicRaycaster>();
            //	Menu.GetComponent<GraphicRaycaster>().enabled = true;
            //	Menu.GetComponent<GraphicRaycaster>().m_BlockingMask = 0;

            //	_ = new CMBackground(Menu.transform, Color.gray);
            //	_ = new CMPage(Menu.transform);

            //	Menu.SetActive(false);
            //	Object.DontDestroyOnLoad(UI);
            //}
            //catch (System.Exception e)
            //{
            //	ModConsole.DebugError("Exception Generating CheetoMenu!");
            //	ModConsole.DebugErrorExc(e);
            //}
        }

        internal override void OnUpdate()
        {
            //if (Input.GetKeyDown(KeyCode.BackQuote))
            //{
            //	ModConsole.Log("Toggling CheetoMenu");
            //	ToggleMenu();
            //}
        }

        private void ToggleMenu()
        {
            IsOpen = !IsOpen;
            Menu.SetActive(IsOpen);

            if (IsOpen)
            {
                Transform ptransform = GameInstances.LocalPlayer.GetPlayer().transform;
                Vector3? center = PlayerUtils.GetPlayer().Get_Center_Of_Player();
                if (center != null && ptransform != null)
                {
                    UI.transform.position = center.Value + (ptransform.forward * 0.30f);
                    UI.transform.position += new Vector3(0, 0.1f, 0);
                    UI.transform.localScale = new Vector3(0.00025f, 0.00025f, 0.00025f);
                    UI.transform.LookAt(ptransform);
                    UI.transform.Rotate(new Vector3(45, 180, 0));
                }
            }
        }
    }
}