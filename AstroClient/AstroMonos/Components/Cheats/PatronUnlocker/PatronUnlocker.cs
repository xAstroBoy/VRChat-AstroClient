using AstroClient.ClientActions;
using AstroClient.Tools.UdonEditor;

namespace AstroClient.AstroMonos.Components.Cheats.PatronUnlocker
{
    using System;
    using AstroClient.Tools.Extensions;
    using AstroUdons;
    using ClientAttributes;
    using CustomClasses;
    using Il2CppSystem.Collections.Generic;
    using Tools;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using VRC;
    using VRC.Udon;
    using xAstroBoy.Utility;
    using static Constants.CustomLists;


    [RegisterComponent]
    public class PatronUnlocker : MonoBehaviour
    {
        private bool _EveryoneHasPatreonPerk;

        private bool _OnlySelfHasPatreonPerk;
        public List<MonoBehaviour> AntiGcList;

        private bool DebugMode = true;

        public PatronUnlocker(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<MonoBehaviour>(1);
            AntiGcList.Add(this);
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

                        ClientEventActions.Event_OnRoomLeft += OnRoomLeft;
                        ClientEventActions.Event_OnUdonSyncRPC += OnUdonSyncRPCEvent;

                    }
                    else
                    {

                        ClientEventActions.Event_OnRoomLeft -= OnRoomLeft;
                        ClientEventActions.Event_OnUdonSyncRPC -= OnUdonSyncRPCEvent;
                    }
                }
                _HasSubscribed = value;
            }
        }


        private void OnRoomLeft()
        {
            Destroy(this);
        }

        internal bool EveryoneHasPatreonPerk
        {
            [HideFromIl2Cpp]
            get => _EveryoneHasPatreonPerk;
            [HideFromIl2Cpp]
            set
            {
                _EveryoneHasPatreonPerk = value;
                if (value) SendPublicPatreonSkinEvent();
            }
        }

        internal bool OnlySelfHasPatreonPerk
        {
            [HideFromIl2Cpp]
            get => _OnlySelfHasPatreonPerk;
            [HideFromIl2Cpp]
            set
            {
                _OnlySelfHasPatreonPerk = value;
                if (value) SendOnlySelfPatreonSkinEvent();
            }
        }


        internal VRC_AstroPickup CustomPickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal bool IgnoreEventReceiver { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal UdonBehaviour_Cached NonPatronSkinEvent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal UdonBehaviour_Cached PatronSkinEvent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal PickupController PickupController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        // Use this for initialization
        internal void Start()
        {
            Debug($"Finding Skin Events for pickup {gameObject.name}");
            if (CustomPickup == null) CustomPickup = gameObject.AddComponent<VRC_AstroPickup>();
            if (CustomPickup != null)
            {
                CustomPickup.OnPickup += OnPickup;
                CustomPickup.OnDrop += onDrop;
            }
            PickupController = gameObject.GetOrAddComponent<PickupController>();
            if (PickupController != null)
            {
                PickupController.OnPickupHeld += OnPickupControllerHeld;
                PickupController.OnPickupDrop += OnPickupControllerDrop;
            }

            var list = gameObject.GetComponentsInChildren<UdonBehaviour>(true);
            for (int i1 = 0; i1 < list.Count; i1++)
            {
                UdonBehaviour item = list[i1];
                var eventKeys = item.Get_EventKeys();
                if (eventKeys == null) continue;
                for (int i = 0; i < eventKeys.Length; i++)
                {
                    var subaction = eventKeys[i];
                    if (NonPatronSkinEvent == null)
                        if (PatronEventsLists.GetNonPatronSkinEventNames.Contains(subaction))
                            NonPatronSkinEvent = new UdonBehaviour_Cached(item, subaction);

                    if (PatronSkinEvent == null)
                        if (PatronEventsLists.GetPatronSkinEventNames.Contains(subaction))
                            PatronSkinEvent = new UdonBehaviour_Cached(item, subaction);

                    if (PatronSkinEvent != null && NonPatronSkinEvent != null) break;
                }

                if (PatronSkinEvent != null && NonPatronSkinEvent != null)
                {
                    Debug("Found all The required Events!");
                    HasSubscribed = true;
                    break;
                }
            }
            if (PatronSkinEvent == null && NonPatronSkinEvent == null)
            {
                Log.Debug("Failed to Find all the required Events, destroying!");
                Destroy(this);
            }

        }

        internal void OnDestroy()
        {
            if (CustomPickup != null) CustomPickup.DestroyMeLocal();
            if(PickupController != null)
            {
                PickupController.OnPickupHeld -= OnPickupControllerHeld;
                PickupController.OnPickupDrop -= OnPickupControllerDrop;
            }
            HasSubscribed = false;
        }

        private void OnPickupControllerHeld()
        {
            if (EveryoneHasPatreonPerk)
            {
                SendPublicPatreonSkinEvent();
            }

        }
        private void OnPickupControllerDrop()
        {
            if(EveryoneHasPatreonPerk)
            {
                SendPublicNonPatreonSkinEvent();
            }
        }



        [HideFromIl2Cpp]
        private void Debug(string msg)
        {
            if (DebugMode) Log.Debug($"[Patron Item Debug] : {msg}");
        }

        private void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
        {
            try
            {
                if (!IgnoreEventReceiver)
                    if (obj == gameObject)
                    {
                        if (EveryoneHasPatreonPerk)
                            if (action == NonPatronSkinEvent.EventKey)
                                // Fight back by disabling receiver and sending a delayed event after.
                                MiscUtils.DelayFunction(0.2f, () =>
                                {
                                    if (PatronSkinEvent != null)
                                    {
                                        IgnoreEventReceiver = true;
                                        PatronSkinEvent.InvokeBehaviour();
                                        IgnoreEventReceiver = false;
                                    }
                                });
                        if (OnlySelfHasPatreonPerk)
                            if (sender == GameInstances.LocalPlayer.GetPlayer())
                                if (action == NonPatronSkinEvent.EventKey)
                                    // Fight back by disabling receiver and sending a delayed event after.
                                    MiscUtils.DelayFunction(0.2f, () =>
                                    {
                                        if (PatronSkinEvent != null)
                                        {
                                            IgnoreEventReceiver = true;
                                            PatronSkinEvent.InvokeBehaviour();
                                            IgnoreEventReceiver = false;
                                        }
                                    });
                    }
            }
            catch
            {
            }
        }

        

        
        private void OnPickup()
        {
            if (OnlySelfHasPatreonPerk) SendPublicPatreonSkinEvent();
        }

        private void onDrop()
        {
            if (OnlySelfHasPatreonPerk) SendPublicNonPatreonSkinEvent();
        }

        internal void SendPublicPatreonSkinEvent()
        {
            if (PatronSkinEvent != null)
            {
                IgnoreEventReceiver = true;
                PatronSkinEvent.InvokeBehaviour();
                IgnoreEventReceiver = false;
            }
        }

        internal void SendPublicNonPatreonSkinEvent()
        {
            if (PatronSkinEvent != null)
            {
                IgnoreEventReceiver = true;
                NonPatronSkinEvent.InvokeBehaviour();
                IgnoreEventReceiver = false;
            }
        }

        internal void SendOnlySelfPatreonSkinEvent()
        {
            if (PatronSkinEvent != null)
            {
                IgnoreEventReceiver = true;
                PatronSkinEvent.InvokeBehaviour();
                IgnoreEventReceiver = false;
            }
        }
    }
}