using AstroClient.ClientAttributes;
using System;
using AstroClient.Spawnables;
using UnhollowerBaseLib.Attributes;
using UnityEngine;

namespace AstroClient.AstroMonos.Prefabs.SwingerTether.Tether
{
    /// <summary>
    /// Holds properties for TetherControllers. Can be used to share properties between multiple TetherControllers.
    /// </summary>
    internal static class TetherProperties 
    {

        internal static void UniversalMask()
        {
            LayerMask everythingMask = -1;
            LayerMask subtractedMask = everythingMask;
            string[] layersToSubtract = new string[] {
            "Ignore Raycast",
            "Water",
            "UI",
            "Player",
            "PlayerLocal",
            "UIMenu",
            "PickupNoEnvironment",
            "StereoLeft",
            "StereoRight",
            "Walkthrough",
            "MirrorReflection",
            "Interactive",
        };

            foreach (string layer in layersToSubtract)
            {
                int layerIndex = LayerMask.NameToLayer(layer);
                if (layerIndex != -1)
                {
                    subtractedMask &= ~layerIndex;
                }
                //else
                //{
                //    Debug.LogWarning($"Layer {layer} does not exist.");
                //}
            }
            Log.Debug($"Universal LayerMask is  {subtractedMask.ToString()}");
            tetherDetectionMask = subtractedMask;
        }

        /// <summary>
        /// "Maximum length of a grapple."
        /// </summary>
        internal static float tetherMaximumLength { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 10.0f;
        /// <summary>
        /// "Maximum Range for how far the grapple gun can shoot."
        /// </summary>
        internal static float tetherMaximumRange { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 20.0f;

        /// <summary>
        /// "Force"
        /// "Force to tug the player back to center with. Gives the grapple a bungee-like springiness."
        /// </summary>
        internal static float tetherSpringFactor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 45.0f; // 45.0f

        /// <summary>
        /// "Maximum amount of force the tether will tug the player back to the center with. Use this to prevent the grapple from pulling the player too fast."
        /// </summary>
        internal static float tetherMaximumSpringForce { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 10.0f;

        /// <summary>
        /// "Rate to project the player's velocity inside the grapple's sphere. Increasing this makes swinging smoother, but reduces the bounciness of the line."
        /// </summary>
        internal static float tetherProjectionRate { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 4.0f;

        /// <summary>
        /// "Physics"
        /// "Whether the grapple should manipulate rigidbodies, rather than swing on them."
        /// </summary>
        internal static bool manipulatesRigidbodies { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } 

        /// <summary>
        /// "Mass of the player. The player will swing on rigidbodies heavier than this."
        /// </summary>
        internal static float playerMass { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 70.0f;

        /// <summary>
        /// "Force to tug rigidbodies back to center with. Gives the grapple a bungee-like springiness."
        /// </summary>
        internal static float rigidbodySpringFactor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 45.0f;

        /// <summary>
        /// "Maximum amount of force the tether will tug the rigidbody back to the center with. Use this to prevent the grapple from pulling rigidbodies too fast."
        /// </summary>
        internal static float rigidbodyMaximumSpringForce { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 10.0f;

        /// <summary>
        /// "Amount to project the rigidbody's velocity inside the grapple's sphere. Increasing this makes swinging smoother, but reduces the bounciness of the line."
        /// </summary>
        internal static float rigidbodyProjectionRate { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 0.25f;

        /// <summary>
        /// "Detection"
        /// "Layers you can grapple on."
        /// </summary>
        internal static LayerMask tetherDetectionMask { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = -1;

        /// <summary>
        /// "How wide to cast a detection ray for finding objects to grapple on."
        /// </summary>
        internal static float tetherDetectionSize { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 0.75f;

        /// <summary>
        /// "Number of times to cast a detection ray. Each ray's size is a division of tetherDetectionSize. Makes auto-aim more accurate."
        /// </summary>
        internal static int tetherDetectionIncrements { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 2;

        /// <summary>
        /// "Input"
        /// "Deadzone before inputs are accepted. Controllers will probably already have their own deadzone, so this is 0 by default."
        /// </summary>
        internal static float tetherInputDeadzone { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 0.0f;

        /// <summary>
        /// "Value of input needed to stop unreeling tether."
        /// </summary>
        internal static float tetherHoldDeadzone { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 0.95f;

        /// <summary>
        /// "Whether to allow a tether to unwind if the trigger is pressed only half-way (below tetherHoldDeadzone)"
        /// </summary>
        internal static bool allowUnwinding { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        /// <summary>
        /// "Maximum speed at which the tether unwinds."
        /// </summary>
        internal static float unwindRate { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 2.0f;
    }
}