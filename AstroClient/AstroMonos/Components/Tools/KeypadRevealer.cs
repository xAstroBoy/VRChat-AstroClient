using AstroClient.Tools.Keypads;

namespace AstroClient.AstroMonos.Components.Tools
{
    using System;
    using AstroClient.Tools.Extensions;
    using CheetosUI;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using xAstroBoy.Extensions;

    [RegisterComponent]
    public class KeypadRevealer : AstroMonoBehaviour
    {
        public List<AstroMonoBehaviour> AntiGcList;

        public KeypadRevealer(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<AstroMonoBehaviour>(1);
            AntiGcList.Add(this);

        }




        private WorldButton GeneratedButton { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool Success  { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;
        // Use this for initialization
        private void Start()
        {
            KeypadRevealerHelper.DestroyAllFailedFinds += OnDestroyFailedSearch;
            if (FindAndRevealPassword())
            {
                Success = true;
                Log.Debug("Found KeyCode password!");
            }
        }

        internal override void OnRoomLeft()
        {
            Destroy(this);
        }

        internal void OnDestroy()
        {
            if (GeneratedButton != null)
            {
                GeneratedButton.DestroyMe();
            }
            KeypadRevealerHelper.DestroyAllFailedFinds -= OnDestroyFailedSearch;
        }


        private void OnDestroyFailedSearch()
        {
            if(!Success)
            {
                KeypadRevealerHelper.DestroyAllFailedFinds -= OnDestroyFailedSearch;
                DestroyImmediate(this);
            }
        }

        private bool FindAndRevealPassword()
        {
            for (int i = 0; i < KeypadRevealerHelper.PasswordsVariables.Length; i++)
            {
                string item = KeypadRevealerHelper.PasswordsVariables[i];
                var UdonObj = gameObject.FindUdonVariable(item, false);
                if (UdonObj != null)
                {
                    var heaptostring = UdonObj.UnboxAsString(item);
                    if (heaptostring.IsNotNullOrEmptyOrWhiteSpace())
                    {
                        var cleaned = heaptostring.RemoveWhitespace();
                        if (HasFailedUnpacking(heaptostring) || isInvalidPasscode(cleaned)) continue;

                        // At this point it should contain the keycode password.
                        GeneratedButton = GenerateButtonWithPassword(cleaned);
                        return true;
                    }
                }
            }

            return false;
        }

        internal bool HasFailedUnpacking(string value)
        {
            return value.StartsWith("Not Supported Yet") ||
                   value.StartsWith("Error Unboxing") ||
                   value.StartsWith("Not Unboxable") ||
                   value.StartsWith("empty") ||
                   value.StartsWith("Null");
        }

        internal bool isInvalidPasscode(string value)
        {
            return /*value == "_" || value == "-" ||*/ !value.isDigitsOnly();
        }

        [HideFromIl2Cpp]
        private WorldButton GenerateButtonWithPassword(string password)
        {
            Vector3? buttonPosition = gameObject.transform.position + new Vector3(0, 0.5f, 0);
            Quaternion? buttonRotation = gameObject.transform.rotation;
            if (buttonRotation != null && buttonRotation != null)
            {
                var btn = new WorldButton(buttonPosition.Value, buttonRotation.Value, password, null);
                if (btn != null)
                {
                    btn.RotateButton(90f);
                    btn.MakePickupable();
                    btn.RegisterToWorldMenu();
                }
                return btn;
            }

            return null;
        }
    }
}