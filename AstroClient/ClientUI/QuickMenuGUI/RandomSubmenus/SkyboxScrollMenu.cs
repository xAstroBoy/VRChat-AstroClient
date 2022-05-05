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
                if (SkyboxEditor.GeneratedSkyboxesList.Count() == 0)
                {
                    var empty = new QMSingleButton(CurrentScrollMenu, "No Skyboxes Found", null, "No Skyboxes Found");
                    GeneratedButtons.Add(empty);
                    HasGenerated = true;
                    return;
                }
                else
                {
                    try
                    {
                        foreach (var skybox in SkyboxEditor.GeneratedSkyboxesList)
                            if (skybox != null)
                            {
                                var btn = new QMSingleButton(CurrentScrollMenu, skybox.Name, () => { SkyboxEditor.SetRenderSettingSkybox(skybox); }, $"Load Skybox {skybox.Name} as map Skybox.");
                                if (skybox.Front != null)
                                    btn.SetButtonImage(skybox.Front);
                                else if (skybox.Left != null)
                                    btn.SetButtonImage(skybox.Left);
                                else if (skybox.Back != null) btn.SetButtonImage(skybox.Back);

                                GeneratedButtons.Add(btn);
                            }
                    }
                    catch (Exception e)
                    {
                        Log.Exception(e);
                        HasThrownException = true;
                    }
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
        }

        private void OnQuickMenuClose()
        {
            OnCloseMenu();
        }

        private static void OnCloseMenu()
        {
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
            Regenerate();
        }


        private static void InitWingPage()
        {
            WingMenu = new QMWings(CurrentScrollMenu, 1007, true, "Skybox Options", "Edit Current Skybox");
            new QMWingSingleButton(WingMenu, "Refresh", () =>
            {


                DestroyGeneratedButtons();
                // Reload the list entirely
                foreach (var item in SkyboxEditor.GeneratedSkyboxesList)
                {
                    item.Destroy();
                }
                SkyboxEditor.GeneratedSkyboxesList.Clear();


                SkyboxEditor.FindAndLoadSkyboxes();
                Regenerate();
            }, "Reload Skyboxes ");
            new QMWingSingleButton(WingMenu, "Reset Skybox", () => { SkyboxEditor.RestoreOriginalSkybox(); }, "Restore Original Skybox.");
            
            
            ExportSkybox = new QMWingSingleButton(WingMenu, "Export Skybox", () =>
            {
                if (SkyboxEditor.isUsingCustomSkybox) return;
                if (!HasExportedSkybox)
                {
                    SkyboxEditor.ExportSkybox();
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