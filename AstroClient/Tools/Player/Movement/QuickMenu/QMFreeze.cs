using AstroClient.ClientActions;

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
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += OnRoomLeft;
            ClientEventActions.OnQuickMenuOpen += OnQuickMenuOpen;
            ClientEventActions.OnQuickMenuClose += OnQuickMenuClose;

        }

        private void OnRoomLeft()
        {
            Frozen = false;
        }

        private void OnQuickMenuOpen()
        {
            if (Networking.LocalPlayer != null)
            {
                if (FreezePlayerOnQMOpen)
                {
                    Freeze();
                }
                else
                {
                    Frozen = false;
                }

            }
        }

        private void OnQuickMenuClose()
        {
            if (Networking.LocalPlayer != null)
            {
                if (FreezePlayerOnQMOpen)
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
                    GameInstances.LocalPlayer.Immobilize(false);
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
                    Networking.LocalPlayer.Immobilize(true);
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
    }
}