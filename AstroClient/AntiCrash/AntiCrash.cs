using AstroClient.ConsoleUtils;
using AstroClient.variables;
using System.Collections.Generic;
using UnityEngine;
using VRC.SDKBase;

namespace AstroClient.AntiCrash
{
    public static class AntiCrashUtils
    {
        /// <summary>
        /// This is temporary while I figure out things
        /// </summary>
        /// <param name="msg"></param>
        public static void TempLog(string msg)
        {
            ModConsole.CheetoLog($"[ACS] {msg}");
        }
    }

    public static class AntiCrash_Lists
    {
        public static List<string> GenitalNames = new List<string>();

        public static List<string> CrasherCreators = new List<string>();

        public static List<string> CrashShaderTerms = new List<string>();

        public static void DownloadLists()
        {
        }
    }

    /// <summary>
    /// Just calling it AntiCrash, as the name is pretty generic
    /// </summary>
    public class AntiCrash : GameEvents
    {
        public static bool Enabled;

        public override void OnApplicationStart()
        {
            // Just while it's being developed
            if (Bools.IsCheetosMode)
            {
                Enabled = true;
            }
        }

        public override void OnAvatarSpawn(GameObject avatar, VRC_AvatarDescriptor DescriptorObj, bool state)
        {
            if (Enabled)
            {
                // Check and scan :)
                AntiCrashScanner.ScanAvatar(avatar, DescriptorObj);
            }
        }
    }
}