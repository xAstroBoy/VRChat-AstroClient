namespace AstroClient.Components
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using System;
    using System.Linq;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;

    [RegisterComponent]
    public class ESP_Trigger : GameEventsBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;

        public ESP_Trigger(IntPtr obj0) : base(obj0)
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
                ModConsole.DebugLog($"[ESP_Trigger Debug] : {msg}");
            }
        }

        // Use this for initialization
        internal void Start()
        {
            ESPColor = GetDefaultColor();
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
                    HighLightOptions = EspHelper.HighLightFXCamera.AddHighlighter();
                }
                if (HighLightOptions != null)
                {
                    HighLightOptions.SetHighLighterColor(ESPColor);
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

        private Color GetDefaultColor()
        {
            return ColorUtils.HexToColor("EF2C3F");
        }

        internal void ResetColor()
        {
            ESPColor = GetDefaultColor();
            if (HighLightOptions != null)
            {
                HighLightOptions.SetHighLighterColor(GetDefaultColor());
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
            get
            {
                return HighLightOptions.highlightColor;
            }
        }

        internal VRC.SDKBase.VRC_Trigger trigger;
        internal VRCSDK2.VRC_Trigger trigger2;
        internal bool Lock = true;
        internal bool HasSetupESP = false;
        internal Color ESPColor { get; private set; }
        internal HighlightsFXStandalone HighLightOptions { get; private set; }
        private UnhollowerBaseLib.Il2CppArrayBase<MeshRenderer> ObjMeshRenderers;
    }
}