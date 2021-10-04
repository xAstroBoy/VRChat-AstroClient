namespace AstroClient.ItemTweakerV2.Handlers
{
    using AstroClient.Components;
    using AstroClient.ItemTweakerV2.Selector;
    using AstroClient.ItemTweakerV2.TweakerEventArgs;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using System;
    using UnityEngine;

    internal class CrazyBehaviourHandler : Tweaker_Events
    {
        internal override void OnSelectedObject_Destroyed()
        {
            Event_OnCrazyBehaviourPropertyChanged.SafetyRaise(new OnCrazyBehaviourArgs(null)); // Dunno if it works.
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
                                Event_OnCrazyBehaviourPropertyChanged.SafetyRaise(new OnCrazyBehaviourArgs(newinstance)); // Dunno if it works.
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
                        Event_OnCrazyBehaviourPropertyChanged.SafetyRaise(new OnCrazyBehaviourArgs(newinstance)); // Dunno if it works.
                    });
                }

            }
        }

        

        internal static event EventHandler<OnCrazyBehaviourArgs> Event_OnCrazyBehaviourPropertyChanged;
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
                        Event_OnCrazyBehaviourPropertyChanged.SafetyRaise(new OnCrazyBehaviourArgs(CrazyBehaviour)); // Dunno if it works.
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