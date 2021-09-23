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
    public class PlayerESP : GameEventsBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public PlayerESP(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
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
        public void Start()
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
                    ObjMeshRenderers = SelectRegion.GetComponentsInChildren<MeshRenderer>(true);
                    if (ObjMeshRenderers == null && ObjRenderers == null && ObjMeshRenderers.Count() == 0 && ObjRenderers.Count() == 0)
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
                        for (int i = 0; i < ObjMeshRenderers.Count; i++)
                        {
                            MeshRenderer ObjMeshRenderer = ObjMeshRenderers[i];
                            if (ObjMeshRenderer != null)
                            {
                                HighLightOptions.SetHighLighter(ObjMeshRenderer, true);
                            }
                        }
                    }
                }
                SetPlayerDefaultESP();
                //RoutineCancellationToken = MelonCoroutines.Start(StartUpdater());
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

        private Color ESPColor
        {
            get
            {
                return ConfigManager.PublicESPColor;
            }
        }

        public override void OnFriended()
        {
            if (!UseCustomColor)
            {
                SetPlayerDefaultESP();
            }
        }

        public override void OnUnfriended()
        {
            if (!UseCustomColor)
            {
                SetPlayerDefaultESP();
            }
        }

        public override void OnPlayerBlockedYou(Photon.Realtime.Player player)
        {
            if (!UseCustomColor)
            {
                SetPlayerDefaultESP();
            }
        }

        public override void OnPlayerUnblockedYou(Photon.Realtime.Player player)
        {
            if (!UseCustomColor)
            {
                SetPlayerDefaultESP();
            }

        }


        public void OnDestroy()
        {
            HighLightOptions.DestroyHighlighter();
            if (RoutineCancellationToken != null)
            {
                MelonCoroutines.Stop(RoutineCancellationToken);
            }
        }

        public void OnEnable()
        {
            if (HighLightOptions != null)
            {
                for (int i = 0; i < ObjRenderers.Count; i++)
                {
                    Renderer ObjRenderer = ObjRenderers[i];
                    if (ObjRenderer != null)
                    {
                        HighLightOptions.SetHighLighter(ObjRenderer, true);
                    }
                }
                for (int i = 0; i < ObjMeshRenderers.Count; i++)
                {
                    MeshRenderer ObjMeshRenderer = ObjMeshRenderers[i];
                    if (ObjMeshRenderer != null)
                    {
                        HighLightOptions.SetHighLighter(ObjMeshRenderer, true);
                    }
                }
            }
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

        private void SetPlayerDefaultESP()
        {
            if (HighLightOptions != null && AssignedPlayer != null && AssignedPlayer.GetAPIUser() != null)
            {
                if (AssignedPlayer.GetAPIUser().HasBlockedYou())
                {
                    if (HighLightOptions.highlightColor != BlockedColor)
                    {
                        HighLightOptions.highlightColor = BlockedColor;
                    }
                }
                else if (AssignedPlayer.GetAPIUser().GetIsFriend())
                {
                    if (HighLightOptions.highlightColor != FriendColor)
                    {
                        HighLightOptions.highlightColor = FriendColor;
                    }
                }
                else
                {
                    if (HighLightOptions.highlightColor != ESPColor)
                    {
                        HighLightOptions.highlightColor = ESPColor;
                    }
                }
            }
        }

        private Transform SelectRegion;
        private UnhollowerBaseLib.Il2CppArrayBase<Renderer> ObjRenderers;
        private UnhollowerBaseLib.Il2CppArrayBase<MeshRenderer> ObjMeshRenderers;
        private HighlightsFXStandalone HighLightOptions;
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
        internal object RoutineCancellationToken { get; private set; }
    }
}