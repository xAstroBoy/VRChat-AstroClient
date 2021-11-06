namespace AstroClient.ItemTweakerV2.Handlers
{
    using System;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using AstroMonos.Components.Tools.Listeners;
    using Selector;
    using UnityEngine;

    internal class ListenerHandler : Tweaker_Events
    {
        internal static event EventHandler Event_OnSelectedObject_Enabled;

        internal static event EventHandler Event_OnSelectedObject_Disabled;

        internal static event EventHandler Event_OnSelectedObject_Destroyed;

        internal override void On_New_GameObject_Selected(GameObject obj)
        {
            if (obj != null)
            {
                var listener = obj.GetOrAddComponent<TweakerListener>();
                if (listener != null)
                {
                    // Set actions to fire events.
                    listener.OnEnabled += () =>
                    {
                        Event_OnSelectedObject_Enabled.SafetyRaise();
                    };
                    listener.OnDisabled += () =>
                    {
                        Event_OnSelectedObject_Disabled.SafetyRaise();
                    };
                    listener.OnDestroyed += () =>
                    {
                        Event_OnSelectedObject_Destroyed.SafetyRaise();
                    };
                    // Then call and update the SetActive
                    if (obj.active)
                    {
                        Event_OnSelectedObject_Enabled.SafetyRaise();
                    }
                    else
                    {
                        Event_OnSelectedObject_Disabled.SafetyRaise();
                    }
                }
            }
        }

        internal override void On_Old_GameObject_Removed(GameObject obj)
        {
            if (obj != null)
            {
                var listener = obj.GetComponent<TweakerListener>();
                if (listener != null)
                {
                    listener.RemoveListener(); // listener should be only one object, not multiple.
                }
            }
        }
    }
}