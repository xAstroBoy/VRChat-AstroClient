namespace DayClientML2.Utility.Extensions
{
	using Il2CppSystem.Collections.Generic;
	using System.Linq;
	using VRC.Core;

	internal static class ModerationManagerExtension
	{
		public static bool GetIsBlocked(this VRC.Management.ModerationManager instance, string UserID)
		{
			return ModerationFromMe != null &&
				ModerationFromMe.ToArray().ToList().Exists((ApiPlayerModeration m)
				=> m != null && m.moderationType == ApiPlayerModeration.ModerationType.Block && m.targetUserId == UserID);
		}

		public static bool GetIsBlockedByUser(this VRC.Management.ModerationManager instance, string UserID)
		{
			return ModerationAgainstMe != null &&
				ModerationAgainstMe.ToArray().ToList().Exists((ApiPlayerModeration m)
				=> m != null && m.moderationType == ApiPlayerModeration.ModerationType.Block && m.sourceUserId == UserID);
		}

		public static bool IsBannedFromPublicOnly(this VRC.Management.ModerationManager instance, string userId)
		{
			return APIUser.CurrentUser.id == userId || GlobalModerations != null
				&& GlobalModerations.ToArray().ToList().Exists((ApiModeration m)
				=> m != null && m.moderationType == ApiModeration.ModerationType.BanPublicOnly && m.targetUserId == userId);
		}

		public static bool GetIsKickedFromWorld(this VRC.Management.ModerationManager instance, string userId, string worldId, string instanceId)
		{
			return GlobalModerations.ToArray().ToList().Exists((ApiModeration m) => m.moderationType == ApiModeration.ModerationType.Kick && m.worldId == worldId && m.instanceId == instanceId && m.targetUserId == userId);
		}

		public static bool GetIsBlockedEitherWay(this VRC.Management.ModerationManager instance, string UserID)
		{
			return instance.GetIsBlocked(UserID) || instance.GetIsBlockedByUser(UserID);
		}

		public static bool GetIsMuted(this VRC.Management.ModerationManager instance, string UserID)
		{
			if (UserID == APIUser.CurrentUser.id)
				return false;
			bool flag = ModerationAgainstMe.ToArray().ToList().Exists((ApiPlayerModeration m)
				=> m.moderationType == ApiPlayerModeration.ModerationType.Mute && m.sourceUserId == UserID);
			if (flag)
			{
				return true;
			}
			bool flag2 = ModerationAgainstMe.ToArray().ToList().Exists((ApiPlayerModeration m)
				=> m.moderationType == ApiPlayerModeration.ModerationType.Unmute && m.sourceUserId == UserID);
			if (flag2)
			{
				return false;
			}
			return false;
		}

		public static bool GetIsMutedByUser(this VRC.Management.ModerationManager instance, string userId)
		{
			if (userId == APIUser.CurrentUser.id)
			{
				return false;
			}
			bool flag = ModerationFromMe.ToArray().ToList().Exists((ApiPlayerModeration m) => m.moderationType == ApiPlayerModeration.ModerationType.Mute && m.sourceUserId == userId);
			if (flag)
			{
				return true;
			}
			bool flag2 = ModerationFromMe.ToArray().ToList().Exists((ApiPlayerModeration m) => m.moderationType == ApiPlayerModeration.ModerationType.Unmute && m.sourceUserId == userId);
			if (flag2)
			{
				return false;
			}
			return false;
		}

		public static int GetModerationAgainstYOU(this VRC.Management.ModerationManager instance, ApiPlayerModeration.ModerationType type)
		{
			return ModerationAgainstMe.ToArray().Where((ApiPlayerModeration m) => m.moderationType == type).Count();
		}

		public static int GetModerationFromYOU(this VRC.Management.ModerationManager instance, ApiPlayerModeration.ModerationType type)
		{
			return ModerationFromMe.ToArray().Where((ApiPlayerModeration m) => m.moderationType == type).Count();
		}

		public static void FetchModeration(this VRC.Management.ModerationManager instance)
		{
			ApiModeration.LocalFetchAll(new System.Action<Il2CppSystem.Collections.Generic.IEnumerable<ApiModeration>>((mods) =>
			{
				var newlist = new Il2CppSystem.Collections.Generic.Dictionary<string, List<ApiModeration>>();
				newlist.AddRange(mods);
				GlobalModerations = newlist;
			}), null);
			ApiPlayerModeration.FetchAllMine(new System.Action<Il2CppSystem.Collections.Generic.IEnumerable<ApiPlayerModeration>>((mods) =>
			{
				var newlist = new Il2CppSystem.Collections.Generic.List<ApiPlayerModeration>();
				newlist.AddRange(mods);
				ModerationFromMe = newlist;
			}), null);
			ApiPlayerModeration.FetchAllAgainstMe(new System.Action<Il2CppSystem.Collections.Generic.IEnumerable<ApiPlayerModeration>>((mods) =>
			{
				var newlist = new Il2CppSystem.Collections.Generic.List<ApiPlayerModeration>();
				newlist.AddRange(mods);
				ModerationAgainstMe = newlist;
			}), null);
		}

		private static Il2CppSystem.Collections.Generic.Dictionary<string, List<ApiModeration>> ModerationAgainstMe
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

		private static Il2CppSystem.Collections.Generic.Dictionary<string, List<ApiPlayerModeration>> ModerationFromMe
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

		private static Il2CppSystem.Collections.Generic.Dictionary<string, List<ApiModeration>> GlobalModerations
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