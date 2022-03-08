namespace AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI
{
    using AstroClient.Tools.Extensions;
    using PageGenerators;
    using System;
    using Tools;
    using UnityEngine;
    using VRC.UI.Elements;
    using CameraMenu = MonoBehaviour1PublicBuToBuGaTMBuGaBuGaBuUnique;
    using Object = UnityEngine.Object;

    internal class QMNestedGridMenu
    {
        internal QMSingleButton mainButton { get; set; }

        internal GameObject backButton { get; set; }

        internal GameObject ButtonsMenu { get; set; }

        internal GameObject Parent { get; set; }

        internal UIPage page { get; set; }

        internal string menuName { get; set; }

        internal string btnQMLoc { get; set; }
        internal string btnType { get; set; }

        internal QMNestedGridMenu(QMNestedGridMenu btnMenu, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            Parent = btnMenu.GetButtonsMenu();
            InitButton(0, 0, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
        }

        internal QMNestedGridMenu(QMGridTab btnMenu, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            Parent = btnMenu.GetButtonsMenu();
            InitButton(0, 0, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
        }

        internal QMNestedGridMenu(QmQuickActions btnMenu, float btnXLocation, float btnYLocation, string btnText, string btnToolTip, Color? btnTextColor = null, bool isUserPage = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            Parent = btnMenu.GetButtonsMenu();
            InitButton(btnXLocation, btnYLocation, btnText, btnToolTip, null, null, btnTextColor, null, null, false);

            if (isUserPage)
            {
                mainButton.GetGameObject().EnableComponents();
                mainButton.GetGameObject().FindObject("Text_H4").GetComponent<VRC.UI.Core.Styles.StyleElement>().enabled = true;
            }
        }

        internal QMNestedGridMenu(QMNestedButton btnMenu, float btnXLocation, float btnYLocation, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            Parent = btnMenu.GetButtonsMenu();
            InitButton(btnXLocation, btnYLocation, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
        }

        internal QMNestedGridMenu(QMGridTab btnMenu, float btnXLocation, float btnYLocation, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            Parent = btnMenu.GetButtonsMenu();
            InitButton(btnXLocation, btnYLocation, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
        }

        internal QMNestedGridMenu(QMTabMenu btnMenu, float btnXLocation, float btnYLocation, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            Parent = btnMenu.GetButtonsMenu();
            InitButton(btnXLocation, btnYLocation, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
        }

        internal QMNestedGridMenu(string btnMenu, float btnXLocation, float btnYLocation, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu;
            InitButton(btnXLocation, btnYLocation, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
        }

        internal QMNestedGridMenu(string btnMenu, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null)
        {
            btnQMLoc = btnMenu;
            InitButton(0, 0, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor);
        }

        internal void InitButton(float btnXLocation, float btnYLocation, string btnText, string btnToolTip, string Title = "", Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnType = QMButtonAPI.identifier + "_Nested_GridMenu_";
            menuName = $"Page_{btnType}_{Title}_{btnXLocation}_{btnYLocation}_{btnText}_{btnToolTip}_{Guid.NewGuid().ToString()}";

            var NestedPart = Object.Instantiate(QuickMenuTools.NestedMenuTemplate.gameObject, QuickMenuTools.NestedPages, true);
            ButtonsMenu = NestedPart.FindObject("Buttons");
            NestedPart.ToggleScrollRectOnExistingMenu(true);
            Object.Destroy(NestedPart.GetComponentInChildren<CameraMenu>());
            Object.Destroy(NestedPart.FindObject("Panel_Info"));
            Object.Destroy(NestedPart.FindObject("Button_PhotosFolder"));
            //UnityEngine.GameObject.Destroy(ButtonsMenu.GetComponentInChildren<GridLayoutGroup>());
            foreach (var item in ButtonsMenu.transform.Get_Childs())
            {
                item.DestroyMeLocal(true);
            }

            page = NestedPart.GenerateQuickMenuPage(menuName);
            NestedPart.name = menuName;
            NestedPart.NewText("Text_Title").text = Title;
            NestedPart.SetActive(false);
            NestedPart.CleanButtonsNestedMenu();
            string TextColorHTML = null;
            TextColorHTML = "#" + ColorUtility.ToHtmlStringRGB(btnTextColor.GetValueOrDefault(System.Drawing.Color.White.ToUnityEngineColor()));

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
                    backButton = NestedPart.CreateBackButton(QMButtonAPI.identifier + "_Nested_GridMenu_" + "Main Menu");
                    break;
            }
        }

        internal void SetTextColor(Color buttonTextColor)
        {
            mainButton.SetTextColor(buttonTextColor);
        }

        internal void SetText(string Text)
        {
            mainButton.SetButtonText(Text);
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

        internal void SetBackButtonAction(QMNestedGridMenu action, Action onCloseAction = null)
        {
            backButton.SetBackButtonAction(() =>
            {
                QuickMenuTools.ShowQuickmenuPage(action.GetMenuName());
                if (onCloseAction != null) onCloseAction();
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

        internal void SetBackButtonAction(QMGridTab action, Action onCloseAction = null)
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

        internal GameObject GetButtonsMenu()
        {
            return ButtonsMenu;
        }

        internal UIPage GetPage()
        {
            return page;
        }

        internal string GetMenuName()
        {
            return menuName;
        }

        internal void SetInteractable(bool Interactable)
        {
            mainButton.SetInteractable(Interactable);
        }

        internal QMSingleButton GetMainButton()
        {
            return mainButton;
        }

        internal GameObject GetBackButton()
        {
            return backButton;
        }

        internal void DestroyMe()
        {
            mainButton.DestroyMe();
            backButton.DestroyMeLocal(true);
            ButtonsMenu.DestroyMeLocal(true);
            // page.DestroyMeLocal(true);
        }
    }
}