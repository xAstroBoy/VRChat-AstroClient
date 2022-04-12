namespace AstroClient.ClientUI.Menu.ItemTweakerV2.Handlers
{
    using System;
    using AstroMonos.Components.Custom.Random;
    using Selector;
    using Tools.Extensions;
    using UnityEngine;

    internal class SpinnerBehaviourHandler : Tweaker_Events
    {
        internal static event Action<SpinnerBehaviour> Event_OnSpinnerBehaviourPropertyChanged;

        internal override void OnSelectedObject_Destroyed()
        {
            Event_OnSpinnerBehaviourPropertyChanged.SafetyRaiseWithParams(null) ; // Dunno if it works.

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
                                Event_OnSpinnerBehaviourPropertyChanged.SafetyRaiseWithParams(newinstance); // Dunno if it works.
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
                        Event_OnSpinnerBehaviourPropertyChanged.SafetyRaiseWithParams(newinstance); // Dunno if it works.
                    });
                }

            }
        }

        

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
                        Event_OnSpinnerBehaviourPropertyChanged.SafetyRaiseWithParams(SpinnerBehaviour); // Dunno if it works.
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