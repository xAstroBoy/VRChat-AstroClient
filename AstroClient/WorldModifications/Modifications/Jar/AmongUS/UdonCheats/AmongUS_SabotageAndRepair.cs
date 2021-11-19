namespace AstroClient.WorldModifications.Modifications.Jar.AmongUS.UdonCheats
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Constants;
    using Tools.Extensions;
    using UnityEngine;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;
    using xAstroBoy.AstroButtonAPI;

    internal class AmongUS_SabotageAndRepair : AstroEvents
    {
        private static QMNestedGridMenu CurrentScrollMenu;
        private static List<QMSingleButton> GeneratedButtons = new List<QMSingleButton>();
        //private static List<QMNestedGridMenu> GeneratedPages = new List<QMNestedGridMenu>();
        private static List<CustomLists.UdonBehaviour_Cached> CachedDoorsEvents = new List<CustomLists.UdonBehaviour_Cached>();

        private static bool isGenerating { get; set; }
        private static bool CleanOnRoomLeave { get; } = true;
        private static bool DestroyOnMenuClose { get; } = false;

        private static bool HasGenerated { get; set; } = false;
        private static bool isOpen { get; set; }

        internal override void OnRoomLeft()
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
            CurrentScrollMenu.SetBackButtonAction(menu, () =>
            {
                OnCloseMenu();
            });
            CurrentScrollMenu.AddOpenAction(() =>
            {
                OnOpenMenu();
            });
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
                    ModConsole.Error($"[AMONG US]: Error in Sabotage & Repair Exploits Button!");
                    ModConsole.ErrorExc(e);
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
            var RepairsPage = new QMNestedGridMenu(menu, "Repairs Options", "All Repairs Options here!", null, Color.red);

            foreach (var subaction in action._eventTable)
            {
                if (subaction.Key.StartsWith("SyncDoSabotage"))
                {
                    var cleanedstr = subaction.key.Replace("SyncDoSabotage", string.Empty).Replace(" ", string.Empty);

                    var subaction_btn = new QMSingleButton(sabotagepage, "Sabotage " + cleanedstr, null, action.gameObject?.ToString() + " Sabotage " + cleanedstr);
                    subaction_btn.SetTextColor(Color.red);
                    subaction_btn.SetAction(new Action(() => {
                        if (subaction.key.StartsWith("_"))
                        {
                            action.SendCustomEvent(subaction.Key);
                        }
                        else
                        {
                            action.SendCustomNetworkEvent(NetworkEventTarget.All, subaction.Key);
                        }
                    }));
                    GeneratedButtons.Add(subaction_btn);
                    if (subaction.key.Contains("Doors"))
                    {
                        var tmp = new CustomLists.UdonBehaviour_Cached(action, subaction.key);
                        if (!CachedDoorsEvents.Contains(tmp))
                        {
                            CachedDoorsEvents.Add(tmp);
                        }
                    }
                }
                else if (subaction.Key.StartsWith("CancelAllSabotage"))
                {
                    var subaction_btn = new QMSingleButton(menu, "Cancel All Sabotages ", null, action.gameObject?.ToString() + "Cancel All Sabotages");
                    subaction_btn.SetAction(new Action(() => {
                        if (subaction.key.StartsWith("_"))
                        {
                            action.SendCustomEvent(subaction.Key);
                        }
                        else
                        {
                            action.SendCustomNetworkEvent(NetworkEventTarget.All, subaction.Key);
                        }
                    }));
                    subaction_btn.SetTextColor(Color.green);
                    GeneratedButtons.Add(subaction_btn);
                }
                else if (subaction.Key.StartsWith("SyncRepair"))
                {
                    var cleanedstr = subaction.key.Replace("SyncRepair", string.Empty).Replace(" ", string.Empty);
                    var subaction_btn = new QMSingleButton(RepairsPage, "Repair " + cleanedstr, null, action.gameObject?.ToString() + " Repair " + cleanedstr);
                    subaction_btn.SetAction(new Action(() => {
                        if (subaction.key.StartsWith("_"))
                        {
                            action.SendCustomEvent(subaction.Key);
                        }
                        else
                        {
                            action.SendCustomNetworkEvent(NetworkEventTarget.All, subaction.Key);
                        }
                    }));
                    subaction_btn.SetTextColor(Color.green);
                    GeneratedButtons.Add(subaction_btn);
                }
            }
            if (CachedDoorsEvents.Count() != 0)
            {
                var subaction_btn = new QMSingleButton(menu, "Sabotage All Doors", null, "Sabotage All Doors");
                subaction_btn.SetAction(new Action(() =>
                {
                    CachedDoorsEvents.ExecuteUdonEvent();
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

        internal override void OnQuickMenuClose()
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