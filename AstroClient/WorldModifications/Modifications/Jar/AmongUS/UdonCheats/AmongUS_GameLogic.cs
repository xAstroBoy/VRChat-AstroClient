namespace AstroClient.WorldModifications.Modifications.Jar.AmongUS.UdonCheats
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;
    using xAstroBoy.AstroButtonAPI;

    internal class AmongUS_GameLogic : AstroEvents
    {
        private static QMNestedGridMenu CurrentScrollMenu;
        private static List<QMSingleButton> Generated = new List<QMSingleButton>();

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
            CurrentScrollMenu = new QMNestedGridMenu(menu, "Game Controller", "Control The Game!");
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
                    ModConsole.Error("[Among US]: Error in Game Controller Button!");
                    ModConsole.ErrorExc(e);
                    var btnerror = new QMSingleButton(CurrentScrollMenu, "ERROR, SEE CONSOLE", null, "ERROR, SEE CONSOLE", Color.red);
                    Generated.Add(btnerror);
                }


                HasGenerated = true;
                isGenerating = false;
            }
        }

        private static void GenerateInternal(QMNestedGridMenu menu, UdonBehaviour action)
        {
            foreach (var subaction in action._eventTable)
            {
                var button = new QMSingleButton(menu, subaction.Key, () =>
                {
                    if (subaction.key.StartsWith("_"))
                    {
                        action.SendCustomEvent(subaction.Key);
                    }
                    else
                    {
                        action.SendCustomNetworkEvent(NetworkEventTarget.All, subaction.Key);
                    }
                }, $"Invoke Event {subaction.Key} of {action.gameObject?.ToString()} (Interaction : {action.interactText})");
                Generated.Add(button);
            }
        }

        internal static void DestroyGeneratedButtons()
        {
            HasGenerated = false;

            if (Generated.Count != 0)
            {
                foreach (var item in Generated) item.DestroyMe();
            }
            Generated.Clear();
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