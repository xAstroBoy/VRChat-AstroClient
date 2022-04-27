using AstroClient.ClientActions;

namespace AstroClient.ClientUI.Menu.ItemTweakerV2.Handlers
{
    using System;
    using AstroMonos.Components.Custom.Random;
    using Selector;
    using Tools.Extensions;
    using UnityEngine;

    internal class SpinnerBehaviourHandler : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            TweakerEventActions.Event_On_New_GameObject_Selected += On_New_GameObject_Selected;
            TweakerEventActions.Event_On_Old_GameObject_Removed += On_Old_GameObject_Removed;
            TweakerEventActions.Event_OnSelectedObject_Destroyed += OnSelectedObject_Destroyed;
        }
         

        private void OnSelectedObject_Destroyed()
        {
            TweakerEventActions.Event_OnSpinnerBehaviourPropertyChanged.SafetyRaiseWithParams(null) ; // Dunno if it works.

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
                                TweakerEventActions.Event_OnSpinnerBehaviourPropertyChanged.SafetyRaiseWithParams(newinstance); // Dunno if it works.
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
                        TweakerEventActions.Event_OnSpinnerBehaviourPropertyChanged.SafetyRaiseWithParams(newinstance); // Dunno if it works.
                    });
                }

            }
        }

        

        private void On_New_GameObject_Selected(GameObject obj)
        {
            if (obj != null)
            {
                SpinnerBehaviour SpinnerBehaviour = obj.GetComponent<SpinnerBehaviour>();
                if (SpinnerBehaviour != null)
                {
                    instance = SpinnerBehaviour; 
                    SpinnerBehaviour.SetOnSpinnerPropertyChanged(() =>
                    {
                        TweakerEventActions.Event_OnSpinnerBehaviourPropertyChanged.SafetyRaiseWithParams(SpinnerBehaviour); // Dunno if it works.
                    });
                }
            }
        }

        private void On_Old_GameObject_Removed(GameObject obj)
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