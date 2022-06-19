using AstroClient.AstroMonos.Components.Tools.Listeners;
using AstroClient.ClientActions;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;

namespace AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Handlers
{
    internal class ListenerHandler : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            TweakerEventActions.On_New_GameObject_Selected += On_New_GameObject_Selected;
            TweakerEventActions.On_Old_GameObject_Removed += On_Old_GameObject_Removed;


        }
    

        private void On_New_GameObject_Selected(GameObject obj)
        {
            if (obj != null)
            {
                var listener = ComponentUtils.GetOrAddComponent<TweakerListener>(obj);
                if (listener != null)
                {
                    // Set actions to fire events.
                    listener.OnEnabled += () =>
                    {
                        TweakerEventActions.OnSelectedObject_Enabled.SafetyRaise();
                    };
                    listener.OnDisabled += () =>
                    {
                        TweakerEventActions.OnSelectedObject_Disabled.SafetyRaise();
                    };
                    listener.OnDestroyed += () =>
                    {
                        TweakerEventActions.OnSelectedObject_Destroyed.SafetyRaise();
                    };
                    // Then call and update the SetActive
                    if (obj.active)
                    {
                        TweakerEventActions.OnSelectedObject_Enabled.SafetyRaise();
                    }
                    else
                    {
                        TweakerEventActions.OnSelectedObject_Disabled.SafetyRaise();
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