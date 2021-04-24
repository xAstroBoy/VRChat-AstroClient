using AstroClient.ConsoleUtils;
using System;
using System.IO;

namespace AstroClient
{
    public static class ConfigManager
    {
        private static string ConfigFolder = Environment.CurrentDirectory + @"\AstroClient";

        private static string ConfigPath = ConfigFolder + @"\Config.json";

        private static string ConfigUIPath = ConfigFolder + @"\ConfigUI.json";

        public static Config General = new Config();

        public static ConfigUI UI = new ConfigUI();

        public static void Validate()
        {
            if (!Directory.Exists(ConfigFolder))
            {
                Directory.CreateDirectory(ConfigFolder);
                ModConsole.DebugWarning($"Config Folder Created: {ConfigFolder}");
            }

            if (!File.Exists(ConfigPath))
            {
                var fs = new FileStream(ConfigPath, FileMode.Create);
                fs.Dispose();
                Save();
                ModConsole.DebugWarning($"Config File Created: {ConfigPath}");
            }

            if (!File.Exists(ConfigUIPath))
            {
                var fs = new FileStream(ConfigUIPath, FileMode.Create);
                fs.Dispose();
                Save();
                ModConsole.DebugWarning($"ConfigUI File Created: {ConfigUIPath}");
            }
        }

        public static void Save()
        {
            JSonWriter.WriteToJsonFile(ConfigPath, General);
            JSonWriter.WriteToJsonFile(ConfigUIPath, UI);
        }

        public static void Load()
        {
            UI = JSonWriter.ReadFromJsonFile<ConfigUI>(ConfigUIPath);
            General = JSonWriter.ReadFromJsonFile<Config>(ConfigPath);
        }
    }
}