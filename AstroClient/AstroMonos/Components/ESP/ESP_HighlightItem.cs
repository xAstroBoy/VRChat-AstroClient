﻿namespace AstroClient.AstroMonos.Components.ESP
{
    using System;
    using System.Linq;
    using AstroClient.Tools.Colors;
    using AstroClient.Tools.Extensions;
    using ClientAttributes;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;

    [RegisterComponent]
    public class ESP_HighlightItem : AstroMonoBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<AstroMonoBehaviour> AntiGcList;

        public ESP_HighlightItem(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<AstroMonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        private bool DebugMode = true;

        private void Debug(string msg)
        {
            if (DebugMode)
            {
                ModConsole.DebugLog($"[ESP_HighlightItem Debug] : {msg}");
            }
        }

        // Use this for initialization
        internal void Start()
        {
            ESPColor = DefaultColor;
            ObjMeshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>(true);
            if (ObjMeshRenderers == null && ObjMeshRenderers.Count() == 0)
            {
                ModConsole.DebugError($"Unable to add ESP_HighlightItem to  {gameObject.name} due to MeshRenderer Being null or empty");
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

        //void OnBecameInvisible()
        //{
        //    HighLightOptions.enabled = false;
        //}
        //void OnBecameVisible()
        //{
        //    HighLightOptions.enabled = true;
        //}

        internal void ResetColor()
        {
            ESPColor = DefaultColor;
            HighLightOptions?.SetHighlighterColor(DefaultColor);
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
            HighLightOptions?.SetHighlighterColor(newcolor);
        }

        internal void ChangeColor(string HexColor)
        {
            Color hextocolor = ColorUtils.HexToColor(HexColor);
            ESPColor = hextocolor;
            HighLightOptions?.SetHighlighterColor(hextocolor);
        }

        internal Color GetCurrentESPColor
        {
            [HideFromIl2Cpp]
            get
            {
                return HighLightOptions.highlightColor;
            }
        }
        internal override void OnRoomLeft()
        {
            Destroy(this);
        }

        internal Color ESPColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal Color DefaultColor { [HideFromIl2Cpp] get; } = Color.yellow;

        internal HighlightsFXStandalone HighLightOptions { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        private UnhollowerBaseLib.Il2CppArrayBase<MeshRenderer> ObjMeshRenderers;
    }
}