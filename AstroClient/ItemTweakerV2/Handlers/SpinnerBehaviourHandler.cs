namespace AstroClient.ItemTweakerV2.Handlers
{
    using AstroClient.Components;
    using AstroClient.ItemTweakerV2.Selector;
    using AstroClient.ItemTweakerV2.TweakerEventArgs;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using System;
    using UnityEngine;

    internal class SpinnerBehaviourHandler : Tweaker_Events
    {
        internal override void OnSelectedObject_Destroyed()
        {
            Event_OnSpinnerBehaviourPropertyChanged.SafetyRaise(new OnSpinnerBehaviourArgs(null)) ; // Dunno if it works.

            instance = null;
        }

        internal static void FocusPageOnSpinner(SpinnerBehaviour newinstance)
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
                            newinstance.SetOnSpinnerPropertyChanged(() =>
                            {
                                Event_OnSpinnerBehaviourPropertyChanged.SafetyRaise(new OnSpinnerBehaviourArgs(newinstance)); // Dunno if it works.
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
                    newinstance.SetOnSpinnerPropertyChanged(() =>
                    {
                        Event_OnSpinnerBehaviourPropertyChanged.SafetyRaise(new OnSpinnerBehaviourArgs(newinstance)); // Dunno if it works.
                    });
                }

            }
        }

        

        internal static event EventHandler<OnSpinnerBehaviourArgs> Event_OnSpinnerBehaviourPropertyChanged;
        internal override void On_New_GameObject_Selected(GameObject obj)
        {
            if (obj != null)
            {
                SpinnerBehaviour SpinnerBehaviour = obj.GetComponent<SpinnerBehaviour>();
                if (SpinnerBehaviour != null)
                {
                    instance = SpinnerBehaviour; 
                    SpinnerBehaviour.SetOnSpinnerPropertyChanged(() =>
                    {
                        Event_OnSpinnerBehaviourPropertyChanged.SafetyRaise(new OnSpinnerBehaviourArgs(SpinnerBehaviour)); // Dunno if it works.
                    });
                }
            }
        }

        internal override void On_Old_GameObject_Removed(GameObject obj)
        {
            if (obj != null)
            {
                SpinnerBehaviour SpinnerBehaviour = obj.GetComponent<SpinnerBehaviour>();
                if (SpinnerBehaviour != null)
                {
                    SpinnerBehaviour.RemoveActionEvents(); // No more Focused on tweaker, so no need for The property Event changed.
                }
            }
        }

        private static SpinnerBehaviour instance;
    }
}