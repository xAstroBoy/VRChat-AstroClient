namespace AstroClient
{
    #region Imports

    using AstroLibrary.Console;
    using AstroNetworkingLibrary;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    using UnityEngine;

    #endregion Imports

    internal static  class ConfigManager
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

        private static string ConfigFavoritesPath = ConfigFolder + @"\ConfigFavorites.json";

        private static string ConfigPerformancePath = ConfigFolder + @"\ConfigPerformance.json";

        #endregion Paths

        #region Config Classes

        internal static  ConfigGeneral General = new ConfigGeneral();

        internal static  ConfigUI UI = new ConfigUI();

        internal static  ConfigESP ESP = new ConfigESP();

        internal static  ConfigFlight Flight = new ConfigFlight();

        internal static  ConfigMovement Movement = new ConfigMovement();

        internal static  ConfigFavorites Favorites = new ConfigFavorites();

        internal static  ConfigPerformance Performance = new ConfigPerformance();

        #endregion Config Classes

        internal static  Color PublicESPColor
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

        internal static  Color ESPFriendColor
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

        internal static  Color ESPBlockedColor
        {
            get
            {
                return new Color(ESP.ESPBlockedColor[0], ESP.ESPBlockedColor[1], ESP.ESPBlockedColor[2], ESP.ESPBlockedColor[3]);
            }
            set
            {
                ESP.ESPBlockedColor[0] = value.r;
                ESP.ESPBlockedColor[1] = value.g;
                ESP.ESPBlockedColor[2] = value.b;
                ESP.ESPBlockedColor[3] = value.a;
            }
        }

        internal static  void Validate()
        {
            _ = SaveMutex.WaitOne();

            if (!Directory.Exists(ConfigFolder))
            {
                _ = Directory.CreateDirectory(ConfigFolder);
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
            if (!File.Exists(ConfigFavoritesPath))
            {
                FileStream fs = new FileStream(ConfigFavoritesPath, FileMode.Create);
                fs.Dispose();
                Save_Favorites();
                ModConsole.DebugWarning($"ConfigFavorites File Created: {ConfigFavoritesPath}");
            }
            if (!File.Exists(ConfigFavoritesPath))
            {
                FileStream fs = new FileStream(ConfigPerformancePath, FileMode.Create);
                fs.Dispose();
                Save_Performance();
                ModConsole.DebugWarning($"ConfigPerformance File Created: {ConfigPerformancePath}");
            }

            if (!Directory.Exists(ConfigLewdifyPath))
            {
                _ = Directory.CreateDirectory(ConfigLewdifyPath);
                ModConsole.DebugWarning($"ConfigLewdify File Created: {ConfigLewdifyPath}");
            }

            SaveMutex.ReleaseMutex();
        }

        internal static  void Save_General()
        {
            JSonWriter.WriteToJsonFile(ConfigPath, General);
            ModConsole.DebugLog("General Config Saved.");
        }

        internal static  void Save_UI()
        {
            JSonWriter.WriteToJsonFile(ConfigUIPath, UI);
            ModConsole.DebugLog("UI Config Saved.");
        }

        internal static  void Save_ESP()
        {
            JSonWriter.WriteToJsonFile(ConfigESPPath, ESP);
            ModConsole.DebugLog("ESP Config Saved.");
        }

        internal static  void Save_Flight()
        {
            JSonWriter.WriteToJsonFile(ConfigFlightPath, Flight);
            ModConsole.DebugLog("Flight Config Saved.");
        }

        internal static  void Save_Movement()
        {
            JSonWriter.WriteToJsonFile(ConfigMovementPath, Movement);
            ModConsole.DebugLog("Movement Config Saved.");
        }

        internal static  void Save_Favorites()
        {
            JSonWriter.WriteToJsonFile(ConfigFavoritesPath, Favorites);
            ModConsole.DebugLog("Favorites Config Saved.");
        }

        internal static  void Save_Performance()
        {
            JSonWriter.WriteToJsonFile(ConfigPerformancePath, Performance);
            ModConsole.DebugLog("Performance Config Saved.");
        }

        internal static  void SaveAll()
        {
            _ = SaveMutex.WaitOne();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Save_General();
            Save_UI();
            Save_ESP();
            Save_Flight();
            Save_Movement();
            Save_Favorites();
            Save_Performance();
            stopwatch.Stop();
            ModConsole.Log($"Finished Saving Configuration Files: {stopwatch.ElapsedMilliseconds}ms");
            SaveMutex.ReleaseMutex();
        }

        internal static  void Load()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                General = JSonWriter.ReadFromJsonFile<ConfigGeneral>(ConfigPath);
            }
            catch
            {
                ModConsole.Error("Failed to load General config, creating a new one..");
            }

            try
            {
                UI = JSonWriter.ReadFromJsonFile<ConfigUI>(ConfigUIPath);
            }
            catch
            {
                ModConsole.Error("Failed to load UI config, creating a new one..");
            }

            try
            {
                ESP = JSonWriter.ReadFromJsonFile<ConfigESP>(ConfigESPPath);
            }
            catch
            {
                ModConsole.Error("Failed to load ESP config, creating a new one..");
            }

            try
            {
                Flight = JSonWriter.ReadFromJsonFile<ConfigFlight>(ConfigFlightPath);
            }
            catch
            {
                ModConsole.Error("Failed to load Flight config, creating a new one..");
            }

            try
            {
                Movement = JSonWriter.ReadFromJsonFile<ConfigMovement>(ConfigMovementPath);
            }
            catch
            {
                ModConsole.Error("Failed to load Movement config, creating a new one..");
            }

            try
            {
                Favorites = JSonWriter.ReadFromJsonFile<ConfigFavorites>(ConfigFavoritesPath);
            }
            catch
            {
                ModConsole.Error("Failed to load Favorites config, creating a new one..");
            }

            try
            {
                Performance = JSonWriter.ReadFromJsonFile<ConfigPerformance>(ConfigPerformancePath);
            }
            catch
            {
                ModConsole.Error("Failed to load Performance config, creating a new one..");
            }
            stopwatch.Stop();
            ModConsole.DebugLog($"Finished Loading Configuration Files: {stopwatch.ElapsedMilliseconds}ms");
            SaveAll();
        }
    }
}