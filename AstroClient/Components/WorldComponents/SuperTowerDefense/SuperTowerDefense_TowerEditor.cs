namespace AstroClient.Components
{
    using AstroClient.Udon;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using System;
    using Variables;

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
            if (WorldUtils.WorldID.Equals(WorldIds.Super_Tower_defense))
            {
                var obj = gameObject.FindUdonEvent("SetTowerBehaviour");
                if (obj != null)
                {
                    CurrentTower = obj.UdonBehaviour.DisassembleUdonBehaviour();
                }
                else
                {
                    ModConsole.Error("Can't Find CurrentTower behaviour, Unable to Add Reader Component, did the author update the world?");
                    Destroy(this);
                }
            }
            else { Destroy(this); }
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
                        if (value.Value > 0)
                        {
                            UdonHeapEditor.PatchHeap(CurrentTower, RangeAddress, value.Value, true);
                        }
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
                        if (value.Value > 0)
                        {
                            UdonHeapEditor.PatchHeap(CurrentTower, SpeedMultiplierAddress, value.Value, true);
                        }
                    }
                }
            }
        }

        private string SpeedMultiplierAddress { get; } = "SpeedMultiplier";
        private string RangeAddress { get; } = "Range";

        internal DisassembledUdonBehaviour CurrentTower { get; private set; }
    }
}