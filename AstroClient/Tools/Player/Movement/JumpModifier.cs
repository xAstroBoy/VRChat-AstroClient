namespace AstroClient.Tools.Player.Movement
{
    using System.Collections.Generic;
    using Config;
    using UnityEngine;
    using VRC.SDKBase;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenu;
    using xAstroBoy.Utility;

    internal class JumpModifier : AstroEvents
    {
        internal override void OnInput_Jump(bool isClicked, bool isDown, bool isUp)
        {
            if (isDown)
            {
                if (!IsRocketJumpActive)
                {
                    if (LocalPlayer.IsPlayerGrounded())
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

        private VRCPlayerApi _LocalPlayer;

        private VRCPlayerApi LocalPlayer
        {
            get
            {
                if (_LocalPlayer == null)
                {
                    return _LocalPlayer = GameInstances.LocalPlayer;
                }

                return _LocalPlayer;
            }
        }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (Networking.LocalPlayer != null)
            {
                if (Networking.LocalPlayer.GetJumpImpulse() == 0f)
                {
                    ModConsole.Warning("This World has Jump disabled by default.");
                    PopupUtils.QueHudMessage($"This World has Jump disabled by default!");

                    Networking.LocalPlayer.SetJumpImpulse(4);
                }
            }
        }

        internal override void OnSceneLoaded(int buildIndex, string sceneName)
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