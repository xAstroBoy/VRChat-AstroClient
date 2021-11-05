namespace AstroClient
{
    using AstroClient.Components;
    using System;
    using UnityEngine;

    [RegisterComponent]
    public class FlashlightBehaviour : MonoBehaviour
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
                    ToggleLightTrigger = FlashLight_Body.AddComponent<VRC_AstroPickup>();
                    if (ToggleLightTrigger != null)
                    {
                        ToggleLightTrigger.OnPickupUseUp = ToggleFlashLight;
                        ToggleLightTrigger.UseText = OnText;
                        ToggleLightTrigger.InteractionText = "Flashlight <3";
                    }
                }

                FlashLight_Light.enabled = false;
                _IsFlashlightActive = false;
            }
        }

        private void ToggleFlashLight() { IsFlashlightActive = !IsFlashlightActive; }

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
                    if (FlashLight_Light.enabled) ToggleLightTrigger.UseText = OffText;
                    else ToggleLightTrigger.UseText = OnText;
                }
            }
        }

        internal string OnText { get; } = "Turn On Flashlight";
        internal string OffText { get; } = "Turn Off Flashlight";

        internal GameObject FlashLight_Base;
        internal GameObject FlashLight_Body;
        internal GameObject FlashLight_Head;
        internal Light FlashLight_Light;
        internal VRC_AstroPickup ToggleLightTrigger { get; private set; } // let's test.
    }
}