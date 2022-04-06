namespace AstroClient.Startup.Hooks
{
    #region Imports

    using System;
    using System.Collections;
    using System.Reflection;
    using AstroEventArgs;
    using Cheetos;
    using Harmony;
    using MelonLoader;
    using Tools.Extensions;

    #endregion Imports

    [System.Reflection.ObfuscationAttribute(Feature = "HarmonyRenamer")]
    internal class QuickMenuHooks : AstroEvents
    {
        internal static event Action<VRC.Player> Event_OnPlayerSelected;

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(QuickMenuHooks).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }

        internal override void ExecutePriorityPatches()
        {
            MelonCoroutines.Start(Init());
        }

        private IEnumerator Init()
        {
            InitPatch();
            yield break;
        }

        private void InitPatch()
        {
            try
            {
                new AstroPatch(typeof(QuickMenu).GetMethod(nameof(QuickMenu.Method_Public_Void_Player_0)), GetPatch(nameof(OnSelectedPlayerPatch)));
            }
            catch (Exception e) { Log.Error("Error in applying patches : " + e); }
            finally { }
        }

        private static void OnSelectedPlayerPatch(ref VRC.Player __0)
        {
            Event_OnPlayerSelected.SafetyRaise(__0);
        }

    }
}