using System;
using AstroClient.AstroMonos.Prefabs.SwingerTether.Tether;
using AstroClient.ClientAttributes;
using AstroClient.UdonUtils.UdonSharp;
using UnhollowerBaseLib.Attributes;
using UnityEngine;

namespace AstroClient.AstroMonos.Prefabs.SwingerTether.Effects
{
    /// <summary>
    /// Script for the visual representation and sound effects of the example grapple device.
    /// </summary>
    [RegisterComponent]
    public class ExampleAnimator : MonoBehaviour
    {
        internal Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object> AntiGarbageCollection = new();
        public ExampleAnimator(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        /// <summary>
        /// "TetherController to get information from."
        /// </summary>
        internal TetherController controller { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// "Animator"
        /// "Animator to send parameter values to."
        /// </summary>
        internal Animator animator { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// "Name of animator float for displaying value of player input."
        /// </summary>
        internal string inputParam { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = "Input";

        /// <summary>
        /// "Name of animator boolean to determine if the player is giving input or not."
        /// </summary>
        internal string inputOnParam { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = "InputOn";

        /// <summary>
        /// "Name of animator float for displaying length of tether line."
        /// </summary>
        internal string lengthParam { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = "Length";

        /// <summary>
        /// "Name of animator boolean to determine if the line is out or not."
        /// </summary>
        internal string lengthOnParam { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = "LengthOn";

        /// <summary>
        /// "Name of animator boolean for displaying if the player is unreeling or not."
        /// </summary>
        internal string heldParam { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = "Clamp";

        /// <summary>
        /// "End Point Effects"
        /// "End point game object."
        /// </summary>
        internal GameObject endPoint { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// "Particle system to play when first tethering."
        /// </summary>
        internal ParticleSystem particles { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// "Number of particles to emit on tether."
        /// </summary>
        internal int particleEmission { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 5;

        /// <summary>
        /// "Sound Effects"
        /// "Audio to play on hit."
        /// </summary>
        internal AudioSource hitSound { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// "Audio to play on held."
        /// </summary>
        internal AudioSource heldSound { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// "Audio to play while unwinding."
        /// </summary>
        internal AudioSource unwindSound { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// "Pitch for slowest unwind speed"
        /// </summary>
        internal float unwindPitchLow { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 0.5f;

        /// <summary>
        /// "Pitch for fastest unwind speed"
        /// </summary>
        internal float unwindPitchHigh { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 1.0f;
        private bool tetheringDown { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;
        private bool heldDown { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;

        internal void Update()
        {
            animator.SetFloat(inputParam, controller.GetInput());
            animator.SetBool(inputOnParam, controller.GetInput() > 0.0f);

            animator.SetFloat(lengthParam, controller.GetTetherLength());
            animator.SetBool(lengthOnParam, controller.GetTetherLength() > 0.0f);

            if (controller.GetTethering())
            {
                endPoint.transform.SetPositionAndRotation(controller.GetTetherPoint(), Quaternion.LookRotation(controller.GetTetherNormal()));

                if (!tetheringDown)
                {
                    particles.Emit(particleEmission);
                    hitSound.PlayOneShot(hitSound.clip);
                    tetheringDown = true;
                }

                if (!controller.IsInputHeld())
                {
                    if (!unwindSound.isPlaying)
                    {
                        unwindSound.Play();
                        unwindSound.pitch = Mathf.Lerp(unwindPitchLow, unwindPitchHigh, controller.GetTetherUnwindRate());
                    }
                }
                else
                {
                    unwindSound.Stop();
                }
            }
            else
            {
                tetheringDown = false;
                unwindSound.Stop();
            }

            animator.SetBool(heldParam, controller.IsInputHeld());

            if (controller.IsInputHeld())
            {
                if (!heldDown)
                {
                    heldSound.PlayOneShot(heldSound.clip);
                    heldDown = true;
                }
            }
            else
            {
                heldDown = false;
            }
        }
    }
}
