namespace AstroClient.Components
{
    using AstroClient.Udon;
    using System;
    using AstroLibrary.Extensions;
    using VRC.Udon;

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
            var Obj = this.gameObject.FindUdonEvent("AskForNewWave");
            if (Obj != null)
            {
                WaveController = Obj.UdonBehaviour.DisassembleUdonBehaviour();
            }
        }




        internal int? CurrentRound
        {
            get
            {
                if (WaveController != null)
                {
                    return UdonHeapParser.Udon_Parse_Int32(WaveController, Address);
                }
                return null;
            }
            set
            {
                if (WaveController != null)
                {
                    if (value.HasValue)
                    {
                        UdonHeapEditor.PatchHeap(WaveController, Address, value.Value, true);
                    }
                }
            }
        }

        
        private readonly string Address = "Wave";


        private DisassembledUdonBehaviour WaveController { get; set; }
    }
}