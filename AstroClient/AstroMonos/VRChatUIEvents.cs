namespace AstroClient.AstroMonos
{
    using System;
    using System.Collections;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using Components.Tools.Listeners;
    using MelonLoader;

    internal class VRChatUIEvents : GameEvents
    {
        internal static EventHandler Event_OnQuickMenuOpen { get; set; }
        internal static EventHandler Event_OnQuickMenuClose { get; set; }

        internal static EventHandler Event_OnBigMenuOpen { get; set; }
        internal static EventHandler Event_OnBigMenuClose {  get; set; }

        internal override void VRChat_OnQuickMenuInit()
        {
            MelonCoroutines.Start(InitListenerForQM());
            MelonCoroutines.Start(InitListenerForBigMenu());
        }

        internal IEnumerator InitListenerForBigMenu()
        {
            while (UserInterfaceObjects.BigMenuElements == null)
                yield return null;
            if (UserInterfaceObjects.BigMenuElements != null)
            {
                var listener = UserInterfaceObjects.BigMenuElements.gameObject.AddComponent<UiListener>();
                if (listener != null)
                {
                    listener.OnEnabled += new Action(() => { Event_OnBigMenuOpen?.SafetyRaise(); });
                    listener.OnDisabled += new Action(() => { Event_OnBigMenuClose?.SafetyRaise(); });
                    ModConsole.DebugLog("Big Menu Listener Added!");
                }
            }
            yield return null;
        }

        internal IEnumerator InitListenerForQM()
        {
            while (UserInterfaceObjects.QuickMenuElements == null)
                yield return null;
            if (UserInterfaceObjects.QuickMenuElements != null)
            {
                var listener = UserInterfaceObjects.QuickMenuElements.gameObject.AddComponent<UiListener>();
                if (listener != null)
                {
                    listener.OnEnabled += new Action(() => { Event_OnQuickMenuOpen?.SafetyRaise(); });
                    listener.OnDisabled += new Action(() => { Event_OnQuickMenuClose?.SafetyRaise(); });
                    ModConsole.DebugLog("QuickMenu Listener Added!");
                }
            }
            yield return null;
        }

        // Mostly background UIs paths .

    }
}