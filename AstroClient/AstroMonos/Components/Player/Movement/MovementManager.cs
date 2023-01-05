using AstroClient.AstroMonos.Components.Tools;
using AstroClient.ClientActions;
using AstroClient.ClientUI.Hud.Notifier;

namespace AstroClient.AstroMonos.Components.Player.Movement
{
    using System;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using Il2CppSystem.Linq;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using VRC.SDKBase;
    using xAstroBoy.Utility;

    [RegisterComponent]
    public class MovementManager : MonoBehaviour
    {
        internal VRCPlayerApi CurrentPlayer
        {
            [HideFromIl2Cpp]
            get => Networking.LocalPlayer;
        }
        public List<MonoBehaviour> AntiGcList;

        public MovementManager(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        internal bool CheckAndActivateJumpOnWorldJoin { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = true;

        void Start()
        {
            HasSubscribed = true;
        }

        void OnDestroy()
        {
            HasSubscribed = false;
        }

        void OnEnable()
        {
            HasSubscribed = true;
        }

        void OnDisable()
        {
            HasSubscribed = false;
        }


        #region  GravityStrength

        private float Original_GravityStrength { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private float Modified_GravityStrength { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool HasModified_GravityStrength { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal float GravityStrength
        {
            [HideFromIl2Cpp]
            get => CurrentPlayer.GetGravityStrength();
            [HideFromIl2Cpp]
            set
            {
                if (!value.Equals(Original_GravityStrength))
                {
                    HasModified_GravityStrength = true;
                }

                Modified_GravityStrength = value;
                CurrentPlayer.SetGravityStrength(value);
            }
        }

        internal void Restore_GravityStrength()
        {
            if (HasModified_GravityStrength)
            {
                GravityStrength = Original_GravityStrength;
                HasModified_GravityStrength = false;
            }
        }



        #endregion GravityStrength

        #region  JumpImpulse

        private float Original_JumpImpulse { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private float Modified_JumpImpulse { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool HasModified_JumpImpulse { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal float JumpImpulse
        {
            [HideFromIl2Cpp]
            get => CurrentPlayer.GetJumpImpulse();
            [HideFromIl2Cpp]
            set
            {
                if (!value.Equals(Original_JumpImpulse))
                {
                    HasModified_JumpImpulse = true;
                }

                Modified_JumpImpulse = value;
                CurrentPlayer.SetJumpImpulse(value);
            }
        }

        internal void Restore_JumpImpulse()
        {
            if (HasModified_JumpImpulse)
            {
                JumpImpulse = Original_JumpImpulse;
                HasModified_JumpImpulse = false;
            }
        }



        #endregion JumpImpulse

        #region  RunSpeed

        private float Original_RunSpeed { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private float Modified_RunSpeed { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool HasModified_RunSpeed { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal float RunSpeed
        {
            [HideFromIl2Cpp]
            get => CurrentPlayer.GetRunSpeed();
            [HideFromIl2Cpp]
            set
            {
                if (!value.Equals(Original_RunSpeed))
                {
                    HasModified_RunSpeed = true;
                }

                Modified_RunSpeed = value;
                CurrentPlayer.SetRunSpeed(value);
            }
        }

        internal void Restore_RunSpeed()
        {
            if (HasModified_RunSpeed)
            {
                RunSpeed = Original_RunSpeed;
                HasModified_RunSpeed = false;
            }
        }



        #endregion RunSpeed

        #region  StrafeSpeed

        private float Original_StrafeSpeed { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private float Modified_StrafeSpeed { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool HasModified_StrafeSpeed { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal float StrafeSpeed
        {
            [HideFromIl2Cpp]
            get => CurrentPlayer.GetStrafeSpeed();
            [HideFromIl2Cpp]
            set
            {
                if (!value.Equals(Original_StrafeSpeed))
                {
                    HasModified_StrafeSpeed = true;
                }

                Modified_StrafeSpeed = value;
                CurrentPlayer.SetStrafeSpeed(value);
            }
        }

        internal void Restore_StrafeSpeed()
        {
            if (HasModified_StrafeSpeed)
            {
                StrafeSpeed = Original_StrafeSpeed;
                HasModified_StrafeSpeed = false;
            }
        }



        #endregion StrafeSpeed

        #region  WalkSpeed

        private float Original_WalkSpeed { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private float Modified_WalkSpeed { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private bool HasModified_WalkSpeed { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal float WalkSpeed
        {
            [HideFromIl2Cpp]
            get => CurrentPlayer.GetWalkSpeed();
            [HideFromIl2Cpp]
            set
            {
                if (!value.Equals(Original_WalkSpeed))
                {
                    HasModified_WalkSpeed = true;
                }

                Modified_WalkSpeed = value;
                CurrentPlayer.SetWalkSpeed(value);
            }
        }

        internal void Restore_WalkSpeed()
        {
            if (HasModified_WalkSpeed)
            {
                WalkSpeed = Original_WalkSpeed;
                HasModified_WalkSpeed = false;
            }
        }



        #endregion WalkSpeed

        #region  Velocity

        internal Vector3 Velocity
        {
            [HideFromIl2Cpp]
            get => CurrentPlayer.GetVelocity();
            [HideFromIl2Cpp]
            set
            {
                CurrentPlayer.SetVelocity(value);
            }
        }
        #endregion Velocity




        //internal void Update()
        //{
        //    if (!HasModified_GravityStrength)
        //    {
        //        Original_GravityStrength = GravityStrength;
        //    }
        //    if (!HasModified_JumpImpulse)
        //    {
        //        Original_JumpImpulse = JumpImpulse;
        //    }
        //    if (!HasModified_RunSpeed)
        //    {
        //        Original_RunSpeed = RunSpeed;
        //    }
        //    if (!HasModified_StrafeSpeed)
        //    {
        //        Original_StrafeSpeed = StrafeSpeed;
        //    }
        //    if (!HasModified_WalkSpeed)
        //    {
        //        Original_WalkSpeed = WalkSpeed;
        //    }
        //}


        private void ForceActivateJump()
        {
            if (CheckAndActivateJumpOnWorldJoin)
            {
                if (JumpImpulse == 0f)
                {
                    Log.Warn("This World has Jump disabled by default.");
                    NewHudNotifier.WriteHudMessage($"This World has Jump disabled by default!");
                    JumpImpulse = 4f;
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

                        ClientEventActions.OnRoomLeft += OnRoomLeft;
                        ClientEventActions.OnWorldReveal += OnWorldReveal;

                    }
                    else
                    {

                        ClientEventActions.OnRoomLeft -= OnRoomLeft;
                        ClientEventActions.OnWorldReveal -= OnWorldReveal;

                    }
                }
                _HasSubscribed = value;
            }
        }


        private void OnRoomLeft()
        {
            Restore_GravityStrength();
            Restore_JumpImpulse();
            Restore_RunSpeed();
            Restore_StrafeSpeed();
            Restore_WalkSpeed();
        }


        private void OnWorldReveal(string id, string Name, System.Collections.Generic.List<string> tags, string AssetURL, string AuthorName)
        {

            // Backup Original Values;
            Original_GravityStrength = GravityStrength;
            Original_JumpImpulse = JumpImpulse;
            Original_RunSpeed = RunSpeed;
            Original_StrafeSpeed = StrafeSpeed;
            Original_WalkSpeed = WalkSpeed;

            ForceActivateJump();
        }

    }
}