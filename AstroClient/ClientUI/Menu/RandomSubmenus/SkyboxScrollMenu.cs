namespace AstroClient
{
    using AstroButtonAPI;
    using Skyboxes;
    using System.Collections.Generic;
    using System.Linq;
    using VRC.UI.Elements;

    internal class SkyboxScrollMenu : GameEvents
    {
        private static QMWings WingMenu;
        private static QMNestedGridMenu CurrentScrollMenu;
        private static List<QMSingleButton> GeneratedButtons = new List<QMSingleButton>();
        private static bool HasGenerated = false;
        private static bool isOpen;

        internal static void InitButtons(QMGridTab menu)
        {
            CurrentScrollMenu = new QMNestedGridMenu(menu, "Skybox Options", "Edit Current Skybox");
            CurrentScrollMenu.SetBackButtonAction(menu, () =>
            {
                WingMenu.SetActive(false);
                WingMenu.ClickBackButton();
            });
            CurrentScrollMenu.AddOpenAction(() =>
            {
                if (WingMenu != null)
                {
                    WingMenu.SetActive(true);
                    WingMenu.ShowLeftWingPage();
                }
                Regenerate();
            });
            InitWingPage();
        }

        private static void Regenerate()
        {
            if (!HasGenerated)
            {
                if (SkyboxEditor.LoadedSkyboxesBundles.Count() != 0)
                {
                    foreach (var skybox in SkyboxEditor.LoadedSkyboxesBundles)
                    {
                        if (skybox != null)
                        {
                            var btn = new QMSingleButton(CurrentScrollMenu, $" Skybox : {skybox.SkyboxName}.", () => { SkyboxEditor.SetRenderSettingSkybox(skybox); }, $"Load Skybox {skybox.SkyboxName} as map Skybox.", false);
                            GeneratedButtons.Add(btn);
                        }
                    }

                    HasGenerated = true;
                }
                else
                {
                    var empty = new QMSingleButton(CurrentScrollMenu, "No Skyboxes Found", null, "No Skyboxes Found", null, false);
                    GeneratedButtons.Add(empty);
                    HasGenerated = true;
                }
            }
        }

        internal static void DestroyGeneratedButtons()
        {
            if (GeneratedButtons.Count != 0)
            {
                foreach (var item in GeneratedButtons) item.DestroyMe();
            }
        }

        internal override void OnQuickMenuClose()
        {
            OnCloseMenu();
        }

        private static void OnCloseMenu()
        {
            WingMenu.SetActive(false);
            WingMenu.ClickBackButton();
        }

        private static void OnOpenMenu()
        {
            isOpen = true;
            if (WingMenu != null)
            {
                WingMenu.SetActive(true);
                WingMenu.ShowLeftWingPage();
            }
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
                _ = MelonLoader.MelonCoroutines.Start(SkyboxEditor.FindAndLoadBundle());
                HasGenerated = false;
                foreach (var item in GeneratedButtons) item.DestroyMe();
                Regenerate();
            }, "Find New Skyboxes");
            new QMWingSingleButton(WingMenu, "Reset Skybox", () =>
            {
                SkyboxEditor.SetRenderSettingSkybox(SkyboxEditor.OriginalSkybox);
            }, "Restore Original Skybox.");

            WingMenu.SetActive(false);
        }
    }
}