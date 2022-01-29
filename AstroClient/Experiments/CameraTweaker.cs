namespace AstroClient.Experiments
{
    using System.Collections.Generic;
    using AstroMonos.Components.Tools;
    using Tools.Extensions;
    using UnityEngine;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.Utility;

    internal class CameraTweaker : AstroEvents
    {
        //internal static void CheckCamera()
        //{
        //    if (userCameraParent != null)
        //    {
        //        if (!UserCamera.Is_DontDestroyOnLoad().Value)
        //        {
        //            userCameraParent.Set_DontDestroyOnLoad();
        //        }
        //    }
        //    if (UserCamera != null)
        //    {
        //        if (UserCamera.Is_DontDestroyOnLoad().Value)
        //        {
        //            UserCamera.Set_DontDestroyOnLoad();
        //        }
        //        foreach (var child in UserCamera.Get_All_Childs())
        //        {
        //            if (!child.Is_DontDestroyOnLoad().Value)
        //            {
        //                child.Set_DontDestroyOnLoad();
        //            }
        //        }
        //    }
        //}

        //internal override void OnSceneLoaded(int buildIndex, string sceneName)
        //{
        //    CheckCamera();
        //    if (UserCamera != null)
        //    {
        //        if (UserCamera.parent != userCameraParent)
        //        {
        //            ModConsole.DebugLog("Reset Camera parent to avoid Borkage.");
        //            UserCamera.parent = userCameraParent;
        //        }
        //        if (ViewFinder != null)
        //        {
        //            RigidBodyController controller = ViewFinder.gameObject.GetOrAddComponent<RigidBodyController>();
        //            if (controller != null)
        //            {
        //                if (controller.EditMode)
        //                {
        //                    if (controller.isKinematic)
        //                    {
        //                        controller.isKinematic = false;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        //internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        //{
        //    CheckCamera(); // Just in case it Loses the Flags.
        //    if (IsCameraFree)
        //    {
        //        if (UserCamera != null)
        //        {
        //            if (UserCamera.parent != null)
        //            {
        //                ModConsole.DebugLog("Removing Parent from Camera as isCameraFree is toggled on...");
        //                UserCamera.parent = null;
        //            }
        //        }
        //    }
        //    if (RespawnCameraOnLevelLoad)
        //    {
        //        ModConsole.DebugLog("Resetting Camera Position...");
        //        ViewFinder.gameObject.TeleportToMe(HumanBodyBones.RightHand, true, true);
        //    }
        //}

        //internal static void InitQMMenu(QMGridTab tab)
        //{
        //    var tmp = new QMNestedGridMenu(tab, "Camera Experiments", "Edit Camera Behaviours");
        //    _ = new QMSingleButton(tmp, 1, 0, "Set Camera (Tweaker)", () => { UserCamera.gameObject.Set_As_Object_To_Edit(); CheckCamera(); }, "Sets Camera on the tweaker", null, null, true);
        //    _ = new QMSingleButton(tmp, 1, 0.5f, "Set ViewFinder (Tweaker)", () => { ViewFinder.gameObject.Set_As_Object_To_Edit(); CheckCamera(); }, "Sets Camera on the tweaker", null, null, true);
        //    _ = new QMSingleButton(tmp, 1, 1f, "Reset Camera Parent", () => { UserCamera.parent = userCameraParent; CheckCamera(); }, "Restore Original parent", null, null, true);
        //    IsCameraFreeToggle = new QMToggleButton(tmp, 1, 1.5f, "Free Camera", () => { IsCameraFree = true; }, "Parented Camera", () => { IsCameraFree = false; }, "Set if Camera needs to be bound or freed from you.", Color.green, Color.red, null, false);
        //    RespawnOnLevelChangeToggle = new QMToggleButton(tmp, 1, 2f, "Reset Camera on Level Change", () => { RespawnCameraOnLevelLoad = true; }, () => { RespawnCameraOnLevelLoad = false; }, "Resets Camera Position to be in front of you on level changes.", Color.green, Color.red, null, false);
        //}

        internal static Transform UserCamera
        {
            get
            {
                if (_UserCamera == null)
                {
                    var camerapath1 = GameObjectFinder.Find("_Application/TrackingVolume/PlayerObjects/UserCamera").transform;
                    if (camerapath1 != null)
                    {
                        return _UserCamera = camerapath1;
                    }
                    else
                    {
                        var camerapath2 = GameObjectFinder.Find("UserCamera").transform;
                        if (camerapath2 != null)
                        {
                            return _UserCamera = camerapath2;
                        }
                    }
                    return null;
                }
                else
                {
                    return _UserCamera;
                }
            }
        }

        internal static Transform ViewFinder
        {
            get
            {
                if (_ViewFinder != null)
                {
                    return _ViewFinder;
                }
                else
                {
                    var item = UserCamera.FindObject("ViewFinder").transform;
                    if (item != null)
                    {
                        return _ViewFinder = item;
                    }
                }
                return null;
            }
        }

        internal static Transform userCameraParent
        {
            get
            {
                if (_UserCameraParent != null)
                {
                    return _UserCameraParent;
                }
                else
                {
                    var item = GameObjectFinder.Find("_Application/TrackingVolume/PlayerObjects").transform;
                    if (item != null)
                    {
                        return _UserCameraParent = item;
                    }
                }
                return null;
            }
        }

        private static Transform _UserCamera;
        private static Transform _ViewFinder;
        private static Transform _UserCameraParent;

        //private static QMToggleButton RespawnOnLevelChangeToggle;
        //private static QMToggleButton IsCameraFreeToggle;

        //private static bool _RespawnCameraOnLevelLoad;

        //private static bool RespawnCameraOnLevelLoad
        //{
        //    get
        //    {
        //        return _RespawnCameraOnLevelLoad;
        //    }
        //    set
        //    {
        //        _RespawnCameraOnLevelLoad = value;
        //        if (RespawnOnLevelChangeToggle != null)
        //        {
        //            RespawnOnLevelChangeToggle.SetToggleState(value);
        //        }
        //    }
        //}

        //private static bool _IsCameraFree;

        //private static bool IsCameraFree
        //{
        //    get
        //    {
        //        return _IsCameraFree;
        //    }
        //    set
        //    {
        //        _IsCameraFree = value;
        //        if (IsCameraFreeToggle != null)
        //        {
        //            IsCameraFreeToggle.SetToggleState(value);
        //        }
        //        if (value)
        //        {
        //            UserCamera.parent = null;
        //        }
        //        else
        //        {
        //            UserCamera.parent = userCameraParent;
        //        }
        //        CheckCamera();
        //    }
        //}
    }
}