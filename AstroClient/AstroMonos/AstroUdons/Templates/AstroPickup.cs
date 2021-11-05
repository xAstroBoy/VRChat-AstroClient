using UnhollowerBaseLib.Attributes;

namespace AstroClient.Components
{
    using AstroLibrary.Console;
    using AstroLibrary.Utility;
    using System;
    using UnityEngine;
    using VRC.SDK3.Components;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;
    using VRC.Udon.ProgramSources;

    [RegisterComponent]
    public class AstroPickup : GameEventsBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public AstroPickup(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);

            CustomPickup = this.gameObject.AddComponent<VRC_AstroPickup>();
            if (CustomPickup != null)
            {
                if (!CustomPickup.HasPickupComponent)
                {
                    CustomPickup.ForcePickupComponent = true;
                }

                if (!CustomPickup.PickupController.EditMode)
                {
                    CustomPickup.PickupController.EditMode = true;
                }
                if (!CustomPickup.PickupController.RigidBodyController.EditMode)
                {
                    CustomPickup.PickupController.RigidBodyController.EditMode = true;
                }

                CustomPickup.OnDrop += OnDrop;
                CustomPickup.OnPickup += OnPickup;
                CustomPickup.OnPickupUseUp += OnPickupUseUp;
                CustomPickup.OnPickupUseDown += OnPickupUseDown;

            }
        }


        internal string UseText
        {
           [HideFromIl2Cpp] 
           get => CustomPickup.UseText;
           [HideFromIl2Cpp]
           set => CustomPickup.UseText = value;
        }
        internal string InteractionText
        {
            [HideFromIl2Cpp]
            get => CustomPickup.InteractionText;
            [HideFromIl2Cpp]
            set => CustomPickup.InteractionText = value;
        }


        internal virtual void OnDrop() {}
        internal virtual void OnPickup() {}
        internal virtual void OnPickupUseUp() { }
        internal virtual void OnPickupUseDown() { }

        private VRC_AstroPickup CustomPickup { [HideFromIl2Cpp] get; }

        internal PickupController PickupProperties
        {
            [HideFromIl2Cpp]
            get
            {
                return CustomPickup.PickupController;
            }
        }
        internal RigidBodyController RigidBodyProperties
        {
            [HideFromIl2Cpp]
            get
            {
                return PickupProperties.RigidBodyController;
            }
        }

    }
}