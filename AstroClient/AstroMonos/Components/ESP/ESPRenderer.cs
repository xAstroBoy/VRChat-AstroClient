using AstroClient.ClientActions;

namespace AstroClient.AstroMonos.Components.ESP
{
    using System;
    using System.Linq;
    using AstroClient.Tools.Colors;
    using AstroClient.Tools.Extensions;
    using ClientAttributes;
    using UnhollowerBaseLib.Attributes;
    using UnityEngine;

    [RegisterComponent]
    public class ESPRenderer : MonoBehaviour
    {
        public Il2CppSystem.Collections.Generic.List<MonoBehaviour> AntiGcList;

        public ESPRenderer(IntPtr obj0) : base(obj0)
        {
            AntiGcList = new Il2CppSystem.Collections.Generic.List<MonoBehaviour>(1);
            AntiGcList.Add(this);
        }

        private bool DebugMode = true;

        private void Debug(string msg)
        {
            if (DebugMode)
            {
                Log.Debug($"[ESPRenderer Debug] : {msg}");
            }
        }

        // Use this for initialization
        internal void Start()
        {
            ESPColor = DefaultColor;

            
        }




        internal Color GetCurrentESPColor
        {
            [HideFromIl2Cpp]
            get
            {
                return HighLightOptions.highlightColor;
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

        private void OnRoomLeft()
        {
            Destroy(this);
        }

        internal Color ESPColor { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        internal Color DefaultColor { [HideFromIl2Cpp] get; } = Color.yellow;

        internal HighlightsFXStandalone HighLightOptions { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
        private UnhollowerBaseLib.Il2CppArrayBase<MeshRenderer> ObjMeshRenderers;
    }
}