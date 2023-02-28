using AstroClient.ClientAttributes;
using UnhollowerBaseLib.Attributes;
using UnityEngine;

namespace AstroClient.AstroMonos.Prefabs.SwingerTether.Tether
{
    /// <summary>
    /// Basic TetherController input example that reads an input directly. Combine with TrackedObject.
    /// </summary>
    [RegisterComponent]
    public class TetherAxisInput : MonoBehaviour
    {
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
            float input = Input.GetAxis(tetherInput);
            controller.SetInput(input);
        }

        private void OnDisable()
        {
            controller.SetInput(0.0f);
        }
    }
}