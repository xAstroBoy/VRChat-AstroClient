// Credits to Blaze and DayOfThePlay

namespace AstroLibrary.Utility
{
    using AstroLibrary.Extensions;
    using UnityEngine;
    using UnityEngine.XR;
    using VRC.Core;
    using VRC.SDKBase;
    using PhotonHandler = MonoBehaviour1PrivateObInPrInBoInInInInUnique;

    public static class PlayerUtils
    {
        #region CurrentUser
        /// <summary>
        /// Gets the current VRCPlayer
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static VRCPlayer GetVRCPlayer()
        {
            return VRCPlayer.field_Internal_Static_VRCPlayer_0;
        }

        public static VRC.Player GetPlayer()
        {
            return GetVRCPlayer().GetPlayer();
        }

        /// <summary>
        /// Gets the current APIUser
        /// </summary>
        /// <returns></returns>
        public static APIUser GetAPIUser()
        {
            return GetVRCPlayer().GetAPIUser();
        }

        /// <summary>
        /// Gets the current players userid
        /// </summary>
        /// <returns></returns>
        public static string UserID()
        {
            return GetVRCPlayer().GetUserID();
        }

        /// <summary>
        /// Gets the current players dispay name
        /// </summary>
        /// <returns></returns>
        public static string DisplayName()
        {
            return GetVRCPlayer().GetDisplayName();
        }

        public static bool IsInVR()
        {
            return XRDevice.isPresent;
        }
        #endregion

        #region VRC.Player
        public static VRC.Player GetPlayer(this VRCPlayer instance)
        {
            return instance?._player;
        }

        public static VRC.Player GetPlayer(this PlayerNet instance)
        {
            return instance?.prop_Player_0;
        }

        public static VRC.Player GetPlayer(this VRCPlayerApi instance)
        {
            return Utils.PlayerManager.GetPlayerID(instance.playerId);
        }

        public static VRC.Player GetPlayer(this APIUser instance)
        {
            return Utils.PlayerManager.GetPlayer(instance.id);
        }
        #endregion

        #region VRCPlayer
        public static VRCPlayer GetVRCPlayer(this VRC.Player instance)
        {
            return instance?._vrcplayer;
        }

        public static VRCPlayer GetVRCPlayer(this PlayerNet instance)
        {
            return instance?._vrcPlayer;
        }
        #endregion

        #region API User
        public static APIUser GetAPIUser(this VRCPlayer instance)
        {
            return instance?._player.prop_APIUser_0;
        }

        public static APIUser GetAPIUser(this VRC.Player instance)
        {
            return instance?.prop_APIUser_0;
        }

        public static APIUser GetAPIUser(this PlayerNet instance)
        {
            return instance?.GetPlayer().GetAPIUser();
        }
        #endregion

        #region Api Avatar
        // Get PC Api Avatar
        public static ApiAvatar GetApiAvatar(this VRCPlayer instance)
        {
            return instance.prop_ApiAvatar_0;
        }

        public static ApiAvatar GetApiAvatar(this VRC.Player instance)
        {
            return instance.prop_ApiAvatar_0;
        }

        // Get Quest Api Avatar (fallback avatar)
        public static ApiAvatar GetApiAvatarQuest(this VRCPlayer instance)
        {
            return instance.prop_ApiAvatar_1;
        }

        public static ApiAvatar GetApiAvatarQuest(this VRC.Player instance)
        {
            return instance._vrcplayer.prop_ApiAvatar_1;
        }

        // Api Avatar Details
        public static bool IsAllPlatform(this ApiAvatar instance)
        {
            return instance.supportedPlatforms == ApiModel.SupportedPlatforms.All;
        }

        public static bool IsPCPlatform(this ApiAvatar instance)
        {
            return instance.supportedPlatforms == ApiModel.SupportedPlatforms.StandaloneWindows;
        }

        public static bool IsQuestPlatform(this ApiAvatar instance)
        {
            return instance.supportedPlatforms == ApiModel.SupportedPlatforms.Android;
        }

        #endregion

        #region USpeaker
        public static USpeaker GetUSpeaker(this VRC.Player instance)
        {
            return instance.prop_USpeaker_0;
        }

        public static USpeaker GetUSpeaker(this VRCPlayer instance)
        {
            return instance.prop_USpeaker_0;
        }

        public static bool Is_Talking(this USpeaker speaker)
        {
            return speaker.prop_Boolean_0;
        }
        #endregion

        #region VRCPlayerApi
        public static VRCPlayerApi GetVRCPlayerApi(this VRCPlayer instance)
        {
            return instance?.prop_VRCPlayerApi_0;
        }

        public static VRCPlayerApi GetVRCPlayerApi(this VRC.Player instance)
        {
            return instance?.prop_VRCPlayerApi_0;
        }

        public static VRCPlayerApi GetVRCPlayerApi(this PlayerNet instance)
        {
            return instance?.GetVRCPlayer().GetVRCPlayerApi();
        }
        #endregion

        #region PlayerNet
        public static PlayerNet GetPlayerNet(this VRC.Player instance)
        {
            return instance._playerNet;
        }

        public static PlayerNet GetPlayerNet(this VRCPlayer instance)
        {
            return instance._playerNet;
        }
        #endregion

        #region Photon
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
        #endregion

        #region Avatar
        public static void ReloadAvatar()
        {
            VRCPlayer.Method_Public_Static_Void_APIUser_0(GetAPIUser());
        }

        public static void ReloadAvatar(this VRCPlayer instance)
        {
            VRCPlayer.Method_Public_Static_Void_APIUser_0(instance.GetAPIUser());
        }

        public static void ReloadAvatar(this VRC.Player instance)
        {
            ReloadAvatar(instance.GetVRCPlayer());
        }

        public static GameObject GetAvatar(this VRC.Player Instance)
        {
            return Instance.GetVRCPlayer().GetAvatarManager().GetAvatar();
        }

        public static GameObject GetAvatar(this VRCPlayer Instance)
        {
            return Instance.GetAvatarManager().GetAvatar();
        }

        public static VRCAvatarManager GetAvatarManager(this VRCPlayer Instance)
        {
            return Instance.prop_VRCAvatarManager_0;
        }

        public static GameObject GetAvatar(this VRCAvatarManager Instance)
        {
            if (Instance.prop_GameObject_0 != null)
                return Instance.prop_GameObject_0;
            return null;
        }

        public static ApiAvatar GetAPIAvatar(this VRCAvatarManager Instance)
        {
            return Instance.field_Private_ApiAvatar_0;
        }
        #endregion

        #region User Info
        // Is In VR
        public static bool IsInVR(this VRCPlayer instance)
        {
            return instance.prop_VRCPlayerApi_0.IsUserInVR();
        }

        public static bool IsInVR(this VRCPlayerApi instance)
        {
            return instance.IsUserInVR();
        }

        public static bool IsInVR(this VRC.Player instance)
        {
            return instance.prop_VRCPlayerApi_0.IsUserInVR();
        }

        // Is Instance Master
        public static bool IsInstanceMaster(this VRCPlayer instance)
        {
            return instance.prop_VRCPlayerApi_0.isMaster;
        }

        public static bool IsInstanceMaster(this VRCPlayerApi instance)
        {
            return instance.isMaster;
        }

        public static bool IsInstanceMaster(this VRC.Player instance)
        {
            return instance.prop_VRCPlayerApi_0.isMaster;
        }

        // Is Instance Creator
        public static bool IsInstanceCreator(this VRCPlayer instance)
        {
            return instance.prop_VRCPlayerApi_0.isInstanceOwner;
        }

        public static bool IsInstanceCreator(this VRCPlayerApi instance)
        {
            return instance.isInstanceOwner;
        }

        public static bool IsInstanceCreator(this VRC.Player instance)
        {
            return instance.prop_VRCPlayerApi_0.isInstanceOwner;
        }

        // Is World Creator
        public static bool IsWorldCreator(this VRC.Player instance)
        {
            return WorldUtils.GetWorld().authorId == instance.prop_APIUser_0.id;
        }

        public static bool IsWorldCreator(this VRCPlayer instance)
        {
            return WorldUtils.GetWorld().authorId == instance._player.prop_APIUser_0.id;
        }

        public static bool IsWorldCreator(this APIUser instance)
        {
            return WorldUtils.GetWorld().authorId == instance.id;
        }

        // Is Friend
        public static bool IsFriend(this VRCPlayer instance)
        {
            return APIUser.IsFriendsWith(instance._player.field_Private_APIUser_0.id);
        }

        public static bool IsFriend(this VRC.Player instance)
        {
            return APIUser.IsFriendsWith(instance.field_Private_APIUser_0.id);
        }

        public static bool IsFriend(this APIUser instance)
        {
            return APIUser.IsFriendsWith(instance.id);
        }

        // Is Staff Member
        public static bool IsStaffMember(this APIUser instance)
        {
            return instance.tags.Contains("admin_moderator")
                || instance.hasModerationPowers
                || instance.tags.Contains("admin_")
                || instance.hasSuperPowers
                || instance.id == "usr_81ac81f6-cdd1-4eaa-961f-22a80dc772c9";
        }

        public static bool IsStaffMember(this VRCPlayer instance)
        {
            return instance.GetAPIUser().tags.Contains("admin_moderator")
                || instance.GetAPIUser().hasModerationPowers
                || instance.GetAPIUser().tags.Contains("admin_")
                || instance.GetAPIUser().hasSuperPowers
                || instance.GetAPIUser().id == "usr_81ac81f6-cdd1-4eaa-961f-22a80dc772c9";
        }

        public static bool IsStaffMember(this VRC.Player instance)
        {
            return instance.GetAPIUser().tags.Contains("admin_moderator")
                || instance.GetAPIUser().hasModerationPowers
                || instance.GetAPIUser().tags.Contains("admin_")
                || instance.GetAPIUser().hasSuperPowers
                || instance.GetAPIUser().id == "usr_81ac81f6-cdd1-4eaa-961f-22a80dc772c9";
        }

        // Display Name
        public static string GetDisplayName(this VRCPlayerApi instance)
        {
            return instance.displayName;
        }

        public static string GetDisplayName(this VRCPlayer instance)
        {
            return instance._player.prop_APIUser_0.displayName;
        }

        public static string GetDisplayName(this VRC.Player instance)
        {
            return instance.prop_APIUser_0.displayName;
        }

        public static string GetDisplayName(this APIUser instance)
        {
            return instance.displayName;
        }

        // User ID
        public static string GetUserID(this VRCPlayer instance)
        {
            return instance._player.prop_APIUser_0.id;
        }

        public static string GetUserID(this VRC.Player instance)
        {
            return instance.prop_APIUser_0.id;
        }

        public static string GetUserID(this APIUser instance)
        {
            return instance.id;
        }

        // Frames
        public static int GetFrames(this VRC.Player instance)
        {
            return instance.GetPlayerNet().prop_Byte_0 != 0 ? (int)(1000f / instance.GetPlayerNet().prop_Byte_0) : 0;
        }

        public static int GetFrames(this VRCPlayer instance)
        {
            return instance.GetPlayerNet().prop_Byte_0 != 0 ? (int)(1000f / instance.GetPlayerNet().prop_Byte_0) : 0;
        }

        public static string GetFramesColored(this VRC.Player instance)
        {
            var frames = instance.GetFrames();
            return frames >= 80
                ? $"<color=green>{frames}</color>"
                : frames <= 25 ? $"<color=red>{frames}</color>" : $"<color=orange>{frames}</color>";
        }

        public static string GetFramesColored(this VRCPlayer instance)
        {
            var frames = instance.GetFrames();
            return frames >= 80
                ? $"<color=green>{frames}</color>"
                : frames <= 25 ? $"<color=red>{frames}</color>" : $"<color=orange>{frames}</color>";
        }

        // Ping
        public static short GetPing(this VRCPlayer instance)
        {
            return instance.GetPlayerNet().field_Private_Int16_0;
        }

        public static short GetPing(this VRC.Player instance)
        {
            return instance.GetPlayerNet().field_Private_Int16_0;
        }

        public static string GetPingColored(this VRCPlayer instance)
        {
            var ping = instance.GetPing();
            return ping >= 80 ? $"<color=red>{ping}</color>" : ping <= 35 ? $"<color=green>{ping}</color>" : $"<color=orange>{ping}</color>";
        }

        public static string GetPingColored(this VRC.Player instance)
        {
            var ping = instance.GetPing();
            return ping >= 80 ? $"<color=red>{ping}</color>" : ping <= 35 ? $"<color=green>{ping}</color>" : $"<color=orange>{ping}</color>";
        }
        #endregion

        #region Ranks
        public static Color GetRankColor(this APIUser instance)
        {
            if (instance != null)
            {
                ColorUtility.DoTryParseHtmlColor(GetRankColor(instance.GetRank()), out Color32 color);
                return color;
            }
            else
            {
                return Color.white;
            }
        }

        public static string GetRankColorHex(this APIUser instance)
        {
            string playerRank = instance.GetRank();
            return GetRankColor(playerRank);
        }

        private static string GetRankColor(string rank)
        {
            return rank.ToLower() switch
            {
                "moderation user" => "#5e0000",
                "admin user" => "#5e0000",
                "legend" => "#ff5e5e",
                "veteran" => "#fff821",
                "trusted" => "#a621ff",
                "known" => "#ffa200",
                "user" => "#00e62a",
                "new user" => "#00aeff",
                "visitor" => "#bababa",
                _ => "#303030",
            };
        }

        public static string GetRank(this APIUser instance)
        {
            if (instance.hasModerationPowers || instance.tags.Contains("admin_moderator"))
                return "Moderation User";
            if (instance.hasSuperPowers || instance.tags.Contains("admin_"))
                return "Admin User";
            if (instance.tags.Contains("system_legend") && instance.tags.Contains("system_trust_legend") && instance.tags.Contains("system_trust_trusted"))
                return "Legend";
            if (instance.tags.Contains("system_trust_legend") && instance.tags.Contains("system_trust_trusted"))
                return "Veteran";
            if (instance.hasVeteranTrustLevel)
                return "Trusted";
            if (instance.hasTrustedTrustLevel)
                return "Known";
            if (instance.hasKnownTrustLevel)
                return "User";
            if (instance.hasBasicTrustLevel || instance.isNewUser)
                return "New User";
            if (instance.hasNegativeTrustLevel || instance.tags.Contains("system_probable_troll"))
                return "NegativeTrust";
            if (instance.hasVeryNegativeTrustLevel)
                return "VeryNegativeTrust";
            return "Visitor";
        }
        #endregion

        #region Module Based Methods
        public static string GetTags(VRC.Player instance)
        {
            string results = string.Empty;

            if (instance.IsStaffMember())
                return "[<color=red>MOD</color>]";
            else
            {
                if (instance.IsWorldCreator())
                    results += $"[<color=#{ColorUtility.ToHtmlStringRGB(new Color32(255, 0, 220, 255))}>WC</color>]";

                if (instance.IsInstanceCreator() && !instance.IsWorldCreator())
                    results += $"[<color=#{ColorUtility.ToHtmlStringRGB(new Color32(76, 255, 0, 255))}>IC</color>]";

                if (instance.IsInstanceMaster() && !instance.IsWorldCreator() && !instance.IsInstanceCreator())
                    results += $"[<color=#{ColorUtility.ToHtmlStringRGB(new Color32(255, 106, 0, 255))}>M</color>]";

                return results;
            }
        }

        public static string GetPlatform(this VRC.Player instance)
        {
            if (instance.prop_VRCPlayerApi_0.IsUserInVR())
            {
                if (instance.prop_APIUser_0.last_platform.ToLower() != "standalonewindows")
                {
                    return "Quest";
                }
                else
                {
                    return "VR";
                }
            }
            else
            {
                return "Desktop";
            }
        }

        public static string GetPlatformColored(this VRC.Player instance)
        {
            if (instance.prop_VRCPlayerApi_0.IsUserInVR())
            {
                return instance.GetPlatform() != "VR" ? "<color=#1aff00>[Q]</color>" : "<color=grey>[VR]</color>";
            }
            else
            {
                return "<color=grey>[D]</color>";
            }
        }

        public static string GetState(this VRC.Player instance)
        {
            if (instance.prop_APIUser_0.statusIsSetToAskMe)
            {
                return "Ask Me";
            }
            else if (instance.prop_APIUser_0.statusIsSetToDoNotDisturb)
            {
                return "Do Not Disturb";
            }
            else if (instance.prop_APIUser_0.statusIsSetToJoinMe)
            {
                return "Join Me";
            }
            else
            {
                return "Online";
            }
        }

        public static string GetState(this APIUser instance)
        {
            if (instance.statusIsSetToAskMe)
            {
                return "Ask Me";
            }
            else if (instance.statusIsSetToDoNotDisturb)
            {
                return "Do Not Disturb";
            }
            else if (instance.statusIsSetToJoinMe)
            {
                return "Join Me";
            }
            else
            {
                return "Online";
            }
        }

        public static string GetState(this VRCPlayer instance)
        {
            if (instance._player.prop_APIUser_0.statusIsSetToAskMe)
            {
                return "Ask Me";
            }
            else if (instance._player.prop_APIUser_0.statusIsSetToDoNotDisturb)
            {
                return "Do Not Disturb";
            }
            else if (instance._player.prop_APIUser_0.statusIsSetToJoinMe)
            {
                return "Join Me";
            }
            else
            {
                return "Online";
            }
        }
        #endregion

        #region Mod Methods

        //internal static string GetTrueRank(this APIUser instance)
        //{
        //    var apiUser = Modules.TrueRanks.CachedApiUsers.Find(x => x.id == instance.id) ?? instance;
        //    return GetRank(apiUser);
        //}

        //internal static string GetTrueRankColor(this APIUser instance)
        //{
        //    var apiUser = Modules.TrueRanks.CachedApiUsers.Find(x => x.id == instance.id) ?? instance;
        //    return GetRankColor(apiUser);
        //}
        #endregion
    }
}
