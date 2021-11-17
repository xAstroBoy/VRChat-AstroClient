namespace AstroClient.ClientUI.Menu.RandomSubmenus
{
    using System.Collections.Generic;
    using AstroMonos.Components.Tools.Listeners;
    using Tools.Extensions;
    using Tools.World;
    using VRC.UI.Elements;
    using xAstroBoy.AstroButtonAPI;

    internal class VRC_InteractableSubMenu : AstroEvents
    {
        private static QMWings WingMenu;
        private static QMNestedGridMenu CurrentScrollMenu;
        private static List<QMSingleButton> GeneratedButtons = new List<QMSingleButton>();
        private static List<ScrollMenuListener> Listeners = new List<ScrollMenuListener>();



        private static bool CleanOnRoomLeave { get; } = true;
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
            CurrentScrollMenu = new QMNestedGridMenu(menu, "VRC_Interactables", "Interact VRC_Interactable");
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
                foreach (var obj in WorldUtils_Old.Get_VRCInteractables())
                {
                    var btn = new QMSingleButton(CurrentScrollMenu, $"Click {obj.name}", () => { obj.VRC_Interactable_Click(); }, $"Interact with {obj.name}", obj.Get_GameObject_Active_ToColor());
                    var listener = obj.AddComponent<ScrollMenuListener>();
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
            WingMenu = new QMWings(1003, true, "VRC Interactables Menu", "Interact with VRC_Interactable Triggers");
            new QMWingSingleButton(WingMenu, "Refresh", () =>
            {
                DestroyGeneratedButtons();
                Regenerate();
            }, "Refresh and force menu to regenerate");
            WingMenu.SetActive(false);
        }
    }
}