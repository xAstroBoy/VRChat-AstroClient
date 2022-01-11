namespace AstroClient.AstroMonos.Components.Tools.KeycodeRevealer
{
    using System;
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.Extensions.Components_exts;
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
        private System.Collections.Generic.List<string> PasswordsVariables { [HideFromIl2Cpp] get; } = new()
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

        // Use this for initialization
        private void Start()
        {
            if (FindAndRevealPassword())
            {
                ModConsole.DebugLog("Found KeyCode password!");
            }
            else
            {
                ModConsole.DebugLog("Failed to find Keycode password.");
                Destroy(this);
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
        }

        private bool FindAndRevealPassword()
        {
            foreach (var item in PasswordsVariables)
            {
                var UdonObj = gameObject.FindUdonVariable(item);
                if (UdonObj != null)
                {
                    var heaptostring = UdonObj.UnboxUdonHeap();
                    if (heaptostring.IsNotNullOrEmptyOrWhiteSpace())
                    {
                        var cleaned = heaptostring.RemoveWhitespace();
                        if (HasFailedUnpacking(heaptostring) || isInvalidPasscode(cleaned)) continue;

                        // At this point it should contain the keycode password.
                        GeneratedButton = GenerateButtonWithPassword(Environment.NewLine + cleaned + Environment.NewLine);
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
                    btn.MakePickupable();
                    btn.RegisterToWorldMenu();
                }
                return btn;
            }

            return null;
        }
    }
}