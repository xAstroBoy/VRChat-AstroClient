using AstroClient.Config;
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
    internal class UdonEventsHook : AstroEvents
    {
        internal static event EventHandler<UdonBehaviourEvent> Event_Udon_OnPickup;
        internal static event EventHandler<UdonBehaviourEvent> Event_Udon_OnPickupUseUp;
        internal static event EventHandler<UdonBehaviourEvent> Event_Udon_OnPickupUseDown;
        internal static event EventHandler<UdonBehaviourEvent> Event_Udon_OnDrop;
        internal static event EventHandler<UdonBehaviourEvent> Event_Udon_OnInteract;
        internal static event EventHandler<UdonBehaviourCustomEvent> Event_Udon_SendCustomEvent;

        [System.Reflection.ObfuscationAttribute(Feature = "HarmonyGetPatch")]
        private static HarmonyMethod GetPatch(string name)
        {
            return new HarmonyMethod(typeof(UdonEventsHook).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
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
            new AstroPatch(typeof(UdonBehaviour).GetMethod(nameof(UdonBehaviour.Interact)), GetPatch(nameof(Hook_UdonBehaviour_Event_OnInteract)));
            new AstroPatch(typeof(UdonBehaviour).GetMethod(nameof(UdonBehaviour.SendCustomEvent)), GetPatch(nameof(Hook_UdonBehaviour_Event_SendCustomEvent)));

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
        private static void Hook_UdonBehaviour_Event_OnInteract(UdonBehaviour __instance)
        {
            Event_Udon_OnInteract.SafetyRaise(new UdonBehaviourEvent(__instance));
        }
        private static void Hook_UdonBehaviour_Event_SendCustomEvent(UdonBehaviour __instance, string __0)
        {
            Event_Udon_SendCustomEvent.SafetyRaise(new UdonBehaviourCustomEvent(__instance, __0));
        }


    }
}