namespace AstroLibrary.Extensions
{
    using AstroLibrary.Utility;
    using UnityEngine;
    using VRC;
    using VRC.Core;
    using VRC.SDKBase;

    public static class PlayerExtensions
    {
        public static string DisplayName(this Player Instance)
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

        public static bool GetIsInVR(this Player Instance)
        {
            return Instance.GetVRCPlayerApi().IsUserInVR();
        }

        public static short GetPing(this VRCPlayer Instance)
        {
            return Instance.GetPlayerNet().field_Private_Int16_0;
        }

        public static int GetFrames(this VRCPlayer Instance)
        {
            return Instance.GetPlayerNet().prop_Byte_0 != 0 ? (int)(1000f / Instance.GetPlayerNet().prop_Byte_0) : 0;
        }

        public static float GetQuality(this VRCPlayer Instance)
        {
            return float.Parse((((!(Instance.GetPlayerNet() == null)) ? Instance.GetPlayerNet().prop_Single_0 : 0f) * 100).ToString("0.00"));
        }

        public static double GetDelay(this VRCPlayer Instance)
        {
            // -Day: Still working on it
            int num = Mathf.FloorToInt((Instance.GetPing() + 50) / 10f);
            int num2 = Mathf.FloorToInt((1f - Instance.GetQuality()) * 10f);
            double num3 = Mathf.Min(2f, num + num2);
            return 0.20f * num3;
        }

        public static string GetPingColored(this VRCPlayer Instance)
        {
            string color;
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
            string color;
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
            string color;
            if (Instance.GetQuality() >= 90)
                color = "<color=#59D365>";
            else if (Instance.GetQuality() <= 90 && Instance.GetQuality() >= 60)
                color = "<color=#FF7000>";
            else
                color = "<color=red>";

            return $"{color}{Instance.GetQuality()}</color>";
        }

        #region Ranks

        public static RankType GetRankEnum(this APIUser Instance)
        {
            if (Instance.hasModerationPowers || Instance.tags.Contains("admin_moderator"))
                return RankType.Moderator;
            if (Instance.hasSuperPowers || Instance.tags.Contains("admin_"))
                return RankType.Admin;
            if (Instance.tags.Contains("system_legend") && Instance.tags.Contains("system_trust_legend") && Instance.tags.Contains("system_trust_trusted"))
                return RankType.Legend;
            if (Instance.hasLegendTrustLevel || (Instance.tags.Contains("system_trust_legend") && Instance.tags.Contains("system_trust_trusted")))
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

            if (Instance.GetUserID() != APIUser.CurrentUser.id && Utils.ModerationManager.GetIsBlocked(Instance.GetUserID()) && Utils.ModerationManager.GetIsBlockedByUser(Instance.GetUserID()))
                returnstring += "<color=magenta>[B]</color> ";

            if (Instance.GetUserID() != APIUser.CurrentUser.id && Utils.ModerationManager.GetIsBlocked(Instance.GetUserID()))
                returnstring += "<color=cyan>[B]</color> ";

            if (Instance.GetUserID() != APIUser.CurrentUser.id && Utils.ModerationManager.GetIsBlockedByUser(Instance.GetUserID()))
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
            if (Instance.GetUserID() != APIUser.CurrentUser.id && Utils.ModerationManager.GetIsBlocked(Instance.GetUserID()) && Utils.ModerationManager.GetIsBlockedByUser(Instance.GetUserID()))
                returnstring += "<color=magenta>[B]</color> ";

            if (Instance.GetUserID() != APIUser.CurrentUser.id && Utils.ModerationManager.GetIsBlocked(Instance.GetUserID()))
                returnstring += "<color=cyan>[B]</color> ";

            if (Instance.GetUserID() != APIUser.CurrentUser.id && Utils.ModerationManager.GetIsBlockedByUser(Instance.GetUserID()))
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
            return Instance.isFriend || APIUser.IsFriendsWith(Instance.id) || APIUser.CurrentUser.friendIDs.Contains(Instance.id);
        }

        public static bool GetIsDANGER(this VRCPlayer Instance)
        {
            return Instance.GetVRCPlayerApi().isModerator || Instance.GetAPIUser().hasModerationPowers || Instance.GetAPIUser().hasSuperPowers;
        }

        public static bool GetIsBot(this VRCPlayer Instance)
        {
            return Instance.GetPing() == 0 && Instance.GetFrames() == 0 && Instance.GetUserID() != APIUser.CurrentUser.id;
        }

        #endregion Ranks

        #region avatar

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

        //public static VRCSDK2.VRC_AvatarVariations GetAvatarVariations(this VRCAvatarManager Instance)
        //{
        //    return Instance.prop_VRC_AvatarVariations_0;
        //}

        #endregion avatar
    }
}