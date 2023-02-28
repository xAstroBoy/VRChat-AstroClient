using System;
using AstroClient.ClientAttributes;
using UnhollowerBaseLib;
using UnhollowerBaseLib.Attributes;
using UnityEngine;

namespace AstroClient.AstroMonos.Prefabs.SwingerTether.Tether
{
    /// <summary>
    /// Holds properties for TetherControllers. Can be used to share properties between multiple TetherControllers.
    /// </summary>
    [RegisterComponent]
    public class TetherProperties : MonoBehaviour
    {
        internal Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object> AntiGarbageCollection = new();
        public TetherProperties(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        /// <summary>
        /// "Tether"
        /// "Maximum length of a grapple. Also determines how far the grapple gun can shoot."
        /// </summary>
        internal float tetherMaximumLength { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 20.0f;

        /// <summary>
        /// "Force"
        /// "Force to tug the player back to center with. Gives the grapple a bungee-like springiness."
        /// </summary>
        internal float tetherSpringFactor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 45.0f;

        /// <summary>
        /// "Maximum amount of force the tether will tug the player back to the center with. Use this to prevent the grapple from pulling the player too fast."
        /// </summary>
        internal float tetherMaximumSpringForce { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 10.0f;

        /// <summary>
        /// "Rate to project the player's velocity inside the grapple's sphere. Increasing this makes swinging smoother, but reduces the bounciness of the line."
        /// </summary>
        internal float tetherProjectionRate { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 4.0f;

        /// <summary>
        /// "Physics"
        /// "Whether the grapple should manipulate rigidbodies, rather than swing on them."
        /// </summary>
        internal bool manipulatesRigidbodies { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// "Mass of the player. The player will swing on rigidbodies heavier than this."
        /// </summary>
        internal float playerMass { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 70.0f;

        /// <summary>
        /// "Force to tug rigidbodies back to center with. Gives the grapple a bungee-like springiness."
        /// </summary>
        internal float rigidbodySpringFactor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 45.0f;

        /// <summary>
        /// "Maximum amount of force the tether will tug the rigidbody back to the center with. Use this to prevent the grapple from pulling rigidbodies too fast."
        /// </summary>
        internal float rigidbodyMaximumSpringForce { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 10.0f;

        /// <summary>
        /// "Amount to project the rigidbody's velocity inside the grapple's sphere. Increasing this makes swinging smoother, but reduces the bounciness of the line."
        /// </summary>
        internal float rigidbodyProjectionRate { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 0.25f;

        /// <summary>
        /// "Detection"
        /// "Layers you can grapple on."
        /// </summary>
        internal LayerMask tetherDetectionMask { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = LayerMask.GetMask(new Il2CppStringArray(new string[]
        {
            "Default",
            "TransparentFX",
            "Interactive",
            "Player",
            "Environment",
            "Pickup",
            "reserved2",
            "reserved3",
            "reserved4",
        }));

        /// <summary>
        /// "How wide to cast a detection ray for finding objects to grapple on."
        /// </summary>
        internal float tetherDetectionSize { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 0.75f;

        /// <summary>
        /// "Number of times to cast a detection ray. Each ray's size is a division of tetherDetectionSize. Makes auto-aim more accurate."
        /// </summary>
        internal int tetherDetectionIncrements { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 2;

        /// <summary>
        /// "Input"
        /// "Deadzone before inputs are accepted. Controllers will probably already have their own deadzone, so this is 0 by default."
        /// </summary>
        internal float tetherInputDeadzone { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 0.0f;

        /// <summary>
        /// "Value of input needed to stop unreeling tether."
        /// </summary>
        internal float tetherHoldDeadzone { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 0.95f;

        /// <summary>
        /// "Whether to allow a tether to unwind if the trigger is pressed only half-way (below tetherHoldDeadzone)"
        /// </summary>
        internal bool allowUnwinding { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        /// <summary>
        /// "Maximum speed at which the tether unwinds."
        /// </summary>
        internal float unwindRate { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 2.0f;
    }
}
