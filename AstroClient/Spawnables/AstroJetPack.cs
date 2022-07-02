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
        internal static bool SitOnJetpackOnSpawn { get; set; }


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
                MiscUtils.DelayFunction(0.2f, () => {
                    if (SitOnJetpackOnSpawn)
                    {
                        jet.CurrentChair.EnterStation();
                    }
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
                var jet = item.GetOrAddComponent<JetpackController>();
                MiscUtils.DelayFunction(0.2f, () =>
                {
                    if (SitOnJetpackOnSpawn)
                    {
                        jet.CurrentChair.EnterStation();
                    }
                });

                DesktopJetpack = item;
                item.GetOrAddComponent<RegisterAsPrefab>();

            }

        }

        private static void ExitJetpack(GameObject obj)
        {
            if (obj != null)
            {
                var Jetpack = obj.GetComponent<JetpackController>();
                if (Jetpack != null)
                {
                    Jetpack.CurrentChair.BlockVanillaStationExit = false;
                    Jetpack.CurrentChair.ExitStation();

                }
            }
        }

        internal static void ExitJetpacks()
        {
            ExitJetpack(VRJetpack);
            ExitJetpack(DesktopJetpack);

        }

    }
}