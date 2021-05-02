namespace AstroClient
{
	using AstroClient.ConsoleUtils;
	using System;
	using System.IO;

	public static class ConfigManager
	{
		private static string ConfigFolder = Environment.CurrentDirectory + @"\AstroClient";

		private static string ConfigPath = ConfigFolder + @"\Config.json";

		private static string ConfigUIPath = ConfigFolder + @"\ConfigUI.json";

		private static string ConfigESPPath = ConfigFolder + @"\ConfigESP.json";

		public static Config General = new Config();

		public static ConfigUI UI = new ConfigUI();

		public static ConfigESP ESP = new ConfigESP();

		public static void Validate()
		{
			if (!Directory.Exists(ConfigFolder))
			{
				Directory.CreateDirectory(ConfigFolder);
				ModConsole.DebugWarning($"Config Folder Created: {ConfigFolder}");
			}

			if (!File.Exists(ConfigPath))
			{
				FileStream fs = new FileStream(ConfigPath, FileMode.Create);
				fs.Dispose();
				Save();
				ModConsole.DebugWarning($"Config File Created: {ConfigPath}");
			}

			if (!File.Exists(ConfigUIPath))
			{
				FileStream fs = new FileStream(ConfigUIPath, FileMode.Create);
				fs.Dispose();
				Save();
				ModConsole.DebugWarning($"ConfigUI File Created: {ConfigUIPath}");
			}
		}

		public static void Save()
		{
			JSonWriter.WriteToJsonFile(ConfigPath, General);
			JSonWriter.WriteToJsonFile(ConfigUIPath, UI);
			ModConsole.DebugLog("Config Saved.");
		}

		public static void Load()
		{
			UI = JSonWriter.ReadFromJsonFile<ConfigUI>(ConfigUIPath);
			General = JSonWriter.ReadFromJsonFile<Config>(ConfigPath);
			ModConsole.DebugLog("Config Loaded.");
		}
	}
}