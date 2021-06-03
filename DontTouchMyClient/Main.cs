using DontTouchMyClient.Patches;
using Harmony;
using MelonLoader;
using System;
using System.Reflection;
namespace DontTouchMyClient
{

    public class DontTouchMyClient : MelonPlugin
    {
        public override void OnPreInitialization() // Runs before Game Initialization.
        {
            Patching.StartDefenses();
        }
        public override void OnGUI()
        {
            PreventFileSearches = true;
            NeedsToBlockRegistry = true;
            HideModsAndPlugins = true;
        }

        public static bool ProtectVRChatProcessByHidingIt = false;

        public static bool NeedsToBlockRegistry = false;

        public static bool PreventFileSearches = false;

        public static bool HideModsAndPlugins = true;
    }
}