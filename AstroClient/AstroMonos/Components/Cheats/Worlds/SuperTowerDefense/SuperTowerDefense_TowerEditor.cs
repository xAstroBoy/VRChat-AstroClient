namespace AstroClient.AstroMonos.Components.Cheats.Worlds.SuperTowerDefense
{
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.UdonEditor;
    using ClientAttributes;
    using Il2CppSystem;
    using Il2CppSystem.Collections.Generic;
    using UnhollowerBaseLib.Attributes;
    using WorldAddons.WorldsIds;
    using xAstroBoy.Utility;
    using IntPtr = System.IntPtr;
    using Math = System.Math;

    [RegisterComponent]
    public class SuperTowerDefense_TowerEditor : AstroMonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public SuperTowerDefense_TowerEditor(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        internal float? Range
        {
            [HideFromIl2Cpp]
            get
            {
                if (CurrentTower != null) return UdonHeapParser.Udon_Parse_single(CurrentTower, RangeAddress);
                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (CurrentTower != null)
                    if (value.HasValue)
                        UdonHeapEditor.PatchHeap(CurrentTower, RangeAddress, Math.Abs(value.Value), true);
            }
        }

        internal float? SpeedMultiplier
        {
            [HideFromIl2Cpp]
            get
            {
                if (CurrentTower != null) return UdonHeapParser.Udon_Parse_single(CurrentTower, SpeedMultiplierAddress);
                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (CurrentTower != null)
                    if (value.HasValue)
                        UdonHeapEditor.PatchHeap(CurrentTower, SpeedMultiplierAddress, Math.Abs(value.Value), true);
            }
        }

        private string SpeedMultiplierAddress { [HideFromIl2Cpp] get; } = "SpeedMultiplier";
        private string RangeAddress { [HideFromIl2Cpp] get; } = "Range";

        internal DisassembledUdonBehaviour CurrentTower { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

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
            else
            {
                Destroy(this);
            }
        }
    }
}