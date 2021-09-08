namespace AstroClient.Experiments
{
    using AstroClient.Components;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using RubyButtonAPI;
    using System.Collections.Generic;
    using UnityEngine;

    public class CameraTweaker : GameEvents
    {
        public static void CheckCamera()
        {
            if (userCameraParent != null)
            {
                if (!UserCamera.Is_DontDestroyOnLoad().Value)
                {
                    userCameraParent.Set_DontDestroyOnLoad();
                }
            }
            if (UserCamera != null)
            {
                if (UserCamera.Is_DontDestroyOnLoad().Value)
                {
                    UserCamera.Set_DontDestroyOnLoad();
                }
                foreach (var child in UserCamera.Get_All_Childs())
                {
                    if (!child.Is_DontDestroyOnLoad().Value)
                    {
                        child.Set_DontDestroyOnLoad();
                    }
                }
            }
        }

        public override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            CheckCamera();
            if (UserCamera != null)
            {
                if (UserCamera.parent != userCameraParent)
                {
                    ModConsole.DebugLog("Reset Camera parent to avoid Borkage.");
                    UserCamera.parent = userCameraParent;
                }
                if (ViewFinder != null)
                {
                    RigidBodyController controller = ViewFinder.gameObject.GetOrAddComponent<RigidBodyController>();
                    if (controller != null)
                    {
                        if (controller.EditMode)
                        {
                            if (controller.isKinematic)
                            {
                                controller.isKinematic = false;
                            }
                        }
                    }
                }
            }
        }

        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL)
        {
            CheckCamera(); // Just in case it Loses the Flags.
            if (IsCameraFree)
            {
                if (UserCamera != null)
                {
                    if (UserCamera.parent != null)
                    {
                        ModConsole.DebugLog("Removing Parent from Camera as isCameraFree is toggled on...");
                        UserCamera.parent = null;
                    }
                }
            }
            if (RespawnCameraOnLevelLoad)
            {
                ModConsole.DebugLog("Resetting Camera Position...");
                ViewFinder.gameObject.TeleportToMe(HumanBodyBones.RightHand);
            }
        }

        public static void InitQMMenu(QMTabMenu tab, float x, float y, bool btnHalf)
        {
            var tmp = new QMNestedButton(tab, x, y, "Camera Experiments", "Edit Camera Behaviours", null, null, null, null, btnHalf);
            _ = new QMSingleButton(tmp, 1, 0, "Set Camera (Tweaker)", () => { UserCamera.gameObject.Set_As_Object_To_Edit(); CheckCamera(); }, "Sets Camera on the tweaker", null, null, true);
            _ = new QMSingleButton(tmp, 1, 0.5f, "Set ViewFinder (Tweaker)", () => { ViewFinder.gameObject.Set_As_Object_To_Edit(); CheckCamera(); }, "Sets Camera on the tweaker", null, null, true);
            _ = new QMSingleButton(tmp, 1, 1f, "Reset Camera Parent", () => { UserCamera.parent = userCameraParent; CheckCamera(); }, "Restore Original parent", null, null, true);
            IsCameraFreeToggle = new QMSingleToggleButton(tmp, 1, 1.5f, "Free Camera", () => { IsCameraFree = true; }, "Parented Camera", () => { IsCameraFree = false; }, "Set if Camera needs to be bound or freed from you.", Color.green, Color.red, null, false, true);
            RespawnOnLevelChangeToggle = new QMSingleToggleButton(tmp, 1, 2f, "Reset Camera on Level Change", () => { RespawnCameraOnLevelLoad = true; }, "Reset Camera on Level Change", () => { RespawnCameraOnLevelLoad = false; }, "Resets Camera Position to be in front of you on level changes.", Color.green, Color.red, null, false, true);
            RespawnOnLevelChangeToggle.SetResizeTextForBestFit(true);
        }

        public static Transform UserCamera
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

        public static Transform ViewFinder
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

        public static Transform userCameraParent
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

        private static QMSingleToggleButton RespawnOnLevelChangeToggle;
        private static QMSingleToggleButton IsCameraFreeToggle;

        private static bool _RespawnCameraOnLevelLoad;

        private static bool RespawnCameraOnLevelLoad
        {
            get
            {
                return _RespawnCameraOnLevelLoad;
            }
            set
            {
                _RespawnCameraOnLevelLoad = value;
                if (RespawnOnLevelChangeToggle != null)
                {
                    RespawnOnLevelChangeToggle.SetToggleState(value);
                }
            }
        }

        private static bool _IsCameraFree;

        private static bool IsCameraFree
        {
            get
            {
                return _IsCameraFree;
            }
            set
            {
                _IsCameraFree = value;
                if (IsCameraFreeToggle != null)
                {
                    IsCameraFreeToggle.SetToggleState(value);
                }
                if (value)
                {
                    UserCamera.parent = null;
                }
                else
                {
                    UserCamera.parent = userCameraParent;
                }
                CheckCamera();
            }
        }
    }
}