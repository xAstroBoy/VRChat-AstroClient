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


        private static bool HasThrownException { get; set; }
        private static bool CleanOnRoomLeave { get; } = false;
        private static bool DestroyOnMenuClose { get; } = false;

        private static bool HasGenerated { get; set; }
        private static bool isOpen { get; set; }

        private void OnRoomLeft()
        {
            if (CleanOnRoomLeave) DestroyGeneratedButtons();
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
                        foreach (var entry in SkyboxEditor.GeneratedSkyboxesList)
                            if (entry.Value != null)
                            {
                                var skybox = entry.Value;
                                if (skybox != null)
                                {
                                    var btn = new QMSingleButton(CurrentScrollMenu, skybox.Name, () => { SkyboxEditor.SetRenderSettingSkybox(skybox); }, $"Load Skybox {skybox.Name} as map Skybox.");
                                    if (skybox.Front != null)
                                        btn.SetButtonImage(skybox.Front);
                                    else if (skybox.Left != null)
                                        btn.SetButtonImage(skybox.Left);
                                    else if (skybox.Back != null) 
                                        btn.SetButtonImage(skybox.Back);
                                    skybox.SetAssignedButton(btn);
                                    GeneratedButtons.Add(btn);
                                }
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
                    if (!SkyboxEditor.hasExportedSkybox())
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


        private static QMWingToggleButton MaterialCopierToggle = null;
        private static bool _shouldCopyOriginalMatProperties = false;

        internal static bool ShouldCopyOriginalMatProperties
        {
            get => _shouldCopyOriginalMatProperties;
            set
            {
                
                _shouldCopyOriginalMatProperties = value;
                if(MaterialCopierToggle != null)
                {
                    MaterialCopierToggle.SetToggleState(value);
                }

            }
        }

        private static void InitWingPage()
        {
            WingMenu = new QMWings(CurrentScrollMenu, 1007, true, "Skybox Options", "Edit Current Skybox");
            new QMWingSingleButton(WingMenu, "Refresh", () =>
            {
                DestroyGeneratedButtons();
                SkyboxEditor.FindAndLoadSkyboxes();
                Regenerate();
            }, "Loads all the skyboxes in folders.");
            new QMWingSingleButton(WingMenu, "Reset Skybox", () => { SkyboxEditor.RestoreOriginalSkybox(); }, "Restore Original Skybox.");
            new QMWingSingleButton(WingMenu, "Reload Custom Skybox Textures", () =>
            {
                SkyboxEditor.RefreshMaterialTextures();
            }, "Refreshes the material textures.");
            
            
            ExportSkybox = new QMWingSingleButton(WingMenu, "Export Skybox", () =>
            {
                if (SkyboxEditor.isUsingCustomSkybox) return;
                SkyboxEditor.ExportSkybox();
                SkyboxEditor.FindAndLoadSkyboxes();
                ExportSkybox.SetActive(false);
                DestroyGeneratedButtons();
                Regenerate();
            }, "Attempts to Export Skybox and save it. (WIP).");

            MaterialCopierToggle = new QMWingToggleButton(WingMenu, "Copy Original Skybox Properties", () =>
            {

                ShouldCopyOriginalMatProperties = true;
            }, () =>
            {
                ShouldCopyOriginalMatProperties = false;
            },"Copy Original Skybox Properties in case the applied skybox is not well visible.");
            WingMenu.SetActive(false);
        }
    }
}