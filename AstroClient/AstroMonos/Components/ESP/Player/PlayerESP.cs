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

    [RegisterComponent]
    public class PlayerESP : AstroMonoBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<AstroMonoBehaviour> AntiGcList;

        public PlayerESP(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<AstroMonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        // Use this for initialization
        internal void Start()
        {
            // FIND ALLOCATED PLAYER
            var p = gameObject.GetComponent<Player>();
            if (p != null)
            {
                AssignedPlayer = p;
            }
            else
            {
                Destroy(this);
            }
            if (AssignedPlayer != null)
            {
                SelectRegion = AssignedPlayer.transform.Find("SelectRegion");
                if (SelectRegion == null)
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
                        if (HighLightOptions == null)
                        {
                            HighLightOptions = EspHelper.HighlightFXCamera.AddHighlighter();
                        }

                        if (CurrentRenderer != null)
                        {
                            HighLightOptions.SetHighlighter(CurrentRenderer, true);
                        }
                    }
                }
                SetPlayerDefaultESP();
            }
        }

        private Color BlockedColor
        {
            [HideFromIl2Cpp]
            get
            {
                return ConfigManager.ESPBlockedColor;
            }
        }

        private Color FriendColor
        {
            [HideFromIl2Cpp]
            get
            {
                return ConfigManager.ESPFriendColor;
            }
        }

        private Color PublicColor
        {
            [HideFromIl2Cpp]
            get
            {
                return ConfigManager.PublicESPColor;
            }
        }

        internal override void OnFriended()
        {
            if (!CanActuallyEditOnEvent) return;
            if (AssignedPlayer.GetAPIUser().IsFriend())
            {
                CurrentColor = FriendColor;
            }
        }

        internal override void OnUnfriended()
        {
            if (!CanActuallyEditOnEvent) return;
            if (!AssignedPlayer.GetAPIUser().IsFriend())
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

        internal void OnEnable()
        {
            HighLightOptions.enabled = true;
        }

        internal void OnDisable()
        {
            HighLightOptions.enabled = false;
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
                    if (SelectRegion != null)
                    {
                        return _CurrentRenderer = SelectRegion.GetComponentInChildren<MeshRenderer>();
                    }
                }

                return _CurrentRenderer;
            }
        }
        internal override void OnRoomLeft()
        {
            Destroy(this);
        }

        private Transform SelectRegion { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private HighlightsFXStandalone HighLightOptions { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
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

        internal Player AssignedPlayer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
    }
}