﻿namespace AstroClient.ClientUI.Menu.ItemTweakerV2.Handlers
{
    using System;
    using AstroMonos.Components.Custom.Random;
    using Selector;
    using Tools.Extensions;
    using UnityEngine;

    internal class RocketBehaviourHandler : Tweaker_Events
    {

        internal override void OnSelectedObject_Destroyed()
        {
            Event_OnRocketBehaviourPropertyChanged.SafetyRaiseWithParams(null); // Dunno if it works.
            instance = null;
        }

        internal static void FocusPageOnRocket(RocketBehaviour newinstance)
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
                            newinstance.SetOnRocketPropertyChanged(() =>
                            {
                                Event_OnRocketBehaviourPropertyChanged.SafetyRaiseWithParams(newinstance); // Dunno if it works.
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
                    newinstance.SetOnRocketPropertyChanged(() =>
                    {
                        Event_OnRocketBehaviourPropertyChanged.SafetyRaiseWithParams(newinstance); // Dunno if it works.
                    });
                }

            }
        }

        

        internal static event Action<RocketBehaviour> Event_OnRocketBehaviourPropertyChanged;
        internal override void On_New_GameObject_Selected(GameObject obj)
        {
            if (obj != null)
            {
                RocketBehaviour RocketBehaviour = obj.GetComponent<RocketBehaviour>();
                if (RocketBehaviour != null)
                {
                    instance = RocketBehaviour; 
                    RocketBehaviour.SetOnRocketPropertyChanged(() =>
                    {
                        Event_OnRocketBehaviourPropertyChanged.SafetyRaiseWithParams(RocketBehaviour); // Dunno if it works.
                    });
                }
            }
        }

        internal override void On_Old_GameObject_Removed(GameObject obj)
        {
            if (obj != null)
            {
                RocketBehaviour RocketBehaviour = obj.GetComponent<RocketBehaviour>();
                if (RocketBehaviour != null)
                {
                    RocketBehaviour.RemoveActionEvents(); // No more Focused on tweaker, so no need for The property Event changed.
                }
            }
        }

        private static RocketBehaviour instance;
    }
}