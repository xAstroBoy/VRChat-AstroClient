namespace AstroClient
{
    using AstroClient.ConsoleUtils;
    using Cinemachine;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [Serializable]
    public class Config
    {
        public bool JoinLeave = false;

        public bool ShowPlayersMenu = true;

        public bool ShowPlayersList = true;

        public bool LogRPCEvents = false;
    }

    public static class ConfigManager
    {
        public static string ConfigFolder = Environment.CurrentDirectory + @"\AstroClient";

        public static string ConfigPath = ConfigFolder + @"\Config.json";

        public static Config Configuration = new Config();

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
        }

        public static void Save()
        {
            JSonWriter.WriteToJsonFile(ConfigPath, Configuration);
        }

        public static void Load()
        {
            if (!File.Exists(ConfigPath))
            {
                ModConsole.DebugWarning("No config found to load, using defaults..");
            }

            Configuration = JSonWriter.ReadFromJsonFile<Config>(ConfigPath);
        }
    }
}
