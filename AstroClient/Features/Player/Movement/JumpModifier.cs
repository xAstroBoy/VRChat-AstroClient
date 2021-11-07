namespace AstroClient.Features.Player.Movement
{
    using System.Collections.Generic;
    using AstroButtonAPI;
    using AstroLibrary.Utility;
    using UnityEngine;
    using VRC.SDKBase;

    internal class JumpModifier : GameEvents
    {
        internal override void OnUpdate()
        {
            if (IsRocketJumpActive || IsJumpOverriden || IsUnlimitedJumpActive)
            {
                if (Utils.LocalPlayer != null)
                {
                    if (InputUtils.IsInputJumpPressed || InputUtils.IsImputJumpCalled)
                    {
                        if (!IsRocketJumpActive)
                        {
                            if (Utils.LocalPlayer.IsPlayerGrounded())
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
            }
            //CodeDebugTools.CodeDebug.StopWatchDebug("JumpModifier OnUpdate ", () => {
              
            //});
        }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (Networking.LocalPlayer != null)
            {
                if (Networking.LocalPlayer.GetJumpImpulse() == 0f)
                {
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