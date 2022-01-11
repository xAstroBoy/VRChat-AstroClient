// Credits to Blaze and DayOfThePlay

namespace AstroClient.xAstroBoy.Utility
{
    using UnityEngine;
    using VRC;
    using VRC.SDKBase;
    using VRC.UserCamera;
    using PhotonHandler = MonoBehaviour1PrivateObInPrInBoInInInInUnique;

    public static class GameInstances
    {
        public static VRCUiCursorManager VRCUiCursorManager => VRCUiCursorManager.field_Private_Static_VRCUiCursorManager_0;

        public static VRCUiPopupManager VRCUiPopupManager => VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0;

        public static VRCUiManager VRCUiManager => VRCUiManager.prop_VRCUiManager_0;

        public static VRC.Management.ModerationManager ModerationManager => VRC.Management.ModerationManager.prop_ModerationManager_0;

        public static Photon.Realtime.LoadBalancingClient LoadBalancingPeer => PhotonHandler.prop_LoadBalancingClient_0;

        public static PhotonHandler PhotonHandler => PhotonHandler.field_Internal_Static_MonoBehaviour1PrivateObInPrInBoInInInInUnique_0;

        public static NotificationManager NotificationManager => NotificationManager.field_Private_Static_NotificationManager_0;

        public static VRCWebSocketsManager VRCWebSocketsManager => VRCWebSocketsManager.field_Private_Static_VRCWebSocketsManager_0;

        public static PlayerManager PlayerManager => PlayerManager.field_Private_Static_PlayerManager_0;

        public static VRCPlayer CurrentUser => VRCPlayer.field_Internal_Static_VRCPlayer_0;
        public static VRC.Player CurrentPlayer => CurrentUser.GetPlayer();

        public static GameObject CurrentAvatar => CurrentPlayer.GetAvatarObject();

        public static VRCPlayerApi LocalPlayer => Networking.LocalPlayer;

        public static UserInteractMenu UserInteractMenu => Resources.FindObjectsOfTypeAll<UserInteractMenu>()[0];

        public static Camera Camera => VRCVrCamera.field_Private_Static_VRCVrCamera_0.field_Public_Camera_0;

        public static VRCVrCamera VRCVrCamera => VRCVrCamera.field_Private_Static_VRCVrCamera_0;

        public static UserCameraController UserCameraController => UserCameraController.field_Internal_Static_UserCameraController_0;

        public static VRCTrackingManager VRCTrackingManager => VRCTrackingManager.field_Private_Static_VRCTrackingManager_0;

        public static ActionMenu ActionMenu => ActionMenu.field_Private_ActionMenuOpener_0.field_Public_ActionMenu_0;
    }
}