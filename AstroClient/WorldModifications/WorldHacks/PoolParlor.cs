using System.Linq;
using System.Text;
using AstroClient.AstroMonos.Components.Cheats.Worlds.PoolParlor;
using AstroClient.AstroMonos.Components.Spoofer;
using AstroClient.ClientActions;
using AstroClient.Startup.Hooks.EventDispatcherHook.Handlers;
using AstroClient.Startup.Hooks.EventDispatcherHook.RPCFirewall;
using AstroClient.Startup.Hooks.EventDispatcherHook.Tools.Ext;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy.Extensions;
using Iced.Intel;
using VRC.Core;
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

    // TODO: update
    internal class PoolParlorWorld : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnWorldReveal += OnWorldReveal;
            ClientEventActions.OnEnterWorld += OnWorldEnter;
        }
        private void OnWorldEnter(ApiWorld world, ApiWorldInstance instance)
        {
            if (world == null) return;

            if (world.id.Equals(WorldIds.PoolParlor))
            {
                isCurrentWorld = true;
                //BlockCallbackProcessor = true;
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
                EventDispatcher_HandleUdonEvent.IgnoreLogEventKey("_FlushBuffer");


                HasSubscribed = true;
            }
        }

        private static UdonBehaviour_Cached _CallbackProcessor;

        internal static UdonBehaviour_Cached CallbackProcessor
        {
            get
            {
                if (!isCurrentWorld) return null;
                if (_CallbackProcessor == null)
                {
                    return _CallbackProcessor = UdonSearch.FindUdonEvent("PoolParlorModule", "_OnDataDecoded");
                }
                return _CallbackProcessor;
            }
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

        private static bool _BlockCallbackProcessor = false;
        private static bool BlockCallbackProcessor
        {
            get => _BlockCallbackProcessor;
            set
            {
                if (_BlockCallbackProcessor != value)
                {
                    if (value)
                    {
                        GameObject_RPC_Firewall.EditRule("PoolParlorModule", "_OnDataDecoded", false, false, true);
                        CallbackProcessor.Add_UdonFirewall_Rule(false, false, true);
                    }
                    else
                    {
                        GameObject_RPC_Firewall.RemoveRule("PoolParlorModule", "_OnDataDecoded");

                    }
                }
                _BlockCallbackProcessor = value;
            }
        }

        private static float GuidelineOriginalLenght { get; set; } = 0f;
        private static float GuidelineOriginalLenghtPos { get; set; } = 0f;

        private static GameObject Guideline { get; set; }

        private static bool _LongerGuideline = false;

        internal static bool LongerGuideline
        {
            get => _LongerGuideline;
            set
            {
                if (Guideline != null)
                {
                    if (value)
                    {
                        Guideline.transform.localPosition = Guideline.transform.localPosition.SetX(26.49f);
                        Guideline.transform.localScale = Guideline.transform.localScale.SetX(52.6869f);
                    }
                    else
                    {
                        Guideline.transform.localPosition = Guideline.transform.localPosition.SetX(GuidelineOriginalLenghtPos);
                        Guideline.transform.localScale = Guideline.transform.localScale.SetX(GuidelineOriginalLenght);
                    }
                    _LongerGuideline = value;
                }
            }
        }
        private static bool hasPatched { get; set; } = false;
        private static void UdonSendCustomEvent(UdonBehaviour item, string eventkey)
        {
            if (item != null)
            {
                //if (item.gameObject.name.isMatchWholeWord("PoolParlorModule"))
                //{
                //    if (eventkey.Equals("_OnDataDecoded"))
                //    {
                //        if (!hasPatched)
                //        {
                //            HijackDecodedList();
                //        }
                //    }
                //}

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
        public static string CurrentDisplayName
        {
            get
            {
                return PlayerSpooferUtils.Original_DisplayName;
            }
        }

        private static void HijackDecodedList()
        {
            if(DecoderModule != null)
            {
                var Output = DecoderModule.outputString;
                // split string into multiple lines
                var Lines = Output.Split('\n');
                // rebuild the output string
                DecoderModule.outputString = "";
                // generate a new output string based of the old one with our changes
                // stringbuilder that will be used to rebuild the output string
                StringBuilder sb = new StringBuilder();
                foreach (var line in Lines)
                {
                    // strip string of /n/r and other characters at the end of the line.
                    var processedline = line;

                    Log.Debug($"Processing line \"{line}\" ..."); 
                    if(line.StartsWith("version"))
                    {
                        sb.AppendLine("version 1");
                        continue;
                    }
                    if (line.StartsWith("tournament"))
                    {
                        Log.Debug("Patched tournament winners");
                        sb.AppendLine(line + "\t" + CurrentDisplayName);
                        continue;
                    }
                    if (line.StartsWith("announcement"))
                    {
                        Log.Debug("Patched announcement");
                        sb.AppendLine(line + " World Config Edited by AstroClient");
                        continue;
                    }
                    if (line.StartsWith("moderators"))
                    {
                        Log.Debug("Patched Moderator List");
                        sb.AppendLine(line + "\t" + CurrentDisplayName);
                        continue;
                    }
                    if (line.StartsWith("color"))
                    {
                        var split = line.Split('\t');
                        if (split.Length > 1)
                        {
                            if (split[1].Equals("metaphira"))
                            {
                                Log.Debug("Patched Color");
                                sb.AppendLine(line);
                                sb.AppendLine("color\t" + CurrentDisplayName + "\t" + "rainbow");
                                continue;
                            }
                        }
                    }
                    if (line.StartsWith("table"))
                    {
                        var split = line.Split('\t');
                        if (split.Length > 2)
                        {
                            if (!split[2].Contains("~"))
                            {
                                Log.Debug("Patched Table");
                                sb.AppendLine(line + "\t" + CurrentDisplayName);
                                continue;
                            }
                        }
                    }
                    if (line.StartsWith("contributor-table"))
                    {
                        // if ~ is in the name, it means everyone can use it
                        // if not, it means only the people in the list can use it and we need to add our name to the list
                        // contributor-table	 username1 username2 6

                        var split = line.Split('\t');
                        if (split.Length > 1)
                        {
                            if (!split[1].Contains("~"))
                            {
                                // if the name is not in the list, add it
                                if (!split[1].Contains(CurrentDisplayName))
                                {
                                    // replace the split in the line with the modified one using string.replace
                                    Log.Debug("Patched Contributor Table");
                                    sb.AppendLine(line.Replace(split[1], split[1] + "\t" + CurrentDisplayName));
                                    continue;
                                }
                            }
                        }

                    }
                    if (line.StartsWith("cue"))
                    {
                        var split = line.Split('\t');
                        if (split.Length > 2)
                        {
                            // if ~ is in the name, it means everyone can use it
                            // if not, it means only the people in the list can use it and we need to add our name to the list
                            if (!split[2].Contains("~"))
                            {
                                Log.Debug("Patched Cue");
                                sb.AppendLine(line + "\t" + CurrentDisplayName);
                                continue;
                            }
                        }
                    }
                    if (line.StartsWith("contributor-cue"))
                    {
                        var split = line.Split('\t');
                        if (split.Length > 1)
                        {
                            if (!split[1].Contains("~"))
                            {
                                // if the name is not in the list, add it
                                if (!split[1].Contains(CurrentDisplayName))
                                {
                                    // replace the split in the line with the modified one using string.replace
                                    Log.Debug("Patched contributor Cue");
                                    sb.AppendLine(line.Replace(split[1], split[1] + "\t" + CurrentDisplayName));
                                    continue;
                                }
                            }
                        }

                    }

                    
                    sb.AppendLine(line);
                }
                DecoderModule.outputString = sb.ToString();
                BlockCallbackProcessor = false;
                hasPatched = true;
                CallbackProcessor.Invoke();


            }
        }

        private static void StartANewMatch()
        {
            if (CreateMatchOnGameEnd)
            {
                StartNewMatchCreation.Invoke();
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

            CueSkinOverrideBtn = new QMSingleToggleButton(PoolParlorCheats, 1, 2f, "Override Cue Skin", () => { OverrideCurrentSkins = true; }, "Override Cue Skin", () => { OverrideCurrentSkins = false; }, "Enable Cue Skin Override using Spoofer.", Color.green, Color.red, null, false, true);
        }

        private static bool isCurrentWorld { get; set; }
        private static void OnWorldReveal(string id, string Name, List<string> tags, string AssetURL, string AuthorName)
        {
            if (id == WorldIds.PoolParlor)
            {
                isCurrentWorld = true;

                
                if (PoolParlorCheats != null)
                {
                    PoolParlorCheats.SetInteractable(true);
                    PoolParlorCheats.SetTextColor(Color.green);
                }

                Log.Write($"Recognized {Name} World, Patching Skins....");
                Log.Write("Use the Customization Menu to Access Table and Cue skins!");
                UpdateColorScheme_Table = UdonSearch.FindUdonEvent("GraphicsManager", "_UpdateTableColorScheme");
                SetGuidelineCheat();
                try
                {
                    Initialize_DecoderModule();
                }
                catch (Exception e)
                {
                    Log.Exception(e);
                }
                try
                {
                    Initialize_BilliardModule();
                }
                catch (Exception e)
                {
                    Log.Exception(e);
                }
                try
                {
                    Initialize_CueModule();
                }
                catch (Exception e)
                {
                    Log.Exception(e);
                }
                try
                {
                    Initialize_NetworkingModule();
                }
                catch (Exception e)
                {
                    Log.Exception(e);
                }
                try
                {
                    Initialize_PoolParlorModule();
                }
                catch (Exception e)
                {
                    Log.Exception(e);
                }

                try
                {
                    GetCurrentTable();
                }
                catch { }
                try
                {
                    GetCurrentCue();
                }
                catch { }
                try
                {
                    SetupCues();
                }
                catch { }
                try
                {
                    SetupBruteforcerForPopCat();
                }
                catch { }
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

        private static void Initialize_DecoderModule()
        {
            var DecoderReader = UdonSearch.FindUdonEvent("DynamicReader", "_ReadPictureStep");
            if(DecoderReader != null )
            {
                DecoderModule = DecoderReader.gameObject.GetOrAddComponent<PoolParlor_DecoderReader>();
            }
        }
        private static void Initialize_PoolParlorModule()
        {
            var PoolParlorModule_unpacked = UdonSearch.FindUdonEvent("PoolParlorModule", "_GetSAOMenu");
            if (PoolParlorModule_unpacked != null)
            {
                PoolParlorModule = PoolParlorModule_unpacked.gameObject.GetOrAddComponent<PoolParlor_PoolParlorModuleReader>();
            }
        }

        private static void Initialize_NetworkingModule()
        {
            var networkingpath = Finder.Find("Modules/BilliardsModule/Managers/NetworkingManager");
            if (networkingpath != null)
            {
                NetworkingManager_OnGlobalSettingsChanged = networkingpath.FindUdonEvent("__0__OnGlobalSettingsChanged");
                if (NetworkingManager_OnGlobalSettingsChanged == null)
                {
                    Log.Warn("Unable to Find NetworkingManager _OnGlobalSettingsChanged");
                }
                var NetworkingManagerEvent = networkingpath.FindUdonEvent("_OnPlayerPrepareShoot");
                if (NetworkingManagerEvent != null)
                {
                    NetworkingManager = NetworkingManagerEvent.gameObject.GetOrAddComponent<PoolParlor_NetworkingManagerReader_One>();
                    if (NetworkingManager != null)
                    {
                        NetworkingManager.Initialize();
                    }
                }
                else
                {
                    Log.Warn("failed to Find NetworkingManager");
                }

            }
            else
            {
                Log.Warn("failed to Find NetworkingManager");
            }
        }

        private static void Initialize_CueModule()
        {
            var cue_0_unpacked = UdonSearch.FindUdonEvent("intl.cue-0", "__0__SetAuthorizedOwners");
            if (cue_0_unpacked != null)
            {
                Cue_0 = cue_0_unpacked.gameObject.GetOrAddComponent<PoolParlor_CueReader>();
            }
            else
            {
                Log.Warn("failed to Find intl.cue-0");
            }

            var cue_1_unpacked = UdonSearch.FindUdonEvent("intl.cue-1", "__0__SetAuthorizedOwners");
            if (cue_1_unpacked != null)
            {
                Cue_1 = cue_1_unpacked.gameObject.GetOrAddComponent<PoolParlor_CueReader>();
            }
            else
            {
                Log.Warn("failed to Find intl.cue-1");
            }
        }

        private static void Initialize_BilliardModule()
        {
            var BilliardsModuleEvent = UdonSearch.FindUdonEvent("BilliardsModule", "__0__CanUseTableSkin");
            if (BilliardsModuleEvent != null)
            {
                BilliardsModule = BilliardsModuleEvent.gameObject.GetOrAddComponent<PoolParlor_BilliardsModuleReader>();
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
        }

        private static void SetGuidelineCheat()
        {
            var guideline = Finder.Find("Modules/BilliardsModule/intl.balls/guide/guide_display");
            if (guideline != null)
            {
                if (Guideline == null)
                {
                    Guideline = guideline;
                    GuidelineOriginalLenghtPos = guideline.transform.localPosition.x;

                    GuidelineOriginalLenght = guideline.transform.localScale.x;
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
                if (listener != null)
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
                            SendCommand.Invoke();
                            if (popcat.gameObject.active)
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
            var result = NetworkingManager.Two.tableSkinSynced;
            if (result != null)
            {
                currentskin = (int)result;
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
            var result = BilliardsModule.activeCueSkin;
            if (result != null)
            {
                currentskin = result.Value;
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
                BilliardModule_TriggerGlobalSettingsUpdated.Invoke();
            }
            if (NetworkingManager_OnGlobalSettingsChanged != null)
            {
                NetworkingManager_OnGlobalSettingsChanged.Invoke();
            }

            if (UpdateColorScheme_Table != null)
            {
                UpdateColorScheme_Table.Invoke();
            }
        }

        private static void SetTableSkin_BilliardsModule(int value)
        {
            BilliardsModule.tableSkinLocal = value;
            //BilliardsModule.__0_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 = value;
            //BilliardsModule.__0_mp_72681C8A3F190167F4664BA51221AA32_Int32 = value;
            //BilliardsModule.__0_mp_E1F7FEED75E8E688F1A147B44E5225D5_Byte = (byte)value;
            //BilliardsModule.__0_mp_680845797CF11D637DB85E28135E758C_Int32 = value;
        }

        private static void SetTableSkin_PoolParlorModule(int value)
        {
            // PoolParlorModule.__0_mp_64C827E5E2EF62232E24389B8281D1CF_Int32 = value;
            //PoolParlorModule.__1_mp_680845797CF11D637DB85E28135E758C_Int32 = value;
        }

        private static void SetTableSkin_NetworkingManager(int value)
        {
            NetworkingManager.Two.tableSkinSynced = (byte)value;
            //NetworkingManager.__0_mp_72681C8A3F190167F4664BA51221AA32_Byte = (byte)value;
        }

        internal static void SetCueSkin(int skin)
        {
            SetActiveCueSkin(skin);
            SetSyncedCueSkin(skin);
        }

        private static void SetActiveCueSkin(int value)
        {
            BilliardsModule.activeCueSkin = value;
        }

        private static void SetSyncedCueSkin(int value)
        {
            Cue_0.syncedCueSkin = value;
            Cue_1.syncedCueSkin = value;
        }

        internal enum TableSkins
        {
            White = 0,
            Green = 1,
            Blue = 2,
            Purple = 3,
            Black = 4,
            Red = 5,
            ToastersPlease = 6,
            Chintzykid = 7,
            Yuutashoe = 8,
            HolyStar = 9,
            Fre = 10,
            Sezuha = 11,
            Shigamin = 12,
            metaphira = 13,
            TheLoneCone = 14,
            table_15 = 15,
            table_16 = 16,
            table_17 = 17,
            table_18 = 18,
            table_19 = 19,
            table_20 = 20,
            table_21 = 21,
            table_22 = 22,
            table_23 = 23,
            table_24 = 24,
            table_25 = 25,
        }

        internal enum CueSkins
        {
            DefaultDark = 0,
            TournamentWinner = 1,
            Trickshotter = 2,
            Toaster = 3,
            Yuuta = 4,
            Chintzykid = 5,
            metaphira = 6,
            HolyStar = 7,
            DefaultLight = 8,
            BetaTester = 9,
            Tumeski = 10,
            Sezuha = 11,
            Shigamin = 12,
            cue_13 = 13,
            cue_14 = 14,
            cue_15 = 15,
            cue_16 = 16,
            cue_17 = 17,
            cue_18 = 18,
            cue_19 = 19,
            cue_20 = 20,
            cue_21 = 21,
            cue_22 = 22,
            cue_23 = 23,
            Totally_Not_Tim = 24,
            TheLoneCone = 25,
            Blackøut = 26,
            fantasyprogram = 27,
        }

        public static void SetupCues()
        {
            var cue1 = Finder.Find("Modules/BilliardsModule/intl.cue-0");
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
            var cue2 = Finder.Find("Modules/BilliardsModule/intl.cue-1");
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
            GuidelineOriginalLenght = 0f;
            GuidelineOriginalLenghtPos = 0f;
            LongerGuideline = false;
            hasPatched = false;
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

        internal static PoolParlor_CueReader Cue_0 { get; private set; }
        internal static PoolParlor_CueReader Cue_1 { get; private set; }

        internal static PoolParlor_PoolParlorModuleReader PoolParlorModule { get; private set; }
        internal static PoolParlor_NetworkingManagerReader_One NetworkingManager { get; private set; }
        internal static PoolParlor_BilliardsModuleReader BilliardsModule { get; private set; }
        internal static PoolParlor_DecoderReader DecoderModule { get; private set; }

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
                    if (value == (TableSkins)(-1))
                    {
                        value = TableSkins.table_25;
                    }
                    else
                    {
                        value = TableSkins.White;
                    }
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
                    if (value == (CueSkins)(-1))
                    {
                        value = CueSkins.fantasyprogram;
                    }
                    else
                    {
                        value = CueSkins.DefaultDark;
                    }
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