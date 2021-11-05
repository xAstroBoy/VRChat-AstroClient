using UnhollowerBaseLib.Attributes;

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
            [HideFromIl2Cpp]
            get
            {
                if (CurrentTower != null)
                {
                    return UdonHeapParser.Udon_Parse_single(CurrentTower, RangeAddress);
                }
                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (CurrentTower != null)
                {
                    if (value.HasValue)
                    {
                        UdonHeapEditor.PatchHeap(CurrentTower, RangeAddress, Math.Abs(value.Value), true);
                    }
                }
            }
        }

        internal float? SpeedMultiplier
        {
            [HideFromIl2Cpp]
            get
            {
                if (CurrentTower != null)
                {
                    return UdonHeapParser.Udon_Parse_single(CurrentTower, SpeedMultiplierAddress);
                }
                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (CurrentTower != null)
                {
                    if (value.HasValue)
                    {
                        UdonHeapEditor.PatchHeap(CurrentTower, SpeedMultiplierAddress, Math.Abs(value.Value), true);
                    }
                }
            }
        }

        private string SpeedMultiplierAddress { [HideFromIl2Cpp] get; } = "SpeedMultiplier";
        private string RangeAddress { [HideFromIl2Cpp] get; } = "Range";

        internal DisassembledUdonBehaviour CurrentTower { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }
    }
}