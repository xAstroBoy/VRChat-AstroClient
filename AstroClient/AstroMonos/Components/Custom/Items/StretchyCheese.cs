using AstroClient.ClientActions;
using UnityEngine;

namespace AstroClient.AstroMonos.Components.Custom.Items
{
    using System;
    using AstroClient.Tools.UdonSearcher;
    using AstroUdons;
    using ClientAttributes;
    using CustomClasses;
    using Il2CppSystem.Collections.Generic;
    using UnhollowerBaseLib.Attributes;

    [RegisterComponent]
    public class StretchyCheeseBehaviour : MonoBehaviour
    {
        public List<MonoBehaviour> AntiGcList;

        public StretchyCheeseBehaviour(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        private UdonBehaviour_Cached ExtendCheese { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal VRC_AstroPickup PickupBehaviour { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; } // let's test.
        private bool _HasSubscribed = false;
        private bool HasSubscribed
        {
            [HideFromIl2Cpp]
            get => _HasSubscribed;
            [HideFromIl2Cpp]
            set
            {
                if (_HasSubscribed != value)
                {
                    if (value)
                    {

                        ClientEventActions.OnRoomLeft += OnRoomLeft;

                    }
                    else
                    {

                        ClientEventActions.OnRoomLeft -= OnRoomLeft;

                    }
                }
                _HasSubscribed = value;
            }
        }

        private void Start()
        {
            ExtendCheese = UdonSearch.FindUdonEvent(gameObject, "Extend");
            if (ExtendCheese != null)
            {
                HasSubscribed = true;
                var PickupBehaviour = gameObject.AddComponent<VRC_AstroPickup>();
                if (PickupBehaviour != null) PickupBehaviour.OnPickupUseUp += () => { ExtendCheese.InvokeBehaviour(); };
            }
            else
            {
                Log.Debug($"{gameObject.name} : Failed to Bind StretcyCheese Component because there's no Extend behaviour!");
                Destroy(this);
            }
        }
        private void OnRoomLeft()
        {
            Destroy(this);
        }

        private void OnEnable()
        {
            if (PickupBehaviour != null) PickupBehaviour.enabled = true;
        }

        private void OnDisable()
        {
            if (PickupBehaviour != null) PickupBehaviour.enabled = false;
        }

        private void OnDestroy()
        {
            if (PickupBehaviour != null) Destroy(PickupBehaviour);
            HasSubscribed = false;
        }
    }
}