using AstroClient.AstroMonos.Components.Tools;
using AstroClient.AstroMonos.Prefabs;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;

namespace AstroClient.Spawnables
{
    internal class AstroJetPack
    {
        private static JetpackController VR_Jetpack_Controller { get; set; } = null;
        private static JetpackController Desktop_Jetpack_Controller { get; set; } = null;
        private static GameObject VR_Jetpack_Object { get; set; }
        private static GameObject Desktop_Jetpack_Object { get; set; }


        internal static bool SitOnJetpackOnSpawn { get; set; }


        private static bool _AdjustBasedOffAvatarSize = false;
        internal static bool AdjustBasedOffAvatarSize
        {
            get => _AdjustBasedOffAvatarSize;
            set
            {
                _AdjustBasedOffAvatarSize = value;
                if (VR_Jetpack_Controller != null)
                {
                    VR_Jetpack_Controller.AdjustScaleBasedOffAvatar = value;
                }
                if (Desktop_Jetpack_Controller != null)
                {
                    Desktop_Jetpack_Controller.AdjustScaleBasedOffAvatar = value;
                }
            }
        }

        private static bool _DisableThrusterSlowDown = false;
        internal static bool DisableThrusterSlowDown
        {
            get => _DisableThrusterSlowDown;
            set
            {
                _DisableThrusterSlowDown = value;
                if(VR_Jetpack_Controller != null)
                {
                    VR_Jetpack_Controller.IgnoreQuickBoostAnim = value;
                }
                if(Desktop_Jetpack_Controller != null)
                {
                    Desktop_Jetpack_Controller.IgnoreQuickBoostAnim = value;
                }
            }
        }


        internal static void SpawnVRJetpack()
        {
            if (VR_Jetpack_Object != null)
            {
                UnityEngine.Object.Destroy(VR_Jetpack_Object);
                VR_Jetpack_Object = null;
                VR_Jetpack_Controller = null;
                return;
            }
            Vector3? buttonPosition = GameInstances.LocalPlayer.GetPlayer().Get_Center_Of_Player();
            Quaternion? buttonRotation = GameInstances.LocalPlayer.GetPlayer().gameObject.transform.rotation;
            if (buttonPosition.HasValue && buttonRotation.HasValue)
            {
                VR_Jetpack_Object = Object.Instantiate(ClientResources.Loaders.Prefabs.VRJetpack, buttonPosition.GetValueOrDefault(), buttonRotation.GetValueOrDefault(), null);
                VR_Jetpack_Object.AddToWorldUtilsMenu();
                VR_Jetpack_Controller = ComponentUtils.GetOrAddComponent<JetpackController>(VR_Jetpack_Object);
                if (VR_Jetpack_Controller != null)
                {
                    VR_Jetpack_Controller.AdjustScaleBasedOffAvatar = AdjustBasedOffAvatarSize;
                    MiscUtils.DelayFunction(0.2f, () =>
                    {
                        if (SitOnJetpackOnSpawn)
                        {
                            VR_Jetpack_Controller.CurrentChair.EnterStation();
                        }
                    });
                    ComponentUtils.GetOrAddComponent<RegisterAsPrefab>(VR_Jetpack_Object);
                }
            }

        }


        internal static void SpawnDesktopJetpack()
        {
            if (Desktop_Jetpack_Object != null)
            {
                UnityEngine.Object.Destroy(Desktop_Jetpack_Object);
                Desktop_Jetpack_Object = null;
                Desktop_Jetpack_Controller = null;
                return;
            }
            Vector3? buttonPosition = GameInstances.LocalPlayer.GetPlayer().Get_Center_Of_Player();
            Quaternion? buttonRotation = GameInstances.LocalPlayer.GetPlayer().gameObject.transform.rotation;
            if (buttonPosition.HasValue && buttonRotation.HasValue)
            {
                var item = Object.Instantiate(ClientResources.Loaders.Prefabs.DesktopJetpack, buttonPosition.GetValueOrDefault(), buttonRotation.GetValueOrDefault(), null);
                item.AddToWorldUtilsMenu();
                Desktop_Jetpack_Controller = ComponentUtils.GetOrAddComponent<JetpackController>(item);
                if (Desktop_Jetpack_Controller != null)
                {
                    Desktop_Jetpack_Controller.AdjustScaleBasedOffAvatar = AdjustBasedOffAvatarSize;
                    MiscUtils.DelayFunction(0.2f, () =>
                    {
                        if (SitOnJetpackOnSpawn)
                        {
                            Desktop_Jetpack_Controller.CurrentChair.EnterStation();
                        }
                    });
                }
                Desktop_Jetpack_Object = item;
                ComponentUtils.GetOrAddComponent<RegisterAsPrefab>(item);

            }

        }

        internal static void ExitJetpacks()
        {
            if (VR_Jetpack_Controller != null)
            {
                if (VR_Jetpack_Controller.CurrentChair != null)
                {
                    VR_Jetpack_Controller.CurrentChair.ExitStation();
                }
            }
            if (Desktop_Jetpack_Controller != null)
            {
                if (Desktop_Jetpack_Controller.CurrentChair != null)
                {
                    Desktop_Jetpack_Controller.CurrentChair.ExitStation();
                }
            }

        }

    }
}