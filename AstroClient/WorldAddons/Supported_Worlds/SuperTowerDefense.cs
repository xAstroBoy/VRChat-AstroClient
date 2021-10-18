namespace AstroClient
{
    using AstroButtonAPI;
    using AstroClient.Components;
    using AstroClient.Udon;
    using AstroClient.Variables;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using AstroLibrary.Utility;
    using MelonLoader;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using UnityEngine;
    using static AstroClient.Variables.CustomLists;

    internal class SuperTowerDefense : GameEvents
    {
        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.Super_Tower_defense)
            {
                ModConsole.Log($"Recognized {Name}, Cheats available.");
                isSuperTowerDefense = true;
                var one = UdonSearch.FindUdonEvent("Bank", "Restart").UdonBehaviour;
                if (one != null)
                {
                    BankController = one.DisassembleUdonBehaviour();
                }
                var revive = UdonSearch.FindUdonEvent("HealthController", "Revive");
                if (revive != null)
                {
                    ResetHealth = revive;
                    if (HealthController == null)
                    {
                        HealthController = ResetHealth.UdonBehaviour.DisassembleUdonBehaviour();
                    }
                }

                var damagehealth = UdonSearch.FindUdonEvent("HealthController", "LoseLives");
                if (damagehealth != null)
                {
                    LoseHealth = damagehealth;
                }

                var Round = UdonSearch.FindUdonEvent("NewWaveButton", "TryStartNewWave");
                if (Round != null)
                {
                    WaveEvent = Round;
                }
                var wavecontrol = UdonSearch.FindUdonEvent("WaveController", "AskForNewWave");
                if (wavecontrol != null)
                {
                    WaveController = wavecontrol.UdonBehaviour.DisassembleUdonBehaviour();
                }
                var RedWrench = GameObjectFinder.Find("UpgradeTool0");
                var BlueWrench = GameObjectFinder.Find("UpgradeTool1");
                var Hammer = GameObjectFinder.Find("SellTool");
                if (RedWrench != null)
                {
                    RedWrenchPickup = RedWrench.GetOrAddComponent<VRC_AstroPickup>();
                    if (RedWrenchPickup != null)
                    {
                        RedWrenchPickup.OnPickupUseUp = null;
                        RedWrenchPickup.OnPickupUseUp += new System.Action(() => { ResetHealth.ExecuteUdonEvent(); });
                        RedWrenchPickup.enabled = false;
                    }
                }
                if (BlueWrench != null)
                {
                    BlueWrenchPickup = BlueWrench.GetOrAddComponent<VRC_AstroPickup>();
                    if (BlueWrenchPickup != null)
                    {
                        BlueWrenchPickup.OnPickupUseUp = null;
                        BlueWrenchPickup.OnPickupUseUp += new System.Action(() => { ResetHealth.ExecuteUdonEvent(); });
                        BlueWrenchPickup.enabled = false;
                    }
                }
                if (Hammer != null)
                {
                    HammerPickup = Hammer.GetOrAddComponent<VRC_AstroPickup>();
                    if (HammerPickup != null)
                    {
                        HammerPickup.OnPickupUseUp = null;
                        HammerPickup.OnPickupUseUp += new System.Action(() => { LoseHealth.ExecuteUdonEvent(); });
                        HammerPickup.enabled = false;
                    }
                }
            }
            else
            {
                isSuperTowerDefense = false;
            }
        }

        internal override void OnRoomLeft()
        {
            RepairLifeWrenches = false;
            LoseLifeHammer = false;
            LoseHealth = null;
            ResetHealth = null;
            AutomaticWaveStart = false;
            AutomaticGodMode = false;
            RedWrenchPickup = null;
            HammerPickup = null;
            BlueWrenchPickup = null;
        }

        [SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
        internal static void InitButtons(QMTabMenu main, float x, float y, bool btnHalf)
        {
            SuperTowerDefensecheatPage = new QMNestedButton(main, x, y, "Super Tower Defense", "Super Tower Defense Cheats", null, null, null, null, btnHalf);

            _ = new QMSingleButton(SuperTowerDefensecheatPage, 1, 0f, "Set 0 Money", () => { if (CurrentBankBalance.HasValue) { CurrentBankBalance = 0; } }, "Edit Current Balance!", null, null, true); _ = new QMSingleButton(SuperTowerDefensecheatPage, 1, 0.5f, "Add 10000 Money", () => { if (CurrentBankBalance.HasValue) { CurrentBankBalance = CurrentBankBalance.Value + 10000; } }, "Edit Current Balance!", null, null, true);
            _ = new QMSingleButton(SuperTowerDefensecheatPage, 1, 1, "Add 100000 Money", () => { if (CurrentBankBalance.HasValue) { CurrentBankBalance = CurrentBankBalance.Value + 100000; } }, "Edit Current Balance!", null, null, true);
            _ = new QMSingleButton(SuperTowerDefensecheatPage, 1, 1.5f, "Add 1000000 Money", () => { if (CurrentBankBalance.HasValue) { CurrentBankBalance = CurrentBankBalance.Value + 1000000; } }, "Edit Current Balance!", null, null, true);
            _ = new QMSingleButton(SuperTowerDefensecheatPage, 1, 2f, "Add 10000000 Money", () => { if (CurrentBankBalance.HasValue) { CurrentBankBalance = CurrentBankBalance.Value + 10000000; } }, "Edit Current Balance!", null, null, true);
            _ = new QMSingleButton(SuperTowerDefensecheatPage, 1, 2.5f, "Set 999999999 Money", () => { if (CurrentBankBalance.HasValue) { CurrentBankBalance = 999999999; } }, "Edit Current Balance!", null, null, true); 
            _ = new QMSingleButton(SuperTowerDefensecheatPage, 2, 0f, "Wave +1", () => { if (CurrentRound.HasValue) { CurrentRound = CurrentRound.Value + 1; } }, "Edit Current Round!", null, null, true);
            _ = new QMSingleButton(SuperTowerDefensecheatPage, 2, 0.5f, "Wave +10", () => { if (CurrentRound.HasValue) { CurrentRound = CurrentRound.Value + 10; } }, "Edit Current Round!", null, null, true);
            _ = new QMSingleButton(SuperTowerDefensecheatPage, 2, 1, "Wave +100", () => { if (CurrentRound.HasValue) { CurrentRound = CurrentRound.Value + 100; } }, "Edit Current Round!", null, null, true);
            _ = new QMSingleButton(SuperTowerDefensecheatPage, 2, 1.5f, "Wave -1", () => { if (CurrentRound.HasValue) { CurrentRound = CurrentRound.Value - 1; } }, "Edit Current Round!", null, null, true);
            _ = new QMSingleButton(SuperTowerDefensecheatPage, 2, 2f, "Wave -10", () => { if (CurrentRound.HasValue) { CurrentRound = CurrentRound.Value - 10; } }, "Edit Current Round!", null, null, true);
            _ = new QMSingleButton(SuperTowerDefensecheatPage, 2, 2.5f, "Wave -100", () => { if (CurrentRound.HasValue) { CurrentRound = CurrentRound.Value - 100; } }, "Edit Current Round!", null, null, true);
            HealthToolBtn = new QMSingleToggleButton(SuperTowerDefensecheatPage, 4, 0, "Toggle Repair life Wrenches", () => { RepairLifeWrenches = true; }, "Toggle Repair life Wrenches", () => { RepairLifeWrenches = false; }, "Wrenches = Reset Health, Hammer = Lose health (useful to troll)!", UnityEngine.Color.green, UnityEngine.Color.red, null, false, true);
            HammerToolBtn = new QMSingleToggleButton(SuperTowerDefensecheatPage, 4, 0.5f, "Toggle Lose Life Hammer", () => { LoseLifeHammer = true; }, "Toggle Lose Life Hammer", () => { LoseLifeHammer = false; }, "Wrenches = Reset Health, Hammer = Lose health (useful to troll)!", UnityEngine.Color.green, UnityEngine.Color.red, null, false, true);
            HammerToolBtn.SetResizeTextForBestFit(true);
            HealthToolBtn.SetResizeTextForBestFit(true);
            AutomaticWaveBtn = new QMSingleToggleButton(SuperTowerDefensecheatPage, 4, 2f, "Toggle Automatic \n Wave start", () => { AutomaticWaveStart = true; }, "Toggle Automatic \n Wave start", () => { AutomaticWaveStart = false; }, "Turn the Red Wrench able to reset health on interact!", UnityEngine.Color.green, UnityEngine.Color.red, null, false, true);
            AutomaticWaveBtn.SetResizeTextForBestFit(true);
            AutomaticGodModebnt = new QMSingleToggleButton(SuperTowerDefensecheatPage, 4, 2.5f, "Toggle Automatic \n GodMode", () => { AutomaticGodMode = true; }, "Toggle Automatic \n GodMode", () => { AutomaticGodMode = false; }, "Turn the Red Wrench able to reset health on interact!", UnityEngine.Color.green, UnityEngine.Color.red, null, false, true);
            AutomaticGodModebnt.SetResizeTextForBestFit(true);
        }

        internal override void OnLateUpdate()
        {
            if (isSuperTowerDefense && ResetHealth != null && AutomaticGodMode)
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

        private static bool _RepairLifeWrenches;

        private static bool RepairLifeWrenches
        {
            get
            {
                return _RepairLifeWrenches;
            }
            set
            {
                if (HealthToolBtn != null)
                {
                    HealthToolBtn.SetToggleState(value);
                }
                if (value.Equals(_RepairLifeWrenches))
                {
                    return;
                }
                _RepairLifeWrenches = value;
                if (RedWrenchPickup != null)
                {
                    RedWrenchPickup.enabled = value;
                    if (value)
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
            }
        }

        private static bool _LoseLifeHammer;

        private static bool LoseLifeHammer
        {
            get
            {
                return _LoseLifeHammer;
            }
            set
            {
                if (HammerToolBtn != null)
                {
                    HammerToolBtn.SetToggleState(value);
                }
                if (value.Equals(_LoseLifeHammer))
                {
                    return;
                }
                _LoseLifeHammer = value;
                if (HammerPickup != null)
                {
                    HammerPickup.enabled = value;
                    if (value)
                    {
                        HammerPickup.UseText = "Lose Health (AstroClient)";
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
                if (value)
                {
                    cancellationwavetoken = MelonCoroutines.Start(WaveStarter());
                }
                else
                {
                    if (cancellationwavetoken != null)
                    {
                        MelonCoroutines.Stop(cancellationwavetoken);
                    }
                    cancellationwavetoken = null;
                }
            }
        }

        private static IEnumerator WaveStarter()
        {
            while (AutomaticWaveStart)
            {
                yield return new WaitForSeconds(1.5f);
                if (WaveEvent != null)
                {
                    WaveEvent.ExecuteUdonEvent();
                }
                yield return null;
            }
            yield return null;
        }

        private static bool _AutomaticGodMode = false;

        private static bool AutomaticGodMode
        {
            get
            {
                return _AutomaticGodMode;
            }
            set
            {
                if (AutomaticGodModebnt != null)
                {
                    AutomaticGodModebnt.SetToggleState(value);
                }

                if (value.Equals(_AutomaticGodMode))
                {
                    return;
                }
                _AutomaticGodMode = value;
            }
        }

        private static int? CurrentHealth
        {
            get
            {
                if (HealthController != null)
                {
                    return UdonHeapParser.Udon_Parse_Int32(HealthController, "Lives");
                }
                return null;
            }
            set
            {
                if (HealthController != null)
                {
                    if (value.HasValue)
                    {
                        UdonHeapEditor.PatchHeap(BankController, "Lives", value.Value);
                    }
                }
            }
        }

        private static int? CurrentBankBalance
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

        private static int? CurrentRound
        {
            get
            {
                if (WaveController != null)
                {
                    return UdonHeapParser.Udon_Parse_Int32(WaveController, "Wave");
                }
                return null;
            }
            set
            {
                if (WaveController != null)
                {
                    if (value.HasValue)
                    {
                        UdonHeapEditor.PatchHeap(WaveController, "Wave", value.Value, true);
                    }
                }
            }
        }

        internal static QMNestedButton SuperTowerDefensecheatPage { get; set; }

        private static DisassembledUdonBehaviour BankController { get; set; }

        private static QMSingleToggleButton HealthToolBtn { get; set; }
        private static QMSingleToggleButton HammerToolBtn { get; set; }

        private static QMSingleToggleButton AutomaticWaveBtn { get; set; }

        private static QMSingleToggleButton AutomaticGodModebnt { get; set; }

        private static object cancellationwavetoken { get; set; }

        private static VRC_AstroPickup RedWrenchPickup { get; set; }
        private static VRC_AstroPickup BlueWrenchPickup { get; set; }
        private static VRC_AstroPickup HammerPickup { get; set; }

        private static DisassembledUdonBehaviour HealthController { get; set; }

        private static DisassembledUdonBehaviour WaveController { get; set; }

        private static UdonBehaviour_Cached ResetHealth { get; set; }

        private static UdonBehaviour_Cached LoseHealth { get; set; }

        private static UdonBehaviour_Cached WaveEvent { get; set; }

        private static string StartMoney { get; } = "StartMoney";
        private static string CurrentMoney { get; } = "Money";

        private static bool isSuperTowerDefense { get; set; } = false;
    }
}