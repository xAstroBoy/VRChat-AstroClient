


using MelonLoader;

namespace AstroClient.AstroMonos.Components.ESP.Player
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AstroClient.Tools.Extensions;
    using ClientAttributes;
    using Config;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using VRC;
    using xAstroBoy.Extensions;
    using xAstroBoy.Utility;
    using System.Collections;
    using VRC.Core;
    [RegisterComponent]
    public class PlayerESP : AstroMonoBehaviour
    {
        private List<Il2CppSystem.Object> AntiGarbageCollection = new();

        public PlayerESP(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        // Use this for initialization
        internal void Start()
        {

            if (PlayerSelector == null)
            {
                Destroy(this);
            }
            else
            {
                if (CurrentRenderer == null)
                {
                    Log.Error($"Failed to Generate a PlayerESP for Player {AssignedPlayer.DisplayName()}, Due to SelectRegion Renderer Missing!");
                    Destroy(this);
                    return;
                }
                else
                {

                    MelonCoroutines.Start(ForceHighlightSystem()); 
                }
            }
            SetPlayerDefaultESP();
        }

        private IEnumerator ForceHighlightSystem()
        {
            while (HighLightOptions == null)
                yield return null;
            while (AssignedPlayer == null)
                yield return null;

            yield return null;
        }

        private Color BlockedColor
        {
            [HideFromIl2Cpp]
            get
            {
                return Config.ConfigManager.ESPBlockedColor;
            }
        }

        private Color FriendColor
        {
            [HideFromIl2Cpp]
            get
            {
                return Config.ConfigManager.ESPFriendColor;
            }
        }

        private Color PublicColor
        {
            [HideFromIl2Cpp]
            get
            {
                return Config.ConfigManager.PublicESPColor;
            }
        }

        internal override void OnFriended(APIUser User)
        {
            if (!CanActuallyEditOnEvent) return;
            if (AssignedPlayer.GetAPIUser().Equals(User))
            {
                CurrentColor = FriendColor;
            }
        }

        internal override void OnUnfriended(string UserID)
        {
            if (!CanActuallyEditOnEvent) return;
            if (AssignedPlayer.GetAPIUser().id.Equals(UserID))
            {
                CurrentColor = PublicColor;
            }
        }

        internal override void OnPlayerBlockedYou(Photon.Realtime.Player player)
        {
            if (!CanActuallyEditOnEvent) return;

            if (player.GetUserID().Equals(AssignedPlayer.GetUserID()))
            {
                if (!UseCustomColor)
                {
                    CurrentColor = BlockedColor;
                }
            }
        }

        internal override void OnPlayerUnblockedYou(Photon.Realtime.Player player)
        {
            if (!CanActuallyEditOnEvent) return;
            if (player.GetUserID().Equals(AssignedPlayer.GetUserID()))
            {
                if (AssignedPlayer.GetAPIUser().IsFriend())
                {
                    CurrentColor = FriendColor;
                }
                else
                {
                    CurrentColor = PublicColor;
                }
            }
        }

        internal void OnDestroy()
        {
            HighLightOptions.DestroyHighlighter();
        }


        internal void ChangeColor(Color newcolor)
        {
            HighLightOptions.SetHighlighterColor(newcolor);
        }

        internal void ChangeColor(System.Drawing.Color newcolor)
        {
            HighLightOptions.SetHighlighterColor(newcolor.ToUnityEngineColor());
        }

        internal void ResetColor()
        {
            SetPlayerDefaultESP();
        }

        internal override void OnPublicESPColorChanged(Color color)
        {
            if (!CanActuallyEditOnEvent) return;
            if (!AssignedPlayer.GetAPIUser().IsFriend())
            {
                CurrentColor = color;
            }
        }

        internal override void OnFriendESPColorChanged(Color color)
        {
            if (!CanActuallyEditOnEvent) return;
            if (AssignedPlayer.GetAPIUser().IsFriend())
            {
                CurrentColor = color;
            }
        }

        internal override void OnBlockedESPColorChanged(Color color)
        {
            if (!CanActuallyEditOnEvent) return;

            if (AssignedPlayer.GetAPIUser().HasBlockedYou())
            {
                if (CurrentColor.HasValue)
                {
                    CurrentColor = color;
                }
            }
        }

        private void SetPlayerDefaultESP()
        {
            if (CanEditValues)
            {
                if (AssignedPlayer.GetAPIUser().HasBlockedYou())
                {
                    CurrentColor = BlockedColor;
                }
                else if (AssignedPlayer.GetAPIUser().GetIsFriend())
                {
                    CurrentColor = FriendColor;
                }
                else
                {
                    CurrentColor = PublicColor;
                }
            }
        }

        private UnityEngine.Color? CurrentColor
        {
            [HideFromIl2Cpp]
            get
            {
                if (HighLightOptions != null)
                {
                    return HighLightOptions.highlightColor;
                }
                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (HighLightOptions != null)
                {
                    HighLightOptions.highlightColor = value.Value;
                }
            }
        }

        private bool CanActuallyEditOnEvent
        {
            [HideFromIl2Cpp]
            get
            {
                if (CanEditValues)
                {
                    if (UseCustomColor)
                    {
                        return false;
                    }
                    return true;
                }
                return false;
            }
        }

        private bool CanEditValues
        {
            [HideFromIl2Cpp]
            get
            {
                return HighLightOptions != null && AssignedPlayer != null && AssignedPlayer.GetAPIUser() != null && CurrentColor.HasValue;
            }
        }

        private MeshRenderer _CurrentRenderer;
        private MeshRenderer CurrentRenderer
        {
            [HideFromIl2Cpp]
            get
            {
                if (_CurrentRenderer == null)
                {
                    if (PlayerSelector != null)
                    {
                        return _CurrentRenderer = PlayerSelector.GetComponent<MeshRenderer>();
                    }
                }

                return _CurrentRenderer;
            }
        }
        internal override void OnRoomLeft()
        {
            Destroy(this);
        }
        private PlayerSelector _PlayerSelector;
        private PlayerSelector PlayerSelector
        {
            [HideFromIl2Cpp]
            get
            {
                if (_PlayerSelector == null)
                {

                    return _PlayerSelector = this.GetComponentInChildren<PlayerSelector>(true);
                }
                return _PlayerSelector;
            }
        }


        internal HighlightsFXStandalone _HighLightOptions;

        private HighlightsFXStandalone HighLightOptions
        {
            [HideFromIl2Cpp]
            get
            {
                if(_HighLightOptions == null)
                {
                    _HighLightOptions = EspHelper.HighlightFXCamera.AddHighlighter();
                }
                _HighLightOptions.SetHighlighter(CurrentRenderer, true);
                _HighLightOptions.enabled = true;
                return _HighLightOptions;
            }
        }

        internal bool _UseCustomColor;

        internal bool UseCustomColor
        {
            [HideFromIl2Cpp]
            get
            {
                return _UseCustomColor;
            }
            [HideFromIl2Cpp]
            set
            {
                if (!value)
                {
                    SetPlayerDefaultESP();
                }
                _UseCustomColor = value;
            }
        }

        private Player _AssignedPlayer;
        internal Player AssignedPlayer
        {
            [HideFromIl2Cpp]
            get
            {
                if(_AssignedPlayer == null)
                {
                    return _AssignedPlayer = GetComponent<Player>();
                }
                return _AssignedPlayer;
            }
        }
    }
}