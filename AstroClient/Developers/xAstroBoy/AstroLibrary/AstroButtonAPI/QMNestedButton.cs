namespace AstroClient.xAstroBoy.AstroButtonAPI
{
    using System;
    using UnityEngine;
    using UnityEngine.UI;
    using VRC.UI.Elements;
    using Object = UnityEngine.Object;

    internal class QMNestedButton
    {
        internal QMNestedButton(QMNestedButton btnMenu, float btnXLocation, float btnYLocation, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            Parent = btnMenu.GetButtonsMenu();
            InitButton(btnXLocation, btnYLocation, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
        }

        internal QMNestedButton(QMNestedGridMenu btnMenu, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            Parent = btnMenu.GetButtonsMenu();
            InitButton(0, 0, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
        }

        internal QMNestedButton(QMNestedGridMenu btnMenu, float btnXLocation, float btnYLocation, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            Parent = btnMenu.GetButtonsMenu();
            InitButton(btnXLocation, btnYLocation, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
        }

        internal QMNestedButton(QmQuickActions btnMenu, float btnXLocation, float btnYLocation, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.Header.name;
            Parent = btnMenu.QuickActions;
            InitButton(btnXLocation, btnXLocation, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
        }



        internal QMNestedButton(QMGridTab btnMenu, float btnXLocation, float btnYLocation, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            Parent = btnMenu.GetButtonsMenu();
            InitButton(btnXLocation, btnYLocation, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
        }

        internal QMNestedButton(QMGridTab btnMenu, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            Parent = btnMenu.GetButtonsMenu();
            InitButton(0, 0, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
        }

        internal QMNestedButton(QMTabMenu btnMenu, float btnXLocation, float btnYLocation, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            Parent = btnMenu.GetButtonsMenu();
            InitButton(btnXLocation, btnYLocation, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
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

        internal GameObject Parent { get; set; }
        internal QMSingleButton mainButton { get; set; }

        internal GameObject backButton { get; set; }

        internal GameObject ButtonsMenu { get; set; }

        internal string menuName { get; set; }

        internal string btnQMLoc { get; set; }

        internal string btnType { get; set; }

        internal UIPage page { get; set; }

        internal void InitButton(float btnXLocation, float btnYLocation, string btnText, string btnToolTip, string Title = "", Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnType = QMButtonAPI.identifier + "_Nested_Menu_";
            menuName = $"Page_{btnType}_{Title}_{btnXLocation}_{btnYLocation}_{btnText}_{btnToolTip}_{Guid.NewGuid().ToString()}";

            var NestedPart = Object.Instantiate(QuickMenuTools.NestedMenuTemplate.gameObject, QuickMenuTools.NestedPages, true);
            ButtonsMenu = NestedPart.FindObject("Buttons");
            NestedPart.ToggleScrollRectOnExistingMenu(true);
            Object.Destroy(ButtonsMenu.GetComponentInChildren<GridLayoutGroup>());
            Object.Destroy(NestedPart.GetComponentInChildren<CameraMenu>());
            page = NestedPart.GenerateQuickMenuPage(menuName);
            NestedPart.name = menuName;
            NestedPart.NewText("Text_Title").text = Title;
            NestedPart.SetActive(false);
            NestedPart.CleanButtonsNestedMenu();
            string TextColorHTML = null;
            if (btnTextColor.HasValue)
                TextColorHTML = "#" + ColorUtility.ToHtmlStringRGB(btnTextColor.Value);
            else
                TextColorHTML = "#blue";

            if (Parent != null)
            {
                mainButton = new QMSingleButton(Parent, btnQMLoc, btnXLocation, btnYLocation, btnText, () => { QuickMenuTools.ShowQuickmenuPage(menuName); }, btnToolTip, TextColorHTML, btnHalf);
            }
            else
            {
                mainButton = new QMSingleButton(btnQMLoc, btnXLocation, btnYLocation, btnText, () => { QuickMenuTools.ShowQuickmenuPage(menuName); }, btnToolTip, TextColorHTML, btnHalf);
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

        internal void SetBackButtonAction(Action back)
        {
            backButton.SetBackButtonAction(back);
        }

        internal void AddOpenAction(Action onOpenAction)
        {
            mainButton.SetAction(() =>
            {
                QuickMenuTools.ShowQuickmenuPage(menuName);
                if (onOpenAction != null) onOpenAction();
            });
        }

        internal void SetBackButtonAction(QMNestedButton action, Action onCloseAction = null)
        {
            backButton.SetBackButtonAction(() =>
            {
                QuickMenuTools.ShowQuickmenuPage(action.GetMenuName());
                if (onCloseAction != null) onCloseAction();
            });
        }

        internal void SetBackButtonAction(QMNestedGridMenu action, Action onCloseAction = null)
        {
            backButton.SetBackButtonAction(() =>
            {
                QuickMenuTools.ShowQuickmenuPage(action.GetMenuName());
                if (onCloseAction != null) onCloseAction();
            });
        }

        internal void SetBackButtonAction(QMTabMenu action, Action onCloseAction = null)
        {
            backButton.SetBackButtonAction(() =>
            {
                QuickMenuTools.ShowQuickmenuPage(action.GetMenuName());
                if (onCloseAction != null) onCloseAction();
            });
        }

        internal void SetBackButtonAction(QMGridTab action, Action onCloseAction = null)
        {
            backButton.SetBackButtonAction(() =>
            {
                QuickMenuTools.ShowQuickmenuPage(action.GetMenuName());
                if (onCloseAction != null) onCloseAction();
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

        internal void SetIntractable(bool Interactable)
        {
            mainButton.SetIntractable(Interactable);
        }

        internal GameObject GetBackButton()
        {
            return backButton;
        }

        internal void DestroyMe()
        {
            mainButton.DestroyMe();
        }
    }
}