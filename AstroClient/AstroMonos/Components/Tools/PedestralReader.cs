using AstroClient.ClientActions;
using UnhollowerBaseLib.Attributes;

namespace AstroClient.AstroMonos.Components.Tools
{
    using System;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using UnityEngine;

    [RegisterComponent]
    public class PedestralReader : MonoBehaviour
    {
        public List<MonoBehaviour> AntiGcList;

        public PedestralReader(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<MonoBehaviour>(1);
            AntiGcList.Add(this);
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
        private Camera PedestralCamera { get; set; } = null;
        internal string Result { get; set; } = null;

        private void Start()
        {
            PedestralCamera = this.gameObject.GetComponent<Camera>();
            HasSubscribed = true;
            ReadCameraTexture();
        }

        void OnDestroy()
        {
            HasSubscribed = false;
        }

        internal void ReadCameraTexture()
        {
           // if (PedestralCamera != null)
           // {
           //     Result = ReadPedestralTexture.ReadCameraTexture(PedestralCamera);
           //
           //     Log.Debug($"Camera returned : {Result}");
           // }
        }
        


    }
}