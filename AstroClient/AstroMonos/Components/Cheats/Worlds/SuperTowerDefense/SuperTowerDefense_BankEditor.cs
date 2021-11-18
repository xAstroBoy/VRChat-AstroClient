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
    public class SuperTowerDefense_BankEditor : AstroMonoBehaviour
    {
        private List<Object> AntiGarbageCollection = new();

        public SuperTowerDefense_BankEditor(IntPtr ptr) : base(ptr)
        {
            AntiGarbageCollection.Add(this);
        }

        internal int? CurrentBankBalance
        {
            [HideFromIl2Cpp]
            get
            {
                if (BankController != null) return UdonHeapParser.Udon_Parse_Int32(BankController, CurrentMoney);
                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (BankController != null)
                    if (value.HasValue)
                        UdonHeapEditor.PatchHeap(BankController, CurrentMoney, Math.Abs(value.Value));
            }
        }

        private string StartMoney { [HideFromIl2Cpp] get; } = "StartMoney";
        private string CurrentMoney { [HideFromIl2Cpp] get; } = "Money";

        private static DisassembledUdonBehaviour BankController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        // Use this for initialization
        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.Super_Tower_defense))
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
            else
            {
                Destroy(this);
            }
        }
    }
}