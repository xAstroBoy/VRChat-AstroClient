namespace AstroLibrary.Managers
{
	using System.IO;
	using UnityEngine;

	internal class FileManager
	{
		public static string ClientPath = Directory.GetParent(Application.dataPath) + "/DayClient";
		public static string LogPath = ClientPath + "/Logs";
		public static string LoaderLogPath = ClientPath + "/LoaderLogs";
		public static string VRCAPath = LogPath + "/VRCA";
		public static string MiscPath = ClientPath + "/Misc";
		public static string PermissonsPath = ClientPath + "/Permissons";
		public static string SettingsPath = ClientPath + "/Settings";
		public static string AvatarPermissonPath = PermissonsPath + "/AvatarPermissions";
		public static string AssetBundlesPath = ClientPath + "/AssetBundles";
		public static string VRCAPrivateDownloadPath = LogPath + "/Private VRCA";
		public static string PathPlayers = LogPath + "/PlayerLog.txt";
		public static string PathAvatars = LogPath + "/AvatarLog.txt";
		public static string PathAvatarsJSON = LogPath + "/AvatarLog.json";
		public static string PathWorld = LogPath + "/WorldLog.txt";
		public static string PathPrivateAvatars = LogPath + "/PrivateLog.txt";
		public static string PathPrivateWorlds = LogPath + "/PrivateWorldsLog.txt";
		public static string PathCurrentLog = "Invalid";
		public static string PathHWIDSpoofPath = ClientPath + "/HWID.txt";

		public static string PathAvatarBlocker = MiscPath + "/AvatarBlock.txt";
		public static string PathAvatarFavs = MiscPath + "/AvatarFavoriteList.txt";
		public static string PathAvatarFavsJson = MiscPath + "/FavoriteAvatars.Json";
		public static string PathFriends = MiscPath + "/Friends.txt";
		public static string PathSavePoints = MiscPath + "/SavePoints.txt";
		public static string PathWorldHistory = MiscPath + "/WorldHistory.json";

		public static string PathUserPermits = PermissonsPath + "/UserPermission.txt";
		public static string PathPortalKos = PermissonsPath + "/PortalKOS.txt";
		public static string PathRPCBLOCK = PermissonsPath + "/RPCBlock.txt";

		public static string PathConfig = SettingsPath + "/Config.json";
		public static string PathButtons = SettingsPath + "/Buttons.json";
		public static string PathAccount = SettingsPath + "/Account.txt";
		public static string PathAvatarListConfig = SettingsPath + "/AvatarListConfig.txt";
		public static string PathColorConfig = SettingsPath + "/Colors.json";
		public static string PathModerationConfig = SettingsPath + "/Moderation.json";
		public static string PathSafetyConfig = SettingsPath + "/Safety.json";
		public static string PathPortalConfig = SettingsPath + "/Portal.json";
		public static string PathAchievmentsConfig = SettingsPath + "/Achievments.json";
		public static string PathDiscordRPC = SettingsPath + "/DiscordRPC.json";

		public static void START()
		{
			Directory.CreateDirectory(ClientPath);
			Directory.CreateDirectory(SettingsPath);
			Directory.CreateDirectory(LogPath);
			Directory.CreateDirectory(MiscPath);
			Directory.CreateDirectory(VRCAPath);
			Directory.CreateDirectory(VRCAPrivateDownloadPath);
			if (!File.Exists(PathAvatars))
			{
				File.Create(PathAvatars);
			}
			if (!File.Exists(PathWorld))
			{
				File.Create(PathWorld);
			}
			if (!File.Exists(PathPlayers))
			{
				File.Create(PathPlayers);
			}
			if (!File.Exists(PathPrivateAvatars))
			{
				File.Create(PathPrivateAvatars);
			}
			if (!File.Exists(PathPrivateWorlds))
			{
				File.Create(PathPrivateWorlds);
			}
		}
	}
}