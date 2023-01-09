using AstroClient.ClientActions;
using UnhollowerBaseLib.Attributes;

namespace AstroClient.AstroMonos.Components.Tools
{
    using System;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using UnityEngine;

    [RegisterComponent]
    public class Enabler : MonoBehaviour
    {
        public List<MonoBehaviour> AntiGcList;

        public Enabler(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        internal Action Extra { get; set; }
        private bool HasStartedEvent = false;
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


        private void OnRoomLeft()
        {
            Destroy(this);
        }
        private void Start()
        {
            ForceStart();
        }
        private void Awake()
        {
            ForceStart();
        }

        internal void ForceStart()
        {
            if (!HasSubscribed)
            {
                HasSubscribed = true;
            }
            gameObject.SetActive(true);
            Extra.SafetyRaise();
            if (!HasStartedEvent)
            {
                InvokeRepeating(nameof(CustomUpdate), 0.1f, 0.3f);
                HasStartedEvent = true;
            }
        }

        private void OnDisable()
        {
            gameObject.SetActive(true);
            Extra.SafetyRaise();
        }

        private void CustomUpdate()
        {
            if (gameObject != null && !gameObject.active)
            {
                gameObject.SetActive(true);
                Extra.SafetyRaise();
            }
        }

        void OnDestroy()
        {
            HasSubscribed = false;
        }
    }
}