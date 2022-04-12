namespace AstroClient.ClientUI.Menu.ItemTweakerV2.Handlers
{
    using System;
    using AstroMonos.Components.Custom.Random;
    using Selector;
    using Tools.Extensions;
    using UnityEngine;

    internal class CrazyBehaviourHandler : Tweaker_Events
    {
        internal override void OnSelectedObject_Destroyed()
        {
            Event_OnCrazyBehaviourPropertyChanged.SafetyRaiseWithParams(null); // Dunno if it works.
            instance = null;
        }

        internal static void FocusPageOnCrazy(CrazyBehaviour newinstance)
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
                            newinstance.SetOnCrazyPropertyChanged(() =>
                            {
                                Event_OnCrazyBehaviourPropertyChanged.SafetyRaiseWithParams(newinstance); // Dunno if it works.
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
                    newinstance.SetOnCrazyPropertyChanged(() =>
                    {
                        Event_OnCrazyBehaviourPropertyChanged.SafetyRaiseWithParams(newinstance); // Dunno if it works.
                    });
                }

            }
        }

        

        internal static event Action<CrazyBehaviour> Event_OnCrazyBehaviourPropertyChanged;
        internal override void On_New_GameObject_Selected(GameObject obj)
        {
            if (obj != null)
            {
                CrazyBehaviour CrazyBehaviour = obj.GetComponent<CrazyBehaviour>();
                if (CrazyBehaviour != null)
                {
                    instance = CrazyBehaviour; 
                    CrazyBehaviour.SetOnCrazyPropertyChanged(() =>
                    {
                        Event_OnCrazyBehaviourPropertyChanged.SafetyRaiseWithParams(CrazyBehaviour); // Dunno if it works.
                    });
                }
            }
        }

        internal override void On_Old_GameObject_Removed(GameObject obj)
        {
            if (obj != null)
            {
                CrazyBehaviour CrazyBehaviour = obj.GetComponent<CrazyBehaviour>();
                if (CrazyBehaviour != null)
                {
                    CrazyBehaviour.RemoveActionEvents(); // No more Focused on tweaker, so no need for The property Event changed.
                }
            }
        }

        private static CrazyBehaviour instance;
    }
}