using System;
using AstroClient.CheetoLibrary;
using VRC.UI.Elements.Menus;

namespace AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI
{
    using AstroClient.Tools.Extensions;
    using PageGenerators;
    using Tools;
    using UnityEngine;
    using UnityEngine.UI;
    using VRC.UI.Elements;
    ///using CameraMenu = MonoBehaviour1PublicBuToBuGaReBuGaTMVeBuUnique;

    internal class QMTabMenu
    {
        internal string btnQMLoc { get; set; }
        internal string btnType { get; set; }
        internal GameObject ButtonsMenu { get; set; }
        internal QMTabButton mainButton { get; set; }
        internal string menuName { get; set; }
        private UIPage page { get; set; }
        internal GameObject NestedPart { get; set; }
        internal GameObject backButton { get; set; }
        internal Action OnCloseAction { get; set; }
        internal Action OnOpenAction { get; set; }
        internal GameObject Title_Header { get; set; }
        internal TextMeshProUGUIPublicBoUnique TitleText { get; set; }

        internal QMTabMenu(int index, string btnToolTip, Color? btnBackgroundColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, Sprite icon = null)
        {
            InitButton(index, btnToolTip, btnBackgroundColor, backbtnBackgroundColor, backbtnTextColor, icon);
        }

        internal void InitButton(int index, string btnToolTip, Color? btnBackgroundColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, Sprite icon = null)
        {
            btnType = "QMTabMenu";
            menuName = QMButtonAPI.identifier + btnQMLoc + "_" + index + "_" + btnToolTip;

            NestedPart = Object.Instantiate(QuickMenuTools.NestedMenuTemplate.gameObject, QuickMenuTools.NestedPages, true);
            try
            {
                Object.DestroyImmediate(NestedPart.GetComponentInChildren<CameraMenu>());
            }
            catch { }
            ButtonsMenu = NestedPart.FindObject("Scrollrect/Viewport/VerticalLayoutGroup/Buttons (1)");
            NestedPart.FindObject("Scrollrect/Viewport/VerticalLayoutGroup").gameObject.CleanCameraMenu();
            ButtonsMenu.name = "Buttons";
            NestedPart.ToggleScrollRectOnExistingMenu(true);
            Object.DestroyImmediate(ButtonsMenu.GetComponentInChildren<GridLayoutGroup>());
            page = NestedPart.GenerateQuickMenuPage(QuickMenuTools.QuickMenuController, menuName);
            NestedPart.name = menuName;
            Title_Header = NestedPart.FindObject("Header_Camera/LeftItemContainer/Text_Title");
            TitleText = Title_Header.GetComponent<TextMeshProUGUIPublicBoUnique>();
            TitleText.text = btnToolTip;
            NestedPart.SetActive(false);
            mainButton = new QMTabButton(index, () =>
            {
                QuickMenuTools.ShowQuickmenuPage(menuName);
                OnOpenAction.SafetyRaise();
                NestedPart.SetActive(true);
            }, btnToolTip, btnBackgroundColor, icon);
            mainButton.SetGlowEffect(page);
            backButton = NestedPart.CreateMainBackButton();
            SetBackButtonMenuToDashboard();
        }
        internal void SetBackButtonMenuToDashboard()
        {
            backButton.SetBackButtonAction(() =>
            {
                QuickMenuTools.QuickMenuController.ShowTabContent("QuickMenuDashboard");
                OnCloseAction.SafetyRaise();
                NestedPart.SetActive(false);
            });
        }

        internal string GetMenuName()
        {
            return menuName;
        }

        internal QMTabButton GetMainButton()
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

        internal void DestroyMe()
        {

            QuickMenuTools.QuickMenuController.RemovePage(page);
            UnityEngine.Object.Destroy(ButtonsMenu);
            UnityEngine.Object.Destroy(NestedPart);
            UnityEngine.Object.Destroy(backButton);
            mainButton.DestroyMe();
        }

    }
}