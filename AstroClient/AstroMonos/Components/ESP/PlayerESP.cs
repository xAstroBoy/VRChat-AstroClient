using System;
using System.Collections;
using System.Collections.Generic;
using AstroClient.ClientActions;
using AstroClient.ClientAttributes;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy.Extensions;
using AstroClient.xAstroBoy.Utility;
using MelonLoader;
using UnhollowerBaseLib.Attributes;
using UnityEngine;
using VRC.Core;

namespace AstroClient.AstroMonos.Components.ESP
{
    [RegisterComponent]
    public class PlayerESP : MonoBehaviour
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
            HasSubscribed = true;
            SetPlayerDefaultESP();

            InvokeRepeating(nameof(ForceActiveESP), 0.5f, 0.1f);
        }

        private IEnumerator ForceHighlightSystem()
        {
            while (HighLightOptions == null)
                yield return null;
            while (AssignedPlayer == null)
                yield return null;

            yield return null;
        }

        private void ForceActiveESP()
        {
            if (!HighLightOptions.enabled)
            {
                HighLightOptions.enabled = true;
            }
            if (CurrentRenderer != null)
            {
                //CurrentRenderer.enabled = true;
                //CurrentRenderer.gameObject.SetActive(true);
                HighLightOptions.AddRenderer(CurrentRenderer);
            }
        }

        private bool _HasSubscribed = false;

        private bool HasSubscribed
        {
            [HideFromIl2Cpp]
            get => _HasSubscribed;
            [HideFromIl2Cpp]
            set
            {
                if (_HasSubscribed != value)
                {
                    if (value)
                    {
                        ClientEventActions.OnFriended += OnFriended;
                        ClientEventActions.OnUnfriended += OnUnfriended;
                        ClientEventActions.OnPlayerBlockedYou += OnPlayerBlockedYou;
                        ClientEventActions.OnPlayerUnblockedYou += OnPlayerUnblockedYou;
                        ConfigEventActions.ESP_OnPublicColorChange += OnPublicESPColorChanged;
                        ConfigEventActions.ESP_OnFriendColorChange += OnFriendESPColorChanged;
                        ConfigEventActions.ESP_OnBlockedColorChange += OnBlockedESPColorChanged;
                    }
                    else
                    {
                        ClientEventActions.OnFriended -= OnFriended;
                        ClientEventActions.OnUnfriended -= OnUnfriended;
                        ClientEventActions.OnPlayerBlockedYou -= OnPlayerBlockedYou;
                        ClientEventActions.OnPlayerUnblockedYou -= OnPlayerUnblockedYou;
                        ConfigEventActions.ESP_OnPublicColorChange -= OnPublicESPColorChanged;
                        ConfigEventActions.ESP_OnFriendColorChange -= OnFriendESPColorChanged;
                        ConfigEventActions.ESP_OnBlockedColorChange -= OnBlockedESPColorChanged;
                    }
                }
                _HasSubscribed = value;
            }
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

        private void OnFriended(APIUser User)
        {
            if (!CanActuallyEditOnEvent) return;
            if (AssignedPlayer.GetAPIUser().Equals(User))
            {
                CurrentColor = FriendColor;
            }
        }

        private void OnUnfriended(string UserID)
        {
            if (!CanActuallyEditOnEvent) return;
            if (AssignedPlayer.GetAPIUser().id.Equals(UserID))
            {
                CurrentColor = PublicColor;
            }
        }

        private void OnPlayerBlockedYou(Photon.Realtime.Player player)
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

        private void OnPlayerUnblockedYou(Photon.Realtime.Player player)
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
            HasSubscribed = false;
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

        private void OnPublicESPColorChanged(Color color)
        {
            if (!CanActuallyEditOnEvent) return;
            if (!AssignedPlayer.GetAPIUser().IsFriend())
            {
                CurrentColor = color;
            }
        }

        private void OnFriendESPColorChanged(Color color)
        {
            if (!CanActuallyEditOnEvent) return;
            if (AssignedPlayer.GetAPIUser().IsFriend())
            {
                CurrentColor = color;
            }
        }

        private void OnBlockedESPColorChanged(Color color)
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
                if (value.HasValue)
                {
                    if (HighLightOptions != null)
                    {
                        HighLightOptions.highlightColor = value.Value;
                    }
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

        private Renderer _CurrentRenderer;

        private Renderer CurrentRenderer
        {
            [HideFromIl2Cpp]
            get
            {
                if (_CurrentRenderer == null)
                {
                    if (PlayerSelector != null)
                    {
                        return _CurrentRenderer = PlayerSelector.GetComponent<Renderer>();
                    }
                }

                return _CurrentRenderer;
            }
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
                if (_HighLightOptions == null)
                {
                    _HighLightOptions = EspHelper.HighlightFXCamera.AddHighlighter();
                }
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

        private VRC.Player _AssignedPlayer;

        internal VRC.Player AssignedPlayer
        {
            [HideFromIl2Cpp]
            get
            {
                if (_AssignedPlayer == null)
                {
                    return _AssignedPlayer = GetComponent<VRC.Player>();
                }
                return _AssignedPlayer;
            }
        }
    }
}