namespace AstroClient
{
    using AstroButtonAPI;
    using Skyboxes;
    using System.Collections.Generic;
    using System.Linq;
    using AstroMonos.Components.Tools.Listeners;
    using VRC.UI.Elements;

    internal class SkyboxScrollMenu : GameEvents
    {
        private static QMWings WingMenu;
        private static QMNestedGridMenu CurrentScrollMenu;
        private static List<QMSingleButton> GeneratedButtons = new List<QMSingleButton>();
        //private static List<ScrollMenuListener> Listeners = new List<ScrollMenuListener>();



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
                }
                else
                {
                    var empty = new QMSingleButton(CurrentScrollMenu, "No Skyboxes Found", null, "No Skyboxes Found", null, false);
                    GeneratedButtons.Add(empty);
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
            if (DestroyOnMenuClose)
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
                WingMenu.ShowLeftWingPage();
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
                _ = MelonLoader.MelonCoroutines.Start(SkyboxEditor.FindAndLoadBundle());
                DestroyGeneratedButtons();
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