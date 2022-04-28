using AstroClient.ClientActions;
using UnityEngine;

namespace AstroClient.AstroMonos.Components.Tools.Listeners
{
    using System;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using UnhollowerBaseLib.Attributes;

    [RegisterComponent]
    public class TweakerListener : MonoBehaviour
    {
        public List<MonoBehaviour> AntiGcList;

        public TweakerListener(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        void Start()
        {
            HasSubscribed = true;
        }

        private void OnEnable()
        {
            OnEnabled?.Invoke();
        }

        private void OnDisable()
        {
            OnDisabled?.Invoke();
        }

        private void OnDestroy()
        {
            OnDestroyed?.Invoke();
            HasSubscribed = false;
        }

        [method: HideFromIl2Cpp] internal event Action? OnEnabled;

        [method: HideFromIl2Cpp] internal event Action? OnDisabled;

        [method: HideFromIl2Cpp] internal event Action? OnDestroyed;


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
        internal void RemoveListener()
        {
            OnDestroyed = null;
            OnDisabled = null;
            OnEnabled = null;
            DestroyImmediate(this);
        }
    }
}