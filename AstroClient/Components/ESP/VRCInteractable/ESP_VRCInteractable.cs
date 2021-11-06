namespace AstroClient.Components
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using System;
    using System.Linq;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;

    [RegisterComponent]
    public class ESP_VRCInteractable : GameEventsBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;
        private Color DefaultColor = ColorUtils.HexToColor("E47D39");

        public ESP_VRCInteractable(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        private bool DebugMode = true;

        private void Debug(string msg)
        {
            if (DebugMode)
            {
                ModConsole.DebugLog($"[ESP_VRCInteractable Debug] : {msg}");
            }
        }

        // Use this for initialization
        internal void Start()
        {
            ESPColor = DefaultColor;
            ObjMeshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>(true);
            if (ObjMeshRenderers == null && ObjMeshRenderers.Count() == 0)
            {
                ModConsole.DebugError($"Unable to add ESP_VRCInteractable to  {gameObject.name} due to MeshRenderer Being null or empty");
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
            HighlightOptions ??= EspHelper.HighlightFXCamera.AddHighlighter();
            if (HighlightOptions != null)
            {
                HighlightOptions.SetHighlighterColor(ESPColor);
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

        internal void ResetColor()
        {
            ESPColor = DefaultColor;
            if (HighLightOptions != null)
            {
                HighLightOptions.SetHighLighterColor(DefaultColor);
            }
        }

        internal void OnDestroy()
        {
            HighlightOptions.DestroyHighlighter();
        }

        internal void OnEnable()
        {
            SetupHighlighter();
        }

        internal void OnDisable()
        {
            HighlightOptions.DestroyHighlighter();
        }

        internal void ChangeColor(Color newcolor)
        {
            ESPColor = newcolor;
            HighlightOptions?.SetHighlighterColor(newcolor);
        }

        internal void ResetColor()
        {
            ChangeColor(DefaultColor);
        }

        internal void ChangeColor(string HexColor)
        {
            [HideFromIl2Cpp]
            get => HighLightOptions.highlightColor;
            [HideFromIl2Cpp]
            set => HighLightOptions.highlightColor = value;
        }

        internal Color ESPColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal Color DefaultColor { [HideFromIl2Cpp] get; } = ColorUtils.HexToColor("E47D39");

        internal HighlightsFXStandalone HighLightOptions { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        private UnhollowerBaseLib.Il2CppArrayBase<MeshRenderer> ObjMeshRenderers;
    }
}