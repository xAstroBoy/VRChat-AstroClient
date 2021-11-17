﻿namespace AstroClient.AstroMonos.Components.Cheats.PatronUnlocker
{
    using System;
    using System.Collections.Generic;
    using AstroClient.Tools.Extensions;
    using AstroUdons;
    using ClientAttributes;
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
        public Il2CppSystem.Collections.Generic.List<AstroMonoBehaviour> AntiGcList;

        public PatronUnlocker(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<AstroMonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        private bool DebugMode = true;

        [HideFromIl2Cpp]
        private void Debug(string msg)
        {
            if (DebugMode)
            {
                ModConsole.DebugLog($"[Patron Item Debug] : {msg}");
            }
        }

        // Use this for initialization
        internal void Start()
        {
            Debug($"Finding Skin Events for pickup {gameObject.name}");
            PickupListener = gameObject.GetComponent<PickupController>();
            if (PickupListener == null)
            {
                PickupListener = gameObject.GetComponent<PickupController>();
            }

            if (CustomPickup == null)
            {
                CustomPickup = gameObject.AddComponent<VRC_AstroPickup>();
            }

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
                    {
                        if (GetNonPatronSkinEventNames.Contains(item2.key))
                        {
                            NonPatronSkinEvent = new UdonBehaviour_Cached(item, item2.key);
                        }
                    }

                    if (PatronSkinEvent == null)
                    {
                        if (GetPatronSkinEventNames.Contains(item2.key))
                        {
                            PatronSkinEvent = new UdonBehaviour_Cached(item, item2.key);
                        }
                    }

                    if (PatronSkinEvent != null && NonPatronSkinEvent != null)
                    {
                        break;
                    }
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
            if (CustomPickup != null)
            {
                CustomPickup.DestroyMeLocal();
            }
        }

        internal override void OnUdonSyncRPCEvent(Player sender, GameObject obj, string action)
        {
            try
            {
                if (!IgnoreEventReceiver)
                {
                    if (obj == gameObject)
                    {
                        if (EveryoneHasPatreonPerk)
                        {
                            if (action == NonPatronSkinEvent.EventKey)
                            {
                                // Fight back by disabling receiver and sending a delayed event after.
                                MiscUtils.DelayFunction(0.2f, new Action(() =>
                                {
                                    if (PatronSkinEvent != null)
                                    {
                                        IgnoreEventReceiver = true;
                                        PatronSkinEvent.ExecuteUdonEvent();
                                        IgnoreEventReceiver = false;
                                    }
                                }));
                            }
                        }
                        if (OnlySelfHasPatreonPerk)
                        {
                            if (sender == GameInstances.LocalPlayer.GetPlayer())
                            {
                                if (action == NonPatronSkinEvent.EventKey)
                                {
                                    // Fight back by disabling receiver and sending a delayed event after.
                                    MiscUtils.DelayFunction(0.2f, new Action(() =>
                                    {
                                        if (PatronSkinEvent != null)
                                        {
                                            IgnoreEventReceiver = true;
                                            PatronSkinEvent.ExecuteUdonEvent();
                                            IgnoreEventReceiver = false;
                                        }
                                    }));
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void OnPickup()
        {
            if (OnlySelfHasPatreonPerk)
            {
                SendPublicPatreonSkinEvent();
            }
        }

        private void onDrop()
        {
            if (OnlySelfHasPatreonPerk)
            {
                SendPublicNonPatreonSkinEvent();
            }
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
            {
                if (PickupListener.IsHeld)
                {
                    if (PickupListener.CurrentHolder.isLocal)
                    {
                        if (PatronSkinEvent != null)
                        {
                            IgnoreEventReceiver = true;
                            PatronSkinEvent.ExecuteUdonEvent();
                            IgnoreEventReceiver = false;
                        }
                    }
                }
            }
        }

        private bool _EveryoneHasPatreonPerk;

        internal bool EveryoneHasPatreonPerk
        {
            [HideFromIl2Cpp]
            get
            {
                return _EveryoneHasPatreonPerk;
            }
            [HideFromIl2Cpp]
            set
            {
                _EveryoneHasPatreonPerk = value;
                if (value)
                {
                    SendPublicPatreonSkinEvent();
                }
            }
        }

        private bool _OnlySelfHasPatreonPerk;

        internal bool OnlySelfHasPatreonPerk
        {
            [HideFromIl2Cpp]
            get
            {
                return _OnlySelfHasPatreonPerk;
            }
            [HideFromIl2Cpp]
            set
            {
                _OnlySelfHasPatreonPerk = value;
                if (value)
                {
                    SendOnlySelfPatreonSkinEvent();
                }
            }
        }

        private List<string> GetPatronSkinEventNames { [HideFromIl2Cpp] get; } = new List<string>
        {
            "PatronSkin",
        };

        private List<string> GetNonPatronSkinEventNames { [HideFromIl2Cpp] get; } = new List<string>
        {
            "NonPatronSkin",
        };

        internal VRC_AstroPickup CustomPickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal PickupController PickupListener { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal bool IgnoreEventReceiver { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal UdonBehaviour_Cached NonPatronSkinEvent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal UdonBehaviour_Cached PatronSkinEvent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
    }
}