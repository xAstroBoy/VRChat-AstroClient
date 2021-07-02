namespace Blaze.Utils
{
	using System;
	using System.IO;
	using UnityEngine;

	public static class FileManager
	{
		public static string ModPath = Directory.GetParent(Application.dataPath) + "\\Blaze's Mod";
		public static string ConfigsPath = ModPath + "\\Configs";
		public static string MiscPath = ModPath + "\\Misc";
		public static string DependenciesPath = ModPath + "\\Dependencies";
		public static string LogsPath = ModPath + "\\Logs";

		public static string ConfigFile = ConfigsPath + "\\Config.json";
		public static string HWIDFile = ConfigsPath + "\\HWID.json";
		public static string ColorsFile = ConfigsPath + "\\ColorsConfig.json";
		public static string KeyFile = ModPath + "\\Auth.json";
		public static string DiscordFile = DependenciesPath + "\\Discord-RPC.dll";
		public static string RPCBlockFile = MiscPath + "\\RPCBlock.json";
		public static string WHFile = MiscPath + "\\WorldHistory.json";
		public static string AviLogsFile = LogsPath + "\\AvatarLogs.txt";
		public static string WorldLogsFile = LogsPath + "\\WorldLogs.txt";
		public static string PlayerLogsFile = LogsPath + "\\PlayerLogs.txt";
		public static string AvatarFavFile = ConfigsPath + "\\AvatarFavorites.json";

		public static void Initialize()
		{
			int createdCount = 0;
			Logs.Msg("Checking directories...", ConsoleColor.Yellow);
			try
			{
				if (!Directory.Exists(ModPath))
				{
					Directory.CreateDirectory(ModPath);
					createdCount++;
				}

				if (!Directory.Exists(ConfigsPath))
				{
					Directory.CreateDirectory(ConfigsPath);
					createdCount++;
				}

				if (!Directory.Exists(MiscPath))
				{
					Directory.CreateDirectory(MiscPath);
					createdCount++;
				}

				if (!Directory.Exists(DependenciesPath))
				{
					Directory.CreateDirectory(DependenciesPath);
					createdCount++;
				}

				if (!Directory.Exists(LogsPath))
				{
					Directory.CreateDirectory(LogsPath);
					createdCount++;
				}

				if (createdCount == 0)
					Logs.Msg("All directories needed exist!", ConsoleColor.Green);
				else
					Logs.Msg($"Missing directories found! Created {createdCount} directories!", ConsoleColor.Green);
			}
			catch { Logs.Msg("Could not create directories!", ConsoleColor.Red); }
		}
	}
}
