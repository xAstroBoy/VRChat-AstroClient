namespace AstroClient.Components
{
	using AstroLibrary.Console;
	using AstroLibrary.Extensions;
	using System;
	using System.Linq;
	using UnhollowerBaseLib.Attributes;
	using UnityEngine;
	using VRC;
	using VRC.Management;

	public class PlayerESP : GameEventsBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public PlayerESP(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        private bool DebugMode = true;

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
                        foreach (var ObjRenderer in ObjRenderers)
                        {
                            if (ObjRenderer != null)
                            {
                                HighLightOptions.SetHighLighter(ObjRenderer, true);
                            }
                        }
                        foreach (var ObjMeshRenderer in ObjMeshRenderers)
                        {
                            if (ObjMeshRenderer != null)
                            {
                                HighLightOptions.SetHighLighter(ObjMeshRenderer, true);
                            }
                        }
                    }
                }
            }
        }

        public void LateUpdate()
        {
            if (!UseCustomColor)
            {
                if (HighLightOptions != null)
                {
                    if (AssignedPlayer != null)
                    {
                        if (AssignedPlayer.GetAPIUser() != null)
                        {
							if (ModerationManager.field_Private_Static_ModerationManager_0.GetIsBlockedEitherWay(AssignedPlayer.UserID()))
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
                }
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

        public void OnDestroy()
        {
            HighLightOptions.DestroyHighlighter();
        }

        public void OnEnable()
        {
            if (HighLightOptions != null)
            {
                foreach (var ObjRenderer in ObjRenderers)
                {
                    if (ObjRenderer != null)
                    {
                        HighLightOptions.SetHighLighter(ObjRenderer, true);
                    }
                }
                foreach (var ObjMeshRenderer in ObjMeshRenderers)
                {
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
            if (HighLightOptions != null)
            {
                if (AssignedPlayer != null)
                {
                    if (AssignedPlayer.GetAPIUser() != null)
                    {
						if (ModerationManager.field_Private_Static_ModerationManager_0.GetIsBlockedEitherWay(AssignedPlayer.UserID()))
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
            }
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

        private Transform SelectRegion;
        private UnhollowerBaseLib.Il2CppArrayBase<Renderer> ObjRenderers;
        private UnhollowerBaseLib.Il2CppArrayBase<MeshRenderer> ObjMeshRenderers;
        private HighlightsFXStandalone HighLightOptions;
        internal bool UseCustomColor { get; set; } = false;

        internal Player AssignedPlayer { get; private set; }
    }
}