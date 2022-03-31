using VRC.Udon;

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
    internal class UdonEvents : AstroEvents
    {
        internal static event EventHandler<UdonBehaviourEvent> Event_Udon_OnPickup;
        internal static event EventHandler<UdonBehaviourEvent> Event_Udon_OnPickupUseUp;
        internal static event EventHandler<UdonBehaviourEvent> Event_Udon_OnPickupUseDown;
        internal static event EventHandler<UdonBehaviourEvent> Event_Udon_OnDrop;

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(UdonEvents).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
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
            new AstroPatch(typeof(UdonBehaviour).GetMethod(nameof(UdonBehaviour.OnPickup)), GetPatch(nameof(Hook_UdonBehaviour_Event_OnPickup)));
            new AstroPatch(typeof(UdonBehaviour).GetMethod(nameof(UdonBehaviour.OnPickupUseUp)), GetPatch(nameof(Hook_UdonBehaviour_Event_OnPickupUseUp)));
            new AstroPatch(typeof(UdonBehaviour).GetMethod(nameof(UdonBehaviour.OnPickupUseDown)), GetPatch(nameof(Hook_UdonBehaviour_Event_OnPickupUseDown)));
            new AstroPatch(typeof(UdonBehaviour).GetMethod(nameof(UdonBehaviour.OnDrop)), GetPatch(nameof(Hook_UdonBehaviour_Event_OnDrop)));
        }

        private static void Hook_UdonBehaviour_Event_OnPickup(UdonBehaviour __instance)
        {
            Event_Udon_OnPickup.SafetyRaise(new UdonBehaviourEvent(__instance));


        }
        private static void Hook_UdonBehaviour_Event_OnPickupUseUp(UdonBehaviour __instance)
        {
            Event_Udon_OnPickupUseUp.SafetyRaise(new UdonBehaviourEvent(__instance));

        }
        private static void Hook_UdonBehaviour_Event_OnPickupUseDown(UdonBehaviour __instance)
        {
            Event_Udon_OnPickupUseDown.SafetyRaise(new UdonBehaviourEvent(__instance));

        }
        private static void Hook_UdonBehaviour_Event_OnDrop(UdonBehaviour __instance)
        {
            Event_Udon_OnDrop.SafetyRaise(new UdonBehaviourEvent(__instance));

        }

    }
}