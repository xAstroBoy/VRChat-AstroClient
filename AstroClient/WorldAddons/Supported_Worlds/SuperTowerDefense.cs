namespace AstroClient
{
    using AstroClient.Udon;
    using AstroClient.Variables;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using AstroButtonAPI;
    using System.Collections.Generic;
    using UnityEngine;
    using AstroClient.Components;
    using static AstroClient.Variables.CustomLists;

    internal class SuperTowerDefense : GameEvents
    {
        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.Super_Tower_defense)
            {
                ModConsole.Log($"Recognized {Name}, Cheats available.");
                var one = UdonSearch.FindUdonEvent("Bank", "Restart").UdonBehaviour;
                if (one != null)
                {
                    Bank = one.DisassembleUdonBehaviour();
                }
                var two = UdonSearch.FindUdonEvent("TowerManager", "_start").UdonBehaviour;
                if (two != null)
                {
                    TowerManager = two.DisassembleUdonBehaviour();
                }
                var three = UdonSearch.FindUdonEvent("UpgradeTool1", "Restart").UdonBehaviour;
                if (three != null)
                {
                    UpgradeTool1 = three.DisassembleUdonBehaviour();
                }
                var four = UdonSearch.FindUdonEvent("UpgradeTool0", "_start").UdonBehaviour;
                if (four != null)
                {
                    UpgradeTool0 = four.DisassembleUdonBehaviour();
                }
                var five = UdonSearch.FindUdonEvent("SellTool", "_start").UdonBehaviour;
                if (five != null)
                {
                    SellTool = five.DisassembleUdonBehaviour();
                }
                var ListBehaviours = UdonSearch.FindAllUdonEvents("NearbyCollider", "_start");
                if (ListBehaviours != null)
                {
                    foreach (var item in ListBehaviours)
                    {
                        NearbyColliders.Add(item.UdonBehaviour.DisassembleUdonBehaviour());
                    }
                }
                RedWrench  = GameObjectFinder.FindRootSceneObject("UpgradeTool0");
                ReviveEvent = UdonSearch.FindUdonEvent("HealthController", "Revive");

            }
        }

        internal override void OnRoomLeft()
        {
            NearbyColliders.Clear();
            HealthToolEnabled = false;
        }


        internal static void InitButtons(QMTabMenu main, float x, float y, bool btnHalf)
        {
            SuperTowerDefensecheatPage = new QMNestedButton(main, x, y, "Super Tower Defense", "Super Tower Defense Cheats", null, null, null, null, btnHalf);

            _ = new QMSingleButton(SuperTowerDefensecheatPage, 1, 0f, "Set 0 Money", () => { SetBankBalance(0); }, "Edit Current Balance!", null, null, true);
            _ = new QMSingleButton(SuperTowerDefensecheatPage, 1, 0.5f, "Add 10000 Money", () => { AddBankBalance(10000); }, "Edit Current Balance!", null, null, true);
            _ = new QMSingleButton(SuperTowerDefensecheatPage, 1, 1, "Add 100000 Money", () => { AddBankBalance(100000); }, "Edit Current Balance!", null, null, true);
            _ = new QMSingleButton(SuperTowerDefensecheatPage, 1, 1.5f, "Add 1000000 Money", () => { AddBankBalance(1000000); }, "Edit Current Balance!", null, null, true);
            _ = new QMSingleButton(SuperTowerDefensecheatPage, 1, 2f, "Add 10000000 Money", () => { AddBankBalance(10000000); }, "Edit Current Balance!", null, null, true);
            _ = new QMSingleButton(SuperTowerDefensecheatPage, 1, 2.5f, "Set 999999999 Money", () => { SetBankBalance(999999999); }, "Edit Current Balance!", null, null, true);

            _ = new QMSingleButton(SuperTowerDefensecheatPage, 2, 0f, "Default Tower Limit", () => { SetMaxTowerCount(20); }, "Edit Tower Limit!", null, null, true);
            _ = new QMSingleButton(SuperTowerDefensecheatPage, 2, 0.5f, "Unlimited Towers", () => { SetMaxTowerCount(99); }, "Edit Tower Limit!", null, null, true);
            HealthToolBtn = new QMSingleToggleButton(SuperTowerDefensecheatPage, 2, 1, "Toggle Health Tool", () => { HealthToolEnabled = true; }, "Toggle Health Tool", () => { HealthToolEnabled = false; }, "Turn the Red Wrench able to reset health on interact!", UnityEngine.Color.green, UnityEngine.Color.red, null, false, true);
        }




        internal static void AddBankBalance(int amount)
        {
            var result = UdonHeapParser.Udon_Parse_Int32(Bank, CurrentMoney);
            if (result.HasValue)
            {
                var modifiedamount = result.Value + amount;
                UdonHeapEditor.PatchHeap(Bank, CurrentMoney, modifiedamount, true);
            }
            else
            {
                ModConsole.Error("Unable to Edit Bank Balance as is null");
            }
        }



        internal static void SetBankBalance(int amount)
        {
            UdonHeapEditor.PatchHeap(Bank, CurrentMoney, amount, true);
        }


        internal static void SetMaxTowerCount(int amount)
        {
            UdonHeapEditor.PatchHeap(TowerManager, MaxTowerCount, amount, true);
            //UdonHeapEditor.PatchHeap(TowerManager, TowerCount, amount, true);
            UdonHeapEditor.PatchHeap(UpgradeTool1, MaxTowerCount, amount, true);
            UdonHeapEditor.PatchHeap(UpgradeTool0, MaxTowerCount, amount, true);
            UdonHeapEditor.PatchHeap(SellTool, MaxTowerCount, amount, true);
            foreach (var beh in NearbyColliders)
            {
                UdonHeapEditor.PatchHeap(beh, MaxTowers, amount, true);

            }
        }
        private static QMSingleToggleButton HealthToolBtn;
        private static GameObject RedWrench;
        private static VRC_AstroPickup RedWrenchPickup;

        private static UdonBehaviour_Cached ReviveEvent;

        private static bool _HealthToolEnabled;
        private static bool HealthToolEnabled
        {
            get
            {
                return _HealthToolEnabled;   
            }
            set
            {
                _HealthToolEnabled = value;
                if(HealthToolBtn != null)
                {
                    HealthToolBtn.SetToggleState(value);
                }
                if (value.Equals(_HealthToolEnabled))
                {
                    return;
                }
                if(value)
                {
                    GenerateTool();
                }
                else
                {
                    if(RedWrenchPickup != null)
                    {
                        RedWrenchPickup.DestroyMeLocal();
                    }
                }
            }
        }

        private static  void GenerateTool()
        {
            if (RedWrench != null)
            {
                if (ReviveEvent != null)
                {
                    if (RedWrenchPickup == null)
                    {
                        RedWrenchPickup = RedWrench.AddComponent<VRC_AstroPickup>();
                        if (RedWrenchPickup != null)
                        {
                            RedWrenchPickup.OnPickupUseUp += new System.Action(() => { ReviveEvent.ExecuteUdonEvent(); });
                            RedWrenchPickup.InteractionText = "Reset Health (AstroClient)";
                        }
                    }
                }
            }
        }
        internal static QMNestedButton SuperTowerDefensecheatPage { get; set; }

        private static DisassembledUdonBehaviour Bank { get; set; }

        private static DisassembledUdonBehaviour TowerManager { get; set; }

        private static DisassembledUdonBehaviour UpgradeTool1 { get; set; }
        private static DisassembledUdonBehaviour UpgradeTool0 { get; set; }
        private static DisassembledUdonBehaviour SellTool { get; set; }

        private static List<DisassembledUdonBehaviour> NearbyColliders { get; set; } = new List<DisassembledUdonBehaviour>();

        private static string StartMoney { get; } = "StartMoney";
        private static string CurrentMoney { get; } = "Money";

        private static string MaxTowerCount { get; } = "MaxTowerCount";

        private static string MaxTowers { get; } = "MaxTowers";

        private static string TowerCount { get; } = "TowerCount";


    }
}