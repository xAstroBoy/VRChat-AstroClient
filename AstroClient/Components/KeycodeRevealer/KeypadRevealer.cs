namespace AstroClient.Components
{
    using AstroClient.GameObjectDebug;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using System;
    using System.Collections.Generic;
    using AstroLibrary.Console;
    using UnityEngine;
    using VRC;
    using Time = UnityEngine.Time;

    [RegisterComponent]
    public class KeypadRevealer : GameEventsBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public KeypadRevealer(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

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



        private bool FindAndRevealPassword()
        {
            foreach (var item in PasswordsVariables)
            {
                var UdonObj = this.gameObject.FindUdonVariable(item);
                if (UdonObj != null)
                {
                    var heaptostring = UdonObj.UnboxUdonHeap();
                    if (heaptostring.IsNotNullOrEmptyOrWhiteSpace())
                    {
                        var cleaned = heaptostring.RemoveWhitespace();
                        if (HasFailedUnpacking(heaptostring) || isInvalidPasscode(cleaned))
                        {
                            continue;
                        }

                        // At this point it should contain the keycode password.
                        GenerateButtonWithPassword(Environment.NewLine + cleaned + Environment.NewLine);
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
            return value == "_" || value == "-";
        }


        private List<string> PasswordsVariables { get; } = new List<string>
        {
            "password",
            "solution",
            "code",
            "PassCode",
            "correctCodes",
        };

        internal void GenerateButtonWithPassword(string password)
        {
            Vector3? buttonPosition = this.gameObject.transform.position + new Vector3(0, 0.5f, 0);
            Quaternion? buttonRotation = this.gameObject.transform.rotation;
            if (buttonRotation != null && buttonRotation != null)
            {
                var btn = new WorldButton(buttonPosition.Value, buttonRotation.Value, password, null);
                btn.gameObject.Pickup_Set_ForceComponent();
                btn.gameObject.Pickup_Set_Pickupable(true);
                btn.gameObject.AddToWorldUtilsMenu();
            }
        }
    }
}