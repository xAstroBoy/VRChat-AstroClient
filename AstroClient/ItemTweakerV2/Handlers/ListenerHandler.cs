﻿namespace AstroClient.ItemTweakerV2.Handlers
{
	using AstroClient.Components;
	using AstroClient.Extensions;
	using AstroClient.ItemTweakerV2.Selector;
	using System;
	using UnityEngine;

	public class ListenerHandler : Tweaker_Events
    {
        public static event EventHandler Event_OnSelectedObject_Enabled;

        public static event EventHandler Event_OnSelectedObject_Disabled;

        public static event EventHandler Event_OnSelectedObject_Destroyed;

        public override void On_New_GameObject_Selected(GameObject obj)
        {
            if (obj != null)
            {
                var listener = obj.GetOrAddComponent<TweakerListener>();
                if (listener != null)
                {
                    // Set actions to fire events.
                    listener.OnEnabled += () =>
                    {
                        Event_OnSelectedObject_Enabled?.Invoke(null, null);
                    };
                    listener.OnDisabled += () =>
                    {
                        Event_OnSelectedObject_Disabled?.Invoke(null, null);
                    };
                    listener.OnDestroyed += () =>
                    {
                        Event_OnSelectedObject_Destroyed?.Invoke(null, null);
                    };
                }
            }
        }

        public override void On_Old_GameObject_Removed(GameObject obj)
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