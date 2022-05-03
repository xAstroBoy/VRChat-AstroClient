using AstroClient.ClientActions;
using AstroClient.Tools.UdonEditor;

namespace AstroClient.WorldModifications.WorldHacks.Jar.Murder4.UdonCheats
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using VRC.Udon;
    using VRC.Udon.Common.Interfaces;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;

    internal class Murder4_GameLogic : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += OnRoomLeft;
            ClientEventActions.OnQuickMenuClose += OnQuickMenuClose;
        }

        private static QMNestedGridMenu CurrentScrollMenu;
        private static List<QMSingleButton> Generated = new List<QMSingleButton>();

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
            CurrentScrollMenu = new QMNestedGridMenu(menu, "Game Controller", "Control The Game!");
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
                    return _CurrentController = Murder4Cheats.VictoryBystanderEvent.UdonBehaviour;
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
                    Log.Error("[MURDER 4]: Error in Game Controller Button!");
                    Log.Exception(e);
                    var btnerror = new QMSingleButton(CurrentScrollMenu, "ERROR, SEE CONSOLE", null, "ERROR, SEE CONSOLE", Color.red);
                    Generated.Add(btnerror);
                }


                HasGenerated = true;
                isGenerating = false;
            }
        }

        private static void GenerateInternal(QMNestedGridMenu menu, UdonBehaviour action)
        {
            var eventKeys = action.Get_EventKeys();
            if (eventKeys != null)
            {
                for (int UdonKeys = 0; UdonKeys < eventKeys.Length; UdonKeys++)
                {
                    var key = eventKeys[UdonKeys];
                    new QMSingleButton(menu, key, () =>
                    {
                        action.SendUdonEvent(key);
                    }, $"Invoke Event {key} of {action.gameObject?.ToString()} (Interaction : {action.interactText})");
                }
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