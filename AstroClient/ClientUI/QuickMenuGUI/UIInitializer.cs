﻿using AstroClient.AstroMonos;
using AstroClient.ClientActions;
using AstroClient.ClientResources.Loaders;
using AstroClient.ClientUI.QuickMenuGUI.ItemTweakerV2;
using AstroClient.ClientUI.QuickMenuGUI.Menus.Quickmenu;
using AstroClient.ClientUI.QuickMenuGUI.RandomSubmenus;
using AstroClient.ClientUI.QuickMenuGUI.Tabs;
using AstroClient.ClientUI.QuickMenuGUI.Wings;
using AstroClient.Constants;
using AstroClient.Kaned;
using AstroClient.Tools.Headlight;
using AstroClient.Tools.ObjectEditor;
using AstroClient.WorldModifications;
using AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI;

namespace AstroClient.ClientUI.QuickMenuGUI
{
    internal class UIInitializer : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.VRChat_OnUiManagerInit += VRChat_OnQuickMenuInit;
        }

        #region Buttons

        internal static QMToggleButton ToggleDebugInfo;
        internal static QMSingleButton CopyIDButton;
        internal static QMSingleButton AvatarByIDButton;
        internal static QMSingleButton ClearVRamButton;
        internal static QMSingleButton JoinInstanceButton;
        internal static QMSingleButton ReloadAvatarsButton;

        #endregion Buttons

        private void VRChat_OnQuickMenuInit()
        {
            InitMainsButtons();
        }

        internal static void InitMainsButtons()
        {
            QMGridTab AstroClient = new QMGridTab(TabIndexs.Main, "AstroClient Menu", null, null, null, Icons.planet_sprite);
            MainClientWings.InitMainWing();
            GameProcessMenu.InitButtons(AstroClient);
            ProtectionsMenu.InitButtons(AstroClient);
            SkyboxScrollMenu.InitButtons(AstroClient);
            LightControlMenu.InitButtons(AstroClient);
            GameObjectMenu.InitButtons(AstroClient);
            WorldPickupsBtn.InitButtons(AstroClient);

            ComponentsBtn.InitButtons(AstroClient);

            Headlight.HeadlightButtonInit(AstroClient);

            //CameraTweaker.InitQMMenu(AstroClient);

            SettingsMenuBtn.InitButtons(AstroClient);
            if (Bools.IsDeveloper)
            {
                MapEditorMenu.InitButtons(AstroClient);
                KanedWIP.InitMenu(AstroClient);
                //CheetosWIP.InitCheetosWIPMenu(AstroClient);
            }

            ToggleDebugInfo = new QMToggleButton(AstroClient, "Debug Console", () => { Bools.IsDebugMode = true; }, () => { Bools.IsDebugMode = false; }, "Shows Client Details in Melonloader's console", null, null, null, Bools.IsDebugMode);
            ToggleDebugInfo.SetToggleState(Bools.IsDebugMode);

            // Tabs.
            ExploitsMenu.InitButtons(TabIndexs.Exploits);
            WorldsCheats.InitButtons(TabIndexs.Cheats);
            //InstanceHistoryMenu.InitButtons(TabIndexs.History);

            // Misc
            TweakerV2Main.Init_TweakerV2Main(TabIndexs.Tweaker);
            //CheatsShortcutButton.Init_Cheats_ShortcutBtn();

            Log.Debug("Main UI Created!.");
            //_ = new QMSingleButton("MainMenu", 5, 3.5f, "GameObject Toggler", () =>
            //{
            //    GameObjMenu.ReturnToRoot();
            //    GameObjMenu.gameobjtogglermenu.GetMainButton().GetGameObject().GetComponent<Button>().onClick.Invoke();
            //}, "Advanced GameObject Toggler", null, null, true);
        }

    }
}
