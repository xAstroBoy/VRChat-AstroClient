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

                ToggleLightTrigger.interactText = OnText;
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
                if (FlashLight_Light != null && ToggleLightTrigger != null)
                {
                    FlashLight_Light.enabled = value;
                    if (FlashLight_Light.enabled)
                    {
                        ToggleLightTrigger.interactText = OffText;
                    }
                    else
                    {
                        ToggleLightTrigger.interactText = OnText;
                    }
                }
            }
        }
            
        





        internal string OnText { get; } = "Turn On Flashlight";
        internal string OffText { get; } = "Turn Off Flashlight";


        internal GameObject FlashLight_Base { get; set; }

        internal GameObject FlashLight_Body { get; set; }

        internal GameObject FlashLight_Head { get; set; }

        internal Light FlashLight_Light { get; set; }


        internal VRC_AstroUdonTrigger ToggleLightTrigger { get; private set; }
    }
}
