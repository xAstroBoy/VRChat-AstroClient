namespace AstroClient.Components
{
    using AstroClient.Moderation;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using MelonLoader;
    using System;
    using System.Linq;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;
    using VRC;
    using VRC.Management;

    [RegisterComponent]
    public class PlayerESP : EspEvents
    {
        public Il2CppSystem.Collections.Generic.List<EspEvents> AntiGcList;

        public PlayerESP(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<EspEvents>(1);
            AntiGcList.Add(this);
        }

        private bool DebugMode = false;

        [HideFromIl2Cpp]
        private void Debug(string msg)
        {
            if (DebugMode)
            {
                ModConsole.DebugLog($"[PlayerESP Debug] : {msg}");
            }
        }

        // Use this for initialization
        internal void Start()
        {
            // FIND ALLOCATED PLAYER
            var p = this.GetComponent<Player>();
            if (p != null)
            {
                Debug($"Found Target Player {p.DisplayName()}, For PlayerESP");
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
                    Debug($"Found SelectRegion Transform Assigned in {AssignedPlayer.DisplayName()}!");
                    ObjRenderers = SelectRegion.GetComponentsInChildren<Renderer>(true);
                    if (ObjRenderers == null && ObjRenderers.Count() == 0)
                    {
                        ModConsole.Error($"Failed to Generate a PlayerESP for Player {AssignedPlayer.DisplayName()}, Due to SelectRegion Renderer Missing!");
                        Destroy(this);
                        return;
                    }
                    else
                    {
                        Debug($"Found SelectRegion Renderer in {AssignedPlayer.DisplayName()}, Activating ESP !");
                        if (HighLightOptions == null)
                        {
                            HighLightOptions = EspHelper.HighLightFXCamera.AddHighlighter();
                            if (HighLightOptions != null)
                            {
                                Debug("Added HighlightsFXStandalone in SelectRegion For Custom Color Option for ESP!");
                            }
                        }
                        for (int i = 0; i < ObjRenderers.Count; i++)
                        {
                            Renderer ObjRenderer = ObjRenderers[i];
                            if (ObjRenderer != null)
                            {
                                HighLightOptions.SetHighLighter(ObjRenderer, true);
                            }
                        }
                    }
                }
                SetPlayerDefaultESP();
            }
        }

        private Color BlockedColor
        {
            get
            {
                return ConfigManager.ESPBlockedColor;
            }
        }

        private Color FriendColor
        {
            get
            {
                return ConfigManager.ESPFriendColor;
            }
        }

        private Color PublicColor
        {
            get
            {
                return ConfigManager.PublicESPColor;
            }
        }

        internal override void OnFriended()
        {
            if (UseCustomColor || !CanEditValues) return;
            if (AssignedPlayer.GetAPIUser().IsFriend())
            {
                    CurrentColor = FriendColor;
                }
        }

        internal override void OnUnfriended()
        {
            if (UseCustomColor || !CanEditValues) return;
                if (!AssignedPlayer.GetAPIUser().IsFriend())
                {
                    CurrentColor = PublicColor;
                }
            
        }

        internal override void OnPlayerBlockedYou(Photon.Realtime.Player player)
        {
            if (UseCustomColor || !CanEditValues) return;

            if (player.GetUserID() == AssignedPlayer.GetUserID())
            {
                if (!UseCustomColor)
                {
                    CurrentColor = BlockedColor;
                }
            }
        }

        internal override void OnPlayerUnblockedYou(Photon.Realtime.Player player)
        {
            if (UseCustomColor || !CanEditValues) return;

            if (player.GetUserID() == AssignedPlayer.GetUserID())
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
            HighLightOptions.SetHighLighterColor(newcolor);
        }

        internal void ResetColor()
        {
            SetPlayerDefaultESP();
        }

        internal Color GetCurrentESPColor
        {
            get
            {
                return HighLightOptions.highlightColor;
            }
            set
            {
                HighLightOptions.highlightColor = value;
            }
        }

        internal override void OnPublicESPColorChanged(Color color)
        {
            if (UseCustomColor || !CanEditValues) return;
            if (!AssignedPlayer.GetAPIUser().IsFriend())
            {
                if (HighLightOptions.highlightColor != color)
                {
                    HighLightOptions.highlightColor = color;
                }
            }
        }
        internal override void OnFriendESPColorChanged(Color color)
        {
            if (UseCustomColor || !CanEditValues) return;
            if (AssignedPlayer.GetAPIUser().IsFriend())
            {
                if (HighLightOptions.highlightColor != color)
                {
                    HighLightOptions.highlightColor = color;
                }
            }

        }


        internal override void OnBlockedESPColorChanged(Color color)
        {
            if (UseCustomColor || !CanEditValues) return;

            if (AssignedPlayer.GetAPIUser().HasBlockedYou())
            {
                if (CurrentColor.HasValue)
                {
                    if (CurrentColor != BlockedColor)
                    {
                        CurrentColor = BlockedColor;
                    }
                }
            }
        }

        private void SetPlayerDefaultESP()
        {

            if (CanEditValues)
            {
                if (AssignedPlayer.GetAPIUser().GetIsFriend())
                {
                    if (CurrentColor.Value != FriendColor)
                    {
                        CurrentColor = FriendColor;
                    }
                }

                else if (AssignedPlayer.GetAPIUser().HasBlockedYou())
                {
                    if (CurrentColor != BlockedColor)
                    {
                        CurrentColor = BlockedColor;
                    }
                }
                else
                {
                    if (CurrentColor.Value != PublicColor)
                    {
                        CurrentColor = PublicColor;
                    }
                }
            }
        }

        private UnityEngine.Color? CurrentColor
        {
            get
            {
                if(HighLightOptions != null)
                {
                    return HighLightOptions.highlightColor;
                }
                return null;
            }
            set
            {
                if(HighLightOptions != null)
                {
                    HighLightOptions.highlightColor = value.Value;
                }
            }
        }


        private bool CanEditValues
        {
            get
            {
                return HighLightOptions != null && AssignedPlayer != null && AssignedPlayer.GetAPIUser() != null && CurrentColor.HasValue;
            }
        }

        private Transform SelectRegion { get; set; }
        private UnhollowerBaseLib.Il2CppArrayBase<Renderer> ObjRenderers{ get; set; }
        private HighlightsFXStandalone HighLightOptions { get; set; }
        internal bool _UseCustomColor;

        internal bool UseCustomColor
        {
            get
            {
                return _UseCustomColor;
            }
            set
            {
                if (value == _UseCustomColor)
                {
                    return;
                }
                if (!value)
                {
                    SetPlayerDefaultESP();
                }
                _UseCustomColor = value;
            }
        }

        internal Player AssignedPlayer { get; private set; }
    }
}