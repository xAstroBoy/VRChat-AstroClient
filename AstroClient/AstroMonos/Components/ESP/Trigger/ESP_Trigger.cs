namespace AstroClient.AstroMonos.Components.ESP.Trigger
{
    using System;
    using System.Linq;
    using AstroClient.Tools.Colors;
    using AstroClient.Tools.Extensions;
    using ClientAttributes;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;

    [RegisterComponent]
    public class ESP_Trigger : AstroMonoBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<AstroMonoBehaviour> AntiGcList;

        public ESP_Trigger(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<AstroMonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        private bool DebugMode = true;

        private void Debug(string msg)
        {
            if (DebugMode)
            {
                Log.Debug($"[ESP_Trigger Debug] : {msg}");
            }
        }

        // Use this for initialization
        internal void Start()
        {
            ESPColor = DefaultColor;
            ObjMeshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>(true);
            if (ObjMeshRenderers == null && ObjMeshRenderers.Count() == 0)
            {
                Log.Error($"Unable to add ESP_Trigger to  {gameObject.name} due to MeshRenderer Being null or empty");
                Destroy(this);
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

        private void SetupHighlighter()
        {
            if (!HasSetupESP)
            {
                if (HighLightOptions == null)
                {
                    HighLightOptions = EspHelper.HighlightFXCamera.AddHighlighter();
                }
                if (HighLightOptions != null)
                {
                    HighLightOptions.SetHighlighterColor(ESPColor);
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
                HasSetupESP = true;
            }
        }

        internal void FixedUpdate()
        {
            if (!Lock)
            {
                if (trigger != null)
                {
                    if (trigger.enabled)
                    {
                        SetupHighlighter();
                    }
                    else
                    {
                        HighLightOptions.DestroyHighlighter();
                        HasSetupESP = false;
                    }
                }
                else if (trigger2 != null)
                {
                    if (trigger2.enabled)
                    {
                        SetupHighlighter();
                    }
                    else
                    {
                        HighLightOptions.DestroyHighlighter();
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
                HighLightOptions.SetHighlighterColor(DefaultColor);
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
                HighLightOptions.SetHighlighterColor(newcolor);
            }
        }

        internal void ChangeColor(string HexColor)
        {
            Color hextocolor = ColorUtils.HexToColor(HexColor);
            ESPColor = hextocolor;
            if (HighLightOptions != null)
            {
                HighLightOptions.SetHighlighterColor(hextocolor);
            }
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