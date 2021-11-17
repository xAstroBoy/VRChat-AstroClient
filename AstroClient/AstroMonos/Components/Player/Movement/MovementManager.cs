namespace AstroClient.AstroMonos.Components.Player.Movement
{
    using System;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using VRC.SDKBase;

    public class MovementManager : AstroMonoBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<AstroMonoBehaviour> AntiGcList;

        public MovementManager(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<AstroMonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        //  This Binds to the current player.
        private void Start()
        {
        }


        internal override void OnRoomJoined()
        {
            
        }

        private float GravityStrenght
        {
            [HideFromIl2Cpp]
            get => CurrentPlayer.GetGravityStrength();
            [HideFromIl2Cpp]
            set => CurrentPlayer.SetGravityStrength(value);
        }

        private float JumpImpulse
        {
            [HideFromIl2Cpp]
            get => CurrentPlayer.GetJumpImpulse();
            [HideFromIl2Cpp]
            set => CurrentPlayer.SetJumpImpulse(value);
        }


        private float RunSpeed
        {
            [HideFromIl2Cpp]
            get => CurrentPlayer.GetRunSpeed();
            [HideFromIl2Cpp]
            set => CurrentPlayer.SetRunSpeed(value);
        }

        private float StrafeSpeed
        {
            [HideFromIl2Cpp]
            get => CurrentPlayer.GetStrafeSpeed();
            [HideFromIl2Cpp]
            set => CurrentPlayer.SetStrafeSpeed(value);
        }

        private float WalkSpeed
        {
            [HideFromIl2Cpp]
            get => CurrentPlayer.GetWalkSpeed();
            [HideFromIl2Cpp]
            set => CurrentPlayer.SetWalkSpeed(value);
        }

        private Vector3 Velocity
        {
            [HideFromIl2Cpp]
            get => CurrentPlayer.GetVelocity();
            [HideFromIl2Cpp]
            set => CurrentPlayer.SetVelocity(value);
        }


        private VRCPlayerApi _CurrentPlayer;
        internal VRCPlayerApi CurrentPlayer
        {
            get
            {
                if (_CurrentPlayer == null)
                {
                    return _CurrentPlayer = Networking.LocalPlayer;
                }
                return _CurrentPlayer;
            }
        }
    }

}
