﻿namespace AstroClient.Config
{
    #region Imports

    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    using AstroEventArgs;
    using AstroNetworkingLibrary;
    using Tools.Extensions;
    using UnityEngine;

    #endregion Imports

    public static class ConfigManager
    {
        private static Mutex SaveMutex = new Mutex();

        #region ESPEVents
        internal static event Action<Color> Event_OnPublicESPColorChanged;
        internal static event Action<Color> Event_OnBlockedESPColorChanged;
        internal static event Action<Color> Event_OnFriendESPColorChanged;

        #endregion

        #region Paths

        internal static string ConfigFolder { get; } = Environment.CurrentDirectory + @"\AstroClient";

        internal static string ConfigTempFolder { get; } = ConfigFolder + @"\Temp";

        internal static string ConfigPath { get; }  = ConfigFolder + @"\Config.json";

        internal static string ConfigUIPath { get; }  = ConfigFolder + @"\ConfigUI.json";

        internal static string ConfigESPPath { get; } = ConfigFolder + @"\ConfigESP.json";

        internal static string ConfigFlightPath { get; } = ConfigFolder + @"\ConfigFlight.json";

        internal static string ConfigMovementPath { get; } = ConfigFolder + @"\ConfigMovement.json";

        internal static string ConfigFavoritesPath { get; }  = ConfigFolder + @"\ConfigFavorites.json";

        internal static string ConfigPerformancePath { get; }  = ConfigFolder + @"\ConfigPerformance.json";

        internal static string ConfigLoadingScreenPath { get; } = ConfigFolder + @"\ConfigLoadingScreen.json";

        internal static string AstroInstances { get; } = ConfigFolder + @"\AstroInstances.json";

        #endregion Paths

        #region Config Classes

        public static ConfigGeneral General { get; set; } = new ConfigGeneral();

        public static ConfigUI UI { get; set; } = new ConfigUI();

        public static ConfigESP ESP { get; set; }  = new ConfigESP();

        public static ConfigFlight Flight { get; set; }  = new ConfigFlight();

        public static ConfigMovement Movement { get; set; }  = new ConfigMovement();

        public static ConfigFavorites Favorites { get; set; } = new ConfigFavorites();

        public static ConfigPerformance Performance { get; set; } = new ConfigPerformance();

        public static ConfigLoadingScreen LoadingScreen { get; set; } = new ConfigLoadingScreen();

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
                Event_OnPublicESPColorChanged.SafetyRaise(value);
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
                Event_OnFriendESPColorChanged.SafetyRaise(value);
            }
        }

        public static Color ESPBlockedColor
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
                Event_OnBlockedESPColorChanged.SafetyRaise(value);
            }
        }

        public static void Validate()
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
            if (!File.Exists(ConfigPerformancePath))
            {
                FileStream fs = new FileStream(ConfigPerformancePath, FileMode.Create);
                fs.Dispose();
                Save_Performance();
                ModConsole.DebugWarning($"ConfigPerformance File Created: {ConfigPerformancePath}");
            }
            if (!File.Exists(ConfigLoadingScreenPath))
            {
                FileStream fs = new FileStream(ConfigLoadingScreenPath, FileMode.Create);
                fs.Dispose();
                Save_LoadingScreen();
                ModConsole.DebugWarning($"ConfigLoadingScreen File Created: {ConfigLoadingScreenPath}");
            }

            if (!Directory.Exists(ConfigTempFolder))
            {
                _ = Directory.CreateDirectory(ConfigTempFolder);
                ModConsole.DebugWarning($"ConfigTempFolder File Created: {ConfigTempFolder}");
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

        public static void Save_Favorites()
        {
            JSonWriter.WriteToJsonFile(ConfigFavoritesPath, Favorites);
            ModConsole.DebugLog("Favorites Config Saved.");
        }

        public static void Save_Performance()
        {
            JSonWriter.WriteToJsonFile(ConfigPerformancePath, Performance);
            ModConsole.DebugLog("Performance Config Saved.");
        }
        public static void Save_LoadingScreen()
        {
            JSonWriter.WriteToJsonFile(ConfigLoadingScreenPath, LoadingScreen);
            ModConsole.DebugLog("Loading Screen Config Saved.");
        }

        public static void SaveAll()
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
            Save_LoadingScreen();
            stopwatch.Stop();
            ModConsole.Log($"Finished Saving Configuration Files: {stopwatch.ElapsedMilliseconds}ms");
            SaveMutex.ReleaseMutex();
        }

        public static void Load()
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

            try
            {
                LoadingScreen = JSonWriter.ReadFromJsonFile<ConfigLoadingScreen>(ConfigLoadingScreenPath);
            }
            catch
            {
                ModConsole.Error("Failed to load Loading Screen config, creating a new one..");
            }

            stopwatch.Stop();
            ModConsole.DebugLog($"Finished Loading Configuration Files: {stopwatch.ElapsedMilliseconds}ms");
            SaveAll();
        }
    }
}