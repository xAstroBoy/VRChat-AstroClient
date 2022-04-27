using AstroClient.ClientActions;

namespace AstroClient.Tools.Player.Movement
{
    using System.Collections.Generic;
    using Config;
    using UnityEngine;
    using VRC.SDKBase;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.Utility;

    internal class JumpModifier : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.Event_OnRoomLeft += OnRoomLeft;
            ClientEventActions.Event_OnInput_Jump += OnInput_Jump;

        }

        private void OnInput_Jump(bool isClicked, bool isDown, bool isUp)
        {
            if (GameInstances.LocalPlayer == null) return;
            if (isDown)
            {
                if (!IsRocketJumpActive)
                {
                    if (GameInstances.LocalPlayer.IsPlayerGrounded())
                    {
                        if (IsJumpOverriden)
                        {
                            EmulatedJump();
                        }
                    }
                    else
                    {
                        if (IsUnlimitedJumpActive)
                        {
                            EmulatedJump();
                        }
                    }
                }
                else
                {
                    EmulatedJump();
                }
            }
        }


        private void OnRoomLeft()
        {
            IsJumpOverriden = false;
        }

        internal static void EmulatedJump()
        {
            if (Networking.LocalPlayer != null)
            {
                Vector3 velocity = Networking.LocalPlayer.GetVelocity();
                velocity.y = Networking.LocalPlayer.GetJumpImpulse();
                Networking.LocalPlayer.SetVelocity(velocity);
            }
        }

        internal static QMToggleButton UnlimitedJumpToggle;

        internal static bool IsUnlimitedJumpActive
        {
            get
            {
                return ConfigManager.Movement.UnlimitedJump;
            }
            set
            {
                ConfigManager.Movement.UnlimitedJump = value;
                if (UnlimitedJumpToggle != null)
                {
                    UnlimitedJumpToggle.SetToggleState(value);
                }
            }
        }

        internal static QMToggleButton RocketJumpToggle;

        internal static bool IsRocketJumpActive
        {
            get
            {
                return ConfigManager.Movement.RocketJump;
            }
            set
            {
                ConfigManager.Movement.RocketJump = value;
                if (RocketJumpToggle != null)
                {
                    RocketJumpToggle.SetToggleState(value);
                }
            }
        }

        internal static QMToggleButton JumpOverrideToggle;
        private static bool _IsJumpOverriden;

        internal static bool IsJumpOverriden
        {
            get
            {
                return _IsJumpOverriden;
            }
            set
            {
                _IsJumpOverriden = value;
                if (JumpOverrideToggle != null)
                {
                    JumpOverrideToggle.SetToggleState(value);
                }
            }
        }
    }
}