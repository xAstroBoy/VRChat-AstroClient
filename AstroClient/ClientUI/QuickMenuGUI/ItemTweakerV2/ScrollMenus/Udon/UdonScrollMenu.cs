﻿using System.Collections.Generic;
using System.Linq;
using AstroClient.AstroMonos.Components.Tools;
using AstroClient.ClientActions;
using AstroClient.ClientUI.Hud.Notifier;
using AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.Selector;
using AstroClient.CustomClasses;
using AstroClient.Tools.Extensions;
using AstroClient.Tools.UdonEditor;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;
using AstroClient.xAstroBoy.AstroButtonAPI.Tools;
using AstroClient.xAstroBoy.AstroButtonAPI.WingsAPI;
using AstroClient.xAstroBoy.Utility;
using UnityEngine;
using VRC.Udon;
using VRC.UI.Elements;

namespace AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2.ScrollMenus.Udon
{
    internal class UdonScrollMenu : AstroEvents
    {
        private static QMWings WingMenu;
        private static QMNestedGridMenu CurrentScrollMenu;
        private static List<QMNestedGridMenu> GeneratedPages = new List<QMNestedGridMenu>();

        private static bool isGenerating { get; set; }
        private static bool CleanOnRoomLeave { get; } = true;
        private static bool DestroyOnMenuClose { get; } = true; // Due to Performance reasons, destroy it and purge the residual buttons to kill any possible lag // TODO : Make it still a option tho.

        private static bool _SpamSelectedEvent = false;
        private static bool SpamSelectedEvent
        {
            get
            {
                return _SpamSelectedEvent;
            }
            set
            {
                _SpamSelectedEvent = value;
                if (SpamUdonBehaviourEvent != null)
                {
                    SpamUdonBehaviourEvent.SetToggleState(value);
                }
            }
        }

        internal static int ActiveSpammers
        {
            get
            {
                return Active_Spammers.Count;
            }
        }

        private static UdonBehaviour_Cached Generated_Spammer { get; set; }
        private static List<UdonBehaviour_Cached> Active_Spammers = new List<UdonBehaviour_Cached>();
        private static bool HasGenerated { get; set; } = false;
        private static bool isOpen { get; set; }

        internal static void StopSpammers()
        {
            if (Active_Spammers.Count != 0)
            {
                for (int i = 0; i < Active_Spammers.Count; i++)
                {
                    UdonBehaviour_Cached item = Active_Spammers[i];
                    item.InvokeOnLoop = false;
                    item.Cleanup();
                }
            }
            Active_Spammers.Clear();
        }
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += OnRoomLeft;
            ClientEventActions.OnQuickMenuClose += OnCloseMenu;
            ClientEventActions.OnBigMenuClose += OnCloseMenu;
            ClientEventActions.OnBigMenuOpen += OnCloseMenu;
        }
        //private static bool _IsUIPageListenerActive = false;
        //private static bool IsUIPageListenerActive
        //{
        //    get => _IsUIPageListenerActive;
        //    set
        //    {
        //        if (_IsUIPageListenerActive != value)
        //        {
        //            if (value)
        //            {
        //                ClientEventActions.OnUiPageToggled += OnUiPageToggled;

        //            }
        //            else
        //            {
        //                ClientEventActions.OnUiPageToggled -= OnUiPageToggled;

        //            }

        //        }
        //        _IsUIPageListenerActive = value;
        //    }
        //}
        private void OnRoomLeft()
        {
            if (CleanOnRoomLeave)
            {
                DestroyGeneratedButtons();
            }
            isGenerating = false;
            StopSpammers();
        }

        internal static void InitButtons(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            CurrentScrollMenu = new QMNestedGridMenu(menu, x, y, "Internal Udon Events", "Interact with Internal Udon Events", null, null, null, null, btnHalf);
            InitWingPage();

            CurrentScrollMenu.OnOpenAction += OnOpenMenu;
            CurrentScrollMenu.OnCloseAction += OnCloseMenu;
        }

        private static bool isDebugging = true;

        private static void Debug(string msg)
        {
            if (isDebugging)
            {
                Log.Debug(msg);
            }
        }
        private static void Regenerate()
        {
            if (!HasGenerated)
            {
                var udonevents = Tweaker_Object.GetGameObjectToEdit().Get_UdonBehaviours();
                if (udonevents != null && udonevents.Count() != 0)
                {
                    for (var index = 0; index < udonevents.Count; index++)
                    {
                        var action = udonevents[index];
                        var keys = action.Get_EventKeys();
                        if (keys == null) continue;
                        var udon = new QMNestedGridMenu(CurrentScrollMenu, action.gameObject.name, $"Open Events of {action.gameObject.name}");
                        GeneratedPages.Add(udon);
                        GenerateInternal(udon, action);
                        udon.OnOpenAction = (() =>
                        {
                            
                            WingMenu.OpenMe(); // Keep it open.
                            if (CurrentUnboxBehaviourToConsole != null)
                            {
                                CurrentUnboxBehaviourToConsole.SetButtonText($"Unbox {action.gameObject.name}");
                                CurrentUnboxBehaviourToConsole.SetToolTip($"Attempts to unbox  {action.gameObject.name} in console");
                                CurrentUnboxBehaviourToConsole.setAction(() => { action.UnboxUdonEventToConsole(); });
                                CurrentUnboxBehaviourToConsole.SetActive(true);
                            }
                            if (GenerateGettersForThisUdon != null)
                            {
                                GenerateGettersForThisUdon.SetButtonText($"Generate Getters for  {action.gameObject.name} Heap");
                                GenerateGettersForThisUdon.SetToolTip($"Attempts to Generate Getters for  {action.gameObject.name}  Heap to file");
                                GenerateGettersForThisUdon.setAction(() => { action.GenerateGettersForThisUdonBehaviour(); });
                                GenerateGettersForThisUdon.SetActive(true);
                            }

                            if (DisassembleUdonBehaviourProgram != null)
                            {
                                DisassembleUdonBehaviourProgram.SetButtonText($"Disassemble  {action.gameObject.name} Program");
                                DisassembleUdonBehaviourProgram.SetToolTip($"Attempts to Disassemble  {action.gameObject.name} Program to file");
                                DisassembleUdonBehaviourProgram.setAction(() => { action.DumpUdonProgramCode(); });
                                DisassembleUdonBehaviourProgram.SetActive(true);
                            }

                        });
                        udon.OnCloseAction = () =>
                        {
                            WingMenu.OpenMe(); // Keep it open.
                            MakeSingleUdonButtonsUnavailable();
                        };
                    }
                }
                HasGenerated = true;
                isGenerating = false;
            }
        }

        private static void GenerateInternal(QMNestedGridMenu menu, UdonBehaviour action)
        {
            var eventKeys = action.Get_EventKeys();
            if (eventKeys == null) return;
            for (int i = 0; i < eventKeys.Length; i++)
            {
                var subaction = eventKeys[i];
                var btn = new QMSingleButton(menu, subaction, null, $"Invoke Event {subaction} of {action.gameObject?.ToString()} (Interaction : {action.interactText})");
                if (Active_Spammers != null)
                {
                    if (Active_Spammers.Count != 0)
                    {
                        if (Active_Spammers.FirstOrDefault(x => x.UdonBehaviour.Equals(action) && x.EventKey.Equals(subaction)) != null)
                        {
                            btn.setTextColorHTML("#FFA500");
                        }
                        else
                        {
                            btn.SetTextColor(Color.white);
                        }
                    }
                }
                btn.SetAction(() =>
                {
                    if (!SpamSelectedEvent)
                    {
                        action.SendUdonEvent(subaction);
                    }
                    else
                    {
                        Generated_Spammer = new UdonBehaviour_Cached(action, subaction);
                        if (!Active_Spammers.Contains(Generated_Spammer))
                        {
                            Log.Debug($"Spamming Event in {action.name}, {subaction}");
                            NewHudNotifier.WriteHudMessage($"<color=#FFA500>Spamming Udon Event in {action.name}, {subaction}</color>");
                            Active_Spammers.Add(Generated_Spammer);
                            btn.setTextColorHTML("#FFA500");
                            Generated_Spammer.InvokeOnLoop = true;
                            SpamSelectedEvent = false;
                        }
                        else
                        {
                            Generated_Spammer.Cleanup();
                            Active_Spammers.Remove(Generated_Spammer);
                            btn.SetTextColor(Color.white);
                        }

                    }

                });
            }
        }

        internal static void DestroyGeneratedButtons()
        {
            HasGenerated = false;

            if (GeneratedPages.Count != 0)
            {
                for (int i = 0; i < GeneratedPages.Count; i++)
                {
                    GeneratedPages[i].DestroyMe();
                }
            }
        }


        private static void OnCloseMenu()
        {
            //IsUIPageListenerActive = false;
            isOpen = false;			
            if (DestroyOnMenuClose)
            {
                DestroyGeneratedButtons();
            }
            if (WingMenu != null)
            {
                WingMenu.SetActive(false);
            }
        }

        private static void OnOpenMenu()
        {
            isOpen = true;
            //IsUIPageListenerActive = true;
            MakeSingleUdonButtonsUnavailable();
            if (!isGenerating)
            {
                Regenerate();
            }
        }

        private static void MakeSingleUdonButtonsUnavailable()
        {
            if (CurrentUnboxBehaviourToConsole != null)
            {
                CurrentUnboxBehaviourToConsole.SetButtonText($"Unavailable");
                CurrentUnboxBehaviourToConsole.SetToolTip($"Unavailable");
                CurrentUnboxBehaviourToConsole.setAction(() => { });
                CurrentUnboxBehaviourToConsole.SetActive(false);
            }
            if (GenerateGettersForThisUdon != null)
            {
                GenerateGettersForThisUdon.SetButtonText($"Unavailable");
                GenerateGettersForThisUdon.SetToolTip($"Unavailable");
                GenerateGettersForThisUdon.setAction(() => { });
                GenerateGettersForThisUdon.SetActive(false);
            }

            if (DisassembleUdonBehaviourProgram != null)
            {
                DisassembleUdonBehaviourProgram.SetButtonText($"Unavailable");
                DisassembleUdonBehaviourProgram.SetToolTip($"Unavailable");
                DisassembleUdonBehaviourProgram.setAction(() => { });
                DisassembleUdonBehaviourProgram.SetActive(false);
            }

        }


        private static void OnUiPageToggled(UIPage Page, bool Toggle, UIPage.TransitionType TransitionType)
        {
            if (!isOpen) return;
            if (Page != null)
            {
                if (!Page.isPage(CurrentScrollMenu.GetPage()) && GeneratedPages.ContainsPage(Page))
                {
                    OnCloseMenu();
                }
            }
        }

        private static void InitWingPage()
        {
            WingMenu = new QMWings(CurrentScrollMenu, 1005, true, "Udon Behaviours (Tweaker)", "Interact with udon behaviours");
            new QMWingSingleButton(WingMenu, "Refresh", () =>
            {
                DestroyGeneratedButtons();
                Regenerate();
            }, "Refresh and force menu to regenerate");
            CurrentUnboxBehaviourToConsole = new QMWingSingleButton(WingMenu, "Unbox null", () => { }, "Attempts to unbox null in console..");
            GenerateGettersForThisUdon = new QMWingSingleButton(WingMenu, "Generate Getters for null", () => { }, "Attempts to Generate Getters for null in File..");

            DisassembleUdonBehaviourProgram = new QMWingSingleButton(WingMenu, "Disassemble null Program", () => { }, "Attempts to Disassemble null Program to file..");
            SpamUdonBehaviourEvent = new QMWingToggleButton(WingMenu, "Spam Udon Behaviour Event", () => { SpamSelectedEvent = true; }, () => { SpamSelectedEvent = false; }, "Repeatedly Invokes selected event.");
            new QMWingSingleButton(WingMenu, "Stop Generated Udon Event Spammer..", () => { Generated_Spammer.InvokeOnLoop = false; }, "Halt The Current Generated Udon spammer!");
            new QMWingSingleButton(WingMenu, "Stop All Generated Udon Event Spammer..", () => { StopSpammers(); }, "Halt The Current Generated Udon spammer!");

            DisassembleUdonBehaviourProgram.SetActive(false);
            CurrentUnboxBehaviourToConsole.SetActive(false);
            GenerateGettersForThisUdon.SetActive(false);
            WingMenu.SetActive(false);
        }

        private static QMWingSingleButton CurrentUnboxBehaviourToConsole { get; set; }
        private static QMWingSingleButton DisassembleUdonBehaviourProgram { get; set; }
        private static QMWingToggleButton SpamUdonBehaviourEvent { get; set; }
        private static QMWingSingleButton GenerateGettersForThisUdon { get; set; }

    }
}