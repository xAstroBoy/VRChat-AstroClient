using System.IO;
using System.Reflection;
using AstroClient;
using AstroLibrary.Console;
using AstroLibrary.Helpers;
using MelonLoader;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.UI;

namespace AstroLibrary.Managers
{

    internal class ResourceManagerEvents : GameEvents
    {
        internal override void OnApplicationStart()
        {
            ResourcesManager.LoadTextures();
        }

        internal override void VRChat_OnActionMenuInit()
        {
            ResourcesManager.InitLockGameObject();
        }
    }


    internal static class ResourcesManager 
    {
        private static GameObject lockPrefab;
        private static Texture2D pageOne;
        private static Texture2D pageTwo;
        private static Texture2D pageThree;
        private static Texture2D pageFour;
        private static Texture2D pageFive;
        private static Texture2D pageSix;
        private static Texture2D pageSeven;
        private static Texture2D locked;
        private static Texture2D modsSectionIcon;

        public static void LoadTextures()
        {
            modsSectionIcon = CheetosHelpers.LoadPNG(CheetosHelpers.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.planet.png"));
            modsSectionIcon.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            pageOne = CheetosHelpers.LoadPNG(CheetosHelpers.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.Action_Menu_1.png"));
            pageOne.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            pageTwo = CheetosHelpers.LoadPNG(CheetosHelpers.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.Action_Menu_1.png"));
            pageTwo.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            pageThree = CheetosHelpers.LoadPNG(CheetosHelpers.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.Action_Menu_3.png"));;
            pageThree.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            pageFour = CheetosHelpers.LoadPNG(CheetosHelpers.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.Action_Menu_4.png"));
            pageFour.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            pageFive = CheetosHelpers.LoadPNG(CheetosHelpers.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.Action_Menu_5.png"));
            pageFive.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            pageSix = CheetosHelpers.LoadPNG(CheetosHelpers.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.Action_Menu_6.png"));
            pageSix.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            pageSeven = CheetosHelpers.LoadPNG(CheetosHelpers.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.Action_Menu_7.png"));
            pageSeven.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            locked = CheetosHelpers.LoadPNG(CheetosHelpers.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.locked.png"));
            locked.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            ModConsole.DebugLog("ActionMenu Loaded textures");
        }

        public static void InitLockGameObject()
        {
            lockPrefab = Object.Instantiate(ActionMenuDriver.prop_ActionMenuDriver_0.GetRightOpener().GetActionMenu()
                .GetPedalOptionPrefab().GetComponent<PedalOption>().GetActionButton().gameObject.GetChild("Inner")
                .GetChild("Folder Icon"));
            Object.DontDestroyOnLoad(lockPrefab);
            lockPrefab.active = false;
            lockPrefab.gameObject.name = Constants.LOCKED_PEDAL_OVERLAY_GAMEOBJECT_NAME;
            lockPrefab.GetComponent<RawImage>().texture = locked;
            ModConsole.DebugLog("Created lock gameobject");
        }

        public static Texture2D GetPageIcon(int pageIndex)
        {
            switch (pageIndex)
            {
                case 1:
                    return pageOne;
                case 2:
                    return pageTwo;
                case 3:
                    return pageThree;
                case 4:
                    return pageFour;
                case 5:
                    return pageFive;
                case 6:
                    return pageSix;
                case 7:
                    return pageSeven;
                default:
                    return null;
            }
        }

        public static void AddLockChildIcon(GameObject parent)
        {
            var lockedGameObject = Object.Instantiate(lockPrefab, parent.transform, false);
            lockedGameObject.SetActive(true);
            lockedGameObject.transform.localPosition = new Vector3(50, -25, 0);
            lockedGameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }

        public static Texture2D GetModsSectionIcon()
        {
            return modsSectionIcon;
        }
    }
}