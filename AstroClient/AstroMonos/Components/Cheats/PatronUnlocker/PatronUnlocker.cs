namespace AstroClient.AstroMonos.Components.Cheats.PatronUnlocker
{
    using System;
    using AstroClient.Tools.Extensions;
    using AstroUdons;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using Tools;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using VRC;
    using VRC.Udon;
    using xAstroBoy.Utility;
    using static Constants.CustomLists;

    [RegisterComponent]
    public class PatronUnlocker : AstroMonoBehaviour
    {
        private bool _EveryoneHasPatreonPerk;

        private bool _OnlySelfHasPatreonPerk;
        public List<AstroMonoBehaviour> AntiGcList;

        private bool DebugMode = true;

        public PatronUnlocker(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<AstroMonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        internal bool EveryoneHasPatreonPerk
        {
            [HideFromIl2Cpp] get => _EveryoneHasPatreonPerk;
            [HideFromIl2Cpp]
            set
            {
                _EveryoneHasPatreonPerk = value;
                if (value) SendPublicPatreonSkinEvent();
            }
        }

        internal bool OnlySelfHasPatreonPerk
        {
            [HideFromIl2Cpp] get => _OnlySelfHasPatreonPerk;
            [HideFromIl2Cpp]
            set
            {
                _OnlySelfHasPatreonPerk = value;
                if (value) SendOnlySelfPatreonSkinEvent();
            }
        }

        private System.Collections.Generic.List<string> GetPatronSkinEventNames { [HideFromIl2Cpp] get; } = new()
        {
            "PatronSkin"
        };

        private System.Collections.Generic.List<string> GetNonPatronSkinEventNames { [HideFromIl2Cpp] get; } = new()
        {
            "NonPatronSkin"
        };

        internal VRC_AstroPickup CustomPickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal PickupController PickupListener { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal bool IgnoreEventReceiver { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal UdonBehaviour_Cached NonPatronSkinEvent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal UdonBehaviour_Cached PatronSkinEvent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        // Use this for initialization
        internal void Start()
        {
            Debug($"Finding Skin Events for pickup {gameObject.name}");
            PickupListener = gameObject.GetComponent<PickupController>();
            if (PickupListener == null) PickupListener = gameObject.GetComponent<PickupController>();

            if (CustomPickup == null) CustomPickup = gameObject.AddComponent<VRC_AstroPickup>();

            if (CustomPickup != null)
            {
                CustomPickup.OnPickup += OnPickup;
                CustomPickup.OnDrop += onDrop;
            }

            foreach (var item in gameObject.GetComponentsInChildren<UdonBehaviour>(true))
            {
                foreach (var item2 in item._eventTable)
                {
                    if (NonPatronSkinEvent == null)
                        if (GetNonPatronSkinEventNames.Contains(item2.key))
                            NonPatronSkinEvent = new UdonBehaviour_Cached(item, item2.key);

                    if (PatronSkinEvent == null)
                        if (GetPatronSkinEventNames.Contains(item2.key))
                            PatronSkinEvent = new UdonBehaviour_Cached(item, item2.key);

                    if (PatronSkinEvent != null && NonPatronSkinEvent != null) break;
                }

                if (PatronSkinEvent != null && NonPatronSkinEvent != null)
                {
                    Debug("Found all The required Events!");
                    break;
                }
            }
        }

        internal void OnDestroy()
        {
            if (CustomPickup != null) CustomPickup.DestroyMeLocal();
        }

        [HideFromIl2Cpp]
        private void Debug(string msg)
        {
            if (DebugMode) ModConsole.DebugLog($"[Patron Item Debug] : {msg}");
        }

        internal override void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
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
                                        PatronSkinEvent.ExecuteUdonEvent();
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
                                            PatronSkinEvent.ExecuteUdonEvent();
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
                PatronSkinEvent.ExecuteUdonEvent();
                IgnoreEventReceiver = false;
            }
        }

        internal void SendPublicNonPatreonSkinEvent()
        {
            if (PatronSkinEvent != null)
            {
                IgnoreEventReceiver = true;
                NonPatronSkinEvent.ExecuteUdonEvent();
                IgnoreEventReceiver = false;
            }
        }

        internal void SendOnlySelfPatreonSkinEvent()
        {
            if (PickupListener != null)
                if (PickupListener.IsHeld)
                    if (PickupListener.CurrentHolder.isLocal)
                        if (PatronSkinEvent != null)
                        {
                            IgnoreEventReceiver = true;
                            PatronSkinEvent.ExecuteUdonEvent();
                            IgnoreEventReceiver = false;
                        }
        }
    }
}