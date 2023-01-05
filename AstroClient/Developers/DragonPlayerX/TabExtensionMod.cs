using System.Collections;
using AstroClient.ClientActions;
using AstroClient.DragonPlayerX.Config;
using AstroClient.DragonPlayerX.UI;
using AstroClient.xAstroBoy.AstroButtonAPI.Tools;
using MelonLoader;
using UnityEngine;

namespace AstroClient.DragonPlayerX
{
    internal class TabExtensionMod : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnApplicationStart += OnApplicationStart;
        }
        
        internal static TabExtensionMod Instance { get; private set; }

        internal  void OnApplicationStart()
        {
            Instance = this;
            Log.Write("Initializing TabExtension...");

            Configuration.Init();

            MelonCoroutines.Start(Init());
        }

        private IEnumerator Init()
        {
            while (VRCUiManager.field_Private_Static_VRCUiManager_0 == null) yield return null;
            while (QuickMenuTools.UserInterface.transform.Find("Canvas_QuickMenu(Clone)/CanvasGroup/Container/Window/QMParent") == null) yield return null;

            GameObject quickMenu = QuickMenuTools.Canvas_QuickMenu.gameObject;
            GameObject layout = quickMenu.transform.Find("CanvasGroup/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/").gameObject;

            layout.AddComponent<TabLayout>();

            Log.Write("Running TabExtension.");
        }
    }
}
