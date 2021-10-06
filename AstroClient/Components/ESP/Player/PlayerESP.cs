namespace AstroClient.Components
{
    using AstroClient.Moderation;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using MelonLoader;
    using System;
    using System.Collections.Generic;
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
            var p = gameObject.GetComponent<Player>();
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
                    if (CurrentRenderers == null && CurrentRenderers.Count() == 0)
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
                        for (int i = 0; i < CurrentRenderers.Count; i++)
                        {
                            var ObjRenderer = CurrentRenderers[i];
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
            if (!UseCustomColor || !CanEditValues) return;
            if (AssignedPlayer.GetAPIUser().IsFriend())
            {
                    CurrentColor = FriendColor;
                }
        }

        internal override void OnUnfriended()
        {
            if (!UseCustomColor || !CanEditValues) return;
            if (!AssignedPlayer.GetAPIUser().IsFriend())
            {
                    CurrentColor = PublicColor;
                }
            
        }

        internal override void OnPlayerBlockedYou(Photon.Realtime.Player player)
        {
            if (!UseCustomColor || !CanEditValues) return;

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
            if (!UseCustomColor || !CanEditValues) return;
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
            HighLightOptions.SetHighLighterColor(newcolor);
        }

        internal void ResetColor()
        {
            SetPlayerDefaultESP();
        }

        internal override void OnPublicESPColorChanged(Color color)
        {
            if (!UseCustomColor || !CanEditValues) return;
            if (!AssignedPlayer.GetAPIUser().IsFriend())
            {
                CurrentColor = color;
            }
        }
        internal override void OnFriendESPColorChanged(Color color)
        {
            if (!UseCustomColor || !CanEditValues) return;
            if (AssignedPlayer.GetAPIUser().IsFriend())
            {
                CurrentColor = color;
            }

        }


        internal override void OnBlockedESPColorChanged(Color color)
        {
            if (!UseCustomColor || !CanEditValues) return;

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

        private List<MeshRenderer> CurrentRenderers
        {
            get
            {
                if (SelectRegion != null)
                {
                    return SelectRegion.GetComponentsInChildren<MeshRenderer>(true).ToArray().ToList();
                }
                return null;
            }
        }

        private Transform SelectRegion { get; set; }
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