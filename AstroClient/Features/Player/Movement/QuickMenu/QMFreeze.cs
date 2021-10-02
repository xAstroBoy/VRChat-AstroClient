namespace AstroClient.Features.Player.Movement.QuickMenu_QMFreeze
{
    using AstroLibrary.Utility;
    using RubyButtonAPI;
    using UnityEngine;
    using VRC.SDKBase;

    internal class QMFreeze : GameEvents
    {
        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            Frozen = false;
        }


        internal override void OnQuickMenuOpen()
        {
            if (FreezePlayerOnQMOpen)
            {
                if (Networking.LocalPlayer != null)
                {
                    Freeze();
                }
                else
                {
                    Frozen = false;
                }
            }
        }

        internal override void OnQuickMenuClose()
        {
            if (FreezePlayerOnQMOpen)
            {
                if (Networking.LocalPlayer != null)
                {
                    Unfreeze();
                }
                else
                {
                    Frozen = false;
                }
            }
        }

        internal static void Unfreeze()
        {
            if (Frozen)
            {
                Frozen = false;
                if (Networking.LocalPlayer != null)
                {
                    CurrentGravity = originalGravity;
                    if (RestoreVelocity)
                    {
                        Networking.LocalPlayer.SetVelocity(originalVelocity);
                    }
                }
            }
        }

        internal static void Freeze()
        {
            if (Networking.LocalPlayer != null)
            {
                if (!Frozen)
                {
                    Frozen = true;
                    originalGravity = Physics.gravity;
                    originalVelocity = Networking.LocalPlayer.GetVelocity();
                    if (originalVelocity == Vector3.zero)
                    {
                        return;
                    }
                    CurrentGravity = Vector3.zero;
                    Networking.LocalPlayer.SetVelocity(Vector3.zero);
                }
                else
                {
                    if (InputUtils.IsImputJumpCalled || InputUtils.IsInputJumpPressed)
                    {
                        if (Networking.LocalPlayer.GetVelocity() != Vector3.zero)
                        {
                            Networking.LocalPlayer.SetVelocity(Vector3.zero);
                        }
                    }
                }
            }
        }

        internal static bool FreezePlayerOnQMOpen
        {
            get
            {
                return ConfigManager.Movement.QMFreeze;
            }
            set
            {
                ConfigManager.Movement.QMFreeze = value;
                if (FreezePlayerOnQMOpenToggle != null)
                {
                    FreezePlayerOnQMOpenToggle.SetToggleState(value);
                }
            }
        }

        internal static QMToggleButton FreezePlayerOnQMOpenToggle;
        internal static bool Frozen;

        private static Vector3 CurrentGravity
        {
            get
            {
                return Physics.gravity;
            }
            set
            {
                if (Frozen && !Utils.LocalPlayer.IsPlayerGrounded())
                {
                    Physics.gravity = value;
                }
                else
                {
                    if (!Frozen)
                    {

                        if (value.Equals(Vector3.zero))
                        {
                            value = originalGravity;
                        }
                        Physics.gravity = value;
                    }
                }
            }
        }

        private static Vector3 originalGravity
        {
            get
            {
                return _originalGravity;
            }
            set
            {
                if (value.Equals(Vector3.zero))
                {
                    return; // Discard this value as is No Gravity.
                }
                _originalGravity = value;
            }
        }

        private static Vector3 _originalGravity;

        private static Vector3 originalVelocity;

        internal static bool RestoreVelocity = false;
    }
}