using AstroClient.ClientActions;

namespace AstroClient.Config
{
    #region Imports

    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    
    using AstroNetworkingLibrary;
    using Tools.Extensions;
    using UnityEngine;

    #endregion Imports

    public static class ConfigManager
    {
        private static Mutex SaveMutex = new Mutex();

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
        internal static string ConfigAvatarOptionsPath { get; } = ConfigFolder + @"\ConfigAvatarOptions.json";

        internal static string ConfigBlockedRPCPlayersPath { get; } = ConfigFolder + @"\BlockedRPCPlayers.json";

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

        public static ConfigBlockedRPCPlayers BlockedRPCPlayers { get; set; } = new ConfigBlockedRPCPlayers();

        public static ConfigAvatarOptions AvatarOptions { get; set; } = new ConfigAvatarOptions();

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
                ConfigEventActions.ESP_OnPublicColorChange.SafetyRaiseWithParams(value);
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
                ConfigEventActions.ESP_OnFriendColorChange.SafetyRaiseWithParams(value);
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
                ConfigEventActions.ESP_OnBlockedColorChange.SafetyRaiseWithParams(value);
            }
        }

        public static void Validate()
        {
            _ = SaveMutex.WaitOne();

            if (!Directory.Exists(ConfigFolder))
            {
                _ = Directory.CreateDirectory(ConfigFolder);
                Log.Warn($"Config Folder Created: {ConfigFolder}");
            }

            if (!File.Exists(ConfigPath))
            {
                FileStream fs = new FileStream(ConfigPath, FileMode.Create);
                fs.Dispose();
                Save_General();
                Log.Warn($"Config File Created: {ConfigPath}");
            }

            if (!File.Exists(ConfigUIPath))
            {
                FileStream fs = new FileStream(ConfigUIPath, FileMode.Create);
                fs.Dispose();
                Save_UI();
                Log.Warn($"ConfigUI File Created: {ConfigUIPath}");
            }

            if (!File.Exists(ConfigESPPath))
            {
                FileStream fs = new FileStream(ConfigESPPath, FileMode.Create);
                fs.Dispose();
                Save_ESP();
                Log.Warn($"ConfigESP File Created: {ConfigESPPath}");
            }
            if (!File.Exists(ConfigFlightPath))
            {
                FileStream fs = new FileStream(ConfigFlightPath, FileMode.Create);
                fs.Dispose();
                Save_Flight();
                Log.Warn($"ConfigFlight File Created: {ConfigFlightPath}");
            }
            if (!File.Exists(ConfigMovementPath))
            {
                FileStream fs = new FileStream(ConfigMovementPath, FileMode.Create);
                fs.Dispose();
                Save_Movement();
                Log.Warn($"ConfigMovement File Created: {ConfigMovementPath}");
            }
            if (!File.Exists(ConfigFavoritesPath))
            {
                FileStream fs = new FileStream(ConfigFavoritesPath, FileMode.Create);
                fs.Dispose();
                Save_Favorites();
                Log.Warn($"ConfigFavorites File Created: {ConfigFavoritesPath}");
            }
            if (!File.Exists(ConfigPerformancePath))
            {
                FileStream fs = new FileStream(ConfigPerformancePath, FileMode.Create);
                fs.Dispose();
                Save_Performance();
                Log.Warn($"ConfigPerformance File Created: {ConfigPerformancePath}");
            }
            if (!File.Exists(ConfigLoadingScreenPath))
            {
                FileStream fs = new FileStream(ConfigLoadingScreenPath, FileMode.Create);
                fs.Dispose();
                Save_LoadingScreen();
                Log.Warn($"ConfigLoadingScreen File Created: {ConfigLoadingScreenPath}");
            }

            if (!File.Exists(ConfigBlockedRPCPlayersPath))
            {
                FileStream fs = new FileStream(ConfigBlockedRPCPlayersPath, FileMode.Create);
                fs.Dispose();
                Save_BlockedRPCPlayers();
                Log.Warn($"BlockedRPCPlayers File Created: {BlockedRPCPlayers}");
            }
            if (!File.Exists(ConfigAvatarOptionsPath))
            {
                FileStream fs = new FileStream(ConfigAvatarOptionsPath, FileMode.Create);
                fs.Dispose();
                Save_BlockedRPCPlayers();
                Log.Warn($"AvatarOptions File Created: {ConfigAvatarOptionsPath}");
            }

            if (!Directory.Exists(ConfigTempFolder))
            {
                _ = Directory.CreateDirectory(ConfigTempFolder);
                Log.Warn($"ConfigTempFolder File Created: {ConfigTempFolder}");
            }

            SaveMutex.ReleaseMutex();
        }

        public static void Save_General()
        {
            JSonWriter.WriteToJsonFile(ConfigPath, General);
            Log.Debug("General Config Saved.");
        }

        public static void Save_UI()
        {
            JSonWriter.WriteToJsonFile(ConfigUIPath, UI);
            Log.Debug("UI Config Saved.");
        }

        public static void Save_ESP()
        {
            JSonWriter.WriteToJsonFile(ConfigESPPath, ESP);
            Log.Debug("ESP Config Saved.");
        }

        public static void Save_Flight()
        {
            JSonWriter.WriteToJsonFile(ConfigFlightPath, Flight);
            Log.Debug("Flight Config Saved.");
        }

        public static void Save_Movement()
        {
            JSonWriter.WriteToJsonFile(ConfigMovementPath, Movement);
            Log.Debug("Movement Config Saved.");
        }

        public static void Save_Favorites()
        {
            JSonWriter.WriteToJsonFile(ConfigFavoritesPath, Favorites);
            Log.Debug("Favorites Config Saved.");
        }

        public static void Save_Performance()
        {
            JSonWriter.WriteToJsonFile(ConfigPerformancePath, Performance);
            Log.Debug("Performance Config Saved.");
        }
        public static void Save_LoadingScreen()
        {
            JSonWriter.WriteToJsonFile(ConfigLoadingScreenPath, LoadingScreen);
            Log.Debug("Loading Screen Config Saved.");
        }

        public static void Save_BlockedRPCPlayers()
        {
            JSonWriter.WriteToJsonFile(ConfigBlockedRPCPlayersPath, BlockedRPCPlayers);
            Log.Debug("Blocked RPC Players Config Saved.");
        }
        public static void Save_AvatarOptions()
        {
            JSonWriter.WriteToJsonFile(ConfigAvatarOptionsPath, AvatarOptions);
            Log.Debug("Avatar Options Config Saved.");
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
            Save_BlockedRPCPlayers();
            Save_AvatarOptions();
            stopwatch.Stop();
            Log.Write($"Finished Saving Configuration Files: {stopwatch.ElapsedMilliseconds}ms");
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
                Log.Error("Failed to load General config, creating a new one..");
            }

            try
            {
                UI = JSonWriter.ReadFromJsonFile<ConfigUI>(ConfigUIPath);
            }
            catch
            {
                Log.Error("Failed to load UI config, creating a new one..");
            }

            try
            {
                ESP = JSonWriter.ReadFromJsonFile<ConfigESP>(ConfigESPPath);
            }
            catch
            {
                Log.Error("Failed to load ESP config, creating a new one..");
            }

            try
            {
                Flight = JSonWriter.ReadFromJsonFile<ConfigFlight>(ConfigFlightPath);
            }
            catch
            {
                Log.Error("Failed to load Flight config, creating a new one..");
            }

            try
            {
                Movement = JSonWriter.ReadFromJsonFile<ConfigMovement>(ConfigMovementPath);
            }
            catch
            {
                Log.Error("Failed to load Movement config, creating a new one..");
            }

            try
            {
                Favorites = JSonWriter.ReadFromJsonFile<ConfigFavorites>(ConfigFavoritesPath);
            }
            catch
            {
                Log.Error("Failed to load Favorites config, creating a new one..");
            }

            try
            {
                Performance = JSonWriter.ReadFromJsonFile<ConfigPerformance>(ConfigPerformancePath);
            }
            catch
            {
                Log.Error("Failed to load Performance config, creating a new one..");
            }

            try
            {
                LoadingScreen = JSonWriter.ReadFromJsonFile<ConfigLoadingScreen>(ConfigLoadingScreenPath);
            }
            catch
            {
                Log.Error("Failed to load Loading Screen config, creating a new one..");
            }

            try
            {
                BlockedRPCPlayers = JSonWriter.ReadFromJsonFile<ConfigBlockedRPCPlayers>(ConfigBlockedRPCPlayersPath);
            }
            catch
            {
                Log.Error("Failed to load Blocked RPC Players config, creating a new one..");
            }
            try
            {
                AvatarOptions = JSonWriter.ReadFromJsonFile<ConfigAvatarOptions>(ConfigAvatarOptionsPath);
            }
            catch
            {
                Log.Error("Failed to load Avatar Options config, creating a new one..");
            }

            stopwatch.Stop();
            Log.Debug($"Finished Loading Configuration Files: {stopwatch.ElapsedMilliseconds}ms");
            SaveAll();
        }
    }
}