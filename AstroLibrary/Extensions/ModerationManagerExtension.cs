namespace AstroLibrary.Extensions
{
    using AstroLibrary.Utility;
    using Il2CppSystem.Collections.Generic;
    using System;
    using VRC.Core;

    public static class ModerationManagerExtension
    {
        public static bool GetIsBlocked(this VRC.Management.ModerationManager instance, string UserID)
        {
            foreach (var kvp in PlayerModerations)
            {
                var moderations = kvp.Value;

                foreach (var moderation in moderations)
                {
                    if (moderation.moderationType == ApiPlayerModeration.ModerationType.Block && moderation.targetUserId == UserID)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool GetIsBlockedByUser(this VRC.Management.ModerationManager instance, string UserID)
        {
            foreach (var kvp in PlayerModerations)
            {
                var moderations = kvp.Value;

                foreach (var moderation in moderations)
                {
                    if (moderation.moderationType == ApiPlayerModeration.ModerationType.Block && moderation.sourceUserId == UserID && moderation.targetUserId == Utils.CurrentUser.GetUserID())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool GetIsBlockedEitherWay(this VRC.Management.ModerationManager instance, string UserID)
        {
            return instance.GetIsBlocked(UserID) || instance.GetIsBlockedByUser(UserID);
        }

        public static bool IsBannedFromPublicOnly(this VRC.Management.ModerationManager instance, string userId)
        {
            foreach (var kvp in GlobalModerations)
            {
                var moderations = kvp.Value;

                foreach (var moderation in moderations)
                {
                    if (moderation.moderationType == ApiModeration.ModerationType.BanPublicOnly && moderation.targetUserId == userId)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool GetIsKickedFromWorld(this VRC.Management.ModerationManager instance, string userId, string worldId, string instanceId)
        {
            foreach (var kvp in GlobalModerations)
            {
                var moderations = kvp.Value;

                foreach (var moderation in moderations)
                {
                    if (moderation.moderationType == ApiModeration.ModerationType.Kick && moderation.worldId == worldId && moderation.instanceId == instanceId && moderation.targetUserId == userId)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        [Obsolete("Currently Borked, needs fixed")]
        public static bool GetIsMuted(this VRC.Management.ModerationManager instance, string UserID)
        {
            if (UserID == APIUser.CurrentUser.id)
                return false;

            foreach (var kvp in PlayerModerations)
            {
                var moderations = kvp.Value;

                foreach (var moderation in moderations)
                {
                    if (moderation.moderationType == ApiPlayerModeration.ModerationType.Mute && moderation.sourceUserId == UserID)
                    {
                        return true;
                    }
                }
            }

            return false;
            // #Attn Look in to this maybe
            //bool flag2 = ModerationAgainstMe.ToArray().ToList().Exists((ApiPlayerModeration m)
            //	=> m.moderationType == ApiPlayerModeration.ModerationType.Unmute && m.sourceUserId == UserID);
            //if (flag2)
            //{
            //	return false;
            //}
            //return false;
        }

        [Obsolete("Currently Borked, needs fixed")]
        public static bool GetIsMutedByUser(this VRC.Management.ModerationManager instance, string userId)
        {
            if (userId == APIUser.CurrentUser.id)
            {
                return false;
            }
            return false;
            //foreach (var kvp in PlayerModerations)
            //{
            //	var moderations = kvp.Value;

            //	foreach (var moderation in moderations)
            //	{
            //		if (moderation.moderationType == ApiPlayerModeration.ModerationType.Mute && moderation.sourceUserId == userId)
            //		{
            //			return true;
            //		}
            //	}
            //}
            //bool flag2 = ModerationFromMe.ToArray().ToList().Exists((ApiPlayerModeration m) => m.moderationType == ApiPlayerModeration.ModerationType.Unmute && m.sourceUserId == userId);
            //if (flag2)
            //{
            //	return false;
            //}
            //return false;
        }

        [Obsolete("Currently Borked, needs fixed")]
        public static int GetModerationAgainstYOU(this VRC.Management.ModerationManager instance, ApiPlayerModeration.ModerationType type)
        {
            // #Attn FIX
            return 0;
            //return ModerationAgainstMe.ToArray().Where((ApiPlayerModeration m) => m.moderationType == type).Count();
        }

        [Obsolete("Currently Borked, needs fixed")]
        public static int GetModerationFromYOU(this VRC.Management.ModerationManager instance, ApiPlayerModeration.ModerationType type)
        {
            // #Attn FIX
            return 0;
            //return ModerationFromMe.ToArray().Where((ApiPlayerModeration m) => m.moderationType == type).Count();
        }

        [Obsolete("Currently Borked, needs fixed")]
        public static void FetchModeration(this VRC.Management.ModerationManager instance)
        {
            // #Attn FIX
            //ApiModeration.LocalFetchAll(new System.Action<Il2CppSystem.Collections.Generic.IEnumerable<ApiModeration>>((mods) =>
            //{
            //	var newlist = new Il2CppSystem.Collections.Generic.Dictionary<string, List<ApiModeration>>();
            //	newlist.AddRange(mods);
            //	GlobalModerations = newlist;
            //}), null);
            //ApiPlayerModeration.FetchAllMine(new System.Action<Il2CppSystem.Collections.Generic.IEnumerable<ApiPlayerModeration>>((mods) =>
            //{
            //	var newlist = new Il2CppSystem.Collections.Generic.List<ApiPlayerModeration>();
            //	newlist.AddRange(mods);
            //	ModerationFromMe = newlist;
            //}), null);
            //ApiPlayerModeration.FetchAllAgainstMe(new System.Action<Il2CppSystem.Collections.Generic.IEnumerable<ApiPlayerModeration>>((mods) =>
            //{
            //	var newlist = new Il2CppSystem.Collections.Generic.List<ApiPlayerModeration>();
            //	newlist.AddRange(mods);
            //	ModerationAgainstMe = newlist;
            //}), null);
        }

        //private static Il2CppSystem.Collections.Generic.Dictionary<string, List<ApiModeration>> ModerationAgainstMe
        //{
        //	get
        //	{
        //		return Utils.ModerationManager.field_Private_Dictionary_2_String_List_1_ApiModeration_0;
        //	}
        //	set
        //	{
        //		Utils.ModerationManager.field_Private_Dictionary_2_String_List_1_ApiModeration_0 = value;
        //	}
        //}

        private static Dictionary<string, List<ApiPlayerModeration>> PlayerModerations
        {
            get
            {
                return Utils.ModerationManager.field_Private_Dictionary_2_String_List_1_ApiPlayerModeration_0;
            }
            set
            {
                Utils.ModerationManager.field_Private_Dictionary_2_String_List_1_ApiPlayerModeration_0 = value;
            }
        }

        private static Dictionary<string, List<ApiModeration>> GlobalModerations
        {
            get
            {
                return Utils.ModerationManager.field_Private_Dictionary_2_String_List_1_ApiModeration_0;
            }
            set
            {
                Utils.ModerationManager.field_Private_Dictionary_2_String_List_1_ApiModeration_0 = value;
            }
        }
    }
}