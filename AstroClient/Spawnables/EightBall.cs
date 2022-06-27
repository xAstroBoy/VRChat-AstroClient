namespace AstroClient.Spawnables.Enderpearl
{
    using AstroMonos.Components.Custom.Items;
    using Tools.Extensions;
    using Tools.Holders;
    using UnityEngine;
    using VRC.SDKBase;
    using xAstroBoy.Utility;

    internal class EightBall 
    {
        private static GameObject EightBallObject;

        internal static void Spawn()
        {
            if (EightBallObject != null)
            {
                UnityEngine.Object.Destroy(EightBallObject);
                EightBallObject = null;
                return;
            }
            Vector3? Pos = GameInstances.LocalPlayer.GetPlayer().Get_Center_Of_Player();
            Quaternion? Rot = GameInstances.LocalPlayer.GetPlayer().gameObject.transform.rotation;
            if (Pos.HasValue && Rot.HasValue)
            {
                EightBallObject = Object.Instantiate(ClientResources.Loaders.Prefabs.EightBall, Pos.GetValueOrDefault(), Rot.GetValueOrDefault(), null);
                EightBallObject.AddToWorldUtilsMenu();
            }

        }



    }
}