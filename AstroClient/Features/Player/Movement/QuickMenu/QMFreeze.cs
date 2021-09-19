namespace AstroClient.Features.Player.Movement.QuickMenu_QMFreeze
{
    using RubyButtonAPI;
    using UnityEngine;
    using VRC.SDKBase;

    public class QMFreeze : GameEvents
    {
        public override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            Frozen = false;
        }

        public override void OnUpdate()
        {
            if (FreezePlayerOnQMOpen)
            {
                if (QuickMenuUtils_Old.IsQuickMenuOpen)
                {
                    Freeze();
                }
                else
                {
                    Unfreeze();
                }
            }
        }

        public override void OnQuickMenuOpen()
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

        public override void OnQuickMenuClose()
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

        public static void Unfreeze()
        {
            if (Frozen)
            {
                if (Networking.LocalPlayer != null)
                {
                    Physics.gravity = originalGravity;
                    if (RestoreVelocity)
                    {
                        Networking.LocalPlayer.SetVelocity(originalVelocity);
                    }
                    Frozen = false;
                }
            }
        }

        public static void Freeze()
        {
            if (Networking.LocalPlayer != null)
            {
                if (!Frozen)
                {
                    originalGravity = Physics.gravity;
                    originalVelocity = Networking.LocalPlayer.GetVelocity();
                    if (originalVelocity == Vector3.zero)
                    {
                        return;
                    }
                    Physics.gravity = Vector3.zero;
                    Networking.LocalPlayer.SetVelocity(Vector3.zero);
                    Frozen = true;
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

        public static bool FreezePlayerOnQMOpen
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

        public static QMToggleButton FreezePlayerOnQMOpenToggle;
        public static bool Frozen;

        private static Vector3 originalGravity
        {
            get
            {
                return _originalGravity;
            }
            set
            {
                if (value.x == 0f && value.y == 0f && value.z == 0f)
                {
                    return; // Discard this value as is No Gravity.
                }
                _originalGravity = value;
            }
        }

        private static Vector3 _originalGravity;

        private static Vector3 originalVelocity;

        internal static bool Opened;
        internal static bool RestoreVelocity = false;
    }
}