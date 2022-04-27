using AstroClient.ClientActions;
using UnhollowerBaseLib.Attributes;
using UnityEngine;

namespace AstroClient.AstroMonos.Components.Tools.Listeners
{
    using System;
    using AstroClient.Tools.Extensions;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    [RegisterComponent]
    public class ScrollMenuListener : MonoBehaviour
    {
        public List<MonoBehaviour> AntiGcList;
        internal QMNestedGridMenu NestedGridButton;
        internal QMSingleButton SingleButton;
        internal QMToggleButton ToggleButton;

        public ScrollMenuListener(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        void Start()
        {
            HasSubscribed = false;
        }

        private void OnEnable()
        {
            if (NestedGridButton != null)
                NestedGridButton.SetTextColor(gameObject.Get_GameObject_Active_ToColor());
            else if (SingleButton != null)
                SingleButton.SetTextColor(gameObject.Get_GameObject_Active_ToColor());
            else if (SingleButton == null && NestedGridButton == null && ToggleButton == null) DestroyImmediate(this);
        }

        private void OnDisable()
        {
            if (NestedGridButton != null)
                NestedGridButton.SetTextColor(gameObject.Get_GameObject_Active_ToColor());
            else if (SingleButton != null)
                SingleButton.SetTextColor(gameObject.Get_GameObject_Active_ToColor());
            else if (SingleButton == null && NestedGridButton == null && ToggleButton == null) DestroyImmediate(this);
        }

        private void OnDestroy()
        {
            SingleButton?.DestroyMe();
            NestedGridButton?.DestroyMe();
            ToggleButton?.DestroyMe();
            HasSubscribed = false;
            DestroyImmediate(this);
        }

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

                        ClientEventActions.Event_OnRoomLeft += OnRoomLeft;

                    }
                    else
                    {

                        ClientEventActions.Event_OnRoomLeft -= OnRoomLeft;

                    }
                }
                _HasSubscribed = value;
            }
        }


        private void OnRoomLeft()
        {
            Destroy(this);
        }
    }
}