namespace AstroClient
{
    using AstroButtonAPI;
    using AstroClient.Components;
    using AstroClient.Variables;
    using AstroLibrary.Console;
    using AstroLibrary.Extensions;
    using AstroLibrary.Finder;
    using AstroLibrary.Utility;
    using Cheetos;
    using MelonLoader;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using CheetoLibrary;
    using UnityEngine;
    using static AstroClient.Variables.CustomLists;

    internal class SuperTowerDefense : GameEvents
    {
        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.Super_Tower_defense)
            {
                ModConsole.Log($"Recognized {Name}, Cheats available.");
                var one = UdonSearch.FindUdonEvent("Bank", "Restart").UdonBehaviour.gameObject;
                if (one != null)
                {
                    BankEditor = one.GetOrAddComponent<SuperTowerDefense_BankEditor>();
                }
                var revive = UdonSearch.FindUdonEvent("HealthController", "Revive");
                if (revive != null)
                {
                    ResetHealth = revive;
                    LoseHealth = revive.UdonBehaviour.FindUdonEvent("LoseLives");
                    HealthEditor = revive.UdonBehaviour.GetOrAddComponent<SuperTowerDefense_HealthEditor>();
                }

                var Round = UdonSearch.FindUdonEvent("NewWaveButton", "TryStartNewWave");
                if (Round != null)
                {
                    WaveEvent = Round;
                }
                var wavecontrol = UdonSearch.FindUdonEvent("WaveController", "AskForNewWave");
                if (wavecontrol != null)
                {
                    WaveEditor = wavecontrol.UdonBehaviour.gameObject.AddComponent<SuperTowerDefense_WaveEditor>();
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
                var CanvasesObj = GameObjectFinder.Find("WaveInteractables/SM_Bld_Portable_Office_01 (1)/WavePaper");
                if (CanvasesObj != null)
                {
                    foreach (var text in CanvasesObj.GetComponentsInChildren<UnityEngine.UI.Text>(true))
                    {
                        if (text != null)
                        {
                            if (!text.text.ToLower().Equals("wave"))
                            {
                                text.resizeTextForBestFit = true;
                                ModConsole.DebugLog($"Fixed Canvas : {text.gameObject.name}");
                            }
                        }
                    }
                }
            }
        }

        internal override void OnRoomLeft()
        {
            WaveEditor = null;
            HealthEditor = null;
            BankEditor = null;
            cancellationwavetoken = null;
            RedWrenchPickup = null;
            BlueWrenchPickup = null;
            HammerPickup = null;
            GodMode = false;
            ResetHealth = null;
            LoseHealth = null;
            WaveEvent = null;
        }

        [SuppressMessage("ReSharper", "PossibleInvalidOperationException")]
        internal static void InitButtons(QMTabMenu main, float x, float y, bool btnHalf)
        {
            SuperTowerDefensecheatPage = new QMNestedButton(main, x, y, "Super Tower Defense", "Super Tower Defense Cheats", null, null, null, null, btnHalf);

            _ = new QMSingleButton(SuperTowerDefensecheatPage, 1, 0f, "Set 0 Money", () => { if (BankEditor != null && BankEditor.CurrentBankBalance.HasValue) { BankEditor.CurrentBankBalance = 0; } }, "Edit Current Balance!", null, null, true);
            _ = new QMSingleButton(SuperTowerDefensecheatPage, 1, 0.5f, "Add 10000 Money", () => { if (BankEditor != null && BankEditor.CurrentBankBalance.HasValue) { BankEditor.CurrentBankBalance = BankEditor.CurrentBankBalance.Value + 10000; } }, "Edit Current Balance!", null, null, true);
            _ = new QMSingleButton(SuperTowerDefensecheatPage, 1, 1, "Add 100000 Money", () => { if (BankEditor != null && BankEditor.CurrentBankBalance.HasValue) { BankEditor.CurrentBankBalance = BankEditor.CurrentBankBalance.Value + 100000; } }, "Edit Current Balance!", null, null, true);
            _ = new QMSingleButton(SuperTowerDefensecheatPage, 1, 1.5f, "Add 1000000 Money", () => { if (BankEditor != null && BankEditor.CurrentBankBalance.HasValue) { BankEditor.CurrentBankBalance = BankEditor.CurrentBankBalance.Value + 1000000; } }, "Edit Current Balance!", null, null, true);
            _ = new QMSingleButton(SuperTowerDefensecheatPage, 1, 2f, "Add 10000000 Money", () => { if (BankEditor != null && BankEditor.CurrentBankBalance.HasValue) { BankEditor.CurrentBankBalance = BankEditor.CurrentBankBalance.Value + 10000000; } }, "Edit Current Balance!", null, null, true);
            _ = new QMSingleButton(SuperTowerDefensecheatPage, 1, 2.5f, "Set 999999999 Money", () => { if (BankEditor != null && BankEditor.CurrentBankBalance.HasValue) { BankEditor.CurrentBankBalance = 999999999; } }, "Edit Current Balance!", null, null, true);
            _ = new QMSingleButton(SuperTowerDefensecheatPage, 2, 0f, "Wave +1", () => { if (WaveEditor != null && WaveEditor.CurrentRound.HasValue) { WaveEditor.CurrentRound = WaveEditor.CurrentRound.Value + 1; } }, "Edit Current Round!", null, null, true);
            _ = new QMSingleButton(SuperTowerDefensecheatPage, 2, 0.5f, "Wave +10", () => { if (WaveEditor != null && WaveEditor.CurrentRound.HasValue) { WaveEditor.CurrentRound = WaveEditor.CurrentRound.Value + 10; } }, "Edit Current Round!", null, null, true);
            _ = new QMSingleButton(SuperTowerDefensecheatPage, 2, 1, "Wave +100", () => { if (WaveEditor != null && WaveEditor.CurrentRound.HasValue) { WaveEditor.CurrentRound = WaveEditor.CurrentRound.Value + 100; } }, "Edit Current Round!", null, null, true);
            _ = new QMSingleButton(SuperTowerDefensecheatPage, 2, 1.5f, "Wave -1", () => { if (WaveEditor != null && WaveEditor.CurrentRound.HasValue) { WaveEditor.CurrentRound = WaveEditor.CurrentRound.Value - 1; } }, "Edit Current Round!", null, null, true);
            _ = new QMSingleButton(SuperTowerDefensecheatPage, 2, 2f, "Wave -10", () => { if (WaveEditor != null && WaveEditor.CurrentRound.HasValue) { WaveEditor.CurrentRound = WaveEditor.CurrentRound.Value - 10; } }, "Edit Current Round!", null, null, true);
            _ = new QMSingleButton(SuperTowerDefensecheatPage, 2, 2.5f, "Wave -100", () => { if (WaveEditor != null && WaveEditor.CurrentRound.HasValue) { WaveEditor.CurrentRound = WaveEditor.CurrentRound.Value - 100; } }, "Edit Current Round!", null, null, true);

            _ = new QMSingleButton(SuperTowerDefensecheatPage, 3, 0f, "Super Tower Range", () => { SetTowersRange(9999f); }, "Edit Towers Range to maximum!", null, null, true);
            _ = new QMSingleButton(SuperTowerDefensecheatPage, 3, 0.5f, "Super Tower Speed", () => { SetTowerSpeed(9999f); }, "Edit Towers Speed to maximum!", null, null, true);

            HealthToolBtn = new QMSingleToggleButton(SuperTowerDefensecheatPage, 4, 0, "Toggle Repair life Wrenches", () => { RepairLifeWrenches = true; }, "Toggle Repair life Wrenches", () => { RepairLifeWrenches = false; }, "Wrenches = Reset Health, Hammer = Lose health (useful to troll)!", UnityEngine.Color.green, UnityEngine.Color.red, null, false, true);
            HammerToolBtn = new QMSingleToggleButton(SuperTowerDefensecheatPage, 4, 0.5f, "Toggle Lose Life Hammer", () => { LoseLifeHammer = true; }, "Toggle Lose Life Hammer", () => { LoseLifeHammer = false; }, "Wrenches = Reset Health, Hammer = Lose health (useful to troll)!", UnityEngine.Color.green, UnityEngine.Color.red, null, false, true);
            HammerToolBtn.SetResizeTextForBestFit(true);
            HealthToolBtn.SetResizeTextForBestFit(true);
            AutomaticWaveBtn = new QMSingleToggleButton(SuperTowerDefensecheatPage, 4, 2f, "Toggle Automatic \n Wave start", () => { AutomaticWaveStart = true; }, "Toggle Automatic \n Wave start", () => { AutomaticWaveStart = false; }, "Turn the Red Wrench able to reset health on interact!", UnityEngine.Color.green, UnityEngine.Color.red, null, false, true);
            AutomaticWaveBtn.SetResizeTextForBestFit(true);
            AutomaticGodModebnt = new QMSingleToggleButton(SuperTowerDefensecheatPage, 4, 2.5f, "Toggle Automatic \n GodMode", () => { GodMode = true; }, "Toggle Automatic \n GodMode", () => { GodMode = false; }, "Turn the Red Wrench able to reset health on interact!", UnityEngine.Color.green, UnityEngine.Color.red, null, false, true);
            AutomaticGodModebnt.SetResizeTextForBestFit(true);
        }


        // TODO: Add a reversal mechanism to check if speed or range is modified and revert it.


        // TODO : make a Hook to detect when a object is instantiated to immediately add and optimize the component as well, to avoid running this on loop.

        private static List<SuperTowerDefense_TowerEditor> GetCurrentEditors
        {
            get
            {
                List<SuperTowerDefense_TowerEditor> result = new List<SuperTowerDefense_TowerEditor>();
                foreach (var item in GameObjectFinder.RootSceneObjects_WithoutAvatars)
                {
                    if (item.name.StartsWith("TowerMiniGun") && item.name.EndsWith("(Clone)") ||
                        item.name.StartsWith("TowerRocketLauncher") && item.name.EndsWith("(Clone)") ||
                        item.name.StartsWith("TowerSlow") && item.name.EndsWith("(Clone)") ||
                        item.name.StartsWith("TowerLance") && item.name.EndsWith("(Clone)") ||
                        item.name.StartsWith("TowerRadar") && item.name.EndsWith("(Clone)") ||
                         item.name.StartsWith("TowerCannon") && item.name.EndsWith("(Clone)"))
                    {
                        var editor = item.GetOrAddComponent<SuperTowerDefense_TowerEditor>();
                        if (editor != null)
                        {
                            result.Add(editor);
                        }
                    }
                }

                return result;
            }
        }

        private static void SetTowersRange(float value)
        {
            foreach (var tower in GetCurrentEditors)
            {
                if (tower != null)
                {
                    tower.Range = value;
                }
            }
        }

        private static void SetTowerSpeed(float value)
        {
            foreach (var tower in GetCurrentEditors)
            {
                if (tower != null)
                {
                    tower.SpeedMultiplier = value;
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


        private static bool? GodMode
        {
            get
            {
                if (HealthEditor != null)
                {
                    return HealthEditor.GodMode;
                }
                return null;
            }
            set
            {
                if (value.HasValue)
                {
                    if (AutomaticGodModebnt != null)
                    {
                        AutomaticGodModebnt.SetToggleState(value.Value);
                    }

                    if (HealthEditor != null)
                    {
                        HealthEditor.GodMode = value.Value;
                    }
                }
            }
        }

        internal static QMNestedButton SuperTowerDefensecheatPage { get; set; }

        internal static SuperTowerDefense_WaveEditor WaveEditor { get; set; }
        internal static SuperTowerDefense_HealthEditor HealthEditor { get; set; }
        internal static SuperTowerDefense_BankEditor BankEditor { get; set; }

        private static QMSingleToggleButton HealthToolBtn { get; set; }
        private static QMSingleToggleButton HammerToolBtn { get; set; }

        private static QMSingleToggleButton AutomaticWaveBtn { get; set; }

        private static QMSingleToggleButton AutomaticGodModebnt { get; set; }

        private static object cancellationwavetoken { get; set; }

        private static VRC_AstroPickup RedWrenchPickup { get; set; }
        private static VRC_AstroPickup BlueWrenchPickup { get; set; }
        private static VRC_AstroPickup HammerPickup { get; set; }

        private static UdonBehaviour_Cached ResetHealth { get; set; }

        private static UdonBehaviour_Cached LoseHealth { get; set; }

        private static UdonBehaviour_Cached WaveEvent { get; set; }
    }
}