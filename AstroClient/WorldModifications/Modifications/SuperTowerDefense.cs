namespace AstroClient.WorldModifications.Modifications
{
    using System.Collections;
    using System.Collections.Generic;
    using AstroMonos.AstroUdons;
    using AstroMonos.Components.Cheats.Worlds.SuperTowerDefense;
    using AstroMonos.Components.Custom.Random;
    using CheetoLibrary;
    using MelonLoader;
    using Tools.Extensions;
    using Tools.Extensions.Components_exts;
    using Tools.UdonSearcher;
    using UnityEngine;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.Utility;
    using static Constants.CustomLists;

    internal class SuperTowerDefense : AstroEvents
    {
        internal override void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.Super_Tower_defense)
            {
                if (SuperTowerDefensecheatPage != null)
                {
                    SuperTowerDefensecheatPage.SetIntractable(true);
                    SuperTowerDefensecheatPage.SetTextColor(Color.green);
                }

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

                var toolshop = GameObjectFinder.FindRootSceneObject("ToolShop");
                if (toolshop != null)
                {
                    ReturnHammerButtonTool = toolshop.transform.Find("ReturnSellTool").gameObject;
                }


                FixTheTowers(false);

            }
            else
            {
                if (SuperTowerDefensecheatPage != null)
                {
                    SuperTowerDefensecheatPage.SetIntractable(false);
                    SuperTowerDefensecheatPage.SetTextColor(Color.red);
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
            FreezeHammer = false;
            LoseLifeHammer = false;
            RepairLifeWrenches = false;
            BlockHammerReturnButton = false;
        }

        
        private static void FixTheTowers(bool RespawnTowers)
        {
            foreach (var item in WorldUtils.Pickups)
            {
                if (item.gameObject.name.ToLower().StartsWith("tower"))
                {
                    item.gameObject.Pickup_Set_Pickupable(true); // Override and fix potential Tower Bugs.
                    if (RespawnTowers)
                    {
                        item.GetComponent<SyncPhysics>().RespawnItem();
                    }
                }
            }
        }


        internal static void InitButtons(QMGridTab main)
        {
            SuperTowerDefensecheatPage = new QMNestedGridMenu(main, "Super Tower Defense", "Super Tower Defense Cheats");

            var bankmods = new QMNestedGridMenu(SuperTowerDefensecheatPage, "Bank Mods", "Modify Current Bank Balance");
            _ = new QMSingleButton(bankmods, "Set 0 Money", () => { if (BankEditor != null && BankEditor.CurrentBankBalance.HasValue) { BankEditor.CurrentBankBalance = 0; } }, "Edit Current Balance!");
            _ = new QMSingleButton(bankmods,  "Add 10000 Money", () => { if (BankEditor != null && BankEditor.CurrentBankBalance.HasValue) { BankEditor.CurrentBankBalance = BankEditor.CurrentBankBalance.Value + 10000; } }, "Edit Current Balance!");
            _ = new QMSingleButton(bankmods,  "Add 100000 Money", () => { if (BankEditor != null && BankEditor.CurrentBankBalance.HasValue) { BankEditor.CurrentBankBalance = BankEditor.CurrentBankBalance.Value + 100000; } }, "Edit Current Balance!");
            _ = new QMSingleButton(bankmods, "Add 1000000 Money", () => { if (BankEditor != null && BankEditor.CurrentBankBalance.HasValue) { BankEditor.CurrentBankBalance = BankEditor.CurrentBankBalance.Value + 1000000; } }, "Edit Current Balance!");
            _ = new QMSingleButton(bankmods,  "Add 10000000 Money", () => { if (BankEditor != null && BankEditor.CurrentBankBalance.HasValue) { BankEditor.CurrentBankBalance = BankEditor.CurrentBankBalance.Value + 10000000; } }, "Edit Current Balance!");
            _ = new QMSingleButton(bankmods, "Set 999999999 Money", () => { if (BankEditor != null && BankEditor.CurrentBankBalance.HasValue) { BankEditor.CurrentBankBalance = 999999999; } }, "Edit Current Balance!");

            var WaveMods = new QMNestedGridMenu(SuperTowerDefensecheatPage, "Wave Mods", "Modify Current Rounds");

            _ = new QMSingleButton(WaveMods,  "Wave +1", () => { if (WaveEditor != null && WaveEditor.CurrentRound.HasValue) { WaveEditor.CurrentRound = WaveEditor.CurrentRound.Value + 1; } }, "Edit Current Round!");
            _ = new QMSingleButton(WaveMods,  "Wave +10", () => { if (WaveEditor != null && WaveEditor.CurrentRound.HasValue) { WaveEditor.CurrentRound = WaveEditor.CurrentRound.Value + 10; } }, "Edit Current Round!");
            _ = new QMSingleButton(WaveMods,  "Wave +100", () => { if (WaveEditor != null && WaveEditor.CurrentRound.HasValue) { WaveEditor.CurrentRound = WaveEditor.CurrentRound.Value + 100; } }, "Edit Current Round!");
            _ = new QMSingleButton(WaveMods,  "Wave -1", () => { if (WaveEditor != null && WaveEditor.CurrentRound.HasValue) { WaveEditor.CurrentRound = WaveEditor.CurrentRound.Value - 1; } }, "Edit Current Round!");
            _ = new QMSingleButton(WaveMods,  "Wave -10", () => { if (WaveEditor != null && WaveEditor.CurrentRound.HasValue) { WaveEditor.CurrentRound = WaveEditor.CurrentRound.Value - 10; } }, "Edit Current Round!");
            _ = new QMSingleButton(WaveMods,  "Wave -100", () => { if (WaveEditor != null && WaveEditor.CurrentRound.HasValue) { WaveEditor.CurrentRound = WaveEditor.CurrentRound.Value - 100; } }, "Edit Current Round!");

            var TowerMods = new QMNestedGridMenu(SuperTowerDefensecheatPage, "Towers Mods", "Make Towers SuperPowerful");

            _ = new QMSingleButton(TowerMods, "Super Tower Range", () => { SetTowersRange(9999f); }, "Edit Towers Range to maximum!");
            _ = new QMSingleButton(TowerMods, "Super Tower Speed", () => { SetTowerSpeed(9999f); }, "Edit Towers Speed to maximum!");

            var ToolMods = new QMNestedGridMenu(SuperTowerDefensecheatPage, "Tool Mods", "Enable Extra Tools");
            RepairLifeWrenchToolsButton = new QMToggleButton(ToolMods, "Toggle Repair life Wrenches", () => { RepairLifeWrenches = true; }, () => { RepairLifeWrenches = false; }, "Wrenches = Reset Health, Hammer = Lose health (useful to troll)!");
            LoseLifeHammerToolBtn = new QMToggleButton(ToolMods, "Toggle Lose Life Hammer", () => { LoseLifeHammer = true; },  () => { LoseLifeHammer = false; }, "Hammer = Lose health (useful to troll)!");

            AutomaticWaveBtn = new QMToggleButton(SuperTowerDefensecheatPage,  "Toggle Automatic \n Wave start", () => { AutomaticWaveStart = true; }, "Toggle Automatic \n Wave start", () => { AutomaticWaveStart = false; }, "Turn the Red Wrench able to reset health on interact!");
            AutomaticGodModebnt = new QMToggleButton(SuperTowerDefensecheatPage, "Toggle Automatic \n GodMode", () => { GodMode = true; }, "Toggle Automatic \n GodMode", () => { GodMode = false; }, "Turn the Red Wrench able to reset health on interact!");

            new QMSingleButton(SuperTowerDefensecheatPage, "Fix towers", () => { FixTheTowers(true);}, "Fix Towers Being unpickable bug ", Color.green);
            FreezeHammerToolBtn = new QMToggleButton(SuperTowerDefensecheatPage, "Freeze Hammer", () => { FreezeHammer = true; }, () => { FreezeHammer = false; }, "Add a Protection Shield to the hammer!");
            BlockHammerReturnToolBtn = new QMToggleButton(SuperTowerDefensecheatPage, "Block Hammer Return", () => { BlockHammerReturnButton = true; }, () => { BlockHammerReturnButton = false; }, "Add a Protection Shield to the hammer Return Button using Two Apples!");

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



        private static List<GameObject> WorldApples
        {
            get
            {
                List<GameObject> result = new List<GameObject>();
                foreach (var item in WorldUtils.Pickups)
                {
                    if (item.name.StartsWith("Apple"))
                    {
                        result.Add(item.gameObject);
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
                if (tower.name.Contains("RocketLauncher")) continue; // Ignore due to Lag reasons.
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
                if (RepairLifeWrenchToolsButton != null)
                {
                    RepairLifeWrenchToolsButton.SetToggleState(value);
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
                if (LoseLifeHammerToolBtn != null)
                {
                    LoseLifeHammerToolBtn.SetToggleState(value);
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



        private static bool _FreezeHammer;

        private static bool FreezeHammer
        {
            get
            {
                return _FreezeHammer;
            }
            set
            {
                if (FreezeHammerToolBtn != null)
                {
                    FreezeHammerToolBtn.SetToggleState(value);
                }
                _FreezeHammer = value;

                if (HammerPickup != null)
                {
                    if (value)
                    {
                       var item = HammerPickup.gameObject.GetOrAddComponent<ObjectFreezer>();
                       if (item != null)
                       {
                           item.Capture();
                           item.IsEnabled = true;
                       }
                    }
                    else
                    {
                        HammerPickup.gameObject.Remove_ObjectFreezer();
                    }
                }
            }
        }
        private static bool _BlockHammerReturn;

        private static bool BlockHammerReturnButton
        {
            get
            {
                return _BlockHammerReturn;
            }
            set
            {
                if (BlockHammerReturnToolBtn != null)
                {
                    BlockHammerReturnToolBtn.SetToggleState(value);
                }
                _BlockHammerReturn = value;

                if (ReturnHammerButtonTool != null)
                {
                    if (value)
                    {
                        foreach (var apple in WorldApples)
                        {
                            LockAppleOnButton(apple);
                        }
                    }
                    else
                    {
                        foreach (var apple in WorldApples)
                        {
                            apple.Remove_ObjectFreezer();
                        }
                    }
                }
            }
        }


        private static void LockAppleOnButton(GameObject Apple)
        {
            if (Apple != null)
            {
                if (ReturnHammerButtonTool != null)
                {
                    Apple.TakeOwnership();
                    var item = Apple.GetOrAddComponent<ObjectFreezer>();
                    if (item != null)
                    {
                        item.Capture(ReturnHammerButtonTool.transform.position, ReturnHammerButtonTool.transform.rotation);
                        item.LockPosition = true; // Prevent Re-capturing To Fully freeze and protect the button !
                        item.IsEnabled = true;
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
                yield return new WaitForSeconds(1);
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



        internal static QMNestedGridMenu SuperTowerDefensecheatPage { get; set; }

        internal static SuperTowerDefense_WaveEditor WaveEditor { get; set; }
        internal static SuperTowerDefense_HealthEditor HealthEditor { get; set; }
        internal static SuperTowerDefense_BankEditor BankEditor { get; set; }

        private static QMToggleButton RepairLifeWrenchToolsButton { get; set; }
        private static QMToggleButton LoseLifeHammerToolBtn { get; set; }
        private static QMToggleButton FreezeHammerToolBtn { get; set; }
        private static QMToggleButton BlockHammerReturnToolBtn { get; set; }

        private static QMToggleButton AutomaticWaveBtn { get; set; }

        private static QMToggleButton AutomaticGodModebnt { get; set; }

        private static object cancellationwavetoken { get; set; }

        private static VRC_AstroPickup RedWrenchPickup { get; set; }
        private static VRC_AstroPickup BlueWrenchPickup { get; set; }
        private static VRC_AstroPickup HammerPickup { get; set; }

        private static GameObject ReturnHammerButtonTool { get; set; }

        private static UdonBehaviour_Cached ResetHealth { get; set; }

        private static UdonBehaviour_Cached LoseHealth { get; set; }

        private static UdonBehaviour_Cached WaveEvent { get; set; }
    }
}