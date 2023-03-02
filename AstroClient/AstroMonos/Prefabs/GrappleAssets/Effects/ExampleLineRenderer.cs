using AstroClient.AstroMonos.Prefabs.SwingerTether.Tether;
using AstroClient.ClientAttributes;
using System;
using UnhollowerBaseLib.Attributes;
using UnityEngine;

namespace AstroClient.AstroMonos.Prefabs.SwingerTether.Effects
{
    /// <summary>
    /// Basic example for rendering a tether using a line renderer.
    /// </summary>
    [RegisterComponent]
    public class ExampleLineRenderer : MonoBehaviour
    {
        internal Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object> AntiGarbageCollection = new();

        public ExampleLineRenderer(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        /// <summary>
        /// "TetherController to get information from."
        /// </summary>
        internal TetherController controller { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        /// <summary>
        /// "A line renderer, required for visualizing a grapple."
        /// </summary>
        internal LineRenderer line { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        private void Start()
        {
            line = this.gameObject.GetComponent<LineRenderer>();
        }

        internal void LateUpdate()
        {
            if (controller.GetTethering())
            {
                line.enabled = true;

                Vector3 worldTetherPoint = controller.GetTetherPoint();
                line.SetPosition(0, controller.GetTetherStartPoint());
                line.SetPosition(1, Vector3.Lerp(controller.GetTetherStartPoint(), worldTetherPoint, 0.5f));
                line.SetPosition(2, worldTetherPoint);
            }
            else
            {
                line.enabled = false;
            }
        }

        private void OnDisable()
        {
            line.enabled = false;
        }
    }
}