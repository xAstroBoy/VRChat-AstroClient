namespace AstroClient.AstroMonos.Components.Custom.Items
{
    using System;
    using AstroUdons;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;

    [RegisterComponent]
    public class FlashlightBehaviour : AstroMonoBehaviour
    {
        private bool _IsFlashlightActive;
        public List<AstroMonoBehaviour> AntiGcList;

        public FlashlightBehaviour(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<AstroMonoBehaviour>(1);
            AntiGcList.Add(this);
        }
        internal override void OnRoomLeft()
        {
            Destroy(this);
        }

        internal bool IsFlashlightActive
        {
            [HideFromIl2Cpp]
            get => _IsFlashlightActive;
            [HideFromIl2Cpp]
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

        internal string OnText { [HideFromIl2Cpp] get; } = "Turn On Flashlight";
        internal string OffText { [HideFromIl2Cpp] get; } = "Turn Off Flashlight";
        internal GameObject FlashLight_Base { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal Light FlashLight_Light { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal VRC_AstroPickup ToggleLightTrigger { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; } // let's test.

        internal void InitiateLight()
        {
            if (FlashLight_Base != null != null && FlashLight_Light != null)
            {
                if (ToggleLightTrigger == null)
                {
                    ToggleLightTrigger = FlashLight_Base.AddComponent<VRC_AstroPickup>();
                    if (ToggleLightTrigger != null)
                    {
                        ToggleLightTrigger.OnPickupUseUp += ToggleFlashLight;
                        ToggleLightTrigger.UseText = OnText;
                        ToggleLightTrigger.InteractionText = "Flashlight <3";
                    }
                }

                FlashLight_Light.enabled = false;
                _IsFlashlightActive = false;
            }
        }

        private void ToggleFlashLight()
        {
            IsFlashlightActive = !IsFlashlightActive;
        }
    }
}