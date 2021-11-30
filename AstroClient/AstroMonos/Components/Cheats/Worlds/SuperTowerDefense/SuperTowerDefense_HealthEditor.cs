namespace AstroClient.AstroMonos.Components.Cheats.Worlds.SuperTowerDefense
{
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.UdonEditor;
    using ClientAttributes;
    using Constants;
    using Il2CppSystem;
    using Il2CppSystem.Collections.Generic;
    using UnhollowerBaseLib.Attributes;
    using WorldModifications.WorldsIds;
    using xAstroBoy.Utility;
    using IntPtr = System.IntPtr;
    using Math = System.Math;

    [RegisterComponent]
    public class SuperTowerDefense_HealthEditor : AstroMonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public SuperTowerDefense_HealthEditor(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        internal int? CurrentHealth
        {
            [HideFromIl2Cpp]
            get
            {
                if (HealthController != null) return UdonHeapParser.Udon_Parse_Int32(HealthController, Lives);
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

        private string Lives { [HideFromIl2Cpp] get; } = "Lives";

        internal bool GodMode { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; } = false;

        internal DisassembledUdonBehaviour HealthController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        internal static CustomLists.UdonBehaviour_Cached ResetHealth { [HideFromIl2Cpp] get; [HideFromIl2Cpp] private set; }

        // Use this for initialization
        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.Super_Tower_defense))
            {
                var obj = gameObject.FindUdonEvent("Revive");
                if (obj != null)
                {
                    ResetHealth = obj;
                    HealthController = obj.UdonBehaviour.DisassembleUdonBehaviour();
                }
                else
                {
                    ModConsole.Error("Can't Find HealthController behaviour, Unable to Add Reader Component, did the author update the world?");
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
                        case 3:
                            ResetHealth.InvokeBehaviour();
                            break;
                        case 2:
                            ResetHealth.InvokeBehaviour();
                            break;
                        case 1:
                            ResetHealth.InvokeBehaviour();
                            break;
                        case 0:
                            ResetHealth.InvokeBehaviour();
                            break;
                    }
        }
    }
}