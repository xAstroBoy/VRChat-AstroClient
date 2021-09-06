namespace AstroClient
{
    using System;
    using AstroClient.Components;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using MelonLoader;
    using UnityEngine;

    internal class FlashlightBehaviour : MonoBehaviour
    {

        public FlashlightBehaviour(IntPtr ptr)
            : base(ptr)
        {
        }




        internal void InitiateLight()
        {
            if (FlashLight_Base != null && FlashLight_Body != null && FlashLight_Head != null && FlashLight_Light != null)
            {

                if (ToggleLightTrigger == null)
                {
                    ToggleLightTrigger = FlashLight_Body.AddComponent<VRC_AstroUdonTrigger>();
                    if (ToggleLightTrigger != null)
                    {
                        ToggleLightTrigger.OnInteract = action;
                    }
                }

                ToggleLightTrigger.InteractText = "Turn On Flashlight";
                FlashLight_Light.enabled = false;
                _IsFlashlightActive = false;
            }
        }
        void action() { IsFlashlightActive = !IsFlashlightActive; }



        private bool _IsFlashlightActive;
        internal bool IsFlashlightActive
        {

            get
            {
                return _IsFlashlightActive;
            }
            set
            {
                _IsFlashlightActive = value;
                if(value)
                {
                    if(ToggleLightTrigger != null)
                    {
                        ToggleLightTrigger.InteractText = OnText;
                    }

                }
                else
                {
                    if (ToggleLightTrigger != null)
                    {
                        ToggleLightTrigger.InteractText = OffText;
                    }
                }
                if (FlashLight_Light != null)
                {
                    FlashLight_Light.enabled = value;
                }
            }
        }





        private readonly string OnText = "Turn On Flashlight";
        private readonly string OffText = "Turn On Flashlight";


        internal GameObject FlashLight_Base { get; set; }

        internal GameObject FlashLight_Body { get; set; }

        internal GameObject FlashLight_Head { get; set; }

        internal Light FlashLight_Light { get; set; }


        internal VRC_AstroUdonTrigger ToggleLightTrigger { get; private set; }
    }
}
