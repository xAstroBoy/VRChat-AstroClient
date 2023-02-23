using AstroClient.CheetoLibrary;
using AstroClient.xAstroBoy.Utility;
using UnityEngine.UI;
using VRC.UI.Elements.Controls;
using VRC.UI.Elements.Menus;

namespace AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI
{
    using AstroClient.Tools.Extensions;
    using PageGenerators;
    using System;
    using Tools;
    using UnityEngine;
    using VRC.UI.Elements;
    using Object = UnityEngine.Object;
    internal class QMNestedButton
    {
        internal GameObject Header { get; set; }

        internal QMSingleButton mainButton { get; set; }

        internal GameObject backButton { get; set; }
        internal GameObject NestedPart { get; set; }

        internal GameObject ButtonsMenu { get; set; }

        internal GameObject Parent { get; set; }

        private UIPage page { get; set; }

        internal string menuName { get; set; }

        internal string btnQMLoc { get; set; }
        internal string btnType { get; set; }

        internal Action OnCloseAction { get; set; }
        internal Action OnOpenAction { get; set; }
        internal Action Wing_OnCloseAction { get; set; }
        internal Action Wing_OnOpenAction { get; set; }

        internal GameObject Title_Header { get; set; }
        internal TextMeshProUGUIPublicBoUnique TitleText {get; set;}

        internal QMNestedButton(QMNestedGridMenu btnMenu, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            Parent = btnMenu.GetButtonsMenu();
            InitButton(0, 0, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
            SetBackButtonMenu(btnMenu);
        }

        internal QMNestedButton(QMGridTab btnMenu, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            Parent = btnMenu.GetButtonsMenu();
            InitButton(0, 0, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
            SetBackButtonMenu(btnMenu);

        }

        internal QMNestedButton(QmQuickActions btnMenu, float btnXLocation, float btnYLocation, string btnText, string btnToolTip, Color? btnTextColor = null, bool isUserPage = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            Parent = btnMenu.GetButtonsMenu();
            InitButton(btnXLocation, btnYLocation, btnText, btnToolTip, null, null, btnTextColor, null, null, false);

            if (isUserPage)
            {
                mainButton.GetGameObject().EnableUIComponents();
            }
        }

        internal QMNestedButton(QMNestedButton btnMenu, float btnXLocation, float btnYLocation, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            Parent = btnMenu.GetButtonsMenu();
            InitButton(btnXLocation, btnYLocation, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
            SetBackButtonMenu(btnMenu);

        }

        internal QMNestedButton(QMGridTab btnMenu, float btnXLocation, float btnYLocation, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            Parent = btnMenu.GetButtonsMenu();
            InitButton(btnXLocation, btnYLocation, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
            SetBackButtonMenu(btnMenu);

        }

        internal QMNestedButton(QMTabMenu btnMenu, float btnXLocation, float btnYLocation, string btnText, string btnToolTip, Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnQMLoc = btnMenu.GetMenuName();
            Parent = btnMenu.GetButtonsMenu();
            InitButton(btnXLocation, btnYLocation, btnText, btnToolTip, null, btnBackgroundColor, btnTextColor, backbtnBackgroundColor, backbtnTextColor, btnHalf);
            SetBackButtonMenu(btnMenu);

        }

        

        internal void InitButton(float btnXLocation, float btnYLocation, string btnText, string btnToolTip, string Title = "", Color? btnBackgroundColor = null, Color? btnTextColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, bool btnHalf = false)
        {
            btnType = QMButtonAPI.identifier + "_Nested_GridMenu_";
            menuName = $"Page_{btnType}_{Title}_{btnXLocation}_{btnYLocation}_{btnText}_{btnToolTip}_{Guid.NewGuid().ToString()}";

            NestedPart = Object.Instantiate(QuickMenuTools.NestedMenuTemplate.gameObject, QuickMenuTools.NestedPages, true);
            NestedPart.EnableUIComponents();
            foreach (var item in NestedPart.GetComponentsInChildren<Behaviour>(true))
            {
                item.enabled = true;
            }
            try
            {
                Object.Destroy(NestedPart.GetComponentInChildren<CameraMenu>());
            }
            catch { }
            ButtonsMenu = NestedPart.FindObject("Scrollrect/Viewport/VerticalLayoutGroup/Buttons (1)");
            NestedPart.FindObject("Scrollrect/Viewport/VerticalLayoutGroup").gameObject.CleanCameraMenu();
            ButtonsMenu.name = "Buttons";
            //NestedPart.ToggleScrollRectOnExistingMenu(true);
            try
            {
                Object.Destroy(ButtonsMenu.GetComponentInChildren<GridLayoutGroup>());
            }
            catch { }
            page = NestedPart.GenerateQuickMenuPage(QuickMenuTools.QuickMenuController, menuName);
            NestedPart.name = menuName;
            Header = NestedPart.FindObject("Header_Camera");
            Header.name = "Header";
            Title_Header = Header.FindObject("LeftItemContainer/Text_Title");
            TitleText = Title_Header.GetComponent<TextMeshProUGUIPublicBoUnique>();
            TitleText.text = Title;
            NestedPart.SetActive(false);
            string TextColorHTML = null;
            TextColorHTML = "#" + ColorUtility.ToHtmlStringRGB(btnTextColor.GetValueOrDefault(System.Drawing.Color.White.ToUnityEngineColor()));

            mainButton = new QMSingleButton(Parent, btnQMLoc, btnXLocation, btnYLocation, btnText, () =>
            {
                QuickMenuTools.ShowQuickmenuPage(menuName);
                Wing_OnOpenAction.SafetyRaise();
                OnOpenAction.SafetyRaise();
                NestedPart.SetActive(true);
            }, btnToolTip, TextColorHTML, btnHalf);

            switch (Title)
            {
                case "Main Menu":
                    backButton = NestedPart.CreateMainBackButton();
                    break;
                case "Menu_SelectedUser_Remote":
                    backButton = NestedPart.CreateBackButton("QuickMenuSelectedUserRemote");
                    break;

                case "Menu_SelectedUser_Local":
                    backButton = NestedPart.CreateBackButton("QuickMenuSelectedUserLocal");
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

        internal void SetText(string Text)
        {
            mainButton.SetButtonText(Text);
        }





        internal void SetBackButtonMenu(QMNestedGridMenu menu)
        {
            backButton.SetBackButtonAction(() =>
            {
                QuickMenuTools.ShowQuickmenuPage(menu.GetMenuName());
                Wing_OnCloseAction.SafetyRaise();
                OnCloseAction.SafetyRaise();
                NestedPart.SetActive(false);

            });
        }

        internal void SetBackButtonMenu(QMNestedButton menu)
        {
            backButton.SetBackButtonAction(() =>
            {
                QuickMenuTools.ShowQuickmenuPage(menu.GetMenuName());
                Wing_OnCloseAction.SafetyRaise();
                OnCloseAction.SafetyRaise();
                NestedPart.SetActive(false);

            });
        }

        internal void SetBackButtonMenu(QMGridTab menu)
        {
            backButton.SetBackButtonAction(() =>
            {
                QuickMenuTools.ShowQuickmenuPage(menu.GetMenuName());
                Wing_OnCloseAction.SafetyRaise();
                OnCloseAction.SafetyRaise();
                NestedPart.SetActive(false);

            });
        }

        internal void SetBackButtonMenu(QMTabMenu menu)
        {
            backButton.SetBackButtonAction(() =>
            {
                QuickMenuTools.ShowQuickmenuPage(menu.GetMenuName());
                Wing_OnCloseAction.SafetyRaise();
                OnCloseAction.SafetyRaise();
                NestedPart.SetActive(false);
            });
        }

        internal void SetBackButtonMenuToDashboard()
        {
            backButton.SetBackButtonAction(() =>
            {
                QuickMenuTools.QuickMenuController.ShowTabContent("QuickMenuDashboard");
                Wing_OnCloseAction.SafetyRaise();
                OnCloseAction.SafetyRaise();
                NestedPart.SetActive(false);
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


        internal void SetToolTip(string text)
        {
            mainButton.SetToolTip(text);
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
            QuickMenuTools.QuickMenuController.RemovePage(page);
            UnityEngine.Object.Destroy(NestedPart);
            mainButton.DestroyMe();
        }
    }
}