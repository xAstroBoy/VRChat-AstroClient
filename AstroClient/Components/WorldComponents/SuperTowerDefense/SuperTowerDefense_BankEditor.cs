namespace AstroClient.Components
{
    using AstroClient.Udon;
    using AstroLibrary.Extensions;
    using System;

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
            var obj = gameObject.FindUdonEvent("Restart");
            if (obj != null)
            {
                BankController = obj.UdonBehaviour.DisassembleUdonBehaviour();
            }
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