namespace AstroClient.ClientUI.Menu
{
    using AstroMonos;
    using ClientUI.Menu;
    using Experiments;
    using MelonLoader;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Reflection;
    using Constants;
    using ItemTweakerV2;
    using Menus;
    using Networking;
    using RandomSubmenus;
    using Tabs;
    using Tools.Headlight;
    using Tools.ObjectEditor;
    using UnhollowerBaseLib;
    using UnityEngine;
    using Wings;
    using WorldAddons;
    using xAstroBoy.AstroButtonAPI;
    using Application = UnityEngine.Application;
    using Color = System.Drawing.Color;
    using Console = CheetosConsole.Console;

    internal class UIInitializer : AstroEvents
    {
        #region Buttons

        internal static QMToggleButton ToggleDebugInfo;
        internal static QMSingleButton CopyIDButton;
        internal static QMSingleButton AvatarByIDButton;
        internal static QMSingleButton ClearVRamButton;
        internal static QMSingleButton JoinInstanceButton;
        internal static QMSingleButton ReloadAvatarsButton;

        #endregion Buttons


        internal static void InitMainsButtons()
        {
            if (!KeyManager.IsAuthed) return;
            QMGridTab AstroClient = new QMGridTab(TabIndexs.Main, "AstroClient Menu", null, null, null, ClientResources.ClientResources.planet_sprite);
            MainClientWings.InitMainWing();
            GameProcessMenu.InitButtons(AstroClient);
            ProtectionsMenu.InitButtons(AstroClient);
            SkyboxScrollMenu.InitButtons(AstroClient);
            LightControlMenu.InitButtons(AstroClient);
            GameObjectMenu.InitButtons(AstroClient);
            if (Bools.IsDeveloper)
            {
                MapEditorMenu.InitButtons(AstroClient);
            }

            WorldPickupsBtn.InitButtons(AstroClient);

            ComponentsBtn.InitButtons(AstroClient);

            Headlight.HeadlightButtonInit(AstroClient);

            CameraTweaker.InitQMMenu(AstroClient);

            SettingsMenuBtn.InitButtons(AstroClient);

            ToggleDebugInfo = new QMToggleButton(AstroClient, "Debug Console", () => { Bools.IsDebugMode = true; }, () => { Bools.IsDebugMode = false; }, "Shows Client Details in Melonloader's console", null, null, null, Bools.AntiPortal);
            // Top Right Buttons
            ToggleDebugInfo.SetToggleState(Bools.IsDebugMode);

            ExploitsMenu.InitButtons(TabIndexs.Exploits);
            WorldsCheats.InitButtons(TabIndexs.Cheats);
            HistoryMenu.InitButtons(TabIndexs.History);
            AdminMenu.InitButtons(TabIndexs.Admin);
            DevMenu.InitButtons(TabIndexs.Dev);

            // Misc
            TweakerV2Main.Init_TweakerV2Main(TabIndexs.Tweaker);
            ModConsole.DebugLog("Done.");

            CheatsShortcutButton.Init_Cheats_ShortcutBtn();

            //_ = new QMSingleButton("MainMenu", 5, 3.5f, "GameObject Toggler", () =>
            //{
            //    GameObjMenu.ReturnToRoot();
            //    GameObjMenu.gameobjtogglermenu.GetMainButton().GetGameObject().GetComponent<Button>().onClick.Invoke();
            //}, "Advanced GameObject Toggler", null, null, true);
        }



    }
}
