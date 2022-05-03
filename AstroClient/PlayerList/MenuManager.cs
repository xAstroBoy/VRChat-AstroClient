using AstroClient.ClientActions;
using AstroClient.Tools;
using AstroClient.Tools.Extensions;

namespace AstroClient.PlayerList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using ClientResources.Loaders;
    using Config;
    using Entries;
    using MelonLoader;
    using UnityEngine;
    using UnityEngine.UI;
    using Utilities;
    using VRC.UI.Elements;
    using VRCSDK2;


    internal class MenuManager : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.VRChat_OnUiManagerInit += VRChat_OnUiManagerInit;
            ClientEventActions.OnQuickMenuOpen += OnQuickMenuOpen;
            ClientEventActions.OnQuickMenuClose += OnQuickMenuClose;
        }
        //public static List<SubMenu> playerListMenus { get; set; } = new List<SubMenu>();
        private static bool _IsUIPageListenerActive = false;
        private static bool IsUIPageListenerActive
        {
            get => _IsUIPageListenerActive;
            set
            {
                if (_IsUIPageListenerActive != value)
                {
                    if (value)
                    {
                        ClientEventActions.OnUiPageToggled += OnUiPageToggled;

                    }
                    else
                    {
                        ClientEventActions.OnUiPageToggled -= OnUiPageToggled;

                    }

                }
                _IsUIPageListenerActive = value;
            }
        }
        public static GameObject playerList
        {
            get
            {
                return PlayerList_Constants.playerList;
            }
        }
        public static RectTransform playerListRect{ get; set; }

        //public static GameObject menuButton
        //{
        //    get
        //    {
        //        return PlayerList_Constants.menuButton;
        //    }
        //}


        private static PropertyInfo entryWrapperValue{ get; set; }
        struct menuStates
        {

            public bool dashboard;
            public bool plsettings;
            public bool sort;
            public bool userLocal;
            public bool userRemote;

            public menuStates(bool a, bool b, bool c, bool d, bool e)
            {
                dashboard = a;
                plsettings = b;
                sort = c;
                userLocal = d;
                userRemote = e;
            }
        }
        private static menuStates curMenuState;// = {false, false, false};



        public static void Init()
        {
            entryWrapperValue = PlayerListConfig.currentBaseSort.GetType().GetProperty("Value");
            curMenuState = new menuStates( false, false, false, false, false );
        }


        private void VRChat_OnUiManagerInit()
        {
            Log.Debug("Loading List UI...");

            _ = playerList;
            //_ = menuButton;


            //menuButton.SetLayerRecursive(12);
            //menuButton.transform.localPosition = Converters.ConvertToUnityUnits(new Vector3(4, -1));
            //menuButton.GetComponent<RectTransform>().pivot = new Vector2(0, 0);
            //menuButton.SetActive(!PlayerListConfig.useTabMenu.Value);
            //UiTooltip tooltip = menuButton.AddComponent<UiTooltip>();
            //tooltip.field_Public_String_0 = "Open PlayerList menu";
            //tooltip.field_Public_String_1 = "Open PlayerList menu";
            // menuButton.SetActive(true);


            playerList.SetLayerRecursive(12);
            playerList.AddComponent<VRC_UiShape>();
            playerListRect = playerList.GetComponent<RectTransform>();
            playerListRect.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            playerListRect.anchoredPosition = PlayerListConfig.playerListPosition.Value;
            playerListRect.localPosition = playerListRect.localPosition.SetZ(25); // Do this or else it looks off for whatever reason


            playerList.SetActive(true);
        }


        private static void OnUiPageToggled(UIPage Page, bool Toggle, UIPage.TransitionType TransitionType)
        {
            if (Page != null)
            {
                //Log.Debug("Page: " + page.name + " State: " + state.ToString());

                if (Page == PlayerList_Constants.qmDashboard)
                {
                    curMenuState.dashboard = Toggle;
                }
                else if (Page == PlayerList_Constants.selectedUserLocal)
                {
                    curMenuState.userLocal = Toggle;
                }
                else if (Page == PlayerList_Constants.selectedUserRemote)
                {
                    curMenuState.userRemote = Toggle;
                }

            }
        }

        private void OnQuickMenuOpen()
        {
            EntryManager.CleanUpHungAOI();
            curMenuState.dashboard = true;
            curMenuState.plsettings = false;
            curMenuState.sort = false;
            curMenuState.userLocal = false;
            curMenuState.userRemote = false;
            IsUIPageListenerActive = true;
        }

        private void OnQuickMenuClose()
        {
            PlayerListConfig.SaveEntries();
            IsUIPageListenerActive = false;
        }



        
        public enum MenuButtonPositionEnum
        {
            TopRight,
            TopLeft,
            BottomLeft,
            BottomRight
        }
    }
}
