namespace AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI
{
    using AstroClient.Tools.Extensions;
    using PageGenerators;
    using System;
    using Tools;
    using UnityEngine;
    using UnityEngine.UI;
    using VRC.UI.Elements;
    using CameraMenu = MonoBehaviour1PublicBuToBuGaTMBuGaBuGaBuUnique;
    using Object = UnityEngine.Object;

    internal class QMNestedButton
    {
        internal GameObject NestedPart { get; set; }

        internal GameObject backButton { get; set; }
        internal GameObject ButtonsMenu { get; set; }
        internal GameObject Parent { get; set; }
        private UIPage page { get; set; }

        internal QMSingleButton mainButton { get; set; }

        internal string menuName { get; set; }

        internal string btnQMLoc { get; set; }

        internal string btnType { get; set; }
        internal Action OnCloseAction { get; set; }
        internal Action OnOpenAction { get; set; }

        internal Action Wing_OnCloseAction { get; set; }
        internal Action Wing_OnOpenAction { get; set; }


        internal QMNestedButton(QMNestedButton btnMenu, float btnXLocation, float btnYLocation, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            Parent = btnMenu.GetButtonsMenu();
            InitButton(btnXLocation, btnYLocation, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
            SetBackButtonMenu(btnMenu);
        }

        internal QMNestedButton(QMNestedGridMenu btnMenu, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            Parent = btnMenu.GetButtonsMenu();
            InitButton(0, 0, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
            SetBackButtonMenu(btnMenu);
        }

        internal QMNestedButton(QmQuickActions btnMenu, float btnXLocation, float btnYLocation, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            Parent = btnMenu.GetButtonsMenu();
            InitButton(btnXLocation, btnXLocation, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
        }

        internal QMNestedButton(QMGridTab btnMenu, float btnXLocation, float btnYLocation, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            Parent = btnMenu.GetButtonsMenu();
            InitButton(btnXLocation, btnYLocation, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
            SetBackButtonMenu(btnMenu);
        }

        internal QMNestedButton(QMGridTab btnMenu, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            Parent = btnMenu.GetButtonsMenu();
            InitButton(0, 0, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
            SetBackButtonMenu(btnMenu);
        }

        internal QMNestedButton(QMTabMenu btnMenu, float btnXLocation, float btnYLocation, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            Parent = btnMenu.GetButtonsMenu();
            InitButton(btnXLocation, btnYLocation, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
            SetBackButtonMenuToDashboard();
        }

        internal QMNestedButton(string btnMenu, float btnXLocation, float btnYLocation, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu;
            InitButton(btnXLocation, btnYLocation, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
        }

        internal QMNestedButton(GameObject buttons, string btnMenu, float btnXLocation, float btnYLocation, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu;
            Parent = buttons;
            InitButton(btnXLocation, btnYLocation, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
        }

        internal void InitButton(float btnXLocation, float btnYLocation, string btnText, string btnToolTip, string Title = "", Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnType = QMButtonAPI.identifier + "_Nested_Menu_";
            menuName = $"Page_{btnType}_{Title}_{btnXLocation}_{btnYLocation}_{btnText}_{btnToolTip}_{Guid.NewGuid().ToString()}";

            NestedPart = Object.Instantiate(QuickMenuTools.NestedMenuTemplate.gameObject, QuickMenuTools.NestedPages, true);
            ButtonsMenu = NestedPart.FindUIObject("Buttons");
            NestedPart.ToggleScrollRectOnExistingMenu(true);
            try
            {
                Object.Destroy(ButtonsMenu.GetComponentInChildren<GridLayoutGroup>());
            }
            catch { }
            try
            {
                Object.Destroy(NestedPart.GetComponentInChildren<CameraMenu>());
            }
            catch { }
            try
            {
                Object.Destroy(NestedPart.FindUIObject("Panel_Info"));
            }
            catch { }
            try
            {
                Object.Destroy(NestedPart.FindUIObject("Button_PhotosFolder"));
            }
            catch { }
            try
            {
                Object.Destroy(NestedPart.FindUIObject("Button_PanoramaMain"));
            }
            catch { }
            try
            {
                Object.Destroy(NestedPart.FindUIObject("Button_PanoramaStream"));
            }
            catch { }

            foreach (var item in ButtonsMenu.transform.Get_Childs())
            {
                UnityEngine.Object.Destroy(item);
            }

            page = NestedPart.GenerateQuickMenuPage(QuickMenuTools.QuickMenuController, menuName);
            NestedPart.name = menuName;
            NestedPart.NewText("Text_Title").text = Title;
            NestedPart.SetActive(false);
            NestedPart.CleanButtonsNestedMenu();
            string TextColorHTML = null;
            if (btnTextColor.HasValue)
                TextColorHTML = "#" + ColorUtility.ToHtmlStringRGB(btnTextColor.Value);
            else
                TextColorHTML = "#" + ColorUtility.ToHtmlStringRGB(System.Drawing.Color.White.ToUnityEngineColor());
            if (Parent != null)
            {
                mainButton = new QMSingleButton(Parent, btnQMLoc, btnXLocation, btnYLocation, btnText, () =>
                {
                    QuickMenuTools.ShowQuickmenuPage(menuName);
                    Wing_OnOpenAction.SafetyRaise();
                    OnOpenAction.SafetyRaise();
                }, btnToolTip, TextColorHTML, btnHalf);
            }
            else
            {
                mainButton = new QMSingleButton(btnQMLoc, btnXLocation, btnYLocation, btnText, () =>
                {
                    QuickMenuTools.ShowQuickmenuPage(menuName);
                    Wing_OnOpenAction.SafetyRaise();
                    OnOpenAction.SafetyRaise();
                }, btnToolTip, TextColorHTML, btnHalf);
            }

            switch (Title)
            {
                case "Main Menu":
                    backButton = NestedPart.CreateMainBackButton();
                    break;

                default:
                    backButton = NestedPart.CreateBackButton(QMButtonAPI.identifier + "_Nested_Menu_" + "Main Menu");
                    break;
            }
        }

        internal void SetTextColor(Color buttonTextColor)
        {
            mainButton.SetTextColor(buttonTextColor);
        }

        internal void SetBackButtonMenu(QMNestedGridMenu menu)
        {
            backButton.SetBackButtonAction(() =>
            {
                QuickMenuTools.ShowQuickmenuPage(menu.GetMenuName());
                Wing_OnCloseAction.SafetyRaise();
                OnCloseAction.SafetyRaise();
            });
        }

        internal void SetBackButtonMenu(QMNestedButton menu)
        {
            backButton.SetBackButtonAction(() =>
            {
                QuickMenuTools.ShowQuickmenuPage(menu.GetMenuName());
                Wing_OnCloseAction.SafetyRaise();
                OnCloseAction.SafetyRaise();
            });
        }

        internal void SetBackButtonMenu(QMGridTab menu)
        {
            backButton.SetBackButtonAction(() =>
            {
                QuickMenuTools.ShowQuickmenuPage(menu.GetMenuName());
                Wing_OnCloseAction.SafetyRaise();
                OnCloseAction.SafetyRaise();
            });
        }

        internal void SetBackButtonMenu(QMTabMenu menu)
        {
            backButton.SetBackButtonAction(() =>
            {
                QuickMenuTools.ShowQuickmenuPage(menu.GetMenuName());
                Wing_OnCloseAction.SafetyRaise();
                OnCloseAction.SafetyRaise();
            });
        }

        internal void SetBackButtonMenuToDashboard()
        {
            backButton.SetBackButtonAction(() =>
            {
                QuickMenuTools.QuickMenuController.ShowTabContent("QuickMenuDashboard");
                Wing_OnCloseAction.SafetyRaise();
                OnCloseAction.SafetyRaise();
            });
        }

        internal string GetMenuName()
        {
            return menuName;
        }

        internal QMSingleButton GetMainButton()
        {
            return mainButton;
        }

        internal GameObject GetButtonsMenu()
        {
            return ButtonsMenu;
        }

        internal UIPage GetPage()
        {
            return page;
        }

        internal void SetInteractable(bool Interactable)
        {
            mainButton.SetInteractable(Interactable);
        }

        internal GameObject GetBackButton()
        {
            return backButton;
        }

        internal void DestroyMe()
        {
            UnityEngine.Object.Destroy(NestedPart);
            UnityEngine.Object.Destroy(backButton);
            QuickMenuTools.QuickMenuController.RemovePage(page);
            mainButton.DestroyMe();
        }
    }
}