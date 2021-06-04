namespace AstroClient
{
	#region Imports

	using AstroLibrary.Console;
	using AstroNetworkingLibrary;
	using System;
	using System.IO;
	using System.Threading;
	using UnityEngine;

	#endregion Imports

	public static class ConfigManager
    {
        private static Mutex SaveMutex = new Mutex();

        #region Paths

        private static string ConfigFolder = Environment.CurrentDirectory + @"\AstroClient";

        private static string ConfigLewdifyPath = ConfigFolder + @"\Lewdify";

        private static string ConfigPath = ConfigFolder + @"\Config.json";

        private static string ConfigUIPath = ConfigFolder + @"\ConfigUI.json";

        private static string ConfigESPPath = ConfigFolder + @"\ConfigESP.json";

        private static string ConfigFlightPath = ConfigFolder + @"\ConfigFlight.json";

        private static string ConfigMovementPath = ConfigFolder + @"\ConfigMovement.json";

        #endregion Paths

        #region Config Classes

        public static ConfigGeneral General = new ConfigGeneral();

        public static ConfigUI UI = new ConfigUI();

        public static ConfigESP ESP = new ConfigESP();

        public static ConfigFlight Flight = new ConfigFlight();

        public static ConfigMovement Movement = new ConfigMovement();

        #endregion Config Classes

        public static Color PublicESPColor
        {
            get
            {
                return new Color(ESP.PublicESPColor[0], ESP.PublicESPColor[1], ESP.PublicESPColor[2], ESP.PublicESPColor[3]);
            }
            set
            {
                ESP.PublicESPColor[0] = value.r;
                ESP.PublicESPColor[1] = value.g;
                ESP.PublicESPColor[2] = value.b;
                ESP.PublicESPColor[3] = value.a;
            }
        }

        public static Color ESPFriendColor
        {
            get
            {
                return new Color(ESP.ESPFriendColor[0], ESP.ESPFriendColor[1], ESP.ESPFriendColor[2], ESP.ESPFriendColor[3]);
            }
            set
            {
                ESP.ESPFriendColor[0] = value.r;
                ESP.ESPFriendColor[1] = value.g;
                ESP.ESPFriendColor[2] = value.b;
                ESP.ESPFriendColor[3] = value.a;
            }
        }

        public static void Validate()
        {
            SaveMutex.WaitOne();

            if (!Directory.Exists(ConfigFolder))
            {
                Directory.CreateDirectory(ConfigFolder);
                ModConsole.DebugWarning($"Config Folder Created: {ConfigFolder}");
            }

            if (!File.Exists(ConfigPath))
            {
                FileStream fs = new FileStream(ConfigPath, FileMode.Create);
                fs.Dispose();
                Save_General();
                ModConsole.DebugWarning($"Config File Created: {ConfigPath}");
            }

            if (!File.Exists(ConfigUIPath))
            {
                FileStream fs = new FileStream(ConfigUIPath, FileMode.Create);
                fs.Dispose();
                Save_UI();
                ModConsole.DebugWarning($"ConfigUI File Created: {ConfigUIPath}");
            }

            if (!File.Exists(ConfigESPPath))
            {
                FileStream fs = new FileStream(ConfigESPPath, FileMode.Create);
                fs.Dispose();
                Save_ESP();
                ModConsole.DebugWarning($"ConfigESP File Created: {ConfigESPPath}");
            }
            if (!File.Exists(ConfigFlightPath))
            {
                FileStream fs = new FileStream(ConfigFlightPath, FileMode.Create);
                fs.Dispose();
                Save_Flight();
                ModConsole.DebugWarning($"ConfigFlight File Created: {ConfigFlightPath}");
            }
            if (!File.Exists(ConfigMovementPath))
            {
                FileStream fs = new FileStream(ConfigMovementPath, FileMode.Create);
                fs.Dispose();
                Save_Movement();
                ModConsole.DebugWarning($"ConfigMovement File Created: {ConfigMovementPath}");
            }

            if (!Directory.Exists(ConfigLewdifyPath))
            {
                Directory.CreateDirectory(ConfigLewdifyPath);
                ModConsole.DebugWarning($"ConfigLewdify File Created: {ConfigLewdifyPath}");
            }

            SaveMutex.ReleaseMutex();
        }

        public static void Save_General()
        {
            JSonWriter.WriteToJsonFile(ConfigPath, General);
            ModConsole.DebugLog("General Config Saved.");
        }

        public static void Save_UI()
        {
            JSonWriter.WriteToJsonFile(ConfigUIPath, UI);
            ModConsole.DebugLog("UI Config Saved.");
        }

        public static void Save_ESP()
        {
            JSonWriter.WriteToJsonFile(ConfigESPPath, ESP);
            ModConsole.DebugLog("ESP Config Saved.");
        }

        public static void Save_Flight()
        {
            JSonWriter.WriteToJsonFile(ConfigFlightPath, Flight);
            ModConsole.DebugLog("Flight Config Saved.");
        }

        public static void Save_Movement()
        {
            JSonWriter.WriteToJsonFile(ConfigMovementPath, Movement);
            ModConsole.DebugLog("Movement Config Saved.");
        }

        public static void Save_All()
        {
            SaveMutex.WaitOne();
            Save_General();
            Save_UI();
            Save_ESP();
            Save_Flight();
            Save_Movement();
            ModConsole.Log("Config Saved.");
            SaveMutex.ReleaseMutex();
        }

        public static void Load()
        {
            General = JSonWriter.ReadFromJsonFile<ConfigGeneral>(ConfigPath);
            UI = JSonWriter.ReadFromJsonFile<ConfigUI>(ConfigUIPath);
            ESP = JSonWriter.ReadFromJsonFile<ConfigESP>(ConfigESPPath);
            Flight = JSonWriter.ReadFromJsonFile<ConfigFlight>(ConfigFlightPath);
            Movement = JSonWriter.ReadFromJsonFile<ConfigMovement>(ConfigMovementPath);

            ModConsole.DebugLog("Config Loaded.");
        }
    }
}