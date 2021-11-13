namespace AstroClient.ItemTweakerV2.Submenus.ScrollMenus
{
    using AstroButtonAPI;
    using AstroLibrary.Extensions;
    using AstroLibrary.Utility;
    using AstroMonos.Components.Tools.Listeners;
    using CheetoLibrary;
    using Selector;
    using System.Collections.Generic;
    using VRC.UI.Elements;

    internal class VRC_TriggersScrollMenu : GameEvents
    {
        private static QMWings WingMenu;
        private static QMNestedGridMenu CurrentScrollMenu;
        private static List<QMSingleButton> GeneratedButtons = new List<QMSingleButton>();
        private static List<ScrollMenuListener> Listeners = new List<ScrollMenuListener>();
        private static bool isOpen;

        internal override void OnRoomLeft()
        {
            DestroyGeneratedButtons();
        }

        internal static void InitButtons(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            CurrentScrollMenu = new QMNestedGridMenu(menu, x, y, "Internal Triggers", "Interact with  Internal Triggers", null, null, null, null, btnHalf);
            CurrentScrollMenu.SetBackButtonAction(menu, () =>
            {
                OnCloseMenu();
            });
            CurrentScrollMenu.AddOpenAction(() =>
            {
                OnOpenMenu();
                Regenerate();
            });
            InitWingPage();
        }

        private static void Regenerate()
        {
            foreach (var obj in Tweaker_Object.GetGameObjectToEdit().Get_Triggers())
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
                Listeners.Add(listener);
                GeneratedButtons.Add(btn);
            }
        }

        private static void OnCloseMenu()
        {
            WingMenu.SetActive(false);
            WingMenu.ClickBackButton();
            DestroyGeneratedButtons();
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

        private static void DestroyGeneratedButtons()
        {
            if (GeneratedButtons.Count != 0)
            {
                foreach (var item in GeneratedButtons) item.DestroyMe();
            }

            if (Listeners.Count != 0)
            {
                foreach (var item in Listeners) UnityEngine.Object.Destroy(item);
            }
        }

        internal override void OnQuickMenuClose()
        {
            OnCloseMenu();
        }

        internal override void OnUiPageToggled(UIPage Page, bool Toggle)
        {
            if (!isOpen) return;
            if (Page != null)
            {
                if (!Page.ContainsPage(CurrentScrollMenu.page))
                {
                    OnCloseMenu();
                }
            }
        }

        private static void InitWingPage()
        {
            WingMenu = new QMWings(1002, true, "Tweaker Triggers", "Interact with Internal Triggers");
            new QMWingSingleButton(WingMenu, "Refresh", () => { DestroyGeneratedButtons(); Regenerate(); }, "Refresh and force menu to regenerate");
            WingMenu.SetActive(false);
        }
    }
}