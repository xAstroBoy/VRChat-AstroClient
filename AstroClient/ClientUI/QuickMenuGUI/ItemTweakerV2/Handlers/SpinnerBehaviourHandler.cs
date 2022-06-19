using AstroClient.AstroMonos.Components.Custom.Random;
using AstroClient.ClientActions;
using UnityEngine;

namespace AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Handlers
{
    internal class SpinnerBehaviourHandler : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            TweakerEventActions.On_New_GameObject_Selected += On_New_GameObject_Selected;
            TweakerEventActions.On_Old_GameObject_Removed += On_Old_GameObject_Removed;
            TweakerEventActions.OnSelectedObject_Destroyed += OnSelectedObject_Destroyed;
        }
         

        private void OnSelectedObject_Destroyed()
        {
            TweakerEventActions.OnSpinnerBehaviourPropertyChanged.SafetyRaiseWithParams(null) ; // Dunno if it works.

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
                                TweakerEventActions.OnSpinnerBehaviourPropertyChanged.SafetyRaiseWithParams(newinstance); // Dunno if it works.
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
                        TweakerEventActions.OnSpinnerBehaviourPropertyChanged.SafetyRaiseWithParams(newinstance); // Dunno if it works.
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
                        TweakerEventActions.OnSpinnerBehaviourPropertyChanged.SafetyRaiseWithParams(SpinnerBehaviour); // Dunno if it works.
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