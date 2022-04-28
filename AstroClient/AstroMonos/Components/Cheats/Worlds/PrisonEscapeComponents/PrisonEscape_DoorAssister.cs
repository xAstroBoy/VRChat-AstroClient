using System;
using AstroClient.AstroMonos.AstroUdons;
using AstroClient.AstroMonos.Components.Tools;
using AstroClient.ClientActions;
using AstroClient.CustomClasses;
using AstroClient.Tools.UdonSearcher;
using AstroClient.WorldModifications.WorldHacks.Ostinyo.Prison_Escape.Enums;
using AstroClient.WorldModifications.WorldsIds;
using VRC.Udon;

namespace AstroClient.AstroMonos.Components.Cheats.Worlds.PrisonEscapeComponents
{
    using AstroClient.Tools.Colors;
    using AstroClient.Tools.Extensions;
    using Boo.Lang.Compiler.Ast;
    using ClientAttributes;
    using ESP.Player;
    using Il2CppSystem.Collections.Generic;
    using Tools.Listeners;
    using UI.SingleTag;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using VRC;
    using VRC.Core;
    using WorldModifications.WorldHacks;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;
    using IntPtr = System.IntPtr;
    using Object = Il2CppSystem.Object;


    [RegisterComponent]
    public class PrisonEscape_DoorAssister : MonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public PrisonEscape_DoorAssister(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }
        private void OnRoomLeft()
        {
            Destroy(this);
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

        private UdonBehaviour_Cached KeypadDoorEvent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private UdonBehaviour_Cached KeypadDoorEvent_1 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private UdonBehaviour_Cached KeypadDoorEvent_2 { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private System.Collections.Generic.List<VRC_AstroInteract> Triggers { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = new System.Collections.Generic.List<VRC_AstroInteract>();

        void Start()
        {
            if (!WorldUtils.WorldID.Equals(WorldIds.PrisonEscape)) Destroy(this);

            // This will work along with the laser component
            KeypadDoorEvent = gameObject.FindUdonEvent("Keypad","_interact", false);
            KeypadDoorEvent_1 = gameObject.FindUdonEvent("Keypad (1)", "_interact", false);
            KeypadDoorEvent_2 = gameObject.FindUdonEvent("Keypad (2)", "_interact", false);

            if (KeypadDoorEvent != null || KeypadDoorEvent_1 != null || KeypadDoorEvent_2 != null)
            {
                var list = gameObject.GetComponentsInChildren<UdonBehaviour>(true);
                for (int i = 0; i < list.Count; i++)
                {
                    UdonBehaviour col = list[i];
                    if (col.name.Contains("Mesh"))
                    {
                        var trigger = col.gameObject.GetOrAddComponent<VRC_AstroInteract>();
                        if (trigger != null)
                        {
                            if (!Triggers.Contains(trigger))
                            {
                                trigger.OnInteract += OnInteract;
                                Triggers.Add(trigger);
                            }
                        }
                    }
                }
                if(Triggers.Count != 0)
                {
                    Log.Debug($"Registered {Triggers.Count} On GameObject {gameObject.name}");
                    HasSubscribed = true;
                }
                else
                {
                    Log.Debug($"Failed to Find Any Triggers On GameObject {gameObject.name}");
                    Destroy(this);
                }

            }
            else
            {
                Destroy(this);
            }
        }


        void OnInteract()
        {

            if (KeypadDoorEvent != null && KeypadDoorEvent.gameObject.active)
            {
                KeypadDoorEvent.InvokeBehaviour();
            }
            else if(KeypadDoorEvent_1 != null && KeypadDoorEvent_1.gameObject.active)
            {
                KeypadDoorEvent_1.InvokeBehaviour();
            }
            else if(KeypadDoorEvent_2 != null && KeypadDoorEvent_2.gameObject.active)
            {
                KeypadDoorEvent_2.InvokeBehaviour(); 
            }
        }

        void OnEnable()
        {
            foreach (var trigger in Triggers)
            {
            trigger.enabled = true;
                
            }
        }

        void OnDisable()
        {
            foreach (var trigger in Triggers)
            {
                trigger.enabled = false;

            }
        }
        
        void OnDestroy()
        {
            Triggers.DestroyMeLocal(true);
            HasSubscribed = false;
        }

    }
}