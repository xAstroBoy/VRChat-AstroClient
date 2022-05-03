using AstroClient.ClientActions;
using AstroClient.Tools.UdonEditor;

namespace AstroClient.WorldModifications.WorldHacks.Jar.AmongUS.UdonCheats
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CustomClasses;
    using Tools.Extensions;
    using UnityEngine;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    internal class AmongUS_SabotageAndRepair : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += OnRoomLeft;
            ClientEventActions.OnQuickMenuClose += OnQuickMenuClose;
        }

        private static QMNestedGridMenu CurrentScrollMenu;
        private static List<QMSingleButton> GeneratedButtons = new List<QMSingleButton>();
        //private static List<QMNestedGridMenu> GeneratedPages = new List<QMNestedGridMenu>();
        private static List<UdonBehaviour_Cached> CachedDoorsEvents = new List<UdonBehaviour_Cached>();

        private static bool isGenerating { get; set; }
        private static bool CleanOnRoomLeave { get; } = true;
        private static bool DestroyOnMenuClose { get; } = false;

        private static bool HasGenerated { get; set; } = false;
        private static bool isOpen { get; set; }

        private void OnRoomLeft()
        {
            if (CleanOnRoomLeave)
            {
                DestroyGeneratedButtons();
            }

            isGenerating = false;
        }

        internal static void InitButtons(QMNestedGridMenu menu)
        {
            CurrentScrollMenu = new QMNestedGridMenu(menu, "Sabotage & Repair Exploits", "Control The Game!");
            CurrentScrollMenu.OnOpenAction += OnOpenMenu;
            CurrentScrollMenu.OnCloseAction += OnCloseMenu;
        }

        private static UdonBehaviour _CurrentController;

        private static UdonBehaviour Currentcontroller
        {
            get
            {
                if (_CurrentController == null)
                {
                    return _CurrentController = AmongUSCheats.VictoryCrewmateEvent.UdonBehaviour;
                }
                return _CurrentController;
            }
        }

        private static void Regenerate()
        {
            if (!HasGenerated)
            {
                try
                {
                    GenerateInternal(CurrentScrollMenu, Currentcontroller);
                }
                catch (Exception e)
                {
                    Log.Error($"[AMONG US]: Error in Sabotage & Repair Exploits Button!");
                    Log.Exception(e);
                    var btnerror = new QMSingleButton(CurrentScrollMenu, "ERROR, SEE CONSOLE", null, "ERROR, SEE CONSOLE", Color.red);
                    GeneratedButtons.Add(btnerror);
                }

                HasGenerated = true;
                isGenerating = false;
            }
        }

        private static void GenerateInternal(QMNestedGridMenu menu, UdonBehaviour action)
        {
            var sabotagepage = new QMNestedGridMenu(menu, "Sabotage Options", "All Sabotage Options here!", null, Color.red);
            var RepairsPage = new QMNestedGridMenu(menu, "Repairs Options", "All Repairs Options here!", null, Color.green);
            var eventKeys = action.Get_EventKeys();
            if (eventKeys != null)
            {
                for (int UdonKeys = 0; UdonKeys < eventKeys.Length; UdonKeys++)
                {
                    var key = eventKeys[UdonKeys];
                    if (key.StartsWith("SyncDoSabotage"))
                    {
                        var cleanedstr = key.Replace("SyncDoSabotage", string.Empty).Replace(" ", string.Empty);

                        var subaction_btn = new QMSingleButton(sabotagepage, "Sabotage " + cleanedstr, null, action.gameObject?.ToString() + " Sabotage " + cleanedstr);
                        subaction_btn.SetTextColor(Color.red);
                        subaction_btn.SetAction(new Action(() =>
                        {
                            action.SendUdonEvent(key);
                        }));
                        GeneratedButtons.Add(subaction_btn);
                        if (key.Contains("Doors"))
                        {
                            var tmp = new UdonBehaviour_Cached(action, key);
                            if (!CachedDoorsEvents.Contains(tmp))
                            {
                                CachedDoorsEvents.Add(tmp);
                            }
                        }
                    }
                    else if (key.StartsWith("CancelAllSabotage"))
                    {
                        var subaction_btn = new QMSingleButton(menu, "Cancel All Sabotages ", null, action.gameObject?.ToString() + "Cancel All Sabotages");
                        subaction_btn.SetAction(new Action(() =>
                        {
                            action.SendUdonEvent(key);
                        }));
                        subaction_btn.SetTextColor(Color.green);
                        GeneratedButtons.Add(subaction_btn);
                    }
                    else if (key.StartsWith("SyncRepair"))
                    {
                        var cleanedstr = key.Replace("SyncRepair", string.Empty).Replace(" ", string.Empty);
                        var subaction_btn = new QMSingleButton(RepairsPage, "Repair " + cleanedstr, null, action.gameObject?.ToString() + " Repair " + cleanedstr);
                        subaction_btn.SetAction(new Action(() =>
                        {
                            action.SendUdonEvent(key);
                        }));
                        subaction_btn.SetTextColor(Color.green);
                        GeneratedButtons.Add(subaction_btn);
                    }

                }
            }
            if (CachedDoorsEvents.Count() != 0)
            {
                var subaction_btn = new QMSingleButton(menu, "Sabotage All Doors", null, "Sabotage All Doors");
                subaction_btn.SetAction(new Action(() =>
                {
                    CachedDoorsEvents.InvokeBehaviour();
                }));
                subaction_btn.SetTextColor(Color.red);
                GeneratedButtons.Add(subaction_btn);
            }

        }

        internal static void DestroyGeneratedButtons()
        {
            HasGenerated = false;

            if (GeneratedButtons.Count != 0)
            {
                foreach (var item in GeneratedButtons) item.DestroyMe();
            }
            //if (GeneratedPages.Count != 0)
            //{
            //    foreach (var item in GeneratedPages) item.DestroyMe();
            //}
            //GeneratedPages.Clear();
            GeneratedButtons.Clear();
            CachedDoorsEvents.Clear();
            GeneratedButtons.Clear();
        }

        private void OnQuickMenuClose()
        {
            OnCloseMenu();
        }

        private static void OnCloseMenu()
        {
            if (DestroyOnMenuClose)
            {
                DestroyGeneratedButtons();
            }
            isOpen = false;

        }

        private static void OnOpenMenu()
        {
            isOpen = true;

            if (!isGenerating)
            {
                Regenerate();
            }
        }

    }
}