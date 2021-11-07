namespace AstroClient.AstroMonos.Components.ESP.Pickup
{
    using System;
    using System.Linq;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using CustomMono;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;

    [RegisterComponent]
    public class ESP_Pickup : GameEventsBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public ESP_Pickup(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        private bool DebugMode = true;

        private void Debug(string msg)
        {
            if (DebugMode)
            {
                ModConsole.DebugLog($"[ESP_Pickup Debug] : {msg}");
            }
        }

        // Use this for initialization
        internal void Start()
        {
            ESPColor = DefaultColor;
            ObjMeshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>(true);
            if (ObjMeshRenderers == null && ObjMeshRenderers.Count() == 0)
            {
                ModConsole.DebugError($"Unable to add ESP_Pickup to  {gameObject.name} due to MeshRenderer Being null or empty");
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
                HighLightOptions = EspHelper.HighlightFXCamera.AddHighlighter();
            }

            if (HighLightOptions != null)
            {
                HighLightOptions.SetHighlighterColor(ESPColor);
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
            if (HighLightOptions != null)
            {
                HighLightOptions.highlightColor = newcolor;
            }
        }

        internal void ResetColor()
        {
            ESPColor = DefaultColor;
            if (HighLightOptions != null)
            {
                HighLightOptions.SetHighlighterColor(DefaultColor);
            }
        }

        internal Color GetCurrentESPColor
        {
            [HideFromIl2Cpp]
            get { return HighLightOptions.highlightColor; }
        }

        internal Color ESPColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal Color DefaultColor { [HideFromIl2Cpp] get; } = ColorUtils.HexToColor("4AB30D");

        internal HighlightsFXStandalone HighLightOptions { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        private UnhollowerBaseLib.Il2CppArrayBase<MeshRenderer> ObjMeshRenderers;
    }
}