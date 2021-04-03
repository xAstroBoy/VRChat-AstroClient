namespace AstroClient.AntiCrash
{
    using AstroClient.ConsoleUtils;
    using AstroClient.extensions;
    using AstroClient.variables;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using UnityEngine;
    using VRC.SDKBase;

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
    public class AntiCrash : Overridables
    {
        public static bool Enabled;

        public override void OnApplicationStart()
        {
            // Just while it's being developed
            if (Bools.isCheetosMode)
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
