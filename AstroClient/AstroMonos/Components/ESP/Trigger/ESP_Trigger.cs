using AstroClient.ClientActions;

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
    public class ESP_Trigger : MonoBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<MonoBehaviour> AntiGcList;

        public ESP_Trigger(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<MonoBehaviour>(1);
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
            ObjMeshRenderers = gameObject.GetComponentsInChildren<Renderer>(true);
            if (ObjMeshRenderers == null && ObjMeshRenderers.Count() == 0)
            {
                Log.Error($"Unable to add ESP_Trigger to  {gameObject.name} due to MeshRenderer Being null or empty");
                Destroy(this);
                return;
            }

            SetupHighlighter();
            HasSubscribed = true;
            for (int i = 0; i < ObjMeshRenderers.Count; i++)
            {
                Renderer obj = ObjMeshRenderers[i];
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
                    for (int i = 0; i < ObjMeshRenderers.Count; i++)
                    {
                        Renderer obj = ObjMeshRenderers[i];
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
            HasSubscribed = false;
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
        private void OnRoomLeft()
        {
            Destroy(this);
        }
        private bool _HasSubscribed = false;
        private bool HasSubscribed
        {
            [HideFromIl2Cpp]
            get => _HasSubscribed;
            [HideFromIl2Cpp]
            set
            {
                if (_HasSubscribed != value)
                {
                    if (value)
                    {

                        ClientEventActions.Event_OnRoomLeft += OnRoomLeft;

                    }
                    else
                    {

                        ClientEventActions.Event_OnRoomLeft -= OnRoomLeft;

                    }
                }
                _HasSubscribed = value;
            }
        }


        internal VRC.SDKBase.VRC_Trigger trigger;
        internal VRCSDK2.VRC_Trigger trigger2;
        internal bool Lock = true;
        internal bool HasSetupESP = false;
        internal Color ESPColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal Color DefaultColor { [HideFromIl2Cpp] get; } = ColorUtils.HexToColor("EF2C3F");

        internal HighlightsFXStandalone HighLightOptions { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        private UnhollowerBaseLib.Il2CppArrayBase<Renderer> ObjMeshRenderers;
    }
}