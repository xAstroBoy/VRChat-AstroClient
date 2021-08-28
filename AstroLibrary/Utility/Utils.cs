// Credits to Blaze and DayOfThePlay

namespace AstroLibrary.Utility
{
    using AstroLibrary.Extensions;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using UnityEngine.XR;
    using VRC;
    using VRC.SDKBase;
    using VRC.UserCamera;
    using PhotonHandler = MonoBehaviour1PrivateObInPrInBoInInInInUnique;

    public static class Utils
    {
        public static VRCUiCursorManager VRCUiCursorManager
        {
            get
            {
                return VRCUiCursorManager.field_Private_Static_VRCUiCursorManager_0;
            }
        }

        public static VRCUiPopupManager VRCUiPopupManager
        {
            get
            {
                return VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0;
            }
        }

        public static VRCUiManager VRCUiManager
        {
            get
            {
                return VRCUiManager.prop_VRCUiManager_0;
            }
        }

        public static VRC.Management.ModerationManager ModerationManager
        {
            get
            {
                return VRC.Management.ModerationManager.prop_ModerationManager_0;
            }
        }

        public static Photon.Realtime.LoadBalancingClient LoadBalancingPeer
        {
            get
            {
                return PhotonHandler.prop_LoadBalancingClient_0;
            }
        }

        public static PhotonHandler PhotonHandler
        {
            get
            {
                return PhotonHandler.field_Internal_Static_MonoBehaviour1PrivateObInPrInBoInInInInUnique_0;
            }
        }

        public static NotificationManager NotificationManager
        {
            get
            {
                return NotificationManager.field_Private_Static_NotificationManager_0;
            }
        }

        public static VRCWebSocketsManager VRCWebSocketsManager
        {
            get
            {
                return VRCWebSocketsManager.field_Private_Static_VRCWebSocketsManager_0;
            }
        }

        public static NetworkManager NetworkManager
        {
            get
            {
                return NetworkManager.field_Internal_Static_NetworkManager_0;
            }
        }

        public static PlayerManager PlayerManager
        {
            get
            {
                return PlayerManager.field_Private_Static_PlayerManager_0;
            }
        }

        public static VRCPlayer CurrentUser
        {
            get
            {
                return VRCPlayer.field_Internal_Static_VRCPlayer_0;
            }
        }

        public static VRCPlayerApi LocalPlayer
        {
            get
            {
                return Networking.LocalPlayer;
            }
        }

        public static QuickMenu QuickMenu
        {
            get
            {
                return QuickMenu.prop_QuickMenu_0;
            }
        }

        public static UserInteractMenu UserInteractMenu
        {
            get
            {
                return Resources.FindObjectsOfTypeAll<UserInteractMenu>()[0];
            }
        }

        public static QuickMenuContextualDisplay QuickMenuContextualDisplay
        {
            get
            {
                return QuickMenu.field_Private_QuickMenuContextualDisplay_0;
            }
        }

        public static Camera Camera
        {
            get
            {
                return VRCVrCamera.field_Private_Static_VRCVrCamera_0.field_Public_Camera_0;
            }
        }

        public static VRCVrCamera VRCVrCamera
        {
            get
            {
                return VRCVrCamera.field_Private_Static_VRCVrCamera_0;
            }
        }

        public static UserCameraController UserCameraController
        {
            get
            {
                return UserCameraController.field_Internal_Static_UserCameraController_0;
            }
        }

        public static VRCTrackingManager VRCTrackingManager
        {
            get
            {
                return VRCTrackingManager.field_Private_Static_VRCTrackingManager_0;
            }
        }

        public static ActionMenu ActionMenu
        {
            get
            {
                return ActionMenu.field_Private_ActionMenuOpener_0.field_Public_ActionMenu_0;
            }
        }
    }
}