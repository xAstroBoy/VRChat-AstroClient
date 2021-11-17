namespace AstroClient.Gompoc.ActionMenuAPI.Managers
{
    using ClientResources;
    using Helpers;
    using UnityEngine;
    using UnityEngine.UI;

    internal class ResourceManagerEvents : AstroEvents
    {
        internal override void VRChat_OnActionMenuInit()
        {
            ResourcesManager.InitLockGameObject();
        }
    }

    internal static class ResourcesManager
    {
        private static GameObject lockPrefab;
        public static void InitLockGameObject()
        {
            lockPrefab = Object.Instantiate(ActionMenuDriver.prop_ActionMenuDriver_0.GetRightOpener().GetActionMenu()
                .GetPedalOptionPrefab().GetComponent<PedalOption>().GetActionButton().gameObject.GetChild("Inner")
                .GetChild("Folder Icon"));
            Object.DontDestroyOnLoad(lockPrefab);
            lockPrefab.active = false;
            lockPrefab.gameObject.name = Constants.LOCKED_PEDAL_OVERLAY_GAMEOBJECT_NAME;
            lockPrefab.GetComponent<RawImage>().texture = ClientResources.locked;
            ModConsole.DebugLog("Created lock gameobject");
        }

        public static Texture2D GetPageIcon(int pageIndex)
        {
            switch (pageIndex)
            {
                case 1:
                    return ClientResources.one;

                case 2:
                    return ClientResources.two;

                case 3:
                    return ClientResources.three;

                case 4:
                    return ClientResources.four;

                case 5:
                    return ClientResources.five;

                case 6:
                    return ClientResources.six;

                case 7:
                    return ClientResources.seven;

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
            return ClientResources.planet;
        }
    }
}