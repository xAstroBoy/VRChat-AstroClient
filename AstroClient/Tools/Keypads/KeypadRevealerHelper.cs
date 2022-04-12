using AstroClient.AstroMonos.Components.Tools;
using AstroClient.Tools.UdonEditor;
using AstroClient.Tools.UdonSearcher;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;

namespace AstroClient.Tools.Keypads
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal static class KeypadRevealerHelper
    {

        internal static event Action DestroyAllFailedFinds;

        internal static void RevealCodes()
        {
            // This is to just use one find, and not make the getter keep searching every time.
            var finds = AllKeypadsMatches;

            for (int i = 0; i < finds.Count; i++)
            {
                finds[i].gameObject.GetOrAddComponent<KeypadRevealer>();
            }
            DestroyAllFailedFinds.SafetyRaise();
        }
        internal static readonly string[] PasswordsVariables = new []
        {
            "password",
            "solution",
            "code",
            "PassCode",
            "passcodes",
            "correctCodes",
            "answer",
            "PinCode"
        };


        // Universal Keypad Search System
        internal static List<GameObject> AllKeypadsMatches
        {
            get
            {

                #region Search for Heap Variables instead, is more Accurate
                var results = UdonSearch.FindAllUdonsContainingSymbols(PasswordsVariables);

                if (results.Count != 0)
                {
                    Log.Debug($"Keypad Search returned {results.Count} GameObjects!");
                    return results;
                }




                #endregion

                return null;

            }
        }
    }
}

