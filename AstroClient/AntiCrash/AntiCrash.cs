namespace AstroClient.AntiCrash
{
    using AstroClient.ConsoleUtils;
    using AstroClient.extensions;
    using AstroClient.variables;
    using Il2CppSystem.Collections.Generic;
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
        public static string[] GenitalNames = { "dick", "cock", "penis", "pussy", "vagina", "clit", "anus", "ass", "willy", "shlong", "cum", "sperm", "陰茎", "dildo", "strap on", "strap-on" };
    }

    public static class AntiCrashScanner
    {
        public static void ScanAvatar(GameObject avatar)
        {
            if (avatar != null)
            {
                Transform transform = avatar.transform.parent.Find("_AvatarMirrorClone");
                Transform transform2 = avatar.transform.parent.Find("_AvatarShadowClone");
                Transform transform3 = avatar.transform.parent.Find("IK");

                if (transform != null)
                {
                    AntiCrashUtils.TempLog($"Found: {transform.name}");
                }

                if (transform2 != null)
                {
                    AntiCrashUtils.TempLog($"Found: {transform2.name}");
                }

                if (transform3 != null)
                {
                    AntiCrashUtils.TempLog($"Found: {transform3.name}");
                }
            }
        }

        public static int GetPolyCount(GameObject avatar)
        {
            return 0; // WIP
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
            // Check and scan :)
            AntiCrashScanner.ScanAvatar(avatar);
        }
    }
}
