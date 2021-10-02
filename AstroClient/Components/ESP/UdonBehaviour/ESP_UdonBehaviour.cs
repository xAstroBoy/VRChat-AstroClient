namespace AstroClient.Components
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using System;
    using System.Linq;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;

    [RegisterComponent]
    public class ESP_UdonBehaviour : GameEventsBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public ESP_UdonBehaviour(IntPtr obj0) : base(obj0)
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
                ModConsole.DebugLog($"[ESP_UdonBehaviour Debug] : {msg}");
            }
        }

        // Use this for initialization
        internal void Start()
        {
            ESPColor = GetDefaultColor();
            ObjMeshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>(true);
            if (ObjMeshRenderers == null && ObjMeshRenderers.Count() == 0)
            {
                ModConsole.DebugError($"Unable to add ESP_UdonBehaviour to  {gameObject.name} due to MeshRenderer Being null or empty");
                Destroy(this);
                return;
            }
            SetupHighlighter();
            for (int i = 0; i < ObjMeshRenderers.Count; i++)
			{
				MeshRenderer obj = ObjMeshRenderers[i];
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

        private void SetupHighlighter()
        {
            if (HighLightOptions == null)
            {
                HighLightOptions = EspHelper.HighLightFXCamera.AddHighlighter();
            }
            if (HighLightOptions != null)
            {
                HighLightOptions.SetHighLighterColor(ESPColor);
                for (int i = 0; i < ObjMeshRenderers.Count; i++)
				{
					MeshRenderer obj = ObjMeshRenderers[i];
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

        private Color GetDefaultColor()
        {
            return ColorUtils.HexToColor("CD14C7");
        }

        internal void ResetColor()
        {
            ESPColor = GetDefaultColor();
            HighLightOptions?.SetHighLighterColor(GetDefaultColor());
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
            ESPColor = newcolor;
            HighLightOptions?.SetHighLighterColor(newcolor);
        }

        internal void ChangeColor(string HexColor)
        {
            Color hextocolor = ColorUtils.HexToColor(HexColor);
            ESPColor = hextocolor;
            HighLightOptions?.SetHighLighterColor(hextocolor);
        }

        internal Color GetCurrentESPColor
        {
            get
            {
                return HighLightOptions.highlightColor;
            }
        }

        internal Color ESPColor { get; private set; }
        internal HighlightsFXStandalone HighLightOptions { get; private set; }
        private UnhollowerBaseLib.Il2CppArrayBase<MeshRenderer> ObjMeshRenderers;
    }
}