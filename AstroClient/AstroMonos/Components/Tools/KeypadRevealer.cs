using AstroClient.ClientActions;
using AstroClient.Tools.Keypads;
using UnityEngine.UIElements;

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
    public class KeypadRevealer : MonoBehaviour
    {
        public List<MonoBehaviour> AntiGcList;

        public KeypadRevealer(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<MonoBehaviour>(1);
            AntiGcList.Add(this);
            ClientEventActions.Keypad_DestroyFailedFinds += OnDestroyFailedSearch;

        }




        private WorldButton GeneratedButton { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool Success  { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;
        // Use this for initialization
        private void Start()
        {
            HasSubscribed = true;
            if (FindAndRevealPassword())
            {
                Success = true;
                Log.Debug("Found KeyCode password!");
            }
        }

        private bool _HasSubscribed = false;
        private bool HasSubscribed
        {
            [HideFromIl2Cpp]
            get => _HasSubscribed;
            [HideFromIl2Cpp]
            set
            {
                if (_HasSubscribed != value)
                {
                    if (value)
                    {

                        ClientEventActions.OnRoomLeft += OnRoomLeft;

                    }
                    else
                    {

                        ClientEventActions.OnRoomLeft -= OnRoomLeft;

                    }
                }
                _HasSubscribed = value;
            }
        }


        private void OnRoomLeft()
        {
            Destroy(this);
        }
        internal void OnDestroy()
        {
            if (GeneratedButton != null)
            {
                GeneratedButton.DestroyMe();
            }
            HasSubscribed = false;
            ClientEventActions.Keypad_DestroyFailedFinds -= OnDestroyFailedSearch;
        }


        private void OnDestroyFailedSearch()
        {
            ClientEventActions.Keypad_DestroyFailedFinds -= OnDestroyFailedSearch;
            if (!Success)
            {
                Destroy(this);
            }
        }

        private bool FindAndRevealPassword()
        {
            var keys = KeypadRevealerHelper.PasswordsVariables;
            for (int i = 0; i < keys.Length; i++)
            {
                string item = keys[i];
                var UdonObj = gameObject.FindUdonVariable(item);
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
                   value.StartsWith("Unitialized") ||
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
                    btn.RotateButton(357);
                    btn.MakePickupable();
                    btn.RegisterToWorldMenu();
                }
                return btn;
            }

            return null;
        }
    }
}