using AstroClient.ClientActions;
using UnityEngine;

namespace AstroClient.AstroMonos.Components.Cheats.Worlds.SuperTowerDefense
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
    public class SuperTowerDefense_TowerEditor : MonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public SuperTowerDefense_TowerEditor(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
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


        private void Init()
        {
            Private__SpeedMultiplier = new AstroUdonVariable<float>(CurrentTower, "SpeedMultiplier");
            Private__Range = new AstroUdonVariable<float>(CurrentTower,  "Range");

        }
        void OnDestroy()
        {
            HasSubscribed = false;
            Private__SpeedMultiplier = null;
            Private__Range = null;
        }

        private void OnRoomLeft()
        {
            Destroy(this);
        }
        internal float? Range
        {
            [HideFromIl2Cpp]
            get
            {
                if (Private__Range != null) return Private__Range.Value;
                return null;
            }
            [HideFromIl2Cpp]
            private set
            {
                if (Private__Range != null)
                {
                    if (value.HasValue)
                    {
                        var fixedvalue = Math.Abs(value.GetValueOrDefault(0));
                        if (fixedvalue != 0)
                        {
                            Private__Range.Value = Math.Abs(value.Value);
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
                if(Private__SpeedMultiplier != null) return Private__SpeedMultiplier.Value;
                return null;
            }
            [HideFromIl2Cpp]

            private set
            {
                if (Private__SpeedMultiplier != null)
                {
                    if (value.HasValue)
                    {
                        var fixedvalue = Math.Abs(value.GetValueOrDefault(0));
                        if (fixedvalue != 0)
                        {
                            Private__SpeedMultiplier.Value = Math.Abs(value.Value);
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
        private AstroUdonVariable<float> Private__SpeedMultiplier { [HideFromIl2Cpp] get;[HideFromIl2Cpp]  set; }
        private AstroUdonVariable<float> Private__Range { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        internal RawUdonBehaviour CurrentTower { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        // Use this for initialization
        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.Super_Tower_defense))
            {
                var obj = gameObject.FindUdonEvent("SetTowerBehaviour");
                if (obj != null)
                {
                    CurrentTower = obj.RawItem;
                    HasSubscribed = true;
                    Init();

                }
                else
                {
                    Log.Error("Can't Find CurrentTower behaviour, Unable to Add Reader Component, did the author update the world?");
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