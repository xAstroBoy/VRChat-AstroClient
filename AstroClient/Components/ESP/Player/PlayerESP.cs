namespace AstroClient.Components
{
    using AstroClient.Moderation;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
    using VRC;

    [RegisterComponent]
    public class PlayerESP : EspEvents
    {
        public Il2CppSystem.Collections.Generic.List<EspEvents> AntiGcList;

        public PlayerESP(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<EspEvents>(1);
            AntiGcList.Add(this);
        }

        // Use this for initialization
        internal void Start()
        {
            // FIND ALLOCATED PLAYER
            var p = gameObject.GetComponent<Player>();
            if (p != null) AssignedPlayer = p;
            else Destroy(this);

            if (AssignedPlayer != null)
            {
                SelectRegion = AssignedPlayer.transform.Find("SelectRegion");
                if (SelectRegion == null) Destroy(this);
                else
                {
                    if (CurrentRenderers == null && CurrentRenderers.Count() == 0)
                    {
                        ModConsole.Error($"Failed to Generate a PlayerESP for Player {AssignedPlayer.DisplayName()}, Due to SelectRegion Renderer Missing!");
                        Destroy(this);
                        return;
                    }
                    else
                    {
                        HighlightOptions ??= HighlightOptions = EspHelper.HighlightFXCamera.AddHighlighter();

                        for (int i = 0; i < CurrentRenderers.Count; i++)
                        {
                            var ObjRenderer = CurrentRenderers[i];
                            if (ObjRenderer != null) HighlightOptions.SetHighlighter(ObjRenderer, true);
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
            get => ConfigManager.ESPFriendColor;
        }

        private Color PublicColor
        {
            [HideFromIl2Cpp]
            get => ConfigManager.PublicESPColor;
        }

        internal override void OnFriended()
        {
            if (!CanActuallyEditOnEvent) return;
            if (AssignedPlayer.GetAPIUser().IsFriend()) CurrentColor = FriendColor;
        }

        internal override void OnUnfriended()
        {
            if (!CanActuallyEditOnEvent) return;
            if (!AssignedPlayer.GetAPIUser().IsFriend()) CurrentColor = PublicColor;
            
        }

        internal override void OnPlayerBlockedYou(Photon.Realtime.Player player)
        {
            if (!CanActuallyEditOnEvent) return;
            if (player.GetUserID().Equals(AssignedPlayer.GetUserID()) && !UseCustomColor) CurrentColor = ConfigManager.ESPBlockedColor;
        }

        internal override void OnPlayerUnblockedYou(Photon.Realtime.Player player)
        {
            if (!CanActuallyEditOnEvent) return;
            if (player.GetUserID().Equals(AssignedPlayer.GetUserID()))
            {
                if (AssignedPlayer.GetAPIUser().IsFriend()) CurrentColor = ConfigManager.ESPFriendColor;
                else CurrentColor = ConfigManager.PublicESPColor;
            }
        }

        internal void OnDestroy()
        {
            HighlightOptions.DestroyHighlighter();
        }

        internal void OnEnable()
        {
            HighlightOptions.enabled = true;
        }

        internal void OnDisable()
        {
            HighlightOptions.enabled = false;
        }

        internal void ChangeColor(Color newcolor)
        {
            HighlightOptions?.SetHighlighterColor(newcolor);
        }

        internal void ResetColor()
        {
            SetPlayerDefaultESP();
        }

        internal override void OnPublicESPColorChanged(Color color)
        {
            if (!AssignedPlayer.GetAPIUser().IsFriend()) CurrentColor = color;
        }

        }
        internal override void OnFriendESPColorChanged(Color color)
        {
            if (AssignedPlayer.GetAPIUser().IsFriend()) CurrentColor = color;
        }


        internal override void OnBlockedESPColorChanged(Color color)
        {
            if (!CanActuallyEditOnEvent) return;
            if (AssignedPlayer.GetAPIUser().HasBlockedYou() && CurrentColor.HasValue) CurrentColor = color;
        }

        private void SetPlayerDefaultESP()
        {
            if (CanEditValues)
            {
                if (AssignedPlayer.GetAPIUser().HasBlockedYou()) CurrentColor = ConfigManager.ESPBlockedColor;
                else if (AssignedPlayer.GetAPIUser().GetIsFriend()) CurrentColor = ConfigManager.ESPFriendColor;
                else CurrentColor = ConfigManager.PublicESPColor;
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
                return HighlightOptions != null && AssignedPlayer != null && AssignedPlayer.GetAPIUser() != null && CurrentColor.HasValue;
            }
        }

        private List<MeshRenderer> CurrentRenderers
        {
            [HideFromIl2Cpp]
            get
            {
                if (SelectRegion != null) return SelectRegion.GetComponentsInChildren<MeshRenderer>(true).ToList();
                return null;
            }
        }
        private Transform SelectRegion { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private HighlightsFXStandalone HighLightOptions { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
        private HighlightsFXStandalone HighLightOptions { get; set; }
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
                if (value == _UseCustomColor) return;
                if (!value) SetPlayerDefaultESP();
                _UseCustomColor = value;
            }
        }

        internal Player AssignedPlayer { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
    }
}