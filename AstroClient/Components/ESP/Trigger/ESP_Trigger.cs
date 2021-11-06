namespace AstroClient.Components
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using System;
    using System.Linq;
    using UnityEngine;

    [RegisterComponent]
    public class ESP_Trigger : GameEventsBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;
        private Color DefaultColor = ColorUtils.HexToColor("EF2C3F");

        public ESP_Trigger(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        private bool DebugMode = true;

        private void Debug(string msg)
        {
            if (DebugMode)
            {
                ModConsole.DebugLog($"[ESP_Trigger Debug] : {msg}");
            }
        }

        // Use this for initialization
        internal void Start()
        {
            ESPColor = DefaultColor;
            ObjMeshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>(true);
            if (ObjMeshRenderers == null && ObjMeshRenderers.Count() == 0)
            {
                ModConsole.DebugError($"Unable to add ESP_Trigger to  {gameObject.name} due to MeshRenderer Being null or empty");
                Destroy(this);
                return;
            }
            SetupHighlighter();

            foreach (var obj in ObjMeshRenderers)
            {
                if (obj != null && obj.gameObject.active) HighlightOptions.AddRenderer(obj);
                else HighlightOptions.RemoveRenderer(obj);
            }
        }

        private void SetupHighlighter()
        {
            if (!HasSetupESP)
            {
                HighlightOptions ??= HighlightOptions = EspHelper.HighlightFXCamera.AddHighlighter();
                if (HighlightOptions != null)
                {
                    HighlightOptions.SetHighlighterColor(ESPColor);
                    foreach (var obj in ObjMeshRenderers)
                    {
                        if (obj != null && obj.gameObject.active) HighlightOptions.AddRenderer(obj);
                        else HighlightOptions.RemoveRenderer(obj);
                    }
                }
                HasSetupESP = true;
            }
        }

        internal void FixedUpdate()
        {
            if (!Lock)
            {
                if (trigger != null)
                {
                    if (trigger.enabled) SetupHighlighter();
                    else
                    {
                        HighlightOptions.DestroyHighlighter();
                        HasSetupESP = false;
                    }
                }
                else if (trigger2 != null)
                {
                    if (trigger2.enabled) SetupHighlighter();
                    else
                    {
                        HighlightOptions.DestroyHighlighter();
                        HasSetupESP = false;
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

        internal Color GetCurrentESPColor
        {
            [HideFromIl2Cpp]
            get => HighLightOptions.highlightColor;
        }

        internal VRC.SDKBase.VRC_Trigger trigger;
        internal VRCSDK2.VRC_Trigger trigger2;
        internal bool Lock = true;
        internal bool HasSetupESP = false;
        internal Color ESPColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal Color DefaultColor { [HideFromIl2Cpp] get; } = ColorUtils.HexToColor("EF2C3F");

        internal HighlightsFXStandalone HighLightOptions { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        private UnhollowerBaseLib.Il2CppArrayBase<MeshRenderer> ObjMeshRenderers;
    }
}