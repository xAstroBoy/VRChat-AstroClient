using AstroClient.ClientActions;
using AstroClient.Startup.Hooks.EventDispatcherHook.Handlers;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy.Extensions;
using VRC.Udon;

namespace AstroClient.WorldModifications.WorldHacks
{
    using AstroClient.AstroMonos.Components.Tools.Listeners;
    using AstroClient.Tools.Bruteforcer;
    using AstroClient.xAstroBoy.Utility;
    using AstroMonos.AstroUdons;
    using CustomClasses;
    using System;
    using System.Collections.Generic;
    using Tools.UdonEditor;
    using Tools.UdonSearcher;
    using UnityEngine;
    using WorldsIds;
    using xAstroBoy;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    internal class PoolParlor : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
        }

        internal static bool CreateMatchOnGameEnd { get; set; } = false;

        private static bool _HasSubscribed = false;

        private static bool HasSubscribed
        {
            get => _HasSubscribed;
            set
            {
                if (_HasSubscribed != value)
                {
                    if (value)
                    {
                        ClientEventActions.OnRoomLeft += OnRoomLeft;
                        ClientEventActions.Udon_SendCustomEvent += UdonSendCustomEvent;
                    }
                    else
                    {
                        ClientEventActions.OnRoomLeft -= OnRoomLeft;
                        ClientEventActions.Udon_SendCustomEvent -= UdonSendCustomEvent;
                    }
                }
                _HasSubscribed = value;
            }
        }

        private static void UdonSendCustomEvent(UdonBehaviour item, string eventkey)
        {
            if (item != null)
            {
                if (item.gameObject.name.isMatchWholeWord("NetworkingManager"))
                {
                    if (eventkey.isMatchWholeWord("_OnGameReset"))
                    {
                        StartANewMatch();
                    }
                }
                if (item.gameObject.name.isMatchWholeWord("BilliardsModule"))
                {
                    if (eventkey.isMatchWholeWord("_TriggerGameReset"))
                    {
                        StartANewMatch();
                    }
                }
                if (item.gameObject.name.isMatchWholeWord("GraphicsManager"))
                {
                    if (eventkey.isMatchWholeWord("_SetWinners"))
                    {
                        StartANewMatch();
                    }
                }
            }
        }

        private static void StartANewMatch()
        {
            if (CreateMatchOnGameEnd)
            {
                StartNewMatchCreation.InvokeBehaviour();
                CreateMatchOnGameEnd = false;
            }
        }

        // TODO : Rewrite this (read and cache from behaviour themself!)
        internal static void InitButtons(QMGridTab main)
        {
            PoolParlorCheats = new QMNestedButton(main, "PoolParlor", "PoolParlor Customization");

            _ = new QMSingleButton(PoolParlorCheats, 1, 0f, "+", () => { CurrentTableSkin++; }, "Set Table Skin!", null, null, true);
            TableSkinBtn = new QMSingleButton(PoolParlorCheats, 2, 0f, "Default Table", () => { CurrentTableSkin = _CurrentTableSkin; }, "Table Skin!", null, null, true);
            _ = new QMSingleButton(PoolParlorCheats, 3, 0, "-", () => { CurrentTableSkin--; }, "Set Table Skin!", null, null, true);

            _ = new QMSingleButton(PoolParlorCheats, 1, 1f, "+", () => { CurrentCueSkin++; }, "Set Cue Skin!", null, null, true);
            CueSkinBtn = new QMSingleButton(PoolParlorCheats, 2, 1f, "Default Cue", () => { CurrentCueSkin = _CurrentCueSkin; }, "Cue Skin!", null, null, true);
            _ = new QMSingleButton(PoolParlorCheats, 3, 1, "-", () => { CurrentCueSkin--; }, "Set Cue Skin!", null, null, true);

            CueSkinOverrideBtn = new QMSingleToggleButton(PoolParlorCheats, 1, 2f, "OVerride Cue Skin", () => { OverrideCurrentSkins = true; }, "Override Cue Skin", () => { OverrideCurrentSkins = false; }, "Enable Cue Skin Override using Spoofer.", Color.green, Color.red, null, false, true);
        }

        private static void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.PoolParlor)
            {
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_Tick");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_FixedTick");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("OnSeekSliderChanged");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("IsInVideoMode");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("GetVideoManager");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("GetVideoTexture");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("GetDuration");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("GetTime");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_GetCuetip");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_IsInUI");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_GetCuetip");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_Get");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_IsShooting");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_GetDesktopMarker");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_BeginPerf");
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_EndPerf");

                HasSubscribed = true;
                if (PoolParlorCheats != null)
                {
                    PoolParlorCheats.SetInteractable(true);
                    PoolParlorCheats.SetTextColor(Color.green);
                }

                Log.Write($"Recognized {Name} World, Patching Skins....");
                Log.Write("Use the Customization Menu to Access Table and Cue skins!");

                var BilliardsModuleEvent = UdonSearch.FindUdonEvent("BilliardsModule", "_CanUseTableSkin");
                if (BilliardsModuleEvent != null)
                {
                    BilliardsModule = BilliardsModuleEvent.RawItem;
                    BilliardModule_TriggerGlobalSettingsUpdated = BilliardsModule.gameObject.FindUdonEvent("BilliardsModule", "_TriggerGlobalSettingsUpdated");
                    StartNewMatchCreation = BilliardsModule.gameObject.FindUdonEvent("_TriggerLobbyOpen");
                    CloseNewMatchCreation = BilliardsModule.gameObject.FindUdonEvent("_TriggerLobbyClosed");
                    StartMatch = BilliardsModule.gameObject.FindUdonEvent("_TriggerGameStart");
                    ResetMatch = BilliardsModule.gameObject.FindUdonEvent("_TriggerGameReset");
                }
                else
                {
                    Log.Warn("failed to Find BilliardsModule");
                }

                var cue_0_unpacked = UdonSearch.FindUdonEvent("intl.cue-0", "_SetAuthorizedOwners");
                if (cue_0_unpacked != null)
                {
                    Cue_0 = cue_0_unpacked.UdonBehaviour.ToRawUdonBehaviour();
                }
                else
                {
                    Log.Warn("failed to Find intl.cue-0");
                }

                var cue_1_unpacked = UdonSearch.FindUdonEvent("intl.cue-1", "_SetAuthorizedOwners");
                if (cue_1_unpacked != null)
                {
                    Cue_1 = cue_1_unpacked.UdonBehaviour.ToRawUdonBehaviour();
                }
                else
                {
                    Log.Warn("failed to Find intl.cue-1");
                }

                var networkingpath = GameObjectFinder.Find("Modules/BilliardsModule/Managers/NetworkingManager");
                if (networkingpath != null)
                {
                    var NetworkingManagerEvent = networkingpath.FindUdonEvent("_OnPlayerPrepareShoot");
                    if (NetworkingManagerEvent != null)
                    {
                        NetworkingManager = NetworkingManagerEvent.RawItem;
                    }
                    else
                    {
                        Log.Warn("failed to Find NetworkingManager");
                    }
                    NetworkingManager_OnGlobalSettingsChanged = networkingpath.FindUdonEvent("_OnGlobalSettingsChanged");
                    if (NetworkingManager_OnGlobalSettingsChanged == null)
                    {
                        Log.Warn("Unable to Find NetworkingManager _OnGlobalSettingsChanged");
                    }
                }
                else
                {
                    Log.Warn("failed to Find NetworkingManager");
                }

                var PoolParlorModule_unpacked = UdonSearch.FindUdonEvent("PoolParlorModule", "_GetSAOMenu");
                if (PoolParlorModule_unpacked != null)
                {
                    PoolParlorModule = PoolParlorModule_unpacked.UdonBehaviour.ToRawUdonBehaviour();
                }
                UpdateColorScheme_Table = UdonSearch.FindUdonEvent("GraphicsManager", "_UpdateTableColorScheme");
                GetCurrentTable();
                GetCurrentCue();
                SetupCues();
                SetupBruteforcerForPopCat();
            }
            else
            {
                if (PoolParlorCheats != null)
                {
                    PoolParlorCheats.SetInteractable(false);
                    PoolParlorCheats.SetTextColor(Color.red);
                }
            }
        }

        private static List<string> KnownCommands => new List<string>
        {
            "?",
           "help",
           "version",
           "v",
           "tournament",
           "t",
           "list",
           "finger",
           "clear",
           "si",
           "hi",
           "sync",
        };

        private static void SetupBruteforcerForPopCat()
        {

            var popcat = GameObject.Find("Pool Parlour/Dynamic/EasterEggs/PortablePopCat");
            if (popcat != null)
            {
                var listener = popcat.gameObject.GetOrAddComponent<GameObjectListener>();
                if(listener != null)
                {
                    listener.OnEnabled += () =>
                    {
                        TextBruteforcer.HasFoundCode = true;
                    };
                }
                SendCommand = UdonSearch.FindUdonEvent("PoolParlorModule", "_OnChatCommand");
                if (SendCommand != null)
                {
                    CommandInput = new AstroUdonVariable<string>(SendCommand.RawItem, "inCommand");
                    if (CommandInput != null)
                    {
                        TextBruteforcer.TestPasscode += delegate (string a)
                        {
                            if (KnownCommands.Contains(a.ToLower()))
                            {
                                return;
                            }
                            //Log.Debug($"Testing command : {a}");
                            CommandInput.Value = a;
                            SendCommand.InvokeBehaviour();
                            if(popcat.gameObject.active)
                            {
                                Log.Debug("Command for Popcat is : " + a);
                            }
                        };

                    }
                    else
                    {
                        Log.Warn("Unable to Find CommandInput");
                    }
                }
                else
                {
                    Log.Warn("failed to Find PoolParlorModule _OnChatCommand");
                }
            }
            else
            {
                Log.Warn("failed to Find PortablePopCat");
            }
        }

        private static AstroUdonVariable<string> CommandInput = null;
        private static UdonBehaviour_Cached SendCommand = null;

        internal static void GetCurrentTable()
        {
            int currentskin = 0;
            var result = UdonHeapParser.Udon_Parse<byte>(NetworkingManager, "tableSkinSynced");
            if (result != null)
            {
                currentskin = result;
            }
            if (Enum.IsDefined(typeof(TableSkins), currentskin))
            {
                var translated = (TableSkins)currentskin;
                if (TableSkinBtn != null)
                {
                    TableSkinBtn.SetButtonText(translated.ToString());
                }
            }
            else
            {
                Log.Warn("New Table Skin Detected, Please Notify the developer To implement it.");
            }
        }

        internal static void GetCurrentCue()
        {
            int currentskin = 0;
            var result = UdonHeapParser.Udon_Parse<int>(BilliardsModule, "activeCueSkin");
            if (result != null)
            {
                currentskin = result;
            }
            if (Enum.IsDefined(typeof(CueSkins), currentskin))
            {
                var translated = (CueSkins)currentskin;
                if (CueSkinBtn != null)
                {
                    CueSkinBtn.SetButtonText(translated.ToString());
                }
            }
            else
            {
                Log.Warn("New Cue Skin Detected, Please Notify the developer To implement it.");
            }
        }

        internal static void SetTableSkin(int skin)
        {
            SetTableSkin_BilliardsModule(skin);
            SetTableSkin_PoolParlorModule(skin);
            SetTableSkin_NetworkingManager(skin);
            if (BilliardModule_TriggerGlobalSettingsUpdated != null)
            {
                BilliardModule_TriggerGlobalSettingsUpdated.InvokeBehaviour();
            }
            if (NetworkingManager_OnGlobalSettingsChanged != null)
            {
                NetworkingManager_OnGlobalSettingsChanged.InvokeBehaviour();
            }

            if (UpdateColorScheme_Table != null)
            {
                UpdateColorScheme_Table.InvokeBehaviour();
            }
        }

        private static void SetTableSkin_BilliardsModule(int value)
        {
            UdonHeapEditor.PatchHeap(BilliardsModule, "tableSkinLocal", value);
            UdonHeapEditor.PatchHeap(BilliardsModule, "__0_mp_64C827E5E2EF62232E24389B8281D1CF_Int32", value);
            UdonHeapEditor.PatchHeap(BilliardsModule, "__0_mp_72681C8A3F190167F4664BA51221AA32_Int32", value);
            UdonHeapEditor.PatchHeap(BilliardsModule, "__0_mp_E1F7FEED75E8E688F1A147B44E5225D5_Byte", (byte)value);
            UdonHeapEditor.PatchHeap(BilliardsModule, "__0_mp_680845797CF11D637DB85E28135E758C_Int32", value);
        }

        private static void SetTableSkin_PoolParlorModule(int value)
        {
            UdonHeapEditor.PatchHeap(PoolParlorModule, "__0_mp_64C827E5E2EF62232E24389B8281D1CF_Int32", value);
            UdonHeapEditor.PatchHeap(PoolParlorModule, "__1_mp_680845797CF11D637DB85E28135E758C_Int32", value);
        }

        private static void SetTableSkin_NetworkingManager(int value)
        {
            UdonHeapEditor.PatchHeap(NetworkingManager, "tableSkinSynced", ((byte)value));
            UdonHeapEditor.PatchHeap(NetworkingManager, "__0_mp_72681C8A3F190167F4664BA51221AA32_Byte", (byte)value);
        }

        internal static void SetCueSkin(int skin)
        {
            SetActiveCueSkin(skin);
            SetSyncedCueSkin(skin);
        }

        private static void SetActiveCueSkin(int value)
        {
            UdonHeapEditor.PatchHeap(BilliardsModule, "activeCueSkin", value);
        }

        private static void SetSyncedCueSkin(int value)
        {
            try
            {
                UdonHeapEditor.PatchHeap(Cue_0, "activeCueSkin", value);
            }
            catch { } // Nobody cares .
            try
            {
                UdonHeapEditor.PatchHeap(Cue_0, "syncedCueSkin", value);
            }
            catch { } // Nobody cares .

            try
            {
                UdonHeapEditor.PatchHeap(Cue_1, "activeCueSkin", value);
            }
            catch { } // Nobody cares .
            try
            {
                UdonHeapEditor.PatchHeap(Cue_1, "syncedCueSkin", value);
            }
            catch { } // Nobody cares .
        }

        internal enum TableSkins
        {
            White = 0,
            Green = 1,
            Blue = 2,
            Purple = 3,
            Black = 4,
            Red = 5,
            Toaster = 6,
            Chintzy = 7,
            Yuuta = 8,
            Holystar = 9,
            Fre = 10,
            Sezuha = 11,
            shiga = 12,
        }

        internal enum CueSkins
        {
            DefaultDark = 0,
            TournamentWinner = 1,
            Trickshotter = 2,
            Toaster = 3,
            Yuuta = 4,
            Chintzy = 5,
            Meta = 6,
            HolyStar = 7,
            DefaultLight = 8,
            BetaTester = 9,
        }

        public static void SetupCues()
        {
            var cue1 = GameObjectFinder.FindRootSceneObject("Modules").transform.FindObject("BilliardsModule/intl.cue-0");
            if (cue1 != null)
            {
                var Primary = cue1.FindObject("primary");
                var Secondary = cue1.FindObject("secondary");
                // Do  stuff;
                if (Primary != null)
                {
                    if (Primary != null)
                    {
                        Cue1_Primary = Primary.gameObject.AddComponent<VRC_AstroPickup>();
                        Cue1_Primary.OnPickup = onPickup;
                        Cue1_Primary.OnPickupUseUp = onPickup;
                        Cue1_Primary.OnPickupUseDown = onPickup;
                        Cue1_Primary.OnDrop = OnDrop;
                    }
                    if (Secondary != null)
                    {
                        Cue1_Secondary = Secondary.gameObject.AddComponent<VRC_AstroPickup>();
                        Cue1_Secondary.OnPickup = onPickup;
                        Cue1_Secondary.OnPickupUseUp = onPickup;
                        Cue1_Secondary.OnPickupUseDown = onPickup;
                        Cue1_Secondary.OnDrop = OnDrop;
                    }
                }
            }
            var cue2 = GameObjectFinder.FindRootSceneObject("Modules").transform.FindObject("BilliardsModule/intl.cue-1");
            if (cue2 != null)
            {
                var Primary_2 = cue2.FindObject("primary");
                var Secondary_2 = cue2.FindObject("secondary");
                // Do  stuff;
                if (Primary_2 != null)
                {
                    Cue2_Primary = Primary_2.gameObject.AddComponent<VRC_AstroPickup>();
                    Cue2_Primary.OnPickup = onPickup;
                    Cue2_Primary.OnPickupUseUp = onPickup;
                    Cue2_Primary.OnPickupUseDown = onPickup;

                    Cue2_Primary.OnDrop = OnDrop;
                }
                if (Secondary_2 != null)
                {
                    Cue2_Secondary = Secondary_2.gameObject.AddComponent<VRC_AstroPickup>();
                    Cue2_Secondary.OnPickup = onPickup;
                    Cue2_Secondary.OnPickupUseUp = onPickup;
                    Cue2_Secondary.OnPickupUseDown = onPickup;
                    Cue2_Secondary.OnDrop = OnDrop;
                }
            }
        }

        private static void OnRoomLeft()
        {
            HasSubscribed = false;
        }

        private static void OnDrop()
        {
        }

        private static void onPickup()
        {
            if (OverrideCurrentSkins)
            {
                SetCueSkin((int)_CurrentCueSkin);
            }
        }

        internal static VRC_AstroPickup Cue1_Primary { get; private set; }
        internal static VRC_AstroPickup Cue1_Secondary { get; private set; }

        internal static VRC_AstroPickup Cue2_Primary { get; private set; }
        internal static VRC_AstroPickup Cue2_Secondary { get; private set; }

        internal static UdonBehaviour_Cached UpdateColorScheme_Table { get; private set; }
        internal static UdonBehaviour_Cached BilliardModule_TriggerGlobalSettingsUpdated { get; private set; }
        internal static UdonBehaviour_Cached NetworkingManager_OnGlobalSettingsChanged { get; private set; }
        internal static UdonBehaviour_Cached StartNewMatchCreation { get; private set; }
        internal static UdonBehaviour_Cached CloseNewMatchCreation { get; private set; }
        internal static UdonBehaviour_Cached StartMatch { get; private set; }
        internal static UdonBehaviour_Cached ResetMatch { get; private set; }

        internal static RawUdonBehaviour Cue_0 { get; private set; }
        internal static RawUdonBehaviour Cue_1 { get; private set; }

        internal static RawUdonBehaviour PoolParlorModule { get; private set; }
        internal static RawUdonBehaviour NetworkingManager { get; private set; }
        internal static RawUdonBehaviour BilliardsModule { get; private set; }

        internal static QMNestedButton PoolParlorCheats { get; set; }

        private static TableSkins _CurrentTableSkin;

        internal static TableSkins CurrentTableSkin
        {
            get
            {
                return _CurrentTableSkin;
            }
            set
            {
                if (!Enum.IsDefined(typeof(TableSkins), value))
                {
                    value = TableSkins.White;
                }
                _CurrentTableSkin = value;
                if (TableSkinBtn != null)
                {
                    TableSkinBtn.SetButtonText(value.ToString());
                }
                SetTableSkin((int)value);
            }
        }

        internal static QMSingleButton TableSkinBtn { get; set; }

        private static CueSkins _CurrentCueSkin = CueSkins.DefaultLight;

        internal static CueSkins CurrentCueSkin
        {
            get
            {
                return _CurrentCueSkin;
            }
            set
            {
                if (!Enum.IsDefined(typeof(CueSkins), value))
                {
                    value = CueSkins.DefaultLight;
                }
                if (CueSkinBtn != null)
                {
                    CueSkinBtn.SetButtonText(value.ToString());
                }
                _CurrentCueSkin = value;
                SetCueSkin((int)value);
            }
        }

        internal static QMSingleButton CueSkinBtn { get; set; }

        internal static QMSingleToggleButton CueSkinOverrideBtn { get; set; }

        private static bool _OverrideCurrentSkins = false;

        internal static bool OverrideCurrentSkins
        {
            get
            {
                return _OverrideCurrentSkins;
            }
            set
            {
                _OverrideCurrentSkins = value;
                if (CueSkinOverrideBtn != null)
                {
                    CueSkinOverrideBtn.SetToggleState(value);
                }
            }
        }
    }
}