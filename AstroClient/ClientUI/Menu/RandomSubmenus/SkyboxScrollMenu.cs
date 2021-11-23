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
        private static QMWings WingMenu;
        private static QMNestedGridMenu CurrentScrollMenu;
        private static List<QMSingleButton> GeneratedButtons = new List<QMSingleButton>();

        //private static List<ScrollMenuListener> Listeners = new List<ScrollMenuListener>();
        private static QMWingSingleButton ExportSkybox;

        private static bool HasExportedSkybox { get; set; } = false;

        private static bool HasThrownException { get; set; } = false;
        private static bool CleanOnRoomLeave { get; } = false;
        private static bool DestroyOnMenuClose { get; } = false;

        private static bool HasGenerated { get; set; } = false;
        private static bool isOpen { get; set; }

        internal override void OnRoomLeft()
        {
            if (CleanOnRoomLeave)
            {
                DestroyGeneratedButtons();
            }
        }

        internal static void InitButtons(QMGridTab menu)
        {
            CurrentScrollMenu = new QMNestedGridMenu(menu, "Skybox Options", "Edit Current Skybox");
            CurrentScrollMenu.SetBackButtonAction(menu, () =>
            {
                OnCloseMenu();
            });
            CurrentScrollMenu.AddOpenAction(() =>
            {
                OnOpenMenu();
            });
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
                        {
                            if (skybox != null)
                            {
                                var btn = new QMSingleButton(CurrentScrollMenu, skybox.SkyboxName, () => { SkyboxEditor.SetRenderSettingSkybox(skybox); }, $"Load Skybox {skybox.SkyboxName} as map Skybox.");
                                if (!skybox.isCubeMap)
                                {
                                    if (skybox.content.Front != null)
                                    {
                                        btn.SetButtonImage(skybox.content.Front);
                                    }
                                    else if (skybox.content.Left != null)
                                    {
                                        btn.SetButtonImage(skybox.content.Left);
                                    }
                                    else if (skybox.content.Back != null)
                                    {
                                        btn.SetButtonImage(skybox.content.Back);
                                    }
                                }
                                GeneratedButtons.Add(btn);
                            }
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
                    ModConsole.ErrorExc(e);
                    HasThrownException = true;
                }

                HasGenerated = true;
            }
        }

        internal static void DestroyGeneratedButtons()
        {
            HasGenerated = false;
            if (GeneratedButtons.Count != 0)
            {
                foreach (var item in GeneratedButtons) item.DestroyMe();
            }
            //if (Listeners.Count != 0)
            //{
            //    foreach (var item in Listeners) UnityEngine.Object.DestroyImmediate(item);
            //}
        }

        internal override void OnQuickMenuClose()
        {
            OnCloseMenu();
        }

        private static void OnCloseMenu()
        {
            if (DestroyOnMenuClose || HasThrownException)
            {
                DestroyGeneratedButtons();
            }
            if (WingMenu != null)
            {
                WingMenu.SetActive(false);
                WingMenu.ClickBackButton();
            }
            isOpen = false;
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
                        if (ExportSkybox != null)
                        {
                            ExportSkybox.SetActive(true);
                        }
                    }
                    else
                    {
                        if (ExportSkybox != null)
                        {
                            ExportSkybox.SetActive(false);
                        }
                    }
                }
                else
                {
                    if (ExportSkybox != null)
                    {
                        ExportSkybox.SetActive(false);
                    }
                }
            }
            Regenerate();
        }

        internal override void OnUiPageToggled(UIPage Page, bool Toggle)
        {
            if (!isOpen) return;

            if (Page != null)
            {
                if (!Page.ContainsPage(CurrentScrollMenu.page) && !Page.ContainsPage(WingMenu.CurrentPage))
                {
                    OnCloseMenu();
                }
            }
        }

        private static void InitWingPage()
        {
            WingMenu = new QMWings(1007, true, "Skybox Options", "Edit Current Skybox");
            new QMWingSingleButton(WingMenu, "Refresh", () =>
            {
                SkyboxEditor.FindAndLoadSkyboxes();
                DestroyGeneratedButtons();
                Regenerate();
            }, "Find New Skyboxes");
            new QMWingSingleButton(WingMenu, "Reset Skybox", () =>
            {
                SkyboxEditor.SetRenderSettingSkybox(SkyboxEditor.OriginalSkybox);
            }, "Restore Original Skybox.");
            ExportSkybox = new QMWingSingleButton(WingMenu, "Export Skybox", () =>
             {
                 if (!HasExportedSkybox)
                 {
                     SkyboxEditor.ExportSkybox();
                     SkyboxEditor.FindAndLoadSkyboxes();
                     DestroyGeneratedButtons();
                     Regenerate();
                     ExportSkybox.SetActive(false);
                     HasExportedSkybox = true;
                 }
             }, "Attempts to Export Skybox and save it. (WIP).");

            WingMenu.SetActive(false);
        }
    }
}