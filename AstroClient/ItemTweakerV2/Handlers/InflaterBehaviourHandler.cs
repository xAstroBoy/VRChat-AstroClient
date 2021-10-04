namespace AstroClient.ItemTweakerV2.Handlers
{
    using AstroClient.Components;
    using AstroClient.ItemTweakerV2.Selector;
    using AstroClient.ItemTweakerV2.TweakerEventArgs;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using System;
    using UnityEngine;

    internal class InflaterBehaviourHandler : Tweaker_Events
    {

        internal override void OnSelectedObject_Destroyed()
        {
            Event_OnInflaterBehaviourPropertyChanged.SafetyRaise(new OnInflaterBehaviourArgs(null)); // Dunno if it works.
            instance = null;
        }

        internal static void FocusPageOnInflater(InflaterBehaviour newinstance)
        {
            if (instance != null)
            {
                // Check if is already focused
                if (newinstance != null)
                {
                    if (!instance.Equals(newinstance))
                    {
                        if (newinstance != null)
                        {
                            instance = newinstance;
                            newinstance.SetOnInflaterPropertyChanged(() =>
                            {
                                Event_OnInflaterBehaviourPropertyChanged.SafetyRaise(new OnInflaterBehaviourArgs(newinstance)); // Dunno if it works.
                            });
                        }
                    }
                }
            }
            else
            {
                if (newinstance != null)
                {
                    instance = newinstance;
                    newinstance.SetOnInflaterPropertyChanged(() =>
                    {
                        Event_OnInflaterBehaviourPropertyChanged.SafetyRaise(new OnInflaterBehaviourArgs(newinstance)); // Dunno if it works.
                    });
                }

            }
        }

        

        internal static event EventHandler<OnInflaterBehaviourArgs> Event_OnInflaterBehaviourPropertyChanged;
        internal override void On_New_GameObject_Selected(GameObject obj)
        {
            if (obj != null)
            {
                InflaterBehaviour InflaterBehaviour = obj.GetComponent<InflaterBehaviour>();
                if (InflaterBehaviour != null)
                {
                    instance = InflaterBehaviour; 
                    InflaterBehaviour.SetOnInflaterPropertyChanged(() =>
                    {
                        Event_OnInflaterBehaviourPropertyChanged.SafetyRaise(new OnInflaterBehaviourArgs(InflaterBehaviour)); // Dunno if it works.
                    });
                }
            }
        }

        internal override void On_Old_GameObject_Removed(GameObject obj)
        {
            if (obj != null)
            {
                InflaterBehaviour InflaterBehaviour = obj.GetComponent<InflaterBehaviour>();
                if (InflaterBehaviour != null)
                {
                    InflaterBehaviour.RemoveActionEvents(); // No more Focused on tweaker, so no need for The property Event changed.
                }
            }
        }

        private static InflaterBehaviour instance;
    }
}