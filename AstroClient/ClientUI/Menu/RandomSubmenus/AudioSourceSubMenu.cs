﻿namespace AstroClient
{
    using AstroButtonAPI;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using AstroMonos.Components.Tools.Listeners;
    using CheetoLibrary;
    using System.Collections.Generic;
    using VRC.UI.Elements;

    internal class AudioSourceSubMenu : GameEvents
    {
        private static QMWings WingMenu;
        private static QMNestedGridMenu CurrentScrollMenu;
        private static List<QMSingleButton> GeneratedButtons = new List<QMSingleButton>();

        internal override void OnRoomLeft()
        {
            DestroyGeneratedButtons();
        }

        internal static void InitButtons(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            CurrentScrollMenu = new QMNestedGridMenu(menu, x, y, "AudioSources", "Toggle AudioSources", null, null, null, null, btnHalf);
            CurrentScrollMenu.SetBackButtonAction(menu, () =>
            {
                OnCloseMenu();
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
            foreach (var obj in WorldUtils_Old.Get_AudioSources())
            {
                var btn = new QMSingleButton(CurrentScrollMenu, $"Toggle {obj.name}", null, $"Toggle {obj.name}", obj.Get_AudioSource_Active_ToColor());
                btn.SetAction(() =>
                {
                    obj.enabled = !obj.enabled;
                    btn.SetTextColor(obj.Get_AudioSource_Active_ToColor());
                });
                //var listener = obj.gameObject.AddComponent<ScrollMenuListener_AudioSource>();
                //if (listener != null)
                //{
                //    listener.Assignedbtn = btn;
                //    listener.source = obj;
                //    listener.Lock = false;
                //}
                GeneratedButtons.Add(btn);
            }
        }

        private static void OnCloseMenu()
        {
            WingMenu.SetActive(false);
            WingMenu.ClickBackButton();
            DestroyGeneratedButtons();
        }

        private static void DestroyGeneratedButtons()
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
                    OnCloseMenu();
                }
            }
        }

        private static void InitWingPage()
        {
            WingMenu = new QMWings(1010, true, "AudioSources", "AudioSources Control");
            new QMWingSingleButton(WingMenu, "Refresh", () => { DestroyGeneratedButtons(); Regenerate(); }, "Refresh and force menu to regenerate");
            WingMenu.SetActive(false);
        }
    }
}