namespace AstroClient.Components
{
	using AstroLibrary.Console;
	using AstroClient.Extensions;
	using System;
	using System.Linq;
	using UnhollowerBaseLib.Attributes;
	using UnityEngine;
	using Object = UnityEngine.Object;

	public class ESP_VRCInteractable : GameEventsBehaviour
	{
		public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

		public ESP_VRCInteractable(IntPtr obj0) : base(obj0)
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
				ModConsole.DebugLog($"[ESP_VRCInteractable Debug] : {msg}");
			}
		}

		// Use this for initialization
		public void Start()
		{
			SetColor = GetDefaultColor();
			ObjMeshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>(true);
			if (ObjMeshRenderers == null && ObjMeshRenderers.Count() == 0)
			{
				ModConsole.DebugError($"Unable to add ESP_VRCInteractable to  {gameObject.name} due to MeshRenderer Being null or empty");
				Object.Destroy(this);
				return;
			}
			SetupHighlighter();
			foreach (var obj in ObjMeshRenderers)
			{
				if (obj != null && obj.gameObject.active)
				{
					HighLightOptions.AddRenderer(obj);
				}
				else
				{
					HighLightOptions.RemoveRenderer(obj);
				}
			}

		}


		private Color GetDefaultColor()
		{
			return ColorUtils.HexToColor("E47D39");
		}
		private void SetupHighlighter()
		{
			if (HighLightOptions == null)
			{
				HighLightOptions = EspHelper.HighLightFXCamera.AddHighlighter();
			}
			if (HighLightOptions != null)
			{
				HighLightOptions.SetHighLighterColor(SetColor);
			}
		}

		public void Update()
		{
			if (HighLightOptions == null)
			{
				SetupHighlighter();
			}
			if (HighLightOptions != null)
			{
				// CHECK FOR INTERNAL MESH RENDERERS IF ACTIVE OR DEACTIVE AND ACT ACCORDINGLY BY ADDING/REMOVING IT.
				foreach (var obj in ObjMeshRenderers)
				{
					if (obj != null && obj.gameObject.active)
					{
						HighLightOptions.AddRenderer(obj);
					}
					else
					{
						HighLightOptions.RemoveRenderer(obj);
					}
				}
			}
		}

		internal void ResetColor()
		{
			SetColor = GetDefaultColor();
			if (HighLightOptions != null)
			{
				HighLightOptions.SetHighLighterColor(GetDefaultColor());
			}
		}

		public void OnDestroy()
		{
			HighLightOptions.DestroyHighlighter();
		}

		public void OnEnable()
		{
			SetupHighlighter();
		}

		public void OnDisable()
		{
			HighLightOptions.DestroyHighlighter();
		}

		internal void ChangeColor(Color newcolor)
		{
			SetColor = newcolor;
			if (HighLightOptions != null)
			{
				HighLightOptions.SetHighLighterColor(newcolor);
			}
		}

		internal void ChangeColor(string HexColor)
		{
			Color hextocolor = ColorUtils.HexToColor(HexColor);
			SetColor = hextocolor;
			if (HighLightOptions != null)
			{
				HighLightOptions.SetHighLighterColor(hextocolor);
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


		internal Color SetColor { get; private set; }
		internal HighlightsFXStandalone HighLightOptions { get; private set; }
		private UnhollowerBaseLib.Il2CppArrayBase<MeshRenderer> ObjMeshRenderers;
	}
}