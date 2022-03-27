﻿namespace AstroClient.AstroMonos.Components.Cheats.Worlds.SuperTowerDefense
{
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.UdonEditor;
    using ClientAttributes;
    using Il2CppSystem;
    using Il2CppSystem.Collections.Generic;
    using UnhollowerBaseLib.Attributes;
    using WorldModifications.WorldsIds;
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

        internal override void OnRoomLeft()
        {
            Destroy(this);
        }

        internal float? Range
        {
            [HideFromIl2Cpp]
            get
            {
                if (CurrentTower != null) return UdonHeapParser.Udon_Parse<float>(CurrentTower, RangeAddress);
                return null;
            }
            [HideFromIl2Cpp]
            private set
            {
                if (CurrentTower != null)
                {
                    if (value.HasValue)
                    {
                        var fixedvalue = Math.Abs(value.GetValueOrDefault(0));
                        if (fixedvalue != 0)
                        {
                            UdonHeapEditor.PatchHeap(CurrentTower, RangeAddress, fixedvalue);
                        }
                    }
                }
            }
        }

        internal void BackupAndModifyRange(float value)
        {
            if (Range.HasValue)
            {
                if (!HasModifiedRange)
                {
                    OriginalRange = Range.Value;
                    HasModifiedRange = true;
                }
            }
            Range = value;
        }

        internal void RestoreRange()
        {
            if (HasModifiedRange)
            {
                Range = OriginalRange;
                HasModifiedRange = false;
            }
        }

        private bool HasModifiedRange { get; set; }
        private float OriginalRange { get; set; }

        internal float? SpeedMultiplier
        {
            [HideFromIl2Cpp]
            get
            {
                if (CurrentTower != null) return UdonHeapParser.Udon_Parse<float>(CurrentTower, SpeedMultiplierAddress);
                return null;
            }
            [HideFromIl2Cpp]

            private set
            {
                if (CurrentTower != null)
                {
                    if (value.HasValue)
                    {
                        var fixedvalue = Math.Abs(value.GetValueOrDefault(0));
                        if (fixedvalue != 0)
                        {
                            UdonHeapEditor.PatchHeap(CurrentTower, SpeedMultiplierAddress, Math.Abs(value.Value));
                        }
                    }
                }
            }
        }
        internal void BackupAndModifySpeedMultiplier(float value)
        {
            if (SpeedMultiplier.HasValue)
            {
                if (!HasModifiedSpeedMultiplier)
                {
                    OriginalSpeedMultiplier = SpeedMultiplier.Value;
                    HasModifiedSpeedMultiplier = true;
                }
            }
            SpeedMultiplier = value;
        }

        internal void RestoreSpeedMultiplier()
        {
            if (HasModifiedSpeedMultiplier)
            {
                SpeedMultiplier = OriginalSpeedMultiplier;
                HasModifiedSpeedMultiplier = false;
            }
        }

        private bool HasModifiedSpeedMultiplier { get; set; }
        private float OriginalSpeedMultiplier { get; set; }

        private string SpeedMultiplierAddress { [HideFromIl2Cpp] get; } = "SpeedMultiplier";
        private string RangeAddress { [HideFromIl2Cpp] get; } = "Range";

        internal RawUdonBehaviour CurrentTower { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        // Use this for initialization
        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.Super_Tower_defense))
            {
                var obj = gameObject.FindUdonEvent("SetTowerBehaviour");
                if (obj != null)
                {
                    CurrentTower = obj.UdonBehaviour.ToRawUdonBehaviour();
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