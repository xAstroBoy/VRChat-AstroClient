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

		private static string ConfigFlightPath = ConfigFolder + @"\ConfigFlight.json";

		public static Config General = new Config();

		public static ConfigUI UI = new ConfigUI();

		public static ConfigESP ESP = new ConfigESP();

		public static ConfigFlight Flight = new ConfigFlight();

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

			if (!File.Exists(ConfigESPPath))
			{
				FileStream fs = new FileStream(ConfigESPPath, FileMode.Create);
				fs.Dispose();
				Save();
				ModConsole.DebugWarning($"ConfigESP File Created: {ConfigESPPath}");
			}

			if (!File.Exists(ConfigFlightPath))
			{
				FileStream fs = new FileStream(ConfigFlightPath, FileMode.Create);
				fs.Dispose();
				Save();
				ModConsole.DebugWarning($"ConfigFlight File Created: {ConfigFlightPath}");
			}
		}

		public static void Save()
		{
			JSonWriter.WriteToJsonFile(ConfigPath, General);
			JSonWriter.WriteToJsonFile(ConfigUIPath, UI);
			JSonWriter.WriteToJsonFile(ConfigESPPath, ESP);
			JSonWriter.WriteToJsonFile(ConfigFlightPath, Flight);
			ModConsole.DebugLog("Config Saved.");
		}

		public static void Load()
		{
			General = JSonWriter.ReadFromJsonFile<Config>(ConfigPath);
			UI = JSonWriter.ReadFromJsonFile<ConfigUI>(ConfigUIPath);
			ESP = JSonWriter.ReadFromJsonFile<ConfigESP>(ConfigESPPath);
			Flight = JSonWriter.ReadFromJsonFile<ConfigFlight>(ConfigFlightPath);
			ModConsole.DebugLog("Config Loaded.");
		}
	}
}