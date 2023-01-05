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
            if (CurrentPlayerController != null)
            {
                CurrentPlayerController.enabled = true;
            }
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
            try
            {
                if (Networking.LocalPlayer != null)
                {

                    if (Frozen)
                    {
                        Frozen = false;
                        CurrentPlayerController.enabled = true;
                        
                    }
                }
            }
            catch { }

        }

        internal static void Freeze()
        {
            try
            {
                if (Networking.LocalPlayer != null)
                {
                    if (!Frozen)
                    {
                        Frozen = true;
                        CurrentPlayerController.enabled = false; 
                    }
                }
            } catch{}
        }

        internal static bool FreezePlayerOnQMOpen
        {
            get => ConfigManager.Movement.QMFreeze;
            set
            {
                ConfigManager.Movement.QMFreeze = value;
                if (FreezePlayerOnQMOpenToggle != null)
                {
                    FreezePlayerOnQMOpenToggle.SetToggleState(value);
                }
            }
        }
    
        internal static GamelikeInputController _CurrentMovement { get; set; }
        internal static GamelikeInputController CurrentMovement
        {
            get
            {
                if (Networking.LocalPlayer == null) return null;
                if (Networking.LocalPlayer.gameObject == null) return null;
                if (_CurrentMovement == null)
                {
                    return _CurrentMovement = Networking.LocalPlayer.gameObject.GetComponent<GamelikeInputController>();
                }
                return _CurrentMovement;
            }
        }
        internal static CharacterController _CurrentPlayerController { get; set; }
        internal static CharacterController CurrentPlayerController
        {
            get
            {
                if (Networking.LocalPlayer == null) return null;
                if (Networking.LocalPlayer.gameObject == null) return null;
                if (_CurrentPlayerController == null)
                {
                    return _CurrentPlayerController = Networking.LocalPlayer.gameObject.GetComponent<CharacterController>();
                }
                return _CurrentPlayerController;
            }
        }

        internal static QMToggleButton FreezePlayerOnQMOpenToggle;
        internal static bool Frozen;
    }
}