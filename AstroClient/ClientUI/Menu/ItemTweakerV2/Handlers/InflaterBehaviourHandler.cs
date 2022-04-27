using AstroClient.ClientActions;

namespace AstroClient.ClientUI.Menu.ItemTweakerV2.Handlers
{
    using System;
    using AstroMonos.Components.Custom.Random;
    using Selector;
    using Tools.Extensions;
    using UnityEngine;

    internal class InflaterBehaviourHandler : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            TweakerEventActions.Event_OnSelectedObject_Destroyed += OnSelectedObject_Destroyed;
            TweakerEventActions.Event_On_New_GameObject_Selected += On_New_GameObject_Selected;
            TweakerEventActions.Event_On_Old_GameObject_Removed += On_Old_GameObject_Removed;


        }
        private void OnSelectedObject_Destroyed()
        {
            TweakerEventActions.Event_OnInflaterBehaviourPropertyChanged.SafetyRaiseWithParams(null); // Dunno if it works.
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
                                TweakerEventActions.Event_OnInflaterBehaviourPropertyChanged.SafetyRaiseWithParams(newinstance); // Dunno if it works.
                            });
                            newinstance.SetOnInflaterUpdate(() =>
                            {
                                TweakerEventActions.Event_OnInflaterBehaviourUpdate.SafetyRaiseWithParams(newinstance); // Dunno if it works.
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
                        TweakerEventActions.Event_OnInflaterBehaviourPropertyChanged.SafetyRaiseWithParams(newinstance); // Dunno if it works.
                    });
                    newinstance.SetOnInflaterUpdate(() =>
                    {
                        TweakerEventActions.Event_OnInflaterBehaviourUpdate.SafetyRaiseWithParams(newinstance); // Dunno if it works.
                    });
                }
            }
        }



        private void On_New_GameObject_Selected(GameObject obj)
        {
            if (obj != null)
            {
                InflaterBehaviour InflaterBehaviour = obj.GetComponent<InflaterBehaviour>();
                if (InflaterBehaviour != null)
                {
                    instance = InflaterBehaviour;
                    InflaterBehaviour.SetOnInflaterPropertyChanged(() =>
                    {
                        TweakerEventActions.Event_OnInflaterBehaviourPropertyChanged.SafetyRaiseWithParams(InflaterBehaviour); // Dunno if it works.
                    });
                    InflaterBehaviour.SetOnInflaterUpdate(() =>
                    {
                        TweakerEventActions.Event_OnInflaterBehaviourUpdate.SafetyRaiseWithParams(InflaterBehaviour); // Dunno if it works.
                    });
                }
            }
        }

        private void On_Old_GameObject_Removed(GameObject obj)
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