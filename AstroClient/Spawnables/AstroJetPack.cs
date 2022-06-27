using AstroClient.AstroMonos.Components.Tools;

namespace AstroClient.Spawnables.Enderpearl
{
    using AstroMonos.Components.Custom.Items;
    using Tools.Extensions;
    using Tools.Holders;
    using UnityEngine;
    using VRC.SDKBase;
    using xAstroBoy.Utility;

    internal class AstroJetPack 
    {
        private static GameObject VRJetpack;

        internal static void SpawnVRJetpack()
        {
            if (VRJetpack != null)
            {
                UnityEngine.Object.Destroy(VRJetpack);
                VRJetpack = null;
                return;
            }
            Vector3? buttonPosition = GameInstances.LocalPlayer.GetPlayer().Get_Center_Of_Player();
            Quaternion? buttonRotation = GameInstances.LocalPlayer.GetPlayer().gameObject.transform.rotation;
            if (buttonPosition.HasValue && buttonRotation.HasValue)
            {
                var item = Object.Instantiate(ClientResources.Loaders.Prefabs.VRJetpack, buttonPosition.GetValueOrDefault(), buttonRotation.GetValueOrDefault(), null);
                item.AddToWorldUtilsMenu();
                var  jet = item.GetOrAddComponent<JetpackController>();
                MiscUtils.DelayFunction(1f, () => {
                    jet.CurrentChair.OverrideStationExit = true;

                });
                item.GetOrAddComponent<RegisterAsPrefab>();
                VRJetpack = item;
            }

        }

        private static GameObject DesktopJetpack;

        internal static void SpawnDesktopJetpack()
        {
            if (DesktopJetpack != null)
            {
                UnityEngine.Object.Destroy(DesktopJetpack);
                DesktopJetpack = null;
                return;
            }
            Vector3? buttonPosition = GameInstances.LocalPlayer.GetPlayer().Get_Center_Of_Player();
            Quaternion? buttonRotation = GameInstances.LocalPlayer.GetPlayer().gameObject.transform.rotation;
            if (buttonPosition.HasValue && buttonRotation.HasValue)
            {
                var item = Object.Instantiate(ClientResources.Loaders.Prefabs.DesktopJetpack, buttonPosition.GetValueOrDefault(), buttonRotation.GetValueOrDefault(), null);
                item.AddToWorldUtilsMenu();
                item.GetOrAddComponent<JetpackController>();
                DesktopJetpack = item;
                item.GetOrAddComponent<RegisterAsPrefab>();

            }

        }

        internal static void ExitJetpacks()
        {
            if(DesktopJetpack != null)
            {
                var Jetpack = DesktopJetpack.GetOrAddComponent<JetpackController>();
                if(Jetpack != null)
                {
                    Jetpack.CurrentChair.OverrideStationExit = false;
                    Jetpack.CurrentChair.ExitStation();

                }
            }
            if (VRJetpack != null)
            {
                var Jetpack = VRJetpack.GetOrAddComponent<JetpackController>();
                if (Jetpack != null)
                {
                    Jetpack.CurrentChair.OverrideStationExit = false;
                    Jetpack.CurrentChair.ExitStation();
                }
            }

        }

    }
}