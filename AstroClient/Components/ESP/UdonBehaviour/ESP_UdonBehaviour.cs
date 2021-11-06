namespace AstroClient.Components
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using System;
    using System.Linq;
    using UnityEngine;

    [RegisterComponent]
    public class ESP_UdonBehaviour : GameEventsBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;
        private Color DefaultColor = ColorUtils.HexToColor("CD14C7");

        public ESP_UdonBehaviour(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        private bool DebugMode = true;

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
            ESPColor = DefaultColor;
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
            HighLightOptions?.SetHighLighterColor(DefaultColor);
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

        internal Color GetCurrentESPColor
        {
            [HideFromIl2Cpp]
            get => HighLightOptions.highlightColor;
        }

        internal Color ESPColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal Color DefaultColor { [HideFromIl2Cpp] get; } = ColorUtils.HexToColor("CD14C7");

        internal HighlightsFXStandalone HighLightOptions { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        private UnhollowerBaseLib.Il2CppArrayBase<MeshRenderer> ObjMeshRenderers;
    }
}