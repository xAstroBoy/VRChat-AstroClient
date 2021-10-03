﻿namespace AstroClient
{
    using AstroClient.Components;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using System;
    using UnityEngine;
    using static AstroClient.Variables.CustomLists;

    [RegisterComponent]
    public class StretchyCheeseBehaviour : MonoBehaviour
    {
        public StretchyCheeseBehaviour(IntPtr ptr)
            : base(ptr)
        {
        }


        private void Start()
        {
            ExtendCheese = UdonSearch.FindUdonEvent(this.gameObject, "Extend");
            if (ExtendCheese != null)
            {
                var PickupBehaviour = this.gameObject.AddComponent<VRC_AstroPickup>();
                if (PickupBehaviour != null)
                {
                    PickupBehaviour.OnPickupUseUp += () =>
                    {
                        ExtendCheese.ExecuteUdonEvent();
                    };
                }

            }
            else
            {
                ModConsole.DebugError($"{this.gameObject.name} : Failed to Bind StretcyCheese Component because there's no Extend behaviour!");
                Destroy(this);
            }
        }

        private void OnDestroy()
        {
            if (PickupBehaviour != null)
            {
                Destroy(PickupBehaviour);
            }
        }

        private void OnDisable()
        {
            if (PickupBehaviour != null)
            {
                PickupBehaviour.enabled = false;
            }
        }

        private void OnEnable()
        {
            if (PickupBehaviour != null)
            {
                PickupBehaviour.enabled = true;
            }
        }

        private UdonBehaviour_Cached ExtendCheese { get; set; }
        internal VRC_AstroPickup PickupBehaviour { get; private set; } // let's test.
    }
}