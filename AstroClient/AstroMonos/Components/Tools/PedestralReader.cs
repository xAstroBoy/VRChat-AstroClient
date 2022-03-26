using AvatarImageReader;

namespace AstroClient.AstroMonos.Components.Tools
{
    using System;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using UnityEngine;

    [RegisterComponent]
    public class PedestralReader : AstroMonoBehaviour
    {
        public List<AstroMonoBehaviour> AntiGcList;

        public PedestralReader(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<AstroMonoBehaviour>(1);
            AntiGcList.Add(this);
        }
        internal override void OnRoomLeft()
        {
            Destroy(this);
        }

        private Camera PedestralCamera { get; set; } = null;
        internal string Result { get; set; } = null;

        private void Start()
        {
            PedestralCamera = this.gameObject.GetComponent<Camera>();
            ReadCameraTexture();
        }


        internal void ReadCameraTexture()
        {
            if (PedestralCamera != null)
            {
                Result = ReadPedestralTexture.ReadCameraTexture(PedestralCamera);

                ModConsole.DebugLog($"Camera returned : {Result}");
            }
        }
        


    }
}