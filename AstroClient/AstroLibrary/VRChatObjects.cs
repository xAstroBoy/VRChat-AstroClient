namespace AstroLibrary
{
    using Extensions;
    using UnityEngine;
    using Utility;

    internal class VRChatObjects
    {
        #region Pages

        public static GameObject SettingsPage { get { return GameObject.Find("UserInterface/MenuContent/Screens/Settings"); } }
        public static GameObject SafetyPage { get { return GameObject.Find("UserInterface/MenuContent/Screens/Settings_Safety"); ; } }
        public static GameObject SocialPage { get { return GameObject.Find("UserInterface/MenuContent/Screens/Social"); ; } }
        public static GameObject UserInfoPage { get { return GameObject.Find("UserInterface/MenuContent/Screens/UserInfo"); ; } }
        public static GameObject AvatarPage { get { return GameObject.Find("UserInterface/MenuContent/Screens/Avatar"); ; } }
        public static GameObject WorldsPage { get { return GameObject.Find("UserInterface/MenuContent/Screens/Worlds"); ; } }

        #endregion Pages

        #region notification

        public static Transform NotificationMenu { get { return QuickMenuUtils.QuickMenu.transform.Find("NotificationInteractMenu"); } }
        public static GameObject NotificationMenuOBJ { get { return QuickMenuUtils.QuickMenu.transform.Find("NotificationInteractMenu").gameObject; } }

        #endregion notification

        #region QM

        public static GameObject QMInfoBar { get { return QuickMenuUtils.QuickMenu.transform.Find("QuickMenu_NewElements/_InfoBar").gameObject; } }

        public static GameObject QMWorldsButton { get { return QuickMenuUtils.QuickMenu.transform.Find("ShortcutMenu/WorldsButton").gameObject; } }
        public static GameObject QMAvatarButton { get { return QuickMenuUtils.QuickMenu.transform.Find("ShortcutMenu/AvatarButton").gameObject; } }
        public static GameObject QMSocialButton { get { return QuickMenuUtils.QuickMenu.transform.Find("ShortcutMenu/SocialButton").gameObject; } }
        public static GameObject QMSafetyButton { get { return QuickMenuUtils.QuickMenu.transform.Find("ShortcutMenu/SafetyButton").gameObject; } }
        public static GameObject QMTrustRankToggle { get { return QuickMenuUtils.QuickMenu.transform.Find("ShortcutMenu/Toggle_States_ShowTrustRank_Colors").gameObject; } }

        public static GameObject QMGoHomeButton { get { return QuickMenuUtils.QuickMenu.transform.Find("ShortcutMenu/GoHomeButton").gameObject; } }
        public static GameObject QMRespawnButton { get { return QuickMenuUtils.QuickMenu.transform.Find("ShortcutMenu/RespawnButton").gameObject; } }
        public static GameObject QMSitButton { get { return QuickMenuUtils.QuickMenu.transform.Find("ShortcutMenu/SitButton").gameObject; } }
        public static GameObject QmCalibrateButton { get { return QuickMenuUtils.QuickMenu.transform.Find("ShortcutMenu/CalibrateButton").gameObject; } }
        public static GameObject QMSettingsButton { get { return QuickMenuUtils.QuickMenu.transform.Find("ShortcutMenu/SettingsButton").gameObject; } }
        public static GameObject QMReportWorldButton { get { return QuickMenuUtils.QuickMenu.transform.Find("ShortcutMenu/ReportWorldButton").gameObject; } }

        public static GameObject QMUIElementsButton { get { return QuickMenuUtils.QuickMenu.transform.Find("ShortcutMenu/UIElementsButton").gameObject; } }
        public static GameObject QMCameraButton { get { return QuickMenuUtils.QuickMenu.transform.Find("ShortcutMenu/CameraButton").gameObject; } }
        public static GameObject QMEmoteButton { get { return QuickMenuUtils.QuickMenu.transform.Find("ShortcutMenu/EmoteButton").gameObject; } }
        public static GameObject QMEmojiButton { get { return QuickMenuUtils.QuickMenu.transform.Find("ShortcutMenu/EmojiButton").gameObject; } }
        public static GameObject QMEmojiDown { get { return GameObject.Find("/UserInterface/QuickMenu/EmojiMenu/PageDown"); } }
        public static GameObject QMEmojiUp { get { return GameObject.Find("/UserInterface/QuickMenu/EmojiMenu/PageUp"); } }

        public static GameObject QMMicButton { get { return QuickMenuUtils.QuickMenu.transform.Find("MicControls/MicButton").gameObject; } }

        public static GameObject QMStatusInfoBar { get { return GameObject.Find("/UserInterface/QuickMenu/QuickMenu_NewElements/_CONTEXT/QM_Context_User_Hover/_UserStatus/Text"); } }
        public static GameObject QMFPSText { get { return QuickMenuUtils.QuickMenu.transform.Find("ShortcutMenu/FPSText").gameObject; } }
        public static GameObject RemoveBackdrop { get { return QuickMenuUtils.QuickMenu.transform.Find("/UserInterface/MenuContent/Backdrop/Backdrop/Background").gameObject; } }
        public static GameObject RemoveSkyCube { get { return QuickMenuUtils.QuickMenu.transform.Find("/UserInterface/MenuContent/Popups/LoadingPopup/3DElements/LoadingBackground_TealGradient/SkyCube_Baked").gameObject; } }
        public static GameObject QMPingText { get { return QuickMenuUtils.QuickMenu.transform.Find("ShortcutMenu/PingText").gameObject; } }
        public static GameObject QMEarlyAccessText { get { return QuickMenuUtils.QuickMenu.transform.Find("ShortcutMenu/EarlyAccessText").gameObject; } }
        public static GameObject UIEarlyAccessText { get { return QuickMenuUtils.QuickMenu.transform.Find("/UserInterface/MenuContent/Backdrop/Backdrop/Image").gameObject; } }
        public static GameObject UIBetaShit { get { return QuickMenuUtils.QuickMenu.transform.Find("/UserInterface/MenuContent/Backdrop/Header/Tabs/ViewPort/Content/SafetyPageTab/Image (1)").gameObject; } }
        public static GameObject QMNameText { get { return QuickMenuUtils.QuickMenu.transform.Find("ShortcutMenu/NameText").gameObject; } }
        public static GameObject QMBuildNumText { get { return QuickMenuUtils.QuickMenu.transform.Find("ShortcutMenu/BuildNumText").gameObject; } }
        public static GameObject VRCSettingsBuildNumText { get { return QuickMenuUtils.QuickMenu.transform.Find("/UserInterface/MenuContent/Screens/Settings/TitlePanel/VersionText").gameObject; } }
        public static GameObject QMBuildNumTextUI { get { return QuickMenuUtils.QuickMenu.transform.Find("/UserInterface/MenuContent/Screens/Settings/TitlePanel/VersionText").gameObject; } }
        public static GameObject QMWorldText { get { return QuickMenuUtils.QuickMenu.transform.Find("ShortcutMenu/WorldText").gameObject; } }
        public static GameObject AdvancedSettingsMenu { get { return QuickMenuUtils.QuickMenu.transform.Find("/UserInterface/MenuContent/Screens/Settings/Button_AdvancedOptions/Image_NEW").gameObject; } }
        public static GameObject SafetyMenuBetaText { get { return QuickMenuUtils.QuickMenu.transform.Find("/UserInterface/MenuContent/Screens/Settings_Safety/TitlePanel/Image").gameObject; } }
        public static GameObject SafetyMenuPerformanceOptions { get { return QuickMenuUtils.QuickMenu.transform.Find("/UserInterface/MenuContent/Screens/Settings_Safety/TitlePanel/Button_PerformanceOptions/Image_NEW").gameObject; } }
        public static GameObject BindingsNew { get { return QuickMenuUtils.QuickMenu.transform.Find("/UserInterface/MenuContent/Screens/Settings/Button_EditBindings/Image_NEW").gameObject; } }
        public static GameObject RemoveInfoPanel { get { return QuickMenuUtils.QuickMenu.transform.Find("/UserInterface/MenuContent/Popups/LoadingPopup/3DElements/LoadingInfoPanel/InfoPanel_Template_ANIM").gameObject; } }

        public static GameObject Ads1 { get { return QuickMenuUtils.QuickMenu.transform.Find("ShortcutMenu/VRCPlusMiniBanner").gameObject; } }
        public static GameObject Ads2 { get { return QuickMenuUtils.QuickMenu.transform.Find("ShortcutMenu/VRCPlusThankYou").gameObject; } }
        public static GameObject Ads3 { get { return QuickMenuUtils.QuickMenu.transform.Find("ShortcutMenu/UserIconButton").gameObject; } }
        public static GameObject Ads4 { get { return QuickMenuUtils.QuickMenu.transform.Find("ShortcutMenu/UserIconCameraButton").gameObject; } }

        #endregion QM

        #region UserInteract

        public static GameObject UserInteractMenu { get { return QuickMenuUtils.QuickMenu.transform.Find("UserInteractMenu").gameObject; } }
        public static GameObject UIFriendButton { get { return QuickMenuUtils.QuickMenu.transform.Find("UserInteractMenu/FriendButton").gameObject; } }
        public static GameObject UIDetailsButton { get { return QuickMenuUtils.QuickMenu.transform.Find("UserInteractMenu/DetailsButton").gameObject; } }
        public static GameObject UIBlockButton { get { return QuickMenuUtils.QuickMenu.transform.Find("UserInteractMenu/BlockButton").gameObject; } }

        public static GameObject UIViewAvatarThreeToggle { get { return QuickMenuUtils.QuickMenu.transform.Find("UserInteractMenu/ViewAvatarThreeToggle").gameObject; } }

        public static GameObject UIMuteButton { get { return QuickMenuUtils.QuickMenu.transform.Find("UserInteractMenu/MuteButton").gameObject; } }
        public static GameObject UIMicOffButton { get { return QuickMenuUtils.QuickMenu.transform.Find("UserInteractMenu/MicOffButton").gameObject; } }
        public static GameObject UIReportAbuseButton { get { return QuickMenuUtils.QuickMenu.transform.Find("UserInteractMenu/ReportAbuseButton").gameObject; } }
        public static GameObject UIWarnButton { get { return QuickMenuUtils.QuickMenu.transform.Find("UserInteractMenu/WarnButton").gameObject; } }
        public static GameObject UIKickButton { get { return QuickMenuUtils.QuickMenu.transform.Find("UserInteractMenu/KickButton").gameObject; } }
        public static GameObject UIBackButton { get { return QuickMenuUtils.QuickMenu.transform.Find("UserInteractMenu/BackButton").gameObject; } }

        //public static GameObject UIForceLogoutButton = QuickMenuUtils.QuickMenu.transform.Find("UserInteractMenu/ForceLogoutButton").gameObject;
        //public static GameObject UITagAvatarAsDeveloperButton = QuickMenuUtils.QuickMenu.transform.Find("UserInteractMenu/TagAvatarAsDeveloperButton").gameObject;
        public static GameObject UIViewPlaylistsButton { get { return QuickMenuUtils.QuickMenu.transform.Find("UserInteractMenu/ViewPlaylistsButton").gameObject; } }

        public static GameObject UIShowAvatarStatsButton { get { return QuickMenuUtils.QuickMenu.transform.Find("UserInteractMenu/ShowAvatarStatsButton").gameObject; } }
        public static GameObject UICloneAvatarButton { get { return QuickMenuUtils.QuickMenu.transform.Find("UserInteractMenu/CloneAvatarButton").gameObject; } }
        public static GameObject UIShowAuthorButton { get { return QuickMenuUtils.QuickMenu.transform.Find("UserInteractMenu/ShowAuthorButton").gameObject; } }

        #endregion UserInteract

        #region Avatar

        public static GameObject AvatarFavoriteButton { get { return GameObject.Find("UserInterface/MenuContent/Screens/Settings/Favorite Button"); } }
        public static GameObject AvatarTitleText { get { return GameObject.Find("UserInterface/MenuContent/Screens/Settings/TitlePanel (1)/TitleText"); } }
        public static GameObject AvatarPublicAvatarList { get { return GameObject.Find("UserInterface/MenuContent/Screens/Settings/Vertical Scroll View/Viewport/Content/Public Avatar List"); } }
        public static GameObject AvatarChangeButton { get { return GameObject.Find("UserInterface/MenuContent/Screens/Settings/Change Button"); } }
        public static GameObject AvatarStatsButton { get { return GameObject.Find("UserInterface/MenuContent/Screens/Settings/Stats Button"); } }
        public static GameObject AvatarModel { get { return GameObject.Find("UserInterface/MenuContent/Screens/Settings/AvatarModel"); } }

        #endregion Avatar

        #region Social

        public static GameObject SocialSearch { get { return GameObject.Find("UserInterface/MenuContent/Social/Vertical Scroll View/Viewport/Content/Search"); } }
        public static GameObject SocialOfflineFriendsList { get { return GameObject.Find("UserInterface/MenuContent/Social/Vertical Scroll View/Viewport/Content/OfflineFriends"); } }
        public static GameObject SocialOnlineFriendsList { get { return GameObject.Find("UserInterface/MenuContent/Social/Vertical Scroll View/Viewport/Content/OfflineFriends"); } }
        public static GameObject SocialFriendRequestList { get { return GameObject.Find("UserInterface/MenuContent/Social/ Vertical Scroll View/Viewport/Content/FriendRequests"); } }
        public static GameObject SocialFriendsGroup1List { get { return GameObject.Find("UserInterface/MenuContent/Social/Vertical Scroll View/Viewport/Content/FriendsGroup1"); } }
        public static GameObject SocialFriendsGroup2List { get { return GameObject.Find("UserInterface/MenuContent/Social/Vertical Scroll View/Viewport/Content/FriendsGroup2"); } }
        public static GameObject SocialFriendsGroup3List { get { return GameObject.Find("UserInterface/MenuContent/Social/Vertical Scroll View/Viewport/Content/FriendsGroup3"); } }

        #endregion Social

        #region UserInfo

        public static GameObject UserInfoPlaylistButton { get { return GameObject.Find("MenuContent/Screens/UserInfo/User Panel/Playlists/PlaylistsButton"); } }
        public static GameObject USINFOVRCSupportButton { get { return GameObject.Find("UserInterface/MenuContent/Screens/UserInfo/User Panel/Supporter"); } }
        public static GameObject USINFOStupidCat { get { return GameObject.Find("UserInterface/MenuContent/Screens/UserInfo/User Panel/VRCPlusEarlyAdopter"); } }

        #endregion UserInfo

        #region Settings

        public static GameObject SettingsTitleText { get { return Utils.VRCUiManager.GetMenuContent().transform.Find("Screens/Settings/TitlePanel/TitleText").gameObject; } }
        public static GameObject SettingsVersionText { get { return Utils.VRCUiManager.GetMenuContent().transform.Find("Screens/Settings/TitlePanel/VersionText").gameObject; } }
        public static GameObject SettingsAudioSlider { get { return Utils.VRCUiManager.GetMenuContent().transform.Find("Screens/Settings/AudioDevicePanel/VolumeSlider").gameObject; } }
        public static GameObject SettingsAudioSelectPrevMic { get { return Utils.VRCUiManager.GetMenuContent().transform.Find("Screens/Settings/AudioDevicePanel/SelectPrevMic").gameObject; } }
        public static GameObject SettingsAudioSelectNextMic { get { return Utils.VRCUiManager.GetMenuContent().transform.Find("Screens/Settings/AudioDevicePanel/SelectNextMic").gameObject; } }
        public static GameObject SettingsNameText { get { return Utils.VRCUiManager.GetMenuContent().transform.Find("Screens/Settings/Footer/NameText").gameObject; } }

        #endregion Settings

        #region notifications

        public static GameObject HudRoot { get { return GameObject.Find("UserInterface/UnscaledUI/HudContent/Hud").gameObject; } }
        public static GameObject InviteObj { get { return HudRoot.transform.Find("NotificationDotParent/InviteDot").gameObject; } }
        public static GameObject InviteReqObj { get { return HudRoot.transform.Find("NotificationDotParent/InviteRequestDot").gameObject; } }
        public static GameObject NotificationObj { get { return HudRoot.transform.Find("NotificationDotParent/NotificationDot").gameObject; } }
        public static GameObject VoteKickObj { get { return HudRoot.transform.Find("NotificationDotParent/VoteKickDot").gameObject; } }
        public static GameObject FriendRequestObj { get { return HudRoot.transform.Find("NotificationDotParent/FriendRequestDot").gameObject; } }
        public static GameObject VoiceDotObj { get { return HudRoot.transform.Find("VoiceDotParent/VoiceDot").gameObject; } }
        public static GameObject VoiceDotDisabledObj { get { return HudRoot.transform.Find("VoiceDotParent/VoiceDotDisabled").gameObject; } }
        public static GameObject VoicePushToTalkKeybd { get { return HudRoot.transform.Find("VoiceDotParent/PushToTalkKeybd").gameObject; } }
        public static GameObject VoicePushToTalkXboxj { get { return HudRoot.transform.Find("VoiceDotParent/PushToTalkXbox").gameObject; } }

        #endregion notifications

        #region Mouse

        public static GameObject Mouse { get { return GameObject.Find("/_Application/CursorManager/BlueFireballMouse"); ; } }

        #endregion Mouse
    }
}