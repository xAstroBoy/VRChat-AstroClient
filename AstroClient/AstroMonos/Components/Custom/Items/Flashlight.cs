namespace AstroClient.AstroMonos.Components.Custom.Items
{
    using System;
    using AstroUdons;
    using CustomMono;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;

    [RegisterComponent]
    public class FlashlightBehaviour : GameEventsBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public FlashlightBehaviour(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
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
            [HideFromIl2Cpp]
            get
            {
                return _IsFlashlightActive;
            }
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
        internal GameObject FlashLight_Body { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal GameObject FlashLight_Head { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal Light FlashLight_Light { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal VRC_AstroPickup ToggleLightTrigger { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; } // let's test.
    }


}