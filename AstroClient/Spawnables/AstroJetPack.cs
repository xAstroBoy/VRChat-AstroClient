using AstroClient.AstroMonos.Components.Tools;
using AstroClient.AstroMonos.Prefabs;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;

namespace AstroClient.Spawnables
{
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
                var  jet = ComponentUtils.GetOrAddComponent<JetpackController>(item);
                MiscUtils.DelayFunction(0.2f, () => {
                    if (SitOnJetpackOnSpawn)
                    {
                        jet.CurrentChair.EnterStation();
                    }
                });
                ComponentUtils.GetOrAddComponent<RegisterAsPrefab>(item);
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
                var jet = ComponentUtils.GetOrAddComponent<JetpackController>(item);
                MiscUtils.DelayFunction(0.2f, () =>
                {
                    if (SitOnJetpackOnSpawn)
                    {
                        jet.CurrentChair.EnterStation();
                    }
                });

                DesktopJetpack = item;
                ComponentUtils.GetOrAddComponent<RegisterAsPrefab>(item);

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