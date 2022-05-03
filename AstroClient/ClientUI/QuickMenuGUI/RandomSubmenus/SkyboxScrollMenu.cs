using AstroClient.ClientActions;

namespace AstroClient.ClientUI.Menu.RandomSubmenus
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Tools.Skybox;
    using VRC.UI.Elements;
    using xAstroBoy.AstroButtonAPI.QuickMenuAPI;
    using xAstroBoy.AstroButtonAPI.Tools;
    using xAstroBoy.AstroButtonAPI.WingsAPI;

    internal class SkyboxScrollMenu : AstroEvents
    {
        internal override void RegisterToEvents()
        {
            ClientEventActions.OnRoomLeft += OnRoomLeft;
            ClientEventActions.OnQuickMenuClose += OnCloseMenu;
            ClientEventActions.OnBigMenuClose += OnCloseMenu;
            ClientEventActions.OnBigMenuOpen += OnCloseMenu;
        }
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
        private static QMWings WingMenu;
        private static QMNestedGridMenu CurrentScrollMenu;
        private static List<QMSingleButton> GeneratedButtons = new();

        //private static List<ScrollMenuListener> Listeners = new List<ScrollMenuListener>();
        private static QMWingSingleButton ExportSkybox;

        private static bool HasExportedSkybox { get; set; }

        private static bool HasThrownException { get; set; }
        private static bool CleanOnRoomLeave { get; } = false;
        private static bool DestroyOnMenuClose { get; } = false;

        private static bool HasGenerated { get; set; }
        private static bool isOpen { get; set; }

        private void OnRoomLeft()
        {
            if (CleanOnRoomLeave) DestroyGeneratedButtons();

            HasExportedSkybox = false;
        }

        internal static void InitButtons(QMGridTab menu)
        {
            CurrentScrollMenu = new QMNestedGridMenu(menu, "Skybox Options", "Edit Current Skybox");
            CurrentScrollMenu.OnOpenAction += OnOpenMenu;
            CurrentScrollMenu.OnCloseAction += OnCloseMenu;
            InitWingPage();
        }

        private static void Regenerate()
        {
            if (!HasGenerated)
            {
                try
                {
                    if (SkyboxEditor.LoadedSkyboxesBundles.Count() != 0)
                    {
                        foreach (var skybox in SkyboxEditor.LoadedSkyboxesBundles)
                            if (skybox != null)
                            {
                                var btn = new QMSingleButton(CurrentScrollMenu, skybox.SkyboxName, () => { SkyboxEditor.SetRenderSettingSkybox(skybox); }, $"Load Skybox {skybox.SkyboxName} as map Skybox.");
                                if (!skybox.isCubeMap)
                                {
                                    if (skybox.content.Front != null)
                                        btn.SetButtonImage(skybox.content.Front);
                                    else if (skybox.content.Left != null)
                                        btn.SetButtonImage(skybox.content.Left);
                                    else if (skybox.content.Back != null) btn.SetButtonImage(skybox.content.Back);
                                }

                                GeneratedButtons.Add(btn);
                            }
                    }
                    else
                    {
                        var empty = new QMSingleButton(CurrentScrollMenu, "No Skyboxes Found", null, "No Skyboxes Found");
                        GeneratedButtons.Add(empty);
                    }
                }
                catch (Exception e)
                {
                    Log.Exception(e);
                    HasThrownException = true;
                }

                HasGenerated = true;
            }
        }

        internal static void DestroyGeneratedButtons()
        {
            HasGenerated = false;
            if (GeneratedButtons.Count != 0)
                foreach (var item in GeneratedButtons)
                    item.DestroyMe();
            //if (Listeners.Count != 0)
            //{
            //    foreach (var item in Listeners) UnityEngine.Object.DestroyImmediate(item);
            //}
        }

        private void OnQuickMenuClose()
        {
            OnCloseMenu();
        }

        private static void OnCloseMenu()
        {
            IsUIPageListenerActive = false;
            isOpen = false;
            if (DestroyOnMenuClose || HasThrownException) DestroyGeneratedButtons();
            if (WingMenu != null)
            {
                
                WingMenu.SetActive(false);
            }
        }

        private static void OnOpenMenu()
        {
            isOpen = true;
            if (WingMenu != null)
            {
                WingMenu.SetActive(true);
                WingMenu.ShowWingsPage();

                if (SkyboxEditor.isSupportedSkybox)
                {
                    if (!HasExportedSkybox)
                    {
                        if (ExportSkybox != null) ExportSkybox.SetActive(true);
                    }
                    else
                    {
                        if (ExportSkybox != null) ExportSkybox.SetActive(false);
                    }
                }
                else
                {
                    if (ExportSkybox != null) ExportSkybox.SetActive(false);
                }
            }
            IsUIPageListenerActive = true;
            Regenerate();
        }

        private static void OnUiPageToggled(UIPage Page, bool Toggle, UIPage.TransitionType TransitionType)
        {
            if (!isOpen) return;

            if (Page != null)
                if (!Page.isPage(CurrentScrollMenu.GetPage()) )
                    OnCloseMenu();
        }

        private static void InitWingPage()
        {
            WingMenu = new QMWings(CurrentScrollMenu,1007, true, "Skybox Options", "Edit Current Skybox");
            new QMWingSingleButton(WingMenu, "Refresh", () =>
            {
                SkyboxEditor.FindAndLoadSkyboxes();
                DestroyGeneratedButtons();
                Regenerate();
            }, "Find New Skyboxes");
            new QMWingSingleButton(WingMenu, "Reset Skybox", () => { SkyboxEditor.SetRenderSettingSkybox(SkyboxEditor.OriginalSkybox); }, "Restore Original Skybox.");
            ExportSkybox = new QMWingSingleButton(WingMenu, "Export Skybox", () =>
            {
                if (!HasExportedSkybox)
                {
                    SkyboxEditor.ExportSixSidedSkybox();
                    SkyboxEditor.FindAndLoadSkyboxes();
                    ExportSkybox.SetActive(false);
                    HasExportedSkybox = true;
                    DestroyGeneratedButtons();
                    Regenerate();
                }
            }, "Attempts to Export Skybox and save it. (WIP).");

            WingMenu.SetActive(false);
        }
    }
}