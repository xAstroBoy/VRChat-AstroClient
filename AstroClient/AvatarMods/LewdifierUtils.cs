namespace AstroClient.AvatarMods
{
    using AstroLibrary.Console;
    using AstroNetworkingLibrary;
    using Newtonsoft.Json;
    using RubyButtonAPI;
    using System;
    using System.Collections.Generic;
    using System.IO;

    internal class LewdifierUtils : GameEvents
    {
        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            RefreshAll();
        }

        internal override void OnApplicationQuit()
        {
            SaveAll();
        }

        internal static QMSingleButton LewdifyLists;

        internal static List<string> TermsToToggleOn { get; set; } = new List<string>();
        internal static List<string> TermsToToggleOff { get; set; } = new List<string>();
        internal static List<string> AvatarsToSkip { get; set; } = new List<string>();

        private static string TermsToEnableOnPath { get; } = Path.Combine(Environment.CurrentDirectory, @"AstroClient\Lewdify\TermsToEnable.json");
        private static string TermsToEnableOffPath { get; } = Path.Combine(Environment.CurrentDirectory, @"AstroClient\Lewdify\TermsToDisable.json");
        private static string AvatarsToSkipPath { get; } = Path.Combine(Environment.CurrentDirectory, @"AstroClient\Lewdify\IgnoredAvatars.json");

        internal static void SaveAll()
        {
            Save_TermsToToggleOn();
            Save_TermsToToggleOff();
            Save_AvatarToSkip();
        }

        internal static void Save_TermsToToggleOn()
        {
            JSonWriter.WriteToJsonFile(TermsToEnableOnPath, TermsToToggleOn);
        }

        internal static void Save_TermsToToggleOff()
        {
            JSonWriter.WriteToJsonFile(TermsToEnableOffPath, TermsToToggleOff);
        }

        internal static void Save_AvatarToSkip()
        {
            JSonWriter.WriteToJsonFile(AvatarsToSkipPath, AvatarsToSkip);
        }

        internal static void RefreshAll()
        {
            try
            {
                Refresh_termsToToggleOn();
                Refresh_termsToToggleOff();
                Refresh_AvatarsToSkip();
            }
            catch (Exception e)
            {
                ModConsole.DebugErrorExc(e);
            }
            finally
            {
                if (LewdifyLists != null)
                {
                    LewdifyLists.SetButtonText(ListButtonText);
                }
            }
        }

        internal static string ListButtonText
        {
            get
            {
                return $"Terms To Enable: {TermsToToggleOn.Count}\n" +
                       $"Terms To Disable: {TermsToToggleOff.Count}\n" +
                       $"Avatars to Skip: {AvatarsToSkip.Count}";
            }
        }

        internal static void Refresh_termsToToggleOn()
        {
            if (File.Exists(TermsToEnableOnPath))
            {
                List<string> list = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(TermsToEnableOnPath));
                foreach (var item in list)
                {
                    // Duplicate Check.
                    //ModConsole.DebugLog($"Found Term : {item}");
                    if (!TermsToToggleOn.Contains(item.ToLower()))
                    {
                        //ModConsole.DebugLog($"Registered Term in TermsToToggleOn : {item}");
                        TermsToToggleOn.Add(item.ToLower());
                    }
                    else
                    {
                        //ModConsole.DebugLog($"Found Duplicated Term in TermsToToggleOn : {item}");
                    }
                }
                Save_TermsToToggleOn();
            }
            else
            {
                _ = File.Create(TermsToEnableOnPath);
            }
        }

        internal static void Refresh_termsToToggleOff()
        {
            if (File.Exists(TermsToEnableOffPath))
            {
                List<string> list = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(TermsToEnableOffPath));
                foreach (var item in list)
                {
                    //ModConsole.DebugLog($"Found Term : {item}");
                    if (!TermsToToggleOff.Contains(item.ToLower()))
                    {
                        //ModConsole.DebugLog($"Registered Term in TermsToToggleOff : {item}");
                        TermsToToggleOff.Add(item.ToLower());
                    }
                    else
                    {
                        //ModConsole.DebugLog($"Found Duplicated Term in TermsToToggleOff : {item}");
                    }
                }
                Save_TermsToToggleOff();
            }
            else
            {
                _ = File.Create(TermsToEnableOffPath);
            }
        }

        internal static void Refresh_AvatarsToSkip()
        {
            if (File.Exists(AvatarsToSkipPath))
            {
                List<string> list = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(AvatarsToSkipPath));
                foreach (var item in list)
                {
                    //ModConsole.DebugLog($"Found Term : {item}");
                    if (!AvatarsToSkip.Contains(item))
                    {
                        //ModConsole.DebugLog($"Registered Term in AvatarsToSkip : {item}");
                        AvatarsToSkip.Add(item);
                    }
                    else
                    {
                        //ModConsole.DebugLog($"Found Duplicated Term in AvatarsToSkip : {item}");
                    }
                }
                Save_AvatarToSkip();
            }
            else
            {
                _ = File.Create(AvatarsToSkipPath);
            }
        }
    }
}