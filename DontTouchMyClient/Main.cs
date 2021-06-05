namespace DontTouchMyClient
{
	using AstroLibrary.Console;
	using global::DontTouchMyClient.Patches;
	using MelonLoader;

	public class DontTouchMyClient : MelonPlugin
    {
        public override void OnPreInitialization() // Runs before Game Initialization.
        {
			ModConsole.Initialize("DontTouchMyClient");
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