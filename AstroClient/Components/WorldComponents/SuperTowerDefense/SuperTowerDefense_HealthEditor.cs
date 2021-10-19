namespace AstroClient.Components
{
    using AstroClient.Udon;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using System;
    using Variables;

    [RegisterComponent]
    public class SuperTowerDefense_HealthEditor : GameEventsBehaviour
    {
        public SuperTowerDefense_HealthEditor(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        private Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object> AntiGarbageCollection = new Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object>();

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
            else { Destroy(this); }
        }

        private void LateUpdate()
        {
            if (ResetHealth != null && GodMode)
            {
                if (CurrentHealth.HasValue)
                {
                    switch (CurrentHealth.Value)
                    {
                        case 3:
                            ResetHealth.ExecuteUdonEvent();
                            break;

                        case 2:
                            ResetHealth.ExecuteUdonEvent();
                            break;

                        case 1:
                            ResetHealth.ExecuteUdonEvent();
                            break;

                        case 0:
                            ResetHealth.ExecuteUdonEvent();
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        internal int? CurrentHealth
        {
            get
            {
                if (HealthController != null)
                {
                    return UdonHeapParser.Udon_Parse_Int32(HealthController, Lives);
                }
                return null;
            }
            set
            {
                if (HealthController != null)
                {
                    if (value.HasValue)
                    {
                        UdonHeapEditor.PatchHeap(HealthController, Lives, value.Value);
                    }
                }
            }
        }

        private string Lives { get; } = "Lives";

        internal bool GodMode { get; set; } = false;

        internal DisassembledUdonBehaviour HealthController { get; private set; }

        internal static CustomLists.UdonBehaviour_Cached ResetHealth { get; private set; }
    }
}