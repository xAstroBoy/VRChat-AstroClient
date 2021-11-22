namespace AstroClient.Tools.Player.Movement.QuickMenu
{
    using System.Collections.Generic;
    using Config;
    using UnityEngine;
    using VRC.SDKBase;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.Utility;

    internal class QMFreeze : AstroEvents
    {
        internal override void OnSceneLoaded(int buildIndex, string sceneName)
        {
            Frozen = false;
            hasBackuppedGravity = false;
        }

        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if(!hasBackuppedGravity)
            {
                originalGravity = Physics.gravity;
            }
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
                    originalVelocity = GameInstances.LocalPlayer.GetVelocity();
                    if (originalVelocity == Vector3.zero)
                    {
                        return;
                    }
                    CurrentGravity = Vector3.zero;
                    Networking.LocalPlayer.SetVelocity(Vector3.zero);
                }
            }
        }


        internal override void OnInput_Jump(bool isClicked, bool isDown, bool isUp)
        {
            // Prevent Jumping bug.
            if (Frozen && FreezePlayerOnQMOpen)
            {
                if (isClicked)
                {
                    if (Networking.LocalPlayer.GetVelocity() != Vector3.zero)
                    {
                        Networking.LocalPlayer.SetVelocity(Vector3.zero);
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
                if (Frozen && !GameInstances.LocalPlayer.IsPlayerGrounded())
                {
                    Physics.gravity = value;
                }
                else
                {
                    if (!Frozen)
                    {
                        if (value.x == 0f && value.y == 0f && value.z == 0f)
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
                if (value.x == 0f && value.y == 0f && value.z == 0f)
                {
                    return; // Discard this value as is No Gravity.
                }
                _originalGravity = value;
            }
        }

        private static Vector3 _originalGravity;

        private static Vector3 originalVelocity;

        internal static bool RestoreVelocity = false;

        internal static bool hasBackuppedGravity = false;
    }
}