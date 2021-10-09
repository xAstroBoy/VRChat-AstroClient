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
    using AstroLibrary.Utility;
    using MelonLoader;
    using System.Collections;

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
                var revive = UdonSearch.FindUdonEvent("HealthController", "Revive");
                if(revive != null)
                {
                    ReviveEvent = revive;
                }
                else
                {
                    ModConsole.Warning("HealthController Not Found, unable to create Revive Tool!");
                }
                var Round = UdonSearch.FindUdonEvent("NewWaveButton", "TryStartNewWave");
                if (Round != null)
                {
                    WaveEvent = Round;
                }
                var RedWrench = GameObjectFinder.Find("UpgradeTool0");
                var BlueWrench = GameObjectFinder.Find("UpgradeTool1");
                var Hammer = GameObjectFinder.Find("SellTool");
                if(RedWrench != null)
                {
                    RedWrenchPickup = RedWrench.GetOrAddComponent<VRC_AstroPickup>();
                    if (RedWrenchPickup != null)
                    {
                        RedWrenchPickup.OnPickupUseUp = null;
                        RedWrenchPickup.OnPickupUseUp += new System.Action(() => { ReviveEvent.ExecuteUdonEvent(); });
                        RedWrenchPickup.enabled = HealthToolEnabled;
                    }
                }
                if (BlueWrench != null)
                {
                    BlueWrenchPickup = BlueWrench.GetOrAddComponent<VRC_AstroPickup>();
                    if (BlueWrenchPickup != null)
                    {
                        BlueWrenchPickup.OnPickupUseUp = null;
                        BlueWrenchPickup.OnPickupUseUp += new System.Action(() => { ReviveEvent.ExecuteUdonEvent(); });
                        BlueWrenchPickup.enabled = HealthToolEnabled;
                    }
                }
                if (Hammer != null)
                {
                    HammerPickup = Hammer.GetOrAddComponent<VRC_AstroPickup>();
                    if (HammerPickup != null)
                    {
                        HammerPickup.OnPickupUseUp = null;
                        HammerPickup.OnPickupUseUp += new System.Action(() => { ReviveEvent.ExecuteUdonEvent(); });
                        HammerPickup.enabled = HealthToolEnabled;
                    }
                }

            }
        }

        internal override void OnRoomLeft()
        {
            HealthToolEnabled = false;
            ReviveEvent = null;
            AutomaticWaveStart = false;
            RedWrenchPickup = null;
            HammerPickup = null;
            BlueWrenchPickup = null;
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

            HealthToolBtn = new QMSingleToggleButton(SuperTowerDefensecheatPage, 2, 0, "Toggle Health Tools", () => { HealthToolEnabled = true; }, "Toggle Health Tool", () => { HealthToolEnabled = false; }, "Turn the Red Wrench able to reset health on interact!", UnityEngine.Color.green, UnityEngine.Color.red, null, false, true);
            AutomaticWaveBtn = new QMSingleToggleButton(SuperTowerDefensecheatPage, 2, 0.5f, "Toggle Automatic Wave start", () => { AutomaticWaveStart = true; }, "Toggle Automatic Wave start", () => { AutomaticWaveStart = false; }, "Turn the Red Wrench able to reset health on interact!", UnityEngine.Color.green, UnityEngine.Color.red, null, false, true);

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


        private static bool _HealthToolEnabled;
        private static bool HealthToolEnabled
        {
            get
            {
                return _HealthToolEnabled;
            }
            set
            {
                if (HealthToolBtn != null)
                {
                    HealthToolBtn.SetToggleState(value);
                }
                if (value.Equals(_HealthToolEnabled))
                {
                    return;
                }
                _HealthToolEnabled = value;
                if (RedWrenchPickup != null)
                {
                    RedWrenchPickup.enabled = value;
                    if(value)
                    {
                        RedWrenchPickup.UseText = "Reset Health (AstroClient)";
                    }
                    else
                    {
                        RedWrenchPickup.UseText = "Use";
                    }

                }
                if (BlueWrenchPickup != null)
                {
                    BlueWrenchPickup.enabled = value;
                    if (value)
                    {
                        BlueWrenchPickup.UseText = "Reset Health (AstroClient)";
                    }
                    else
                    {
                        BlueWrenchPickup.UseText = "Use";
                    }
                }
                if (HammerPickup != null)
                {
                    HammerPickup.enabled = value;
                    if (value)
                    {
                        HammerPickup.UseText = "Reset Health (AstroClient)";
                    }
                    else
                    {
                        HammerPickup.UseText = "Use";
                    }

                }
            }
        }


        private static bool _AutomaticWaveStart = false;
        private static bool AutomaticWaveStart
        {
            get
            {
                return _AutomaticWaveStart;
            }
            set
            {
                if (AutomaticWaveBtn != null)
                {
                    AutomaticWaveBtn.SetToggleState(value);
                }

                if (value.Equals(_AutomaticWaveStart))
                {
                    return;
                }
                _AutomaticWaveStart = value;
                if(value)
                {
                    cancellationwavetoken = MelonCoroutines.Start(WaveStarter());
                }
                else
                {
                    if(cancellationwavetoken != null)
                    {
                        MelonCoroutines.Stop(cancellationwavetoken);
                    }
                    cancellationwavetoken = null;
                }
            }
        }



        private static IEnumerator WaveStarter()
        {
            while(AutomaticWaveStart)
            {
                yield return new WaitForSeconds(1.5f);
                if(WaveEvent != null)
                {
                    WaveEvent.ExecuteUdonEvent();
                }
                yield return null;
            }
            yield return null;
        }
        internal static QMNestedButton SuperTowerDefensecheatPage { get; set; }

        private static DisassembledUdonBehaviour Bank { get; set; }

        private static QMSingleToggleButton HealthToolBtn{ get; set; }
        private static QMSingleToggleButton AutomaticWaveBtn { get; set; }
        private static object cancellationwavetoken { get; set; }
        private static VRC_AstroPickup RedWrenchPickup{ get; set; }
        private static VRC_AstroPickup BlueWrenchPickup { get; set; }
        private static VRC_AstroPickup HammerPickup { get; set; }

        private static UdonBehaviour_Cached ReviveEvent{ get; set; }
        private static UdonBehaviour_Cached WaveEvent { get; set; }

        private static string StartMoney { get; } = "StartMoney";
        private static string CurrentMoney { get; } = "Money";


    }
}