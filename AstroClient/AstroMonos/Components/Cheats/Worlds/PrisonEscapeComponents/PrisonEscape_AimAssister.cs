﻿using System;
using AstroClient.AstroMonos.AstroUdons;
using AstroClient.AstroMonos.Components.Tools;
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


    // BUG : Figure what's breaking the Pickup System (not respawning / Desyncing )
    [RegisterComponent]
    public class PrisonEscape_AimAssister : AstroMonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public PrisonEscape_AimAssister(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }
        internal override void OnRoomLeft()
        {
            Destroy(this);
        }

        private UdonBehaviour_Cached ShootInteraction { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
        private LaserPointer Laser { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private PrisonEscape_ESP _LocalUserData { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        internal PrisonEscape_ESP LocalUserData
        {
            [HideFromIl2Cpp]
            get
            {
                if (_LocalUserData == null)
                {
                    return _LocalUserData = GameInstances.LocalPlayer.gameObject.GetOrAddComponent<PrisonEscape_ESP>();
                }
                return _LocalUserData;

            }
        }

        void Start()
        {
            if (!WorldUtils.WorldID.Equals(WorldIds.PrisonEscape)) Destroy(this);

            // This will work along with the laser component
            ShootInteraction = gameObject.FindUdonEvent("_onPickupUseDown");
            if (ShootInteraction != null)
            {
                if (Laser == null)
                {
                    Laser = gameObject.GetGetInChildrens<LaserPointer>(true);
                }

                if (Laser != null)
                {
                    Laser.OnPlayerHit += OnPlayerHit;
                }
            }
        }

        internal static bool IsDebugMode {  [HideFromIl2Cpp]get; [HideFromIl2Cpp] set; } = false;
        [HideFromIl2Cpp]
        void OnPlayerHit(Player player)
        {
            if (isAimAssisterOn || IsDebugMode)
            {

                if (player != null)
                {
                    var ESP = player.GetComponent<PrisonEscape_ESP>();
                    if (ESP != null)
                    {
                        if (!IsDebugMode)
                        {
                            if (player.GetAPIUser().IsSelf) return;
                            if (ESP.CurrentRole == PrisonEscape_Roles.Prisoner && LocalUserData.CurrentRole == PrisonEscape_Roles.Guard)
                            {
                                if (ESP.isWanted)
                                {
                                    ShootInteraction.InvokeBehaviour();
                                }
                            }
                            else if (ESP.CurrentRole == PrisonEscape_Roles.Guard && LocalUserData.CurrentRole == PrisonEscape_Roles.Prisoner)
                            {
                                ShootInteraction.InvokeBehaviour();
                            }
                        }
                        else
                        {
                            ShootInteraction.InvokeBehaviour();
                        }
                    }
                }
            }
        }

        [HideFromIl2Cpp]
        internal override void UdonBehaviour_Event_OnPickupUseDown(UdonBehaviour item)
        {
            if (item.Equals(ShootInteraction.UdonBehaviour))
            {
                isAimAssisterOn = true;
            }
        }

        [HideFromIl2Cpp]
        internal override void UdonBehaviour_Event_OnPickupUseUp(UdonBehaviour item)
        {
            if (item.Equals(ShootInteraction.UdonBehaviour))
            {
                isAimAssisterOn = false;
            }
        }
        internal override void UdonBehaviour_Event_OnDrop(UdonBehaviour item)
        {
            if (item.Equals(ShootInteraction.UdonBehaviour))
            {
                isAimAssisterOn = false;
            }
        }

        private bool isAimAssisterOn { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;


         [HideFromIl2Cpp]
        void OnDrop()
        {
            isAimAssisterOn = false;
        }



    }
}