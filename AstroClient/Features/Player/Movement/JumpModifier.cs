namespace AstroClient.Features.Player.Movement
{
    using AstroLibrary.Utility;
    using RubyButtonAPI;
    using System.Collections.Generic;
    using UnityEngine;
    using VRC.SDKBase;

    public class JumpModifier : GameEvents
    {
        public override void OnUpdate()
        {
            CheckForJumpUpdates();
            FixJumpMissing();
        }

        public override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            HasCheckedJump = false;
        }

        public static void OnLevelLoad()
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

        public static void CheckForJumpUpdates()
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

        public static void EmulatedJump()
        {
            if (Networking.LocalPlayer != null)
            {
                Vector3 velocity = Networking.LocalPlayer.GetVelocity();
                velocity.y = Networking.LocalPlayer.GetJumpImpulse();
                Networking.LocalPlayer.SetVelocity(velocity);
            }
        }

        private static bool HasCheckedJump = false;

        public static QMSingleToggleButton UnlimitedJumpToggle;

        public static bool IsUnlimitedJumpActive
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

        public static QMSingleToggleButton RocketJumpToggle;

        public static bool IsRocketJumpActive
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

        public static QMToggleButton JumpOverrideToggle;
        private static bool _IsJumpOverriden;

        public static bool IsJumpOverriden
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