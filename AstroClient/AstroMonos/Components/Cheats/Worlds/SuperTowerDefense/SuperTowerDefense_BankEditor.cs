namespace AstroClient.AstroMonos.Components.Cheats.Worlds.SuperTowerDefense
{
    using AstroClient.Tools.Extensions;
    using AstroClient.Tools.UdonEditor;
    using AstroClient.xAstroBoy.Extensions;
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

        internal override void OnRoomLeft()
        {
            Destroy(this);
        }

        private int FrozenMoneyBalance;

        internal int? Money
        {
            [HideFromIl2Cpp]
            get
            {
                if (BankController != null) return UdonHeapParser.Udon_Parse<int>(BankController, CurrentMoney_Address);
                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (BankController != null)
                {
                    // First process the value
                    var patchedvalue = Math.Abs(value.GetValueOrDefault(StartMoney.GetValueOrDefault(DefaultStartMoney)));
                    if (patchedvalue != null)
                    {
                        UdonHeapEditor.PatchHeap(BankController, CurrentMoney_Address, patchedvalue);

                        if (FreezeMoney)
                        {
                            if (!patchedvalue.Equals(FrozenMoneyBalance))
                            {
                                FrozenMoneyBalance = patchedvalue;
                            }
                        }
                    }
                }
            }
        }

        internal int? StartMoney
        {
            [HideFromIl2Cpp]
            get
            {
                if (BankController != null) return UdonHeapParser.Udon_Parse<int>(BankController, StartMoney_Address);
                return null;
            }
            [HideFromIl2Cpp]
            set
            {
                if (BankController != null)
                    if (value.HasValue)
                        UdonHeapEditor.PatchHeap(BankController, StartMoney_Address, Math.Abs(value.Value));
            }
        }

        private int DefaultStartMoney { [HideFromIl2Cpp] get; } = 4500;
        private string StartMoney_Address { [HideFromIl2Cpp] get; } = "StartMoney";
        private string CurrentMoney_Address { [HideFromIl2Cpp] get; } = "Money";

        internal bool FixBalanceNegative { [HideFromIl2Cpp] get; [HideFromIl2Cpp]  set; } = false;
        private bool _freezeMoney = false;

        internal bool FreezeMoney
        {
            [HideFromIl2Cpp]
            get
            {
                return _freezeMoney;
            }
            [HideFromIl2Cpp]
            set
            {
                _freezeMoney = value;
                if (value)
                {
                    FrozenMoneyBalance = Money.GetValueOrDefault(StartMoney.GetValueOrDefault(DefaultStartMoney));
                }
            }
        }

        private static RawUdonBehaviour BankController { [HideFromIl2Cpp] get; [HideFromIl2Cpp] set; }

        // Use this for initialization
        internal void Start()
        {
            if (WorldUtils.WorldID.Equals(WorldIds.Super_Tower_defense))
            {
                var obj = gameObject.FindUdonEvent("Restart");
                if (obj != null)
                {
                    BankController = obj.UdonBehaviour.ToRawUdonBehaviour();
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

        internal void LateUpdate()
        {
            if (FreezeMoney)
            {
                if (!Money.GetValueOrDefault(StartMoney.GetValueOrDefault(DefaultStartMoney)).Equals(FrozenMoneyBalance))
                {
                    Money = FrozenMoneyBalance;
                }
            }
            else
            {
                if (FixBalanceNegative)
                {
                    if (Money.GetValueOrDefault(StartMoney.GetValueOrDefault(DefaultStartMoney)).IsNegative())
                    {
                        Money = StartMoney;
                    }
                }
            }
        }
    }
}