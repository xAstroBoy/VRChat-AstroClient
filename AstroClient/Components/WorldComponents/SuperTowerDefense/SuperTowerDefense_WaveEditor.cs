namespace AstroClient.Components
{
    using AstroClient.Udon;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using System;
    using Variables;

    [RegisterComponent]
    public class SuperTowerDefense_WaveEditor : GameEventsBehaviour
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
                if (obj != null)
                {
                    WaveController = obj.UdonBehaviour.DisassembleUdonBehaviour();
                }
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
            get
            {
                if (WaveController != null)
                {
                    return UdonHeapParser.Udon_Parse_Int32(WaveController, Wave);
                }
                return null;
            }
            set
            {
                if (WaveController != null)
                {
                    if (value.HasValue)
                    {
                        UdonHeapEditor.PatchHeap(WaveController, Wave, value.Value, true);
                    }
                }
            }
        }

        private string Wave { get; } = "Wave";

        private DisassembledUdonBehaviour WaveController { get; set; }
    }
}