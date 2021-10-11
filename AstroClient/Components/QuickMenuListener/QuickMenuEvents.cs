namespace AstroClient.Components
{
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
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
            
        }


        internal IEnumerator InitListenerForQM()
        {
            while (QMTabs == null)
                yield return null;
            if(QMTabs != null)
            {
                var listener = QMTabs.AddComponent<QuickMenuListener>();
                if(listener != null)
                {
                    listener.OnEnabled += new Action(() => {Event_OnQuickMenuOpen?.SafetyRaise(new EventArgs()); });
                    listener.OnDisabled += new Action(() => { Event_OnQuickMenuClose?.SafetyRaise(new EventArgs()); });
                }
            }

        }


        private static GameObject _QMTabs;
        internal static GameObject QMTabs
        {
            get
            {
                if(_QMTabs == null)
                {
                    return _QMTabs = GameObjectFinder.Find("UserInterface/QuickMenu/QuickModeTabs");
                }
                return _QMTabs;
            }
        }
    }
}
