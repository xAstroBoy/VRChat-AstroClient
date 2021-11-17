namespace AstroClient.ClientUI.ItemTweakerV2.ScrollMenus.VRC_Triggers
{
    using System.Collections.Generic;
    using AstroMonos.Components.Tools.Listeners;
    using Selector;
    using Tools.Extensions;
    using VRC.UI.Elements;
    using xAstroBoy.AstroButtonAPI;
    using xAstroBoy.Utility;

    internal class VRC_TriggersScrollMenu : AstroEvents
    {
        private static QMWings WingMenu;
        private static QMNestedGridMenu CurrentScrollMenu;
        private static List<QMSingleButton> GeneratedButtons = new List<QMSingleButton>();
        private static List<ScrollMenuListener> Listeners = new List<ScrollMenuListener>();



        private static bool CleanOnRoomLeave { get; } = true;
        private static bool DestroyOnMenuClose { get; } = true;

        private static bool HasGenerated { get; set; } = false;
        private static bool isOpen { get; set; }


        internal override void OnRoomLeft()
        {
            if (CleanOnRoomLeave)
            {
                DestroyGeneratedButtons();
            }
        }


        internal static void InitButtons(QMTabMenu menu, float x, float y, bool btnHalf)
        {
            CurrentScrollMenu = new QMNestedGridMenu(menu, x, y, "Internal Triggers", "Interact with Internal Triggers", null, null, null, null, btnHalf);
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
            if (Listeners.Count != 0)
            {
                foreach (var item in Listeners) UnityEngine.Object.DestroyImmediate(item);
            }
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
            WingMenu = new QMWings(1002, true, "Tweaker Triggers", "Interact with Internal Triggers");
            new QMWingSingleButton(WingMenu, "Refresh", () =>
            {
                DestroyGeneratedButtons();
                Regenerate();
            }, "Refresh and force menu to regenerate");
            WingMenu.SetActive(false);
        }
    }
}