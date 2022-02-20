namespace AstroClient.CustomClasses
{
    using System.Collections;
    using UnityEngine;

    /// <summary>
    /// This is Only with UnityExplorer Support!.
    /// </summary>

    internal class KeypadBruteforcer
    {

        private int CurrentCode = 0;

        private int CurrentCombinationMaxLimit { get; set; } = 1000;

        // TODO : Figure a way to process and 
        private IEnumerator TryCombination()
        {
            yield return null;
        }

        /// <summary>
        /// Assigned Button 0.
        /// </summary>

        internal GameObject Keypad_0 { get; set; }

        /// <summary>
        /// Assigned Button 1.
        /// </summary>
        internal GameObject Keypad_1 { get; set; }

        /// <summary>
        /// Assigned Button 2.
        /// </summary>
        internal GameObject Keypad_2 { get; set; }

        /// <summary>
        /// Assigned Button 3.
        /// </summary>
        internal GameObject Keypad_3 { get; set; }

        /// <summary>
        /// Assigned Button 4.
        /// </summary>
        internal GameObject Keypad_4 { get; set; }

        /// <summary>
        /// Assigned Button 5.
        /// </summary>
        internal GameObject Keypad_5 { get; set; }

        /// <summary>
        /// Assigned Button 6.
        /// </summary>
        internal GameObject Keypad_6 { get; set; }

        /// <summary>
        /// Assigned Button 7.
        /// </summary>
        internal GameObject Keypad_7 { get; set; }

        /// <summary>
        /// Assigned Button 8.
        /// </summary>
        internal GameObject Keypad_8 { get; set; }

        /// <summary>
        /// Assigned Button 9.
        /// </summary>
        internal GameObject Keypad_9 { get; set; }

        /// <summary>
        /// Assigned Button Cancel.
        /// </summary>
        internal GameObject Keypad_Cancel { get; set; }

        /// <summary>
        /// Assigned Button Confirm.
        /// </summary>
        internal GameObject Keypad_Confirm { get; set; }

        /// <summary>
        /// Assigned Button Text (If needed!)
        /// </summary>
        internal GameObject Keypad_Text { get; set; }
    }
}