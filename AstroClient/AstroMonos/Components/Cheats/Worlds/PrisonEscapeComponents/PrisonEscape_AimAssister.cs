using System;
using AstroClient.AstroMonos.AstroUdons;
using AstroClient.AstroMonos.Components.Tools;
using AstroClient.CustomClasses;
using AstroClient.Tools.UdonSearcher;
using AstroClient.WorldModifications.WorldHacks.Ostinyo.Prison_Escape.Enums;

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
        private VRC_AstroPickup PickupSystem  { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;

        private Player TargetPlayer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = null;
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
            // This will work along with the laser component
            ShootInteraction = gameObject.FindUdonEvent("_onPickupUseDown");
            if (ShootInteraction != null)

            {
                if (PickupSystem == null)
                {
                    PickupSystem = gameObject.AddComponent<VRC_AstroPickup>();
                }

                if (PickupSystem != null)
                {
                    PickupSystem.OnPickupUseDown += OnPickupUseDown;
                    PickupSystem.OnPickupUseUp += OnPickupUseUp;
                    PickupSystem.OnDrop += OnDrop;
                }

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

        internal static bool IsDebugMode { get; set; } = false;

        void OnPlayerHit(Player player)
        {
            if (isAimAssisterOn || IsDebugMode)
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
                                return;
                            }
                        }
                        else if (ESP.CurrentRole == PrisonEscape_Roles.Guard && LocalUserData.CurrentRole == PrisonEscape_Roles.Prisoner)
                        {
                            ShootInteraction.InvokeBehaviour();
                            return;
                        }
                    }
                    else
                    {
                        ShootInteraction.InvokeBehaviour();
                    }
                }
            }
        }


        void OnPickupUseDown()
        {
            isAimAssisterOn = true;
        }

        void OnPickupUseUp()
        {
            isAimAssisterOn = false;
        }
        //internal float Shift_X { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 0f;
        //internal float Shift_Y { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 90f;
        //internal float Shift_Z { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = 0f;


        //void Update()
        //{
        //    if (isAimAssisterOn || IsDebugMode)
        //    {
        //        if (TargetPlayer != null)
        //        {
        //            var center = TargetPlayer.Get_Center_Of_Player();
        //            Vector3 relativePos = center - transform.position;

        //            // the second argument, upwards, defaults to Vector3.up
        //            Quaternion rotation = Quaternion.LookRotation(relativePos, new Vector3(0, 1, 0));
        //            transform.rotation = rotation * Quaternion.Euler(Shift_X, Shift_Y, Shift_Z);


        //        }
        //    }
        //}

        private bool isAimAssisterOn { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;



        void OnDrop()
        {
            isAimAssisterOn = false;
            TargetPlayer = null;
        }

        void OnEnable()
        {
            PickupSystem.enabled = true;
            TargetPlayer = null;

        }

        void OnDisable()
        {
            PickupSystem.enabled = false;
            TargetPlayer = null;

        }
    }
}