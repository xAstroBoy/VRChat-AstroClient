namespace AstroClient.Components
{
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using System;
    using System.Linq;
    using UnityEngine;

    [RegisterComponent]
    public class ESP_ItemTweaker : GameEventsBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<GameEventsBehaviour> AntiGcList;
        internal Color ESPColor { get; private set; }
        internal HighlightsFXStandalone HighlightOptions { get; private set; }
        private UnhollowerBaseLib.Il2CppArrayBase<MeshRenderer> ObjMeshRenderers;
        private Color DefaultColor = Color.yellow;

        public ESP_ItemTweaker(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<GameEventsBehaviour>(1);
            AntiGcList.Add(this);
        }

        private bool DebugMode = true;

        private void Debug(string msg)
        {
            if (DebugMode)
            {
                ModConsole.DebugLog($"[ESP_Tweaker Debug] : {msg}");
            }
        }



        // Use this for initialization
            ESPColor = DefaultColor;
        {
            ESPColor = DefaultColor;
            ObjMeshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>(true);
            if (ObjMeshRenderers == null && ObjMeshRenderers.Count() == 0)
            {
                ModConsole.DebugError($"Unable to add ESP_Tweaker to {gameObject.name} due to MeshRenderer Being null or empty");
                Destroy(this);
                return;
            }
            SetupHighlighter();
        }

        private void SetupHighlighter()
        {
            HighlightOptions ??= EspHelper.HighlightFXCamera.AddHighlighter();
            if (HighlightOptions != null)
            {
                HighlightOptions.SetHighlighterColor(ESPColor);
                foreach (var obj in ObjMeshRenderers)
                {
                    if (obj != null && obj.gameObject.active)
                    {
                        HighlightOptions.AddRenderer(obj);
                    }
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
            ESPColor = GetDefaultColor();
            if (HighLightOptions != null)
            {
                HighLightOptions.SetHighLighterColor(GetDefaultColor());
            ESPColor = GetDefaultColor();
            if (HighLightOptions != null)
            {
                HighLightOptions.SetHighLighterColor(GetDefaultColor());
            ESPColor = GetDefaultColor();
            if (HighLightOptions != null)
            {
                HighLightOptions.SetHighLighterColor(GetDefaultColor());
            ESPColor = GetDefaultColor();
            if (HighLightOptions != null)
            {
                HighLightOptions.SetHighLighterColor(GetDefaultColor());
            {
                HighLightOptions.SetHighLighterColor(GetDefaultColor());
            }
        }

        internal void OnDestroy()
        {
            HighlightOptions.DestroyHighlighter();
        }

        internal void OnEnable()
        {
            SetupHighlighter();
        internal Color GetCurrentESPColor
        {
            [HideFromIl2Cpp]
            get => HighLightOptions.highlightColor;


        internal Color ESPColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal Color DefaultColor { [HideFromIl2Cpp] get; } = Color.yellow;

        internal HighlightsFXStandalone HighLightOptions { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        private UnhollowerBaseLib.Il2CppArrayBase<MeshRenderer> ObjMeshRenderers;
        }

        internal void ResetColor()
        {
            ChangeColor(DefaultColor);
        }

        internal Color GetCurrentESPColor
        {
            get
            {
                return HighLightOptions.highlightColor;
            }
        }

        internal Color ESPColor { get; private set; }
        internal HighlightsFXStandalone HighLightOptions { get; private set; }
        private UnhollowerBaseLib.Il2CppArrayBase<MeshRenderer> ObjMeshRenderers;
    }
}