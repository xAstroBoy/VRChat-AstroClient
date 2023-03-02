using AstroClient.AstroMonos.Components.Tools;
using AstroClient.AstroMonos.Prefabs;
using AstroClient.AstroMonos.Prefabs.ReimajoBoothAssets;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy;
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

        internal static float Thruster_Force_Default { get; } = -400f;
        internal static float Jetpack_Force_Default { get; } = -80;
        internal static float Thruster_Force_Current { get; set; } = -400f;
        internal static float Jetpack_Force_Current { get; set; } = -80;

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
            Vector3? Pos = GameInstances.LocalPlayer.GetPlayer().Get_Center_Of_Player();
            Quaternion? Rot = GameInstances.LocalPlayer.GetPlayer().gameObject.transform.rotation;
            if (Pos.HasValue && Rot.HasValue)
            {
                VR_Jetpack_Object = Object.Instantiate(ClientResources.Loaders.Prefabs.VRJetpack, Pos.GetValueOrDefault(), Rot.GetValueOrDefault(), null);
                VR_Jetpack_Object.AddToWorldUtilsMenu();
                VR_Jetpack_Controller = ComponentUtils.GetOrAddComponent<JetpackController>(VR_Jetpack_Object);
                if (VR_Jetpack_Controller != null)
                {
                    VR_Jetpack_Controller.AdjustScaleBasedOffAvatar = AdjustBasedOffAvatarSize;
                    MiscUtils.DelayFunction(0.2f, () =>
                    {
                        if(VR_Jetpack_Controller.Current_Jetpack_Force !=  Jetpack_Force_Current)
                        {
                            VR_Jetpack_Controller.Current_Jetpack_Force = Jetpack_Force_Current;
                        }
                        if(VR_Jetpack_Controller.Current_Thruster_Force != Thruster_Force_Current)
                        {
                            VR_Jetpack_Controller.Current_Thruster_Force = Thruster_Force_Current;
                            VR_Jetpack_Controller.IgnoreQuickBoostAnim = true;
                        }
                        if(DisableThrusterSlowDown)
                        {
                            VR_Jetpack_Controller.IgnoreQuickBoostAnim = true;
                        }
                        if (SitOnJetpackOnSpawn)
                        {
                            VR_Jetpack_Controller.CurrentChair.EnterStation();
                        }
                    });
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
            Vector3? Pos = GameInstances.LocalPlayer.GetPlayer().Get_Center_Of_Player();
            Quaternion? Rot = GameInstances.LocalPlayer.GetPlayer().gameObject.transform.rotation;
            if (Pos.HasValue && Rot.HasValue)
            {
                var item = Object.Instantiate(ClientResources.Loaders.Prefabs.DesktopJetpack, Pos.GetValueOrDefault(), Rot.GetValueOrDefault(), null);
                item.AddToWorldUtilsMenu();
                Desktop_Jetpack_Controller = ComponentUtils.GetOrAddComponent<JetpackController>(item);
                if (Desktop_Jetpack_Controller != null)
                {
                    Desktop_Jetpack_Controller.AdjustScaleBasedOffAvatar = AdjustBasedOffAvatarSize;
                    MiscUtils.DelayFunction(0.2f, () =>
                    {
                        if (Desktop_Jetpack_Controller.Current_Jetpack_Force != Jetpack_Force_Current)
                        {
                            Desktop_Jetpack_Controller.Current_Jetpack_Force = Jetpack_Force_Current;
                        }

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
            if (SpaceShuttle_Controller != null)
            {
                if (SpaceShuttle_Controller.pilotChairStation != null)
                {
                    SpaceShuttle_Controller.pilotChairStation.Station.ExitStation();
                }
            }

        }

        internal static void SetJetpackMovementForce(float newForce)
        {
            Jetpack_Force_Current = newForce;
            if(Desktop_Jetpack_Controller != null)
            {
                Desktop_Jetpack_Controller.Current_Jetpack_Force = newForce;
            }
            if(VR_Jetpack_Controller != null)
            {
                VR_Jetpack_Controller.Current_Jetpack_Force = newForce;
            }

        }
        internal static void SetThrusterMovementForce(float newForce)
        {
            Thruster_Force_Current = newForce;
            if (VR_Jetpack_Controller != null)
            {
                VR_Jetpack_Controller.Current_Thruster_Force = newForce;
                if(newForce != Thruster_Force_Default)
                {
                    VR_Jetpack_Controller.IgnoreQuickBoostAnim = true;
                }
            }

        }
        internal static void RestoreJetpackForces()
        {
            Jetpack_Force_Current = Jetpack_Force_Default;
            Thruster_Force_Current = Thruster_Force_Default;

            if (Desktop_Jetpack_Controller != null)
            {
                Desktop_Jetpack_Controller.RestoreOriginalSettings();
            }
            if (VR_Jetpack_Controller != null)
            {
                VR_Jetpack_Controller.RestoreOriginalSettings();
            }

        }
        private static SpaceShuttleController SpaceShuttle_Controller { get; set; } = null;
        private static GameObject SpaceShuttle_Object { get; set; }

        internal static void SpawnSpaceShuttle()
        {
            if (SpaceShuttle_Object != null)
            {
                UnityEngine.Object.Destroy(SpaceShuttle_Object);
                SpaceShuttle_Object = null;
                SpaceShuttle_Controller = null;
                return;
            }
            Vector3? Pos = GameInstances.LocalPlayer.GetPlayer().Get_Center_Of_Player();
            Quaternion? Rot = GameInstances.LocalPlayer.GetPlayer().gameObject.transform.rotation;
            if (Pos.HasValue && Rot.HasValue)
            {
                var item = Object.Instantiate(ClientResources.Loaders.Prefabs.SpaceShuttle, Pos.GetValueOrDefault(), Rot.GetValueOrDefault(), null);
                item.AddToWorldUtilsMenu();
                SpaceShuttle_Controller = item.FindObject("ShipController").GetOrAddComponent<SpaceShuttleController>();
                float scale = 1.3f;
                item.transform.localScale = new Vector3(scale, scale, scale);
                if (SpaceShuttle_Controller != null)
                {
                   // SpaceShuttle_Controller.Initialize(); // Force a second check.
                    MiscUtils.DelayFunction(0.2f, () =>
                    {
                        if (SitOnJetpackOnSpawn)
                        {
                            SpaceShuttle_Controller.pilotChairStation.Station.EnterStation();
                        }
                    });
                }
                SpaceShuttle_Object = item;
                ComponentUtils.GetOrAddComponent<RegisterAsPrefab>(item);

            }

        }

    }
}