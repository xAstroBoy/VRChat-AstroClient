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
    public class KeycodeRevealer : GameEventsBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public KeycodeRevealer(IntPtr obj0) : base(obj0)
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
                Destroy(this);
            }
            else
            {
                ModConsole.DebugLog("Failed to find Keycode password.");
                Destroy(this);
            }
        }



        private bool FindAndRevealPassword()
        {
            bool result = false;
            foreach (var item in PasswordsVariables)
            {
                var UdonObj = this.gameObject.FindUdonVariable(item);
                if (UdonObj != null)
                {
                    var heaptostring = UdonObj.UnboxUdonHeap();
                    if (heaptostring.IsNotNullOrEmptyOrWhiteSpace() && !heaptostring.isMatch("Not Supported Yet") || !heaptostring.isMatch("empty"))
                    {
                        
                        // At this point it should contain the keycode password.

                        var parsed = int.TryParse(heaptostring.ReplaceWholeWord(" ", string.Empty), out var keycodepassword);
                        if (parsed)
                        {
                            GenerateButtonWithPassword(keycodepassword);
                            result = true;
                            break;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }

            return result;
        }


        private List<string> PasswordsVariables { get; } = new List<string>
        {
            "password",
            "solution",
        };

        internal void GenerateButtonWithPassword(int password)
        {
            Vector3? buttonPosition = Utils.LocalPlayer.GetPlayer().Get_Center_Of_Player();
            Quaternion? buttonRotation = Utils.LocalPlayer.GetPlayer().gameObject.transform.rotation;
            if (buttonRotation != null && buttonRotation != null)
            {
                var btn = new WorldButton(buttonPosition.Value, buttonRotation.Value, password.ToString(), null);
                btn.gameObject.Pickup_Set_ForceComponent();
                btn.gameObject.Pickup_Set_Pickupable(true);
                btn.gameObject.RigidBody_Set_DetectCollisions(true);
                btn.gameObject.RigidBody_Set_isKinematic(true);
                btn.gameObject.RigidBody_Set_Gravity(false);
                btn.gameObject.AddToWorldUtilsMenu();
            }
        }
    }
}