using AstroClient.ClientActions;
using UnityEngine;

namespace AstroClient.AstroMonos.Components.Spoofer
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using ClientAttributes;
    using MelonLoader;
    using Photon.Realtime;
    using UnhollowerBaseLib.Attributes;
    using VRC.Core;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;

    [RegisterComponent]
    public class PlayerSpoofer : MonoBehaviour
    {
        public PlayerSpoofer(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        private Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object> AntiGarbageCollection = new Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object>();

        // Use this for initialization
        internal void Start()
        {
            MelonCoroutines.Start(OnUserInit(() =>
            {
                if (Original_DisplayName != null)
                {
                    Log.Debug($"Spoofer : Got Current DisplayName {Original_DisplayName}");
                }
                else
                {
                    Log.Debug($"Spoofer : Failed To  get Current DisplayName!");
                }
            }));
            HasSubscribed = true;
        }

        private IEnumerator OnUserInit(Action code)
        {
            while (user == null)
                yield return null;

            code();
        }

        private string DisplayName
        {
            [HideFromIl2Cpp]
            get
            {
                if (user != null)
                {
                    return user._displayName_k__BackingField;
                }
                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (user != null)
                {
                    user._displayName_k__BackingField = value;
                }
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


                        ClientEventActions.Event_OnRoomLeft += OnRoomLeft;
                        ClientEventActions.Event_OnRoomJoined += OnRoomJoined;
                        ClientEventActions.Event_OnWorldReveal += OnWorldReveal;
                        ClientEventActions.Event_OnEnterWorld += OnEnterWorld;
                        ClientEventActions.Event_OnMasterClientSwitched += OnMasterClientSwitched;

                    }
                    else
                    {

                        ClientEventActions.Event_OnRoomLeft -= OnRoomLeft;
                        ClientEventActions.Event_OnRoomJoined -= OnRoomJoined;
                        ClientEventActions.Event_OnWorldReveal -= OnWorldReveal;
                        ClientEventActions.Event_OnEnterWorld -= OnEnterWorld;
                        ClientEventActions.Event_OnMasterClientSwitched -= OnMasterClientSwitched;

                    }
                }
                _HasSubscribed = value;
            }
        }

        internal void LateUpdate()
        {
            if (IsSpooferActive && isSecondJoin && user != null && DisplayName != SpoofedName)
            {
                DisplayName = SpoofedName;
            }
        }

        private void OnRoomLeft()
        {
            SafetyCheck();
            if (!KeepSpoofingOnWorldChange)
            {
                IsSpooferActive = false;
            }
        }

        private void OnEnterWorld(ApiWorld world, ApiWorldInstance instance)
        {
            if (PlayerSpooferUtils.SpoofAsWorldAuthor && world != null)
            {
                IsSpooferActive = true;
                SpoofedName = world.authorName;

            }
        }

        private void OnRoomJoined()
        {
            //SafetyCheck();
            if (PlayerSpooferUtils.SpoofAsWorldAuthor)
            {
                IsSpooferActive = true;
                SpoofedName = WorldUtils.AuthorName;
            }
            else if (PlayerSpooferUtils.SpoofAsInstanceMaster && WorldUtils.IsInWorld)
            {
                IsSpooferActive = true;
                SpoofedName = WorldUtils.InstanceMaster.GetAPIUser().displayName;
            }
        }

        private void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (PlayerSpooferUtils.SpoofAsInstanceMaster)
            {
                IsSpooferActive = true;
                SpoofedName = WorldUtils.InstanceMaster.GetAPIUser().displayName;
            }
        }

        private void OnMasterClientSwitched(Player player)
        {
            if (!WorldUtils.IsInWorld) return;

            if (PlayerSpooferUtils.SpoofAsInstanceMaster)
            {
                if (!player.GetVRCPlayer().GetAPIUser().IsSelf)
                {
                    SpoofedName = player.GetVRCPlayer().GetAPIUser().displayName;
                }
                else
                {
                    SpoofedName = Original_DisplayName;
                }
            }
        }

        private void SafetyCheck()
        {
            if (isSecondJoin && isFistJoin)
            {
                return;
            }

            if (!isFistJoin)
            {
                isFistJoin = true;
                return;
            }
            else if (isFistJoin && !isSecondJoin)
            {
                isSecondJoin = true;
            }
        }

        internal bool KeepSpoofingOnWorldChange { [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = false;

        internal APIUser user
        {
            [HideFromIl2Cpp]
            get
            {
                return PlayerUtils.GetAPIUser();
            }
        }

        private bool _IsSpooferActive;

        internal bool IsSpooferActive // TODO : Make it more customizable, for now there's nothing else.
        {
            [HideFromIl2Cpp]
            get
            {
                return _IsSpooferActive;
            }
            [HideFromIl2Cpp]
            set
            {
                //if (!isSecondJoin)
                //{
                //    value = false;
                //}
                _IsSpooferActive = value;
                if (value)
                {
                    if (user != null)
                    {
                        DisplayName = SpoofedName;
                    }
                }
                else
                {
                    if (user != null)
                    {
                        DisplayName = Original_DisplayName;
                        if (SpoofedName.IsNotNullOrEmptyOrWhiteSpace())
                        {
                            Log.Debug($"[PlayerSpoofer] : No Longer Spoofing As {SpoofedName}, Restored : {Original_DisplayName}");
                        }
                    }
                }
            }
        }

        private bool isFistJoin { [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = false;

        private bool isSecondJoin { [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = false;

        private string _SpoofedName { [HideFromIl2Cpp] get;  [HideFromIl2Cpp] set; } = string.Empty;

        internal string SpoofedName
        {
            [HideFromIl2Cpp]
            get
            {
                return _SpoofedName;
            }
            [HideFromIl2Cpp]
            set
            {
                _SpoofedName = value;
                if (IsSpooferActive)
                {
                    DisplayName = value;
                    Log.Debug($"[PlayerSpoofer] : Spoofing As {value}");
                }
            }
        }

        private bool Has_Original_Displayname;
        private string _Original_DisplayName;

        internal string Original_DisplayName
        {
            [HideFromIl2Cpp]
            get
            {
                if (!Has_Original_Displayname)
                {
                    if (user != null)
                    {
                        Has_Original_Displayname = true;
                        return _Original_DisplayName = user.displayName;
                    }
                }
                else
                {
                    return _Original_DisplayName;
                }
                return null;
            }
        }
    }
}