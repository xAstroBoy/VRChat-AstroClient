namespace AstroClient.Components
{
    using AstroClient.Udon;
    using System;
    using AstroLibrary.Extensions;
    using VRC.Udon;

    [RegisterComponent]
    public class SuperTowerDefense_TowerEditor : GameEventsBehaviour
    {
        public SuperTowerDefense_TowerEditor(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        private Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object> AntiGarbageCollection = new Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object>();

        // Use this for initialization
        internal void Start()
        {
            var obj = this.gameObject.FindUdonEvent("SetTowerBehaviour");
            if (obj != null)
            {
                CurrentTower = obj.UdonBehaviour.DisassembleUdonBehaviour();
            }
        }






        internal float? Range
        {
            get
            {
                if (CurrentTower != null)
                {
                    return UdonHeapParser.Udon_Parse_single(CurrentTower, RangeAddress);
                }
                return null;
            }
            set
            {
                if (CurrentTower != null)
                {
                    if (value.HasValue)
                    {
                        AstroClient.UdonHeapEditor.PatchHeap(CurrentTower, RangeAddress, value.Value, true);
                    }
                }
            }
        }


        internal float? SpeedMultiplier
        {
            get
            {
                if (CurrentTower != null)
                {
                    return UdonHeapParser.Udon_Parse_single(CurrentTower, SpeedMultiplierAddress);
                }
                return null;
            }
            set
            {
                if (CurrentTower != null)
                {
                    if (value.HasValue)
                    {
                        AstroClient.UdonHeapEditor.PatchHeap(CurrentTower, SpeedMultiplierAddress, value.Value, true);
                    }
                }
            }
        }


        private readonly string SpeedMultiplierAddress = "SpeedMultiplier";
        private readonly string RangeAddress = "Range";


        internal DisassembledUdonBehaviour CurrentTower { get; private set; }
    }
}