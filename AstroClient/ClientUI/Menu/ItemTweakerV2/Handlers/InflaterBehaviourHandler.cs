namespace AstroClient.ClientUI.Menu.ItemTweakerV2.Handlers
{
    using System;
    using AstroMonos.Components.Custom.Random;
    using Selector;
    using Tools.Extensions;
    using TweakerEventArgs;
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
                            newinstance.SetOnInflaterUpdate(() =>
                            {
                                Event_OnInflaterBehaviourUpdate.SafetyRaise(new OnInflaterBehaviourArgs(newinstance)); // Dunno if it works.
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
                    newinstance.SetOnInflaterUpdate(() =>
                    {
                        Event_OnInflaterBehaviourUpdate.SafetyRaise(new OnInflaterBehaviourArgs(newinstance)); // Dunno if it works.
                    });
                }
            }
        }


        internal static event EventHandler<OnInflaterBehaviourArgs> Event_OnInflaterBehaviourPropertyChanged;
        internal static event EventHandler<OnInflaterBehaviourArgs> Event_OnInflaterBehaviourUpdate;

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
                    InflaterBehaviour.SetOnInflaterUpdate(() =>
                    {
                        Event_OnInflaterBehaviourUpdate.SafetyRaise(new OnInflaterBehaviourArgs(InflaterBehaviour)); // Dunno if it works.
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