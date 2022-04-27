using AstroClient.ClientActions;

namespace AstroClient.ClientUI.Menu.ItemTweakerV2.Handlers
{
    using System;
    using AstroMonos.Components.Tools.Listeners;
    using Selector;
    using Tools.Extensions;
    using UnityEngine;
    using xAstroBoy.Utility;

    internal class ListenerHandler : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            TweakerEventActions.Event_On_New_GameObject_Selected += On_New_GameObject_Selected;
            TweakerEventActions.Event_On_Old_GameObject_Removed += On_Old_GameObject_Removed;


        }
    

        private void On_New_GameObject_Selected(GameObject obj)
        {
            if (obj != null)
            {
                var listener = obj.GetOrAddComponent<TweakerListener>();
                if (listener != null)
                {
                    // Set actions to fire events.
                    listener.OnEnabled += () =>
                    {
                        TweakerEventActions.Event_OnSelectedObject_Enabled.SafetyRaise();
                    };
                    listener.OnDisabled += () =>
                    {
                        TweakerEventActions.Event_OnSelectedObject_Disabled.SafetyRaise();
                    };
                    listener.OnDestroyed += () =>
                    {
                        TweakerEventActions.Event_OnSelectedObject_Destroyed.SafetyRaise();
                    };
                    // Then call and update the SetActive
                    if (obj.active)
                    {
                        TweakerEventActions.Event_OnSelectedObject_Enabled.SafetyRaise();
                    }
                    else
                    {
                        TweakerEventActions.Event_OnSelectedObject_Disabled.SafetyRaise();
                    }
                }
            }
        }

        private void On_Old_GameObject_Removed(GameObject obj)
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