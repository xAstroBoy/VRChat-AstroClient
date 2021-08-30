namespace DontTouchMyClient
{
    using AstroLibrary.Console;
    using global::DontTouchMyClient.Patches;
    using MelonLoader;

	public class DontTouchMyClient : MelonPlugin
    {
        public DontTouchMyClient()
        {
            ModConsole.Initialize("DontTouchMyClient");
            ModConsole.Log("DontTouchMyClient is starting..");
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