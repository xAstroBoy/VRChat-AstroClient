using UnhollowerBaseLib.Attributes; namespace AstroClient.components
{
	using AstroClient.ConsoleUtils;
	using AstroClient.extensions;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using UnhollowerBaseLib.Attributes;
	using UnityEngine;
	using Object = UnityEngine.Object;

	internal class ObjectESP : GameEventsBehaviour
	{
		internal Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

		internal ObjectESP(IntPtr obj0) : base(obj0)
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
				ModConsole.DebugLog($"[ObjectESP Debug] : {msg}");
			}
		}

		// Use this for initialization
		internal void Start()
		{
			ObjMeshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>(true).ToList();
			if (ObjMeshRenderers == null && ObjMeshRenderers.Count() == 0)
			{
				ModConsole.DebugError($"Unable to add ObjectESP to  {gameObject.name} due to MeshRenderer Being null or empty");
				Object.Destroy(this);
				return;
			}
			if (string.IsNullOrEmpty(Identifier) && string.IsNullOrWhiteSpace(Identifier))
			{
				Identifier = "NO_IDENTIFIER_SET";
			}
		}

		private void SetupHighlighter()
		{
			if (HighLightOptions == null)
			{
				HighLightOptions = EspHelper.HighLightFXCamera.AddHighlighter();
				if (HighLightOptions != null)
				{
					HighLightOptions.SetHighLighterColor(ESPColor);
				}
			}
		}

		internal void Update()
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
			HighLightOptions.ResetHighlighterColor();
		}

		internal void OnDestroy()
		{
			HighLightOptions.DestroyHighlighter();
		}

		internal void OnEnable()
		{
			SetupHighlighter();
		}

		internal void OnDisable()
		{
			HighLightOptions.DestroyHighlighter();
		}

		internal void ChangeColor(Color newcolor)
		{
			ESPColor = newcolor;
			if (HighLightOptions != null)
			{
				HighLightOptions.SetHighLighterColor(newcolor);
			}
		}

		internal void ChangeColor(string HexColor)
		{
			Color hextocolor = ColorUtils.HexToColor(HexColor);
			ESPColor = hextocolor;
			if (HighLightOptions != null)
			{
				HighLightOptions.SetHighLighterColor(hextocolor);
			}
		}

		internal Color GetCurrentESPColor
		{
			[HideFromIl2Cpp] get
			{
				return HighLightOptions.highlightColor;
			}
		}

		private string _Identifier;

		internal string Identifier
		{
			[HideFromIl2Cpp] get
			{
				return _Identifier;
			}
			[HideFromIl2Cpp] set
			{
				_Identifier = value;
				ModConsole.DebugLog($"Identifier for ObjectESP bound to {gameObject.name}, should be [HideFromIl2Cpp] set to {value} , currently _ID = {_Identifier}, Current ID {Identifier}");
			}
		}

		private Color ESPColor;
		private List<MeshRenderer> ObjMeshRenderers = new List<MeshRenderer>();
		private HighlightsFXStandalone HighLightOptions;
	}
}