// Credits to Blaze and DayOfThePlay

namespace AstroClient.xAstroBoy.Utility
{
    using System.Collections.Generic;
    using System.Linq;
    using Extensions;
    using Photon.Pun;
    using UnityEngine;
    using UnityEngine.XR;
    using VRC;
    using VRC.Core;
    using VRC.SDKBase;
    using PhotonHandler = Photon.Pun.PhotonHandler;

    public static class PlayerUtils
    {
        public static VRCPlayer? GetVRCPlayer() => VRCPlayer.field_Internal_Static_VRCPlayer_0;

        public static Player? GetPlayer() => GetVRCPlayer()?.GetPlayer();

        public static APIUser? GetAPIUser() => GetVRCPlayer()?.GetAPIUser();

        public static string UserID() => GetVRCPlayer().GetUserID();

        public static string DisplayName() => GetVRCPlayer().GetDisplayName();

        public static bool IsInVR() => XRDevice.isPresent;

        public static VRC.Player GetPlayer(this VRCPlayer instance) => instance._player;

        public static VRC.Player GetPlayer(this PlayerNet instance) => instance.prop_Player_0;

        public static VRC.Player GetPlayer(this VRCPlayerApi instance) => GameInstances.PlayerManager.GetPlayerID(instance.playerId);

        public static VRC.Player GetPlayer(this APIUser instance) => GameInstances.PlayerManager.GetPlayer(instance.id);

        public static VRCPlayer GetVRCPlayer(this VRC.Player instance) => instance._vrcplayer;

        public static VRCPlayer GetVRCPlayer(this PlayerNet instance) => instance._vrcPlayer;

        public static int GetPhotonID(this VRCPlayer instance) => instance.GetPhotonView().GetPhotonID();

        public static APIUser GetAPIUser(this VRCPlayer instance) => instance._player.prop_APIUser_0;

        public static APIUser GetAPIUser(this VRC.Player instance) => instance.prop_APIUser_0;

        public static APIUser GetAPIUser(this PlayerNet instance) => instance.GetPlayer().GetAPIUser();

        public static ApiAvatar GetApiAvatar(this VRCPlayer instance) => instance.prop_ApiAvatar_0;

        public static ApiAvatar GetApiAvatar(this VRC.Player instance) => instance.prop_ApiAvatar_0;

        public static ApiAvatar GetApiAvatarQuest(this VRCPlayer instance) => instance.prop_ApiAvatar_1;

        public static ApiAvatar GetApiAvatarQuest(this VRC.Player instance) => instance._vrcplayer.prop_ApiAvatar_1;

        public static bool IsAllPlatform(this ApiAvatar instance) => instance.supportedPlatforms == ApiModel.SupportedPlatforms.All;

        public static bool IsPCPlatform(this ApiAvatar instance) => instance.supportedPlatforms == ApiModel.SupportedPlatforms.StandaloneWindows;

        public static bool IsQuestPlatform(this ApiAvatar instance) => instance.supportedPlatforms == ApiModel.SupportedPlatforms.Android;

        public static USpeaker GetUSpeaker(this VRC.Player instance) => instance.prop_USpeaker_0;

        public static USpeaker GetUSpeaker(this VRCPlayer instance) => instance.prop_USpeaker_0;

        public static bool Is_Talking(this USpeaker speaker) => speaker.prop_Boolean_0;

        public static VRCPlayerApi GetVRCPlayerApi(this VRCPlayer instance) => instance.prop_VRCPlayerApi_0;

        public static VRCPlayerApi GetVRCPlayerApi(this VRC.Player instance) => instance.prop_VRCPlayerApi_0;

        public static VRCPlayerApi GetVRCPlayerApi(this PlayerNet instance) => instance?.GetVRCPlayer().GetVRCPlayerApi();

        public static PlayerNet GetPlayerNet(this VRC.Player instance) => instance._playerNet;

        public static PlayerNet GetPlayerNet(this VRCPlayer instance) => instance._playerNet;

        public static Photon.Realtime.LoadBalancingClient GetLoadBalancingPeer() => GetPhotonHandler().prop_LoadBalancingClient_0;

        public static PhotonHandler GetPhotonHandler() => PhotonHandler.field_Internal_Static_PhotonHandler_0;

        public static PhotonView GetPhotonView(this VRCPlayer instance) => instance.prop_PhotonView_0;

        private static int GetPhotonID(this PhotonView instance) => instance.field_Private_Int32_0;

        //public static Player GetPlayerIDPhoton(this PlayerManager Instance, int playerID) => Instance.AllPlayers()
        //    .Where(x => x.GetVRCPlayer() != null).Where(x => x.GetVRCPlayer().GetPhotonView() != null)
        //    .Where(x => x.GetVRCPlayer().GetPhotonView().GetPhotonID() == playerID).FirstOrDefault(null);

        public static List<Player> GetAllPlayers(this PlayerManager instance) => instance.AllPlayers();

        public static PlayerManager GetPlayerManager() => PlayerManager.prop_PlayerManager_0;

        public static void ReloadAvatar() => VRCPlayer.Method_Public_Static_Void_APIUser_0(GetAPIUser());

        public static void ReloadAvatar(this VRCPlayer instance) => VRCPlayer.Method_Public_Static_Void_APIUser_0(instance.GetAPIUser());

        public static void ReloadAvatar(this VRC.Player instance) => ReloadAvatar(instance.GetVRCPlayer());

        public static GameObject GetAvatar(this VRC.Player Instance) => Instance.GetVRCPlayer().GetAvatarManager().GetAvatar();

        public static GameObject GetAvatar(this VRCPlayer Instance) => Instance.GetAvatarManager().GetAvatar();

        public static VRCAvatarManager GetAvatarManager(this VRCPlayer Instance) => Instance.prop_VRCAvatarManager_0;

        public static GameObject GetAvatarObject(this VRC.Player Instance) => Instance.GetVRCPlayer().field_Internal_GameObject_0;

        public static GameObject GetAvatar(this VRCAvatarManager Instance)
        {
            if (Instance.prop_GameObject_0 != null)
                return Instance.prop_GameObject_0;
            return null;
        }

        public static ApiAvatar GetAPIAvatar(this VRCAvatarManager Instance) => Instance.field_Private_ApiAvatar_0;

        public static bool IsInVR(this VRCPlayer instance) => instance.prop_VRCPlayerApi_0.IsUserInVR();

        public static bool IsInVR(this VRCPlayerApi instance) => instance.IsUserInVR();

        public static bool IsInVR(this VRC.Player instance) => instance.prop_VRCPlayerApi_0.IsUserInVR();

        public static bool IsInstanceMaster(this VRCPlayer instance) => instance.prop_VRCPlayerApi_0.isMaster;

        public static bool IsInstanceMaster(this VRCPlayerApi instance) => instance.isMaster;

        public static bool IsInstanceMaster(this VRC.Player instance) => instance.prop_VRCPlayerApi_0.isMaster;

        public static bool IsInstanceCreator(this VRCPlayer instance)
        => instance.prop_VRCPlayerApi_0.isInstanceOwner;

        public static bool IsInstanceCreator(this VRCPlayerApi instance) => instance.isInstanceOwner;

        public static bool IsInstanceCreator(this VRC.Player instance) => instance.prop_VRCPlayerApi_0.isInstanceOwner;

        public static bool IsWorldCreator(this VRC.Player instance) => WorldUtils.World.authorId == instance.prop_APIUser_0.id;

        public static bool IsWorldCreator(this VRCPlayer instance) => WorldUtils.World.authorId == instance._player.prop_APIUser_0.id;

        public static bool IsWorldCreator(this APIUser instance) => WorldUtils.World.authorId == instance.id;

        public static bool IsFriend(this VRCPlayer instance) => APIUser.IsFriendsWith(instance._player.field_Private_APIUser_0.id);

        public static bool IsFriend(this VRC.Player instance) => APIUser.IsFriendsWith(instance.field_Private_APIUser_0.id);

        public static bool IsFriend(this APIUser instance) => APIUser.IsFriendsWith(instance.id);

        public static bool IsStaffMember(this APIUser instance) => instance.tags.Contains("admin_moderator") || instance.hasModerationPowers || instance.tags.Contains("admin_") || instance.hasSuperPowers;

        public static bool IsStaffMember(this VRCPlayer instance) => instance.GetAPIUser().tags.Contains("admin_moderator") || instance.GetAPIUser().hasModerationPowers || instance.GetAPIUser().tags.Contains("admin_") || instance.GetAPIUser().hasSuperPowers;

        public static bool IsStaffMember(this VRC.Player instance) => instance.GetAPIUser().tags.Contains("admin_moderator") || instance.GetAPIUser().hasModerationPowers || instance.GetAPIUser().tags.Contains("admin_") || instance.GetAPIUser().hasSuperPowers;

        public static string GetDisplayName(this VRCPlayerApi instance) => instance.displayName;

        public static string GetDisplayName(this VRCPlayer instance) => instance._player.prop_APIUser_0.displayName;

        public static string GetDisplayName(this VRC.Player instance) => instance.prop_APIUser_0.displayName;

        public static string GetDisplayName(this APIUser instance) => instance.displayName;

        public static string GetUserID(this VRCPlayer instance) => instance._player.prop_APIUser_0.id;

        public static string GetUserID(this VRC.Player instance) => instance.prop_APIUser_0.id;

        public static string GetUserID(this APIUser instance) => instance.id;

        public static int GetFrames(this VRC.Player instance) => instance.GetPlayerNet().prop_Byte_0 != 0 ? (int)(1000f / instance.GetPlayerNet().prop_Byte_0) : 0;

        public static int GetFrames(this VRCPlayer instance) => instance.GetPlayerNet().prop_Byte_0 != 0 ? (int)(1000f / instance.GetPlayerNet().prop_Byte_0) : 0;

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

        public static short GetPing(this VRCPlayer instance) => instance.GetPlayerNet().field_Private_Int16_0;

        public static short GetPing(this VRC.Player instance) => instance.GetPlayerNet().field_Private_Int16_0;

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

        public static string GetRankColorHex(this APIUser instance) => GetRankColor(instance.GetRank());

        private static string GetRankColor(string rank)
        {
            switch (rank.ToLower())
            {
                case "moderation user":
                    return "#5e0000";

                case "admin user":
                    return "#5e0000";

                case "legend":
                    return "#ff5e5e";

                case "veteran":
                    return "#fff821";

                case "trusted":
                    return "#a621ff";

                case "known":
                    return "#ffa200";

                case "user":
                    return "#00e62a";

                case "new user":
                    return "#00aeff";

                case "visitor":
                    return "#bababa";

                default:
                    return "#303030";
            }
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
    }
}