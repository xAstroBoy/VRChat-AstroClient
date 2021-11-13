namespace AstroClient
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Management;
    using AstroButtonAPI;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using AstroMonos.Components.Tools.Listeners;
    using MelonLoader;
    using Skyboxes;
    using Udon;
    using Udon.UdonEditor;
    using UnityEngine;
    using VRC.Udon.Common.Interfaces;
    using VRC.UI.Elements;

    internal class SkyboxScrollMenu : GameEvents
    {

        private static QMWings WingMenu;
        private static QMNestedGridMenu CurrentScrollMenu;
        private static List<QMSingleButton> GeneratedButtons = new List<QMSingleButton>();
        private static bool HasGenerated = false;

        internal static void InitButtons(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            CurrentScrollMenu = new QMNestedGridMenu(menu, x, y, "Skybox Options", "Edit Current Skybox", null, null, null, null, btnHalf);
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
            WingMenu.SetActive(false);
            WingMenu.ClickBackButton();
        }


        internal override void OnUiPageToggled(UIPage Page, bool Toggle)
        {
            if (Page != null)
            {
                if (QuickMenuTools.UIPageTemplate_Left() != null)
                {
                    if (Page.Equals(QuickMenuTools.UIPageTemplate_Left())) return;
                }
                if (QuickMenuTools.UIPageTemplate_Right() != null)
                {
                    if (Page.Equals(QuickMenuTools.UIPageTemplate_Right())) return;
                }
                if (Page.Equals(WingMenu.CurrentPage)) return;
                if (!Page.Equals(CurrentScrollMenu.page))
                {
                    WingMenu.SetActive(false);
                }
            }
        }



        private static void InitWingPage()
        {
            WingMenu = new QMWings(1007, true, "Skybox Options", "Edit Current Skybox");
            new QMWingSingleButton(WingMenu, "Refresh", () => {
                _ = MelonLoader.MelonCoroutines.Start(SkyboxEditor.FindAndLoadBundle());
                HasGenerated = false;
                foreach (var item in GeneratedButtons) item.DestroyMe();
                Regenerate();
            }, "Find New Skyboxes");
            new QMWingSingleButton(WingMenu, "Reset Skybox", () => {
                SkyboxEditor.SetRenderSettingSkybox(SkyboxEditor.OriginalSkybox);

            }, "Restore Original Skybox.");

            WingMenu.SetActive(false);
        }


    }
}