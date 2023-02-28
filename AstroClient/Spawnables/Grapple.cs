using AstroClient.AstroMonos.Components.Tools;
using AstroClient.AstroMonos.Prefabs.SwingerTether.Controller;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;

namespace AstroClient.Spawnables
{
    internal class Grapple
    {
        private static VRTetherPrefabController VRTether { get; set; } = null;
        private static GameObject VRTetherObject { get; set; } = null;

        internal static void SpawnVR()
        {
            if (VRTetherObject != null)
            {
                UnityEngine.Object.Destroy(VRTetherObject);
                VRTetherObject = null;
                VRTether = null;
                return;
            }
            Vector3? Pos = GameInstances.LocalPlayer.GetPlayer().Get_Center_Of_Player();
            Quaternion? Rot = GameInstances.LocalPlayer.GetPlayer().gameObject.transform.rotation;
            if (Pos.HasValue && Rot.HasValue)
            {
                VRTetherObject = Object.Instantiate(ClientResources.Loaders.Prefabs.Grapple_VR, Pos.GetValueOrDefault(), Rot.GetValueOrDefault(), null);
                VRTetherObject.AddToWorldUtilsMenu();
                VRTether = ComponentUtils.GetOrAddComponent<VRTetherPrefabController>(VRTetherObject);
                ComponentUtils.GetOrAddComponent<RegisterAsPrefab>(VRTetherObject);
            }
        }
    }
}