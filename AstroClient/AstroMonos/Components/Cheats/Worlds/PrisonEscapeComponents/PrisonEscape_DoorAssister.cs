using AstroClient.AstroMonos.AstroUdons;
using AstroClient.ClientActions;
using AstroClient.CustomClasses;
using AstroClient.WorldModifications.WorldHacks.Ostinyo.Prison_Escape;
using AstroClient.WorldModifications.WorldsIds;
using VRC.Udon;

namespace AstroClient.AstroMonos.Components.Cheats.Worlds.PrisonEscapeComponents
{
    using AstroClient.Tools.Extensions;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
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
        private UdonBehaviour_Cached OpenDoorSynced { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private UdonBehaviour_Cached OpenDoorInteract { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private System.Collections.Generic.List<VRC_AstroInteract> Triggers { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = new System.Collections.Generic.List<VRC_AstroInteract>();

        private void Start()
        {
            if (!WorldUtils.WorldID.Equals(WorldIds.PrisonEscape)) Destroy(this);

            OpenDoorSynced = gameObject.FindUdonEvent("_OpenDoorSynced");
            OpenDoorInteract = gameObject.FindUdonEvent("Mesh", "_interact");


            KeypadDoorEvent = gameObject.FindUdonEvent("Keypad", "_interact", false);
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
                if (Triggers.Count != 0)
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

        private void OnInteract()
        {
            if (PrisonEscape.DoorsStayOpen)
            {
                if(OpenDoorSynced != null)
                {
                    OpenDoorSynced.InvokeBehaviour();
                    return;
                }
            }
            if (KeypadDoorEvent != null && KeypadDoorEvent.gameObject.active)
            {
                KeypadDoorEvent.InvokeBehaviour();
                if (OpenDoorInteract != null)
                {
                    OpenDoorInteract.InvokeBehaviour();
                }
            }
            else if (KeypadDoorEvent_1 != null && KeypadDoorEvent_1.gameObject.active)
            {
                KeypadDoorEvent_1.InvokeBehaviour();
                if (OpenDoorInteract != null)
                {
                    OpenDoorInteract.InvokeBehaviour();
                }
            }
            else if (KeypadDoorEvent_2 != null && KeypadDoorEvent_2.gameObject.active)
            {
                KeypadDoorEvent_2.InvokeBehaviour();
                if (OpenDoorInteract != null)
                {
                    OpenDoorInteract.InvokeBehaviour();
                }
            }
        }

        private void OnEnable()
        {
            foreach (var trigger in Triggers)
            {
                trigger.enabled = true;
            }
        }

        private void OnDisable()
        {
            foreach (var trigger in Triggers)
            {
                trigger.enabled = false;
            }
        }

        private void OnDestroy()
        {
            Triggers.DestroyMeLocal(true);
            HasSubscribed = false;
        }
    }
}