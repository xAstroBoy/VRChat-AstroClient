namespace AstroClient.Features.Player.Movement
{
    using AstroLibrary.Utility;
    using AstroButtonAPI;
    using System.Collections.Generic;
    using UnityEngine;
    using VRC.SDKBase;

    internal class JumpModifier : GameEvents
    {
        internal override void OnUpdate()
        {
            CheckForJumpUpdates();
            FixJumpMissing();
        }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            HasCheckedJump = false;
        }

        internal static void OnLevelLoad()
        {
            IsJumpOverriden = false;
        }

        private static void FixJumpMissing()
        {
            try
            {
                if (Networking.LocalPlayer != null)
                {
                    if (!HasCheckedJump)
                    {
                        if (Networking.LocalPlayer.GetJumpImpulse() == 0f)
                        {
                            HasCheckedJump = true;
                            Networking.LocalPlayer.SetJumpImpulse(4);
                        }
                        else
                        {
                            HasCheckedJump = true;
                        }
                    }
                }
            }
            catch
            {
                HasCheckedJump = false;
            }
        }

        internal static void CheckForJumpUpdates()
        {
            if (Utils.LocalPlayer != null)
            {
                if (InputUtils.IsImputJumpCalled)
                {
                    if (Utils.LocalPlayer.IsPlayerGrounded() && IsJumpOverriden)
                    {
                        EmulatedJump();
                    }
                    else
                    {
                        if (!Utils.LocalPlayer.IsPlayerGrounded() && IsUnlimitedJumpActive)
                        {
                            EmulatedJump();
                        }
                    }
                }

                if (InputUtils.IsInputJumpPressed&& IsRocketJumpActive)
                {
                    EmulatedJump();
                }
            }
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

        private static bool HasCheckedJump = false;

        internal static QMSingleToggleButton UnlimitedJumpToggle;

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

        internal static QMSingleToggleButton RocketJumpToggle;

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