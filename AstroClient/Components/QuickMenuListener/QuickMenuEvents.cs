namespace AstroClient.Components
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using MelonLoader;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using UnityEngine;

    internal class QuickMenuEvents : GameEvents
    {

        internal static EventHandler<EventArgs> Event_OnQuickMenuOpen { get; set; }
        internal static EventHandler<EventArgs> Event_OnQuickMenuClose { get; set; }


        internal override void VRChat_OnQuickMenuInit()
        {
            MelonCoroutines.Start(InitListenerForQM());
        }


        internal IEnumerator InitListenerForQM()
        {
            while (QuickMenuElements == null)
                yield return null;
            if(QuickMenuElements != null)
            {
                var listener = QuickMenuElements.AddComponent<QuickMenuListener>();
                if(listener != null)
                {
                    listener.OnEnabled += new Action(() => {Event_OnQuickMenuOpen?.SafetyRaise(new EventArgs()); });
                    listener.OnDisabled += new Action(() => { Event_OnQuickMenuClose?.SafetyRaise(new EventArgs()); });
                    ModConsole.DebugLog("QuickMenu Listener Added!");
                }
            }
            yield return null;
        }


        private static GameObject _QuickMenuElements;
        internal static GameObject QuickMenuElements
        {
            get
            {
                if(_QuickMenuElements == null)
                {
                    return _QuickMenuElements = GameObjectFinder.Find("UserInterface/QuickMenu/QuickMenu_NewElements");
                }
                return _QuickMenuElements;
            }
        }

        //private static GameObject _UIElements;
        //internal static GameObject UiElement
        //{
        //    get
        //    {
        //        if (_UIElements == null)
        //        {
        //            return _UIElements = GameObjectFinder.Find("UserInterface/QuickMenu/QuickMenu_NewElements");
        //        }
        //        return _UIElements;
        //    }
        //}

    }
}
