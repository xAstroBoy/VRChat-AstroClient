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
    public class GlobalPatronUnlocker : AstroMonoBehaviour
    {
        private bool _EveryoneHasPatreonPerk;

        public List<AstroMonoBehaviour> AntiGcList;


        public GlobalPatronUnlocker(IntPtr obj0) : base(obj0)
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

        internal bool IgnoreEventReceiver { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal UdonBehaviour_Cached NonPatronSkinEvent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal UdonBehaviour_Cached PatronSkinEvent { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        // Use this for initialization
        internal void Start()
        {
            Log.Debug($"Finding Skin Events for pickup {gameObject.name}");

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
                    Log.Debug("Found all The required Events!");
                    break;
                }
            }
            if (PatronSkinEvent == null && NonPatronSkinEvent == null)
            {
                Log.Debug("Failed to Find all the required Events, destroying!");
                Destroy(this);
            }

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
                    }
            }
            catch
            {
            }
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

    }
}