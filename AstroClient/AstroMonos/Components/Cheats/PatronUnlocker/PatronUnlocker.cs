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


    // TODO : FIGURE WHY THIS IS BROKEN (Once added, you are unable to see who grabbed the pickup)
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
        internal override void OnRoomLeft()
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

        private System.Collections.Generic.List<string> GetPatronSkinEventNames { [HideFromIl2Cpp] get; } = new()
        {
            "PatronSkin",
            "Patron",
            "EnablePatronEffects",
        };

        private System.Collections.Generic.List<string> GetNonPatronSkinEventNames { [HideFromIl2Cpp] get; } = new()
        {
            "NonPatronSkin",
            "NonPatron",
            "DisablePatronEffects",
        };

        internal VRC_AstroPickup CustomPickup { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal bool IgnoreEventReceiver { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal UdonBehaviour_Cached NonPatronSkinEvent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal UdonBehaviour_Cached PatronSkinEvent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

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

            var list = gameObject.GetComponentsInChildren<UdonBehaviour>(true);
            for (int i1 = 0; i1 < list.Count; i1++)
            {
                UdonBehaviour item = list[i1];
                for (int i = 0; i < item._eventTable.entries.Count; i++)
                {
                    Dictionary<string, List<uint>>.Entry item2 = item._eventTable.entries[i];
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
            if (PatronSkinEvent == null && NonPatronSkinEvent == null)
            {
                Log.Debug("Failed to Find all the required Events, destroying!");
                Destroy(this);
            }

        }

        internal void OnDestroy()
        {
            if (CustomPickup != null) CustomPickup.DestroyMeLocal();
        }

        [HideFromIl2Cpp]
        private void Debug(string msg)
        {
            if (DebugMode) Log.Debug($"[Patron Item Debug] : {msg}");
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