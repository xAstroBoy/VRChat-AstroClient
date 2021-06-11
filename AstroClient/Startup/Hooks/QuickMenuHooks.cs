namespace AstroClient.Startup.Hooks
{
	using AstroLibrary.Console;
	using AstroLibrary.Extensions;
	using Harmony;
	using MelonLoader;
	using System;
	using System.Reflection;

	public class QuickMenuHooks : GameEvents
    {
        public static event EventHandler<VRCPlayerEventArgs> Event_OnPlayerSelected;

        private HarmonyInstance harmony1;

        public override void ExecutePriorityPatches()
        {
            //HookSelectedPlayer();
        }

        private void HookSelectedPlayer()
        {
            try
            {
                if (harmony1 == null)
                {
                    harmony1 = HarmonyInstance.Create(BuildInfo.Name + " SelectedPlayerHook");
                }

                harmony1.Patch(AccessTools.Method(typeof(QuickMenu), nameof(QuickMenu.Method_Public_Void_Player_PDM_0)), new HarmonyMethod(typeof(QuickMenuHooks).GetMethod(nameof(OnSelectedPlayerPatch), BindingFlags.Static | BindingFlags.NonPublic)), null, null);
                ModConsole.DebugLog("Hooked VRC_EventDispatcherRFC 1");
            }
            catch
            {
                harmony1.UnpatchAll();
                HookSelectedPlayer();
            }
        }

        private static bool OnSelectedPlayerPatch(VRC.Player player)
        {
            ModConsole.Log($"Test OnSelected {player.DisplayName()}");
            Event_OnPlayerSelected.SafetyRaise(new VRCPlayerEventArgs(player));
            return true;
        }
    }
}