namespace AstroClient.Components
{
    using AstroClient.Udon;
    using AstroLibrary.Extensions;
    using System;
    using System.Diagnostics.Eventing.Reader;
    using AstroLibrary.Console;
    using AstroLibrary.Utility;
    using Variables;

    [RegisterComponent]
    public class SuperTowerDefense_BankEditor : GameEventsBehaviour
    {
        public SuperTowerDefense_BankEditor(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        private Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object> AntiGarbageCollection = new Il2CppSystem.Collections.Generic.List<Il2CppSystem.Object>();

        // Use this for initialization
        internal void Start()
        {
            if(WorldUtils.WorldID.Equals(WorldIds.Super_Tower_defense))
            {
                var obj = gameObject.FindUdonEvent("Restart");
                if (obj != null)
                {
                    BankController = obj.UdonBehaviour.DisassembleUdonBehaviour();
                }
                else
                {
                    ModConsole.Error("Can't Find BankController behaviour, Unable to Add Reader Component, did the author update the world?");
                    Destroy(this);
                }
            }
            else {Destroy(this);}
        }

        internal int? CurrentBankBalance
        {
            get
            {
                if (BankController != null)
                {
                    return UdonHeapParser.Udon_Parse_Int32(BankController, CurrentMoney);
                }
                return null;
            }
            set
            {
                if (BankController != null)
                {
                    if (value.HasValue)
                    {
                        UdonHeapEditor.PatchHeap(BankController, CurrentMoney, value.Value);
                    }
                }
            }
        }

        private string StartMoney { get; } = "StartMoney";
        private string CurrentMoney { get; } = "Money";

        private static DisassembledUdonBehaviour BankController { get; set; }
    }
}