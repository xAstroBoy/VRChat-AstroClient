using System;
using AstroClient.ClientAttributes;
using AstroClient.UdonUtils.UdonSharp;
using UnhollowerBaseLib.Attributes;
using UnityEngine;

namespace AstroClient.AstroMonos.Prefabs.SwingerTether.Tether
{
    /// <summary>
    /// Basic TetherController input example that reads an input directly. Combine with TrackedObject.
    /// </summary>
    [RegisterComponent]
    public class TetherButtonInput : MonoBehaviour
    {
        internal Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object> AntiGarbageCollection = new();
        public TetherButtonInput(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        /// <summary>
        /// "TetherController script."
        /// </summary>
        internal TetherController controller { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// "Input to read and send to tether controller."
        /// </summary>
        internal string tetherInput { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal void Update()
        {
            float input = Input.GetButton(tetherInput) == true ? 1.0f : 0.0f;
            controller.SetInput(input);
        }

        private void OnDisable()
        {
            controller.SetInput(0.0f);
        }
    }
}