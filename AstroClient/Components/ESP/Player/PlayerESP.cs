namespace AstroClient.Components
{
	using AstroLibrary.Console;
	using AstroClient.Extensions;
	using DayClientML2.Utility.Extensions;
	using System;
	using System.Linq;
	using UnhollowerBaseLib.Attributes;
	using UnityEngine;
	using VRC;
	using Object = UnityEngine.Object;

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
				player = p;
			}
			else
			{
				Object.Destroy(this);
			}
			if (player != null)
			{
				SelectRegion = player.transform.Find("SelectRegion");
				if (SelectRegion == null)
				{
					Object.Destroy(this);
				}
				else
				{
					Debug($"Found SelectRegion Transform Assigned in {player.DisplayName()}!");
					ObjRenderers = SelectRegion.GetComponentsInChildren<Renderer>(true);
					ObjMeshRenderers = SelectRegion.GetComponentsInChildren<MeshRenderer>(true);
					if (ObjMeshRenderers == null && ObjRenderers == null && ObjMeshRenderers.Count() == 0 && ObjRenderers.Count() == 0)
					{
						ModConsole.Error($"Failed to Generate a PlayerESP for Player {player.DisplayName()}, Due to SelectRegion Renderer Missing!");
						Object.Destroy(this);
						return;
					}
					else
					{
						Debug($"Found SelectRegion Renderer in {player.DisplayName()}, Activating ESP !");
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
					if (player != null)
					{
						if (player.GetAPIUser() != null)
						{
							if (player.GetAPIUser().GetIsFriend())
							{
                                if(HighLightOptions.highlightColor != FriendColor)
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
				if (player != null)
				{
					if (player.GetAPIUser() != null)
					{
						if (player.GetAPIUser().GetIsFriend())
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

		private Player player;
		private Transform SelectRegion;
		private UnhollowerBaseLib.Il2CppArrayBase<Renderer> ObjRenderers;
		private UnhollowerBaseLib.Il2CppArrayBase<MeshRenderer> ObjMeshRenderers;
		private HighlightsFXStandalone HighLightOptions;
		internal bool UseCustomColor { get; set; } = false;

		internal Player AssignedPlayer
		{
			get
			{
				return player;
			}
		}

	}
}