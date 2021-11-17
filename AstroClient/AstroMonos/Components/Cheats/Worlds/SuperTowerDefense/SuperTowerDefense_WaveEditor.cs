namespace AstroClient.AstroMonos.Components.Cheats.Worlds.SuperTowerDefense
{
    using System;
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.UdonEditor;
    using ClientAttributes;
    using UnhollowerBaseLib.Attributes;
    using WorldAddons.WorldsIds;
    using xAstroBoy.Utility;

    [RegisterComponent]
    public class SuperTowerDefense_WaveEditor : AstroMonoBehaviour
    {
        public SuperTowerDefense_WaveEditor(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        private Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object> AntiGarbageCollection = new Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object>();

        // Use this for initialization
        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.Super_Tower_defense))
            {
                var obj = gameObject.FindUdonEvent("AskForNewWave");
                if (obj != null) WaveController = obj.UdonBehaviour.DisassembleUdonBehaviour();
                else
                {
                    ModConsole.Error("Can't Find WaveController behaviour, Unable to Add Reader Component, did the author update the world?");
                    Destroy(this);
                }
            }
            else { Destroy(this); }
        }

        internal int? CurrentRound
        {
            [HideFromIl2Cpp]
            get
            {
                if (WaveController != null) return UdonHeapParser.Udon_Parse_Int32(WaveController, Wave);
                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (WaveController != null)
                {
                    if (value.HasValue) UdonHeapEditor.PatchHeap(WaveController, Wave, Math.Abs(value.Value), true);
                }
            }
        }

        private string Wave { [HideFromIl2Cpp] get; } = "Wave";

        private DisassembledUdonBehaviour WaveController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }
    }
}