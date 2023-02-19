using AstroClient.ClientActions;

namespace AstroClient.AstroMonos.Components.Cheats.Worlds.SuperTowerDefense
{
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.UdonEditor;
    using ClientAttributes;
    using Constants;
    using CustomClasses;
    using Il2CppSystem;
    using Il2CppSystem.Collections.Generic;
    using UnhollowerBaseLib.Attributes;
    using WorldModifications.WorldsIds;
    using xAstroBoy.Utility;
    using IntPtr = System.IntPtr;
    using Math = System.Math;
    using UnityEngine;

    [RegisterComponent]
    public class SuperTowerDefense_HealthEditor : MonoBehaviour
    {
        private List<Il2CppSystem.Object> AntiGarbageCollection = new();

        public SuperTowerDefense_HealthEditor(IntPtr ptr) : base(ptr)
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

        void OnDestroy()
        {
            HasSubscribed = false;
        }

        private void OnRoomLeft()
        {
            Destroy(this);
        }
        internal int? CurrentHealth
        {
            [HideFromIl2Cpp]
            get
            {
                if (HealthController != null) return UdonHeapParser.Udon_Parse<int>(HealthController, Lives);
                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (HealthController != null)
                    if (value.HasValue)
                        UdonHeapEditor.PatchHeap(HealthController, Lives, Math.Abs(value.Value));
            }
        }

        internal int? TimesBoughtLives
        {
            [HideFromIl2Cpp]
            get
            {
                if (HealthController != null) return UdonHeapParser.Udon_Parse<int>(HealthController, BoughtLives);
                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (HealthController != null)
                    if (value.HasValue)
                        UdonHeapEditor.PatchHeap(HealthController, BoughtLives, Math.Abs(value.Value));
            }
        }

        private string Lives { [HideFromIl2Cpp] get; } = "Lives";
        private string BoughtLives { [HideFromIl2Cpp] get; } = "TimesBoughtLives";
        internal bool GodMode { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;

        internal RawUdonBehaviour HealthController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal static UdonBehaviour_Cached ResetHealth { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        // Use this for initialization
        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.Super_Tower_defense))
            {
                var obj = gameObject.FindUdonEvent("Revive");
                if (obj != null)
                {
                    ResetHealth = obj;
                    HealthController = obj.RawItem;
                    HasSubscribed = true;
                }
                else
                {
                    Log.Error("Can't Find HealthController behaviour, Unable to Add Reader Component, did the author update the world?");
                    Destroy(this);
                }
            }
            else
            {
                Destroy(this);
            }
        }

        private void Update()
        {
            if (ResetHealth != null && GodMode)
                if (CurrentHealth.HasValue)
                    switch (CurrentHealth.Value)
                    {
                        case 4:
                        case 3:
                        case 2:
                        case 1:
                        case 0:
                            if (GameInstances.LocalPlayer.IsInstanceMaster())
                            {
                                CurrentHealth++;
                            }
                            else
                            {
                                if (ResetHealth != null)
                                {
                                    ResetHealth.Invoke();
                                }
                            }

                            break;
                        default:
                            break;
                    }
        }
    }
}