namespace AstroClient.AstroMonos.Components.ESP.Pickup
{
    using System;
    using System.Linq;
    using AstroClient.Tools.Colors;
    using AstroClient.Tools.Extensions;
    using ClientAttributes;
    using Il2CppSystem.Collections.Generic;
    using UnhollowerBaseLib;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;

    [RegisterComponent]
    public class ESP_Pickup : AstroMonoBehaviour
    {
        public List<AstroMonoBehaviour> AntiGcList;

        private bool DebugMode = true;
        private Il2CppArrayBase<MeshRenderer> ObjMeshRenderers;

        public ESP_Pickup(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<AstroMonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        internal Color GetCurrentESPColor
        {
            [HideFromIl2Cpp] get => HighLightOptions.highlightColor;
        }

        internal Color ESPColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal Color DefaultColor { [HideFromIl2Cpp] get; } = ColorUtils.HexToColor("4AB30D");

        internal HighlightsFXStandalone HighLightOptions { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

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
            for (var i = 0; i < ObjMeshRenderers.Count; i++)
            {
                var obj = ObjMeshRenderers[i];
                if (obj != null && obj.gameObject.active)
                    HighLightOptions.AddRenderer(obj);
                else
                    HighLightOptions.RemoveRenderer(obj);
            }
        }

        internal void OnEnable()
        {
            HighLightOptions.enabled = true;
        }

        internal void OnDisable()
        {
            HighLightOptions.enabled = false;
        }

        internal void OnDestroy()
        {
            HighLightOptions.DestroyHighlighter();
        }

        private void Debug(string msg)
        {
            if (DebugMode) Log.Debug($"[ESP_Pickup Debug] : {msg}");
        }

        private void SetupHighlighter()
        {
            if (HighLightOptions == null) HighLightOptions = EspHelper.HighlightFXCamera.AddHighlighter();

            if (HighLightOptions != null)
            {
                HighLightOptions.SetHighlighterColor(ESPColor);
                for (var i = 0; i < ObjMeshRenderers.Count; i++)
                {
                    var obj = ObjMeshRenderers[i];
                    if (obj != null && obj.gameObject.active)
                        HighLightOptions.AddRenderer(obj);
                    else
                        HighLightOptions.RemoveRenderer(obj);
                }
            }
        }
        internal override void OnRoomLeft()
        {
            Destroy(this);
        }

        internal void ChangeColor(Color newcolor)
        {
            ESPColor = newcolor;
            if (HighLightOptions != null) HighLightOptions.highlightColor = newcolor;
        }

        internal void ResetColor()
        {
            ESPColor = DefaultColor;
            if (HighLightOptions != null) HighLightOptions.SetHighlighterColor(DefaultColor);
        }
    }
}