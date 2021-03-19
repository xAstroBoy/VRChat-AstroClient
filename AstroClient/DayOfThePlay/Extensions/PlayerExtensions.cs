using DayClientML2.Managers;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.SDKBase;

namespace DayClientML2.Utility.Extensions
{
    internal static class PlayerExtensions
    {
        #region ApiUser

        public static APIUser GetAPIUser(this Player Instance)
        {
            return Instance == null ? null : Instance.field_Private_APIUser_0;
        }

        public static APIUser GetAPIUser(this VRCPlayer Instance)
        {
            return Instance == null ? null : Instance.GetPlayer().GetAPIUser();
        }

        public static APIUser GetAPIUser(this PlayerNet Instance)
        {
            return Instance == null ? null : Instance.GetPlayer().GetAPIUser();
        }

        #endregion ApiUser

        #region Player

        public static Player GetPlayer(this VRCPlayer Instance)
        {
            return Instance == null ? null : Instance.field_Private_Player_0;
        }

        public static Player GetPlayer(this PlayerNet Instance)
        {
            return Instance == null ? null : Instance.prop_Player_0;
        }

        public static Player GetPlayer(this VRCPlayerApi Instance)
        {
            return Instance == null ? null : Utils.PlayerManager.GetPlayerID(Instance.playerId);
        }

        public static Player GetTryPlayer(this APIUser Instance)
        {
            return Instance == null ? null : Utils.PlayerManager.GetPlayer(Instance.id);
        }

        #endregion Player

        #region VRCPlayer

        public static VRCPlayer GetVRCPlayer(this Player Instance)
        {
            return Instance == null ? null : Instance.field_Internal_VRCPlayer_0;
        }

        public static VRCPlayer GetVRCPlayer(this PlayerNet Instance)
        {
            return Instance == null ? null : Instance.field_Internal_VRCPlayer_0;
        }

        public static VRCPlayer GetVRCPlayer(this VRCPlayerApi Instance)
        {
            return Instance == null ? null : Utils.PlayerManager.GetPlayerID(Instance.playerId).GetVRCPlayer();
        }

        #endregion VRCPlayer

        #region VRCPlayerAPI

        public static VRCPlayerApi GetVRCPlayerApi(this Player Instance)
        {
            return Instance == null ? null : Instance.prop_VRCPlayerApi_0;
        }

        public static VRCPlayerApi GetVRCPlayerApi(this VRCPlayer Instance)
        {
            return Instance == null ? null : Instance.prop_VRCPlayerApi_0;
        }

        public static VRCPlayerApi GetVRCPlayerApi(this PlayerNet Instance)
        {
            return Instance == null ? null : Instance.GetVRCPlayer().GetVRCPlayerApi();
        }

        #endregion VRCPlayerAPI

        #region PlayerNet

        public static PlayerNet GetPlayerNet(this Player Instance)
        {
            return Instance == null ? null : Instance.prop_PlayerNet_0;
        }

        public static PlayerNet GetPlayerNet(this VRCPlayer Instance)
        {
            return Instance == null ? null : Instance.prop_PlayerNet_0;
        }

        #endregion PlayerNet

        #region Misc

        public static string UserID(this Player Instance)
        {
            return Instance.GetAPIUser().id;
        }

        public static string UserID(this VRCPlayer Instance)
        {
            return Instance.GetAPIUser().id;
        }

        public static string UserID(this PlayerNet Instance)
        {
            return Instance.GetAPIUser().id;
        }

        public static string UserID(this APIUser Instance)
        {
            return Instance.id;
        }

        public static string DisplayName(this Player Instance)
        {
            return Instance.GetAPIUser().displayName;
        }

        public static string DisplayName(this VRCPlayer Instance)
        {
            return Instance.GetAPIUser().displayName;
        }

        public static string DisplayName(this PlayerNet Instance)
        {
            return Instance.GetAPIUser().displayName;
        }

        public static string DisplayName(this APIUser Instance)
        {
            return Instance.displayName;
        }

        public static bool GetIsMaster(this Player Instance)
        {
            return Instance.GetVRCPlayerApi().isMaster;
        }

        public static bool GetIsMaster(this VRCPlayer Instance)
        {
            return Instance.GetVRCPlayerApi().isMaster;
        }

        public static bool GetIsMaster(this PlayerNet Instance)
        {
            return Instance.GetVRCPlayerApi().isMaster;
        }

        public static bool GetIsInVR(this Player Instance)
        {
            return Instance.GetVRCPlayerApi().IsUserInVR();
        }

        public static bool GetIsInVR(this VRCPlayer Instance)
        {
            return Instance.GetVRCPlayerApi().IsUserInVR();
        }

        public static bool GetIsInVR(this PlayerNet Instance)
        {
            return Instance.GetVRCPlayerApi().IsUserInVR();
        }

        public static short GetPing(this VRCPlayer Instance)
        {
            return Instance.GetPlayerNet().field_Private_Int16_0;
        }

        public static int GetFrames(this VRCPlayer Instance)
        {
            return (Instance.GetPlayerNet().prop_Byte_0 != 0 ? (int)(1000f / (float)Instance.GetPlayerNet().prop_Byte_0) : 0);
        }

        public static float GetQuality(this VRCPlayer Instance)
        {
            return float.Parse((((!(Instance.GetPlayerNet() == null)) ? Instance.GetPlayerNet().prop_Single_0 : 0f) * 100).ToString("0.00"));
        }

        public static double GetDelay(this VRCPlayer Instance)
        {
            // -Day: Still working on it
            int num = Mathf.FloorToInt((float)(Instance.GetPing() + 50) / 10f);
            int num2 = Mathf.FloorToInt((1f - Instance.GetQuality()) * 10f);
            double num3 = (double)Mathf.Min(2f, (float)(num + num2));
            return 0.20f * num3;
        }

        public static ulong GetSteamID(this VRCPlayer player)
        {
            return player.field_Private_UInt64_0;
        }

        public static string GetPingColored(this VRCPlayer Instance)
        {
            string color = "";
            if (Instance.GetPing() <= 75)
                color = "<color=#59D365>";
            else if (Instance.GetPing() >= 75 && Instance.GetPing() <= 150)
                color = "<color=#FF7000>";
            else
                color = "<color=red>";

            return $"{color}{Instance.GetPing()}</color>";
        }

        public static string GetFramesColored(this VRCPlayer Instance)
        {
            string color = "";
            if (Instance.GetFrames() >= 80)
                color = "<color=#59D365>";
            else if (Instance.GetFrames() <= 80 && Instance.GetFrames() >= 30)
                color = "<color=#FF7000>";
            else
                color = "<color=red>";

            return $"{color}{Instance.GetFrames()}</color>";
        }

        public static string GetQualityColored(this VRCPlayer Instance)
        {
            string color = "";
            if (Instance.GetQuality() >= 90)
                color = "<color=#59D365>";
            else if (Instance.GetQuality() <= 90 && Instance.GetQuality() >= 60)
                color = "<color=#FF7000>";
            else
                color = "<color=red>";

            return $"{color}{Instance.GetQuality()}</color>";
        }

        public static void ReloadAvatar(this VRCPlayer Instance)
        {
            VRCPlayer.Method_Public_Static_Void_APIUser_0(Instance.GetAPIUser());
        }

        public static void ReloadAvatar(this Player Instance)
        {
            ReloadAvatar(Instance.GetVRCPlayer());
        }

        #endregion Misc

        #region Ranks

        public static string GetRank(this APIUser Instance)
        {
            if (Instance.hasModerationPowers || Instance.tags.Contains("admin_moderator"))
                return "Moderation User";
            if (Instance.hasSuperPowers || Instance.tags.Contains("admin_"))
                return "Admin User";
            if (Instance.tags.Contains("system_legend") && Instance.tags.Contains("system_trust_legend") && Instance.tags.Contains("system_trust_trusted"))
                return "Legend";
            if (Instance.hasLegendTrustLevel || Instance.tags.Contains("system_trust_legend") && Instance.tags.Contains("system_trust_trusted"))
                return "Veteran";
            if (Instance.hasVeteranTrustLevel)
                return "Trusted";
            if (Instance.hasTrustedTrustLevel)
                return "Known";
            if (Instance.hasKnownTrustLevel)
                return "User";
            if (Instance.hasBasicTrustLevel || Instance.isNewUser)
                return "New User";
            if (Instance.hasNegativeTrustLevel)
                return "NegativeTrust";
            if (Instance.hasVeryNegativeTrustLevel)
                return "VeryNegativeTrust";
            return "Visitor";
        }

        public static RankType GetRankEnum(this APIUser Instance)
        {
            if (Instance.hasModerationPowers || Instance.tags.Contains("admin_moderator"))
                return RankType.Moderator;
            if (Instance.hasSuperPowers || Instance.tags.Contains("admin_"))
                return RankType.Admin;
            if (Instance.tags.Contains("system_legend") && Instance.tags.Contains("system_trust_legend") && Instance.tags.Contains("system_trust_trusted"))
                return RankType.Legend;
            if (Instance.hasLegendTrustLevel || Instance.tags.Contains("system_trust_legend") && Instance.tags.Contains("system_trust_trusted"))
                return RankType.Veteran;
            if (Instance.hasVeteranTrustLevel)
                return RankType.Trusted;
            if (Instance.hasTrustedTrustLevel)
                return RankType.Known;
            if (Instance.hasKnownTrustLevel)
                return RankType.User;
            if (Instance.hasBasicTrustLevel || Instance.isNewUser)
                return RankType.newUser;
            if (Instance.hasNegativeTrustLevel)
                return RankType.NegativeTrust;
            if (Instance.hasVeryNegativeTrustLevel)
                return RankType.VeryNegativeTrust;
            return RankType.visitor;
        }

        public enum RankType
        {
            Moderator,
            Admin,
            Legend,
            Veteran,
            Trusted,
            Known,
            User,
            newUser,
            visitor,
            NegativeTrust,
            VeryNegativeTrust,
        }

        public static string GetThings(this VRCPlayer Instance)
        {
            // Small confusion between [BOT] and [B] when first connecting to the client, just a FYI.    - Love
            string returnstring = string.Empty;
            // arion remember when we where trying to find out why it wasnt showing me in the playerlist in the quickemnu... well i just found it -HI/Nekro
            if (GetIsBot(Instance))
                returnstring += "<color=red>[BOT]</color> ";
            if (Instance.GetAPIUser().statusValue == APIUser.UserStatus.Offline)
                returnstring += "<color=gray>[Offline]</color> ";

            if (Instance.UserID() != APIUser.CurrentUser.id && Utils.ModerationManager.GetIsBlocked(Instance.UserID()) && Utils.ModerationManager.GetIsBlockedByUser(Instance.UserID()))
                returnstring += "<color=magenta>[B]</color> ";

            if (Instance.UserID() != APIUser.CurrentUser.id && Utils.ModerationManager.GetIsBlocked(Instance.UserID()))
                returnstring += "<color=cyan>[B]</color> ";

            if (Instance.UserID() != APIUser.CurrentUser.id && Utils.ModerationManager.GetIsBlockedByUser(Instance.UserID()))
                returnstring += "<color=red>[B]</color> ";
            if (Instance.GetAPIUser().isFriend)
                returnstring += "<color=yellow>[F]</color> ";
            if (Instance.GetVRCPlayerApi().isMaster)
                returnstring += "<color=#12F1FF>[O]</color> ";
            if (Instance.GetIsDANGER())
            {
                returnstring += "<color=#FFC4FF>[MODERATOR]</color> ";
                Instance.GetVRCPlayerApi().ClearPlayerTags();
            }
            if (Instance.GetAPIUser().isSupporter)
                returnstring += "<color=yellow>[V+]</color> ";
            if (Instance.GetAPIUser().IsOnMobile)
                returnstring += "<color=#59D365>[Q]</color> ";
            //if (Instance.GetAPIUser().id == Config.Instance.Target)
            //    returnstring += "<color=red>[T]</color>";
            //if (Config.Instance.SeeMore)
            //    returnstring += $"[{Instance.GetVRCPlayerApi().playerId}]";
            //var groups = Modules.Misc.KosHelper.GetGroups(Instance.GetAPIUser().id);
            //foreach (var group in groups)
            //{
            //    if (group != null)
            //    {
            //        returnstring += $"<color=red>[{group.GroupName}]</color>";
            //    }
            //}
            returnstring += Instance.GetVRCPlayerApi().IsUserInVR() ? "<color=#A6CACD><VR></color> " : "<color=#A6CACD><D></color> ";
            return returnstring;
        }

        public static string GetSmallThings(this VRCPlayer Instance)
        {
            string returnstring = string.Empty;
            if (Instance.UserID() != APIUser.CurrentUser.id && Utils.ModerationManager.GetIsBlocked(Instance.UserID()) && Utils.ModerationManager.GetIsBlockedByUser(Instance.UserID()))
                returnstring += "<color=magenta>[B]</color> ";

            if (Instance.UserID() != APIUser.CurrentUser.id && Utils.ModerationManager.GetIsBlocked(Instance.UserID()))
                returnstring += "<color=cyan>[B]</color> ";

            if (Instance.UserID() != APIUser.CurrentUser.id && Utils.ModerationManager.GetIsBlockedByUser(Instance.UserID()))
                returnstring += "<color=red>[B]</color> ";
            if (Instance.GetAPIUser().isFriend)
                returnstring += "<color=yellow>[F]</color> ";
            if (Instance.GetVRCPlayerApi().isMaster)
                returnstring += "<color=#12F1FF>[O]</color> ";
            if (Instance.GetIsDANGER())
            {
                returnstring += "<color=#FFC4FF>[MODERATOR]</color> ";
                Instance.GetVRCPlayerApi().ClearPlayerTags();
            }
            if (Instance.GetAPIUser().IsOnMobile)
                returnstring += "<color=#59D365>[Q]</color> ";
            //if (Instance.GetAPIUser().id == Config.Instance.Target)
            //    returnstring += "<color=red>[T]</color>";
            //if(Config.Instance.SeeMore)
            //    returnstring += $"[{Instance.GetVRCPlayerApi().playerId}]";
            return returnstring;
        }

        public static bool GetIsFriend(this APIUser Instance)
        {
            return Instance.isFriend || APIUser.IsFriendsWith(Instance.id);
        }

        public static bool GetIsDANGER(this VRCPlayer Instance)
        {
            return Instance.GetVRCPlayerApi().isModerator || Instance.GetAPIUser().hasModerationPowers || Instance.GetAPIUser().hasSuperPowers || Instance.GetAPIUser().hasSuperPowers;
        }

        public static bool GetIsBot(this VRCPlayer Instance)
        {
            return Instance.GetPing() == 0 && Instance.GetFrames() == 0 && Instance.UserID() != APIUser.CurrentUser.id;
        }

        public static Color GetRankColor(this APIUser Instance)
        {
            string playerRank = Instance.GetRank();
            switch (playerRank.ToLower())
            {
                case "legend":
                    return ConversionManager.LegendColor;
                    break;

                case "veteran":
                    return ConversionManager.VeteranColor;
                    break;

                case "trusted":
                    return ConversionManager.TrustedColor;
                    break;

                case "known":
                    return ConversionManager.KnownColor;
                    break;

                case "user":
                    return ConversionManager.UserColor;
                    break;

                case "new user":
                    return ConversionManager.NewUserColor;
                    break;

                case "visitor":
                    return ConversionManager.VisitorsColor;
                    break;
            }
            return Color.red;
        }

        #endregion Ranks

        #region avatar

        public static ApiAvatar GetApiAvatar(this Player Instance)
        {
            return Instance.prop_ApiAvatar_0 == null ? Instance.GetVRCPlayer().GetApiAvatar() : Instance.prop_ApiAvatar_0;
        }

        public static ApiAvatar GetApiAvatar(this VRCPlayer Instance)
        {
            return Instance.prop_ApiAvatar_0 == null ? Instance.GetPlayer().GetApiAvatar() : Instance.prop_ApiAvatar_0;
        }

        public static GameObject GetAvatar(this Player Instance)
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
            if (Instance.field_Private_GameObject_1 != null)
                return Instance.field_Private_GameObject_1;
            return null;
        }

        public static ApiAvatar GetAPIAvatar(this VRCAvatarManager Instance)
        {
            return Instance.field_Private_ApiAvatar_0;
        }

        public static VRC_AvatarDescriptor GetSDK3Descriptor(this VRCAvatarManager Instance)
        {
            return Instance.prop_VRCAvatarDescriptor_0;
        }

        public static VRC_AvatarDescriptor GetSDK2Descriptor(this VRCAvatarManager Instance)
        {
            return Instance.prop_VRC_AvatarDescriptor_1;
        }

        public static bool GetIsSKD3(this VRCAvatarManager Instance)
        {
            return Instance.GetSDK3Descriptor() == null || Instance.GetSDK2Descriptor() != null;
        }

        public static VRCSDK2.VRC_AvatarVariations GetAvatarVariations(this VRCAvatarManager Instance)
        {
            return Instance.prop_VRC_AvatarVariations_0;
        }

        #endregion avatar

        #region SelectedPlayers

        public static APIUser SelectedAPIUser(this QuickMenu instance)
        {
            return instance.field_Private_APIUser_0;
        }

        public static VRCPlayer SelectedVRCPlayer(this QuickMenu instance)
        {
            return instance.SelectedPlayer().GetVRCPlayer();
        }

        public static Player SelectedPlayer(this QuickMenu instance)
        {
            return instance.field_Private_Player_0;
        }


        #endregion SelectedPlayers
    }
}