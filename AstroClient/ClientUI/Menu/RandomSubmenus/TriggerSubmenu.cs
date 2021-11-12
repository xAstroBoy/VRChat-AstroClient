namespace AstroClient
{
    using AstroButtonAPI;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using AstroMonos.Components.Tools.Listeners;
    using CheetoLibrary;
    using System.Collections.Generic;
    using VRC.UI.Elements;

    internal class TriggerSubmenu : GameEvents
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
            CurrentScrollMenu = new QMNestedGridMenu(menu, x, y, "Triggers", "Interact with World Triggers", null, null, null, null, btnHalf);
            CurrentScrollMenu.SetBackButtonAction(menu, () =>
            {
                OnCloseMenu();
            });
            CurrentScrollMenu.AddOpenAction(() =>
            {
                if (WingMenu != null)
                {
                    WingMenu.SetActive(true);
                }
                Regenerate();
            });
            InitWingPage();
        }

        private static void Regenerate()
        {
            foreach (var obj in WorldUtils_Old.Get_Triggers())
            {
                var btn = new QMSingleButton(CurrentScrollMenu, $"Click {obj.name}", () =>
                {
                    obj.TriggerClick();
                }, $"Click {obj.name}", obj.Get_GameObject_Active_ToColor());
                var listener = obj.gameObject.GetOrAddComponent<ScrollMenuListener>();
                if (listener != null)
                {
                    listener.SingleButton = btn;
                }
                GeneratedButtons.Add(btn);
            }
        }

        private static void OnCloseMenu()
        {
            WingMenu.SetActive(false);
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
            WingMenu = new QMWings(1003, true, "Triggers", "Interact with World Triggers");
            new QMWingSingleButton(WingMenu, "Refresh", () => { DestroyGeneratedButtons(); Regenerate(); }, "Refresh and force menu to regenerate");
            WingMenu.SetActive(false);
        }
    }
}