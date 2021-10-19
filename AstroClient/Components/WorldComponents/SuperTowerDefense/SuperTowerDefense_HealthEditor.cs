namespace AstroClient.Components
{
    using AstroClient.Udon;
    using System;
    using AstroLibrary.Extensions;
    using VRC.Udon;

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
            var obj = this.gameObject.FindUdonEvent("Revive");
            if (obj != null)
            {
                HealthController = obj.UdonBehaviour.DisassembleUdonBehaviour();
            }
        }






        internal  int? CurrentHealth
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


        private string  Lives { get; } = "Lives";


        internal DisassembledUdonBehaviour HealthController { get; private set; }
    }
}