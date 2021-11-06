using UnhollowerBaseLib.Attributes;

namespace AstroClient.Components
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using MelonLoader;
    using System;
    using System.Collections;
    using UnityEngine;

    internal class VRChatUIEvents : GameEvents
    {
        internal static EventHandler<EventArgs> Event_OnQuickMenuOpen { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal static EventHandler<EventArgs> Event_OnQuickMenuClose { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal static EventHandler<EventArgs> Event_OnBigMenuOpen { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal static EventHandler<EventArgs> Event_OnBigMenuClose { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal override void VRChat_OnQuickMenuInit()
        {
            MelonCoroutines.Start(InitListenerForQM());
            MelonCoroutines.Start(InitListenerForBigMenu());
        }

        internal IEnumerator InitListenerForBigMenu()
        {
            while (BigMenuElements == null) yield return null;
            if (BigMenuElements != null)
            {
                var listener = BigMenuElements.AddComponent<UiListener>();
                if (listener != null)
                {
                    listener.OnEnabled += new Action(() => { Event_OnBigMenuOpen?.SafetyRaise(new EventArgs()); });
                    listener.OnDisabled += new Action(() => { Event_OnBigMenuClose?.SafetyRaise(new EventArgs()); });
                    ModConsole.DebugLog("Big Menu Listener Added!");
                }
            }
            yield return null;
        }

        internal IEnumerator InitListenerForQM()
        {
            while (QuickMenuElements == null) yield return null;
            if (QuickMenuElements != null)
            {
                var listener = QuickMenuElements.AddComponent<UiListener>();
                if (listener != null)
                {
                    listener.OnEnabled += new Action(() => { Event_OnQuickMenuOpen?.SafetyRaise(new EventArgs()); });
                    listener.OnDisabled += new Action(() => { Event_OnQuickMenuClose?.SafetyRaise(new EventArgs()); });
                    ModConsole.DebugLog("QuickMenu Listener Added!");
                }
            }
            yield return null;
        }

        // Mostly background UIs paths .
        private static GameObject _QuickMenuElements;

        internal static GameObject QuickMenuElements
        {
            [HideFromIl2Cpp]
            get
            {
                if (_QuickMenuElements == null)
                {
                    return _QuickMenuElements = GameObjectFinder.Find("UserInterface/QuickMenu/QuickMenu_NewElements");
                }
                return _QuickMenuElements;
            }
        }

        private static GameObject _BigMenuElements;

        internal static GameObject BigMenuElements
        {
            [HideFromIl2Cpp]
            get
            {
                if (_BigMenuElements == null)
                {
                    return _BigMenuElements = GameObjectFinder.Find("UserInterface/MenuContent/Backdrop/Backdrop");
                }
                return _BigMenuElements;
            }
        }
    }
}