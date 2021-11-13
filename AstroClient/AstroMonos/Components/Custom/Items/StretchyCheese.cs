﻿namespace AstroClient.AstroMonos.Components.Custom.Items
{
    using System;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroUdons;
    using CustomMono;
    using Il2CppSystem.Collections.Generic;
    using UnhollowerBaseLib.Attributes;
    using static Variables.CustomLists;

    [RegisterComponent]
    public class StretchyCheeseBehaviour : GameEventsBehaviour
    {
        public List<GameEventsBehaviour> AntiGcList;

        public StretchyCheeseBehaviour(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        private void Start()
        {
            ExtendCheese = UdonSearch.FindUdonEvent(gameObject, "Extend");
            if (ExtendCheese != null)
            {
                var PickupBehaviour = gameObject.AddComponent<VRC_AstroPickup>();
                if (PickupBehaviour != null)
                {
                    PickupBehaviour.OnPickupUseUp += () => { ExtendCheese.ExecuteUdonEvent(); };
                }
            }
            else
            {
                ModConsole.DebugError($"{gameObject.name} : Failed to Bind StretcyCheese Component because there's no Extend behaviour!");
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

        private UdonBehaviour_Cached ExtendCheese { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal VRC_AstroPickup PickupBehaviour { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; } // let's test.
    }
}