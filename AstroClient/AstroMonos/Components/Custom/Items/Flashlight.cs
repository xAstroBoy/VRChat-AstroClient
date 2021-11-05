namespace AstroClient.AstroMonos.Components.Custom.Items
{
    using System;
    using AstroUdons.Templates;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;

    [RegisterComponent]
    public class FlashlightBehaviour : AstroPickup
    {
        public FlashlightBehaviour(IntPtr ptr)
            : base(ptr)
        {
        }

        internal void InitiateLight()
        {
            if (FlashLight_Base != null && FlashLight_Body != null && FlashLight_Head != null && FlashLight_Light != null)
            {
                InteractionText = "Flashlight <3";
                UseText = OnText;
                FlashLight_Light.enabled = false;
                _IsFlashlightActive = false;
            }
        }


        internal override void OnPickupUseUp()
        {
            IsFlashlightActive = !IsFlashlightActive;;
        }

        private bool _IsFlashlightActive;

        internal bool IsFlashlightActive
        {
            [HideFromIl2Cpp]
            get
            {
                return _IsFlashlightActive;
            }
            [HideFromIl2Cpp]
            set
            {
                _IsFlashlightActive = value;
                if (FlashLight_Light != null)
                {
                    FlashLight_Light.enabled = value;
                    if (FlashLight_Light.enabled)
                    {
                        UseText = OffText;
                    }
                    else
                    {
                        UseText = OnText;
                    }
                }
            }
        }

        internal string OnText { [HideFromIl2Cpp] get; } = "Turn On Flashlight";
        internal string OffText { [HideFromIl2Cpp] get; } = "Turn Off Flashlight";

        internal GameObject FlashLight_Base { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal GameObject FlashLight_Body { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal GameObject FlashLight_Head { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal Light FlashLight_Light { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

    }
}