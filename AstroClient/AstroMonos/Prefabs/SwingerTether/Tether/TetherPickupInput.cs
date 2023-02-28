using System;
using AstroClient.AstroMonos.AstroUdons;
using AstroClient.ClientAttributes;
using AstroClient.UdonUtils.UdonSharp;
using AstroClient.xAstroBoy.Utility;
using UnhollowerBaseLib.Attributes;
using UnityEngine;
using VRC.SDKBase;

namespace AstroClient.AstroMonos.Prefabs.SwingerTether.Tether
{
    /// <summary>
    /// TetherController input script for VRC_Pickup based grapple guns.
    /// </summary>
    [RegisterComponent]
    public class TetherPickupInput : MonoBehaviour
    {

        internal Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object> AntiGarbageCollection = new();
        public TetherPickupInput(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        private bool isScriptActive { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;
        /// <summary>
        /// "Player Attachment"
        /// "If this pickup should return to a point when the player lets go."
        /// </summary>
        internal bool hasReturnPoint { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// "Position to return this pickup when the player lets go. Typically attached to behind the player's head."
        /// </summary>
        internal Transform returnPoint { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// "Scripts"
        /// "The VRC_Pickup to use. Required to be on the same game object."
        /// </summary>
        internal VRC_AstroPickup pickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// "TetherController script."
        /// </summary>
        internal TetherController controller { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// "Inputs"
        /// "Input to read if pickup is in left hand."
        /// </summary>
        internal string leftInput { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = "Oculus_CrossPlatform_PrimaryIndexTrigger";

        /// <summary>
        /// "Input to read if pickup is in right hand."
        /// </summary>
        internal string rightInput { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = "Oculus_CrossPlatform_SecondaryIndexTrigger"; 
        private bool currentlyHeld { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;

        internal void RegisterPickupEvents()
        {
            if(pickup != null)
            {
                pickup.OnPickup += OnPickup;
                pickup.OnDrop += OnDrop;
            }
        }

        internal void Update()
        {
            // read analog values of triggers instead of using OnPickupUseDown
            if (currentlyHeld)
            {
                float input = 0.0f;

                switch (pickup.PickupController.CurrentHand)
                {
                    case VRC_Pickup.PickupHand.Left:
                        input = Input.GetAxis(leftInput);
                        break;
                    case VRC_Pickup.PickupHand.Right:
                        input = Input.GetAxis(rightInput);
                        break;
                }

                controller.SetInput(input);
            }
            else
            {
                controller.SetInput(0.0f);
            }
        }

        internal void LateUpdate()
        {
            if (!currentlyHeld && hasReturnPoint)
            {
                transform.SetPositionAndRotation(returnPoint.position, returnPoint.rotation);
            }
        }

        private void OnDisable()
        {
            currentlyHeld = false;
            isScriptActive = false;
            controller.SetInput(0.0f);
        }

        private  void OnEnable()
        {
            isScriptActive = true;
        }
        internal void OnPickup()
        {
            if (isScriptActive)
            {
                currentlyHeld = true;
            }
        }

        internal void OnDrop()
        {
            if(isScriptActive)
            {
                currentlyHeld = false;
            }
        }
    }
}
