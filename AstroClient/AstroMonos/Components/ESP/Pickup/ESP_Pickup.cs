using AstroClient.ClientActions;

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
    public class ESP_Pickup : MonoBehaviour
    {
        public List<MonoBehaviour> AntiGcList;

        private bool DebugMode = true;
        private Il2CppArrayBase<Renderer> ObjRenderers;

        public ESP_Pickup(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new List<MonoBehaviour>(1);
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
            ObjRenderers = gameObject.GetComponentsInChildren<Renderer>(true);
            if (ObjRenderers == null && ObjRenderers.Count() == 0)
            {
                Log.Error($"Unable to add ESP_Pickup to  {gameObject.name} due to Renderer Being null or empty");
                Destroy(this);
                return;
            }

            SetupHighlighter();
            HasSubscribed = true;
            for (var i = 0; i < ObjRenderers.Count; i++)
            {
                var obj = ObjRenderers[i];
                if (obj != null && obj.gameObject.active)
                    HighLightOptions.AddRenderer(obj);
                else
                    HighLightOptions.RemoveRenderer(obj);
            }
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

                        ClientEventActions.OnRoomLeft += OnRoomLeft;

                    }
                    else
                    {

                        ClientEventActions.OnRoomLeft -= OnRoomLeft;

                    }
                }
                _HasSubscribed = value;
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
            HasSubscribed = false;
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
                for (var i = 0; i < ObjRenderers.Count; i++)
                {
                    var obj = ObjRenderers[i];
                    if (obj != null && obj.gameObject.active)
                        HighLightOptions.AddRenderer(obj);
                    else
                        HighLightOptions.RemoveRenderer(obj);
                }
            }
        }
        private void OnRoomLeft()
        {
            Destroy(this);
            HasSubscribed = false;
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