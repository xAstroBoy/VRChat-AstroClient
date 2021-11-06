namespace AstroButtonAPI
{
    using System;
    using System.Linq;
    using Il2CppSystem.Reflection;
    using UnhollowerRuntimeLib;
    using UnityEngine;

    public class QuickMenuStuff
    {
        // Internal cache of the BoxCollider Background for the Quick Menu
        private static BoxCollider QuickMenuBackgroundReference;

        private static GameObject TabButtonReference;
        // Internal cache of the Single Button Template for the Quick Menu
        private static GameObject SingleButtonReference;

        // Internal cache of the Toggle Button Template for the Quick Menu
        private static GameObject ToggleButtonReference;

        // Internal cache of the Nested Menu Template for the Quick Menu
        private static Transform NestedButtonReference;

        // Internal cache of the QuickMenu
        private static QuickMenu quickmenuInstance;

        // Internal cache of the SocialMenu
        private static GameObject socialmenuInstance;

        // Internal cache of the VRCUiManager
        private static VRCUiManager vrcuimInstance;

        // Internal cache of the Image
        private static GameObject ImageReference;

        // Fetch the background from the Quick Menu
        public static BoxCollider QuickMenuBackground()
        {
            if (QuickMenuBackgroundReference == null)
                QuickMenuBackgroundReference = GetQuickMenuInstance().GetComponent<BoxCollider>();
            return QuickMenuBackgroundReference;
        }

        // Fetch the Single Button Template from the Quick Menu
        public static GameObject SingleButtonTemplate()
        {
            if (SingleButtonReference == null)
                SingleButtonReference = GetQuickMenuInstance().transform.Find("ShortcutMenu/WorldsButton").gameObject;
            return SingleButtonReference;
        }

        public static GameObject TabButtonTemplate()
        {
            // var Tab1 = GameObject.Find("/UserInterface/QuickMenu/QuickModeTabs/HomeTab");
            // var Tab2 = GameObject.Find("/UserInterface/QuickMenu/QuickModeTabs/NotificationsTab");
            if (TabButtonReference == null)
                TabButtonReference = GameObject.Find("/UserInterface/QuickMenu/QuickModeTabs/HomeTab");
            return TabButtonReference;
        }

        // Fetch the Toggle Button Template from the Quick Menu
        public static GameObject ToggleButtonTemplate()
        {
            if (ToggleButtonReference == null)
            {
                ToggleButtonReference = GetQuickMenuInstance().transform.Find("UserInteractMenu/BlockButton").gameObject;
            }
            return ToggleButtonReference;
        }

        // Fetch the Nested Menu Template from the Quick Menu
        public static Transform NestedMenuTemplate()
        {
            if (NestedButtonReference == null)
            {
                NestedButtonReference = GetQuickMenuInstance().transform.Find("CameraMenu");
            }
            return NestedButtonReference;
        }

        // Fetch the Quick Menu instance
        public static QuickMenu GetQuickMenuInstance()
        {
            if (quickmenuInstance == null)
            {
                quickmenuInstance = QuickMenu.prop_QuickMenu_0;
            }
            return quickmenuInstance;
        }

        // Fetch the Social Menu instance
        public static GameObject GetSocialMenuInstance()
        {
            if (socialmenuInstance == null)
            {
                socialmenuInstance = GameObject.Find("UserInterface/MenuContent/Screens");
            }
            return socialmenuInstance;
        }

        // Fetch the VRCUiManager instance
        public static VRCUiManager GetVRCUiMInstance()
        {
            if (vrcuimInstance == null)
            {
                vrcuimInstance = VRCUiManager.prop_VRCUiManager_0;
            }
            return vrcuimInstance;
        }

        // Fetch the Image instance
        public static GameObject GetImageInstance()
        {
            if (ImageReference == null)
            {
                ImageReference = GetSocialMenuInstance().transform.Find("WorldInfo/WorldImage/RoomImage").gameObject;
            }
            return ImageReference;
        }

        // Cache the FieldInfo for getting the current page. Hope to god this works!
        private static FieldInfo currentPageGetter;
        private static GameObject shortcutMenu;
        private static GameObject userInteractMenu;

        // Show a Quick Menu page via the Page Name. Hope to god this works!
        public static void ShowQuickmenuPage(string pagename)
        {
            QuickMenu quickmenu = GetQuickMenuInstance();
            Transform pageTransform = quickmenu?.transform.Find(pagename);
            if (pageTransform == null)
            {
                Console.WriteLine("[QMStuff] pageTransform is null !");
            }

            if (currentPageGetter == null)
            {
                GameObject shortcutMenu = quickmenu.transform.Find("ShortcutMenu").gameObject;
                if (!shortcutMenu.activeInHierarchy)
                    shortcutMenu = quickmenu.transform.Find("UserInteractMenu").gameObject;


                FieldInfo[] fis = Il2CppType.Of<QuickMenu>().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where((fi) => fi.FieldType == Il2CppType.Of<GameObject>()).ToArray();
                //MelonLoader.MelonModLogger.Log("[QMStuff] GameObject Fields in QuickMenu:");
                int count = 0;
                foreach (FieldInfo fi in fis)
                {
                    GameObject value = fi.GetValue(quickmenu)?.TryCast<GameObject>();
                    if (value == shortcutMenu && ++count == 2)
                    {
                        //MelonLoader.MelonModLogger.Log("[QMStuff] currentPage field: " + fi.Name);
                        currentPageGetter = fi;
                        break;
                    }
                }
                if (currentPageGetter == null)
                {
                    Console.WriteLine("[QMStuff] Unable to find field currentPage in QuickMenu");
                    return;
                }
            }

            currentPageGetter.GetValue(quickmenu)?.Cast<GameObject>().SetActive(false);

            GameObject infoBar = GetQuickMenuInstance().transform.Find("QuickMenu_NewElements/_InfoBar").gameObject;
            infoBar.SetActive(pagename == "ShortcutMenu");

            QuickMenuContextualDisplay quickmenuContextualDisplay = GetQuickMenuInstance().field_Private_QuickMenuContextualDisplay_0;
            quickmenuContextualDisplay.Method_Public_Void_EnumNPublicSealedvaUnNoToUs7vUsNoUnique_0(QuickMenuContextualDisplay.EnumNPublicSealedvaUnNoToUs7vUsNoUnique.NoSelection);
            //quickmenuContextualDisplay.Method_Public_Nested0_0(QuickMenuContextualDisplay.Nested0.NoSelection);

            pageTransform.gameObject.SetActive(true);

            currentPageGetter.SetValue(quickmenu, pageTransform.gameObject);

            if (shortcutMenu == null)
                shortcutMenu = QuickMenu.prop_QuickMenu_0.transform.Find("ShortcutMenu")?.gameObject;

            if (userInteractMenu == null)
                userInteractMenu = QuickMenu.prop_QuickMenu_0.transform.Find("UserInteractMenu")?.gameObject;

            if (pagename == "ShortcutMenu")
            {
                SetIndex(0);
            }
            else if (pagename == "UserInteractMenu")
            {
                SetIndex(3);
            }
            else
            {
                SetIndex(-1);
                shortcutMenu?.SetActive(false);
                userInteractMenu?.SetActive(false);
            }
        }

        // Set the current Quick Menu index
        // VRChat Build 1101 - github.com/MintLily
        public static void SetIndex(int index)
        {
            GetQuickMenuInstance().field_Private_EnumNPublicSealedvaUnShEmUsEmNoCaMo_nUnique_0 = (QuickMenu.EnumNPublicSealedvaUnShEmUsEmNoCaMo_nUnique)index;
        }
    }
}
