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

    internal class QMGridTab
    {
        internal GameObject NestedPart { get; set; }
        internal GameObject backButton { get; set; }
        internal string btnQMLoc { get; set; }
        internal string btnType { get; set; }
        internal GameObject ButtonsMenu { get; set; }
        internal GameObject Header { get; set; }
        internal QMTabButton mainButton { get; set; }
        internal string menuName { get; set; }
        private UIPage page { get; set; }
        internal Action OnCloseAction { get; set; }
        internal Action OnOpenAction { get; set; }

        internal GameObject Title_Header { get; set; }
        internal TextMeshProUGUIPublicBoUnique TitleText { get; set; }


        internal QMGridTab(int index, string btnToolTip, Color? btnBackgroundColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, Sprite icon = null)
        {
            InitButton(index, btnToolTip, btnBackgroundColor, backbtnBackgroundColor, backbtnTextColor, icon);
            SetBackButtonMenuToDashboard();
        }

        internal void InitButton(int index, string Title, Color? btnBackgroundColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, Sprite icon = null)
        {
            btnType = "QMTabMenu";
            menuName = QMButtonAPI.identifier + btnQMLoc + "_" + index + "_" + Title;
            NestedPart = Object.Instantiate(QuickMenuTools.NestedMenuTemplate.gameObject, QuickMenuTools.NestedPages);
            foreach (var item in NestedPart.GetComponentsInChildren<Behaviour>(true))
            {
                item.enabled = true;
            }
            try
            {
                Object.DestroyImmediate(NestedPart.GetComponentInChildren<CameraMenu>());
            }
            catch { }
            ButtonsMenu = NestedPart.FindObject("Scrollrect/Viewport/VerticalLayoutGroup/Buttons (1)");
            NestedPart.FindObject("Scrollrect/Viewport/VerticalLayoutGroup").gameObject.CleanCameraMenu();
            ButtonsMenu.name = "Buttons";
            NestedPart.ToggleScrollRectOnExistingMenu(true);
            page = NestedPart.GenerateQuickMenuPage(QuickMenuTools.QuickMenuController, menuName);
            NestedPart.name = menuName;
            Header = NestedPart.FindObject("Header_Camera");
            Header.name = "Header";
            Title_Header = Header.FindObject("LeftItemContainer/Text_Title");
            TitleText = Title_Header.GetComponent<TextMeshProUGUIPublicBoUnique>();
            TitleText.text = Title;
            NestedPart.SetActive(false);
            mainButton = new QMTabButton(index, () =>
            {
                QuickMenuTools.ShowQuickmenuPage(menuName);
                OnOpenAction.SafetyRaise();
                NestedPart.SetActive(true);
            }, Title, btnBackgroundColor, icon);
            mainButton.SetGlowEffect(page);
            backButton = NestedPart.CreateBackButton(QMButtonAPI.identifier + "_Nested_GridMenu_" + "Main Menu");
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

        internal GameObject GetBackButton()
        {
            return backButton;
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
            mainButton.DestroyMe();

            QuickMenuTools.QuickMenuController.RemovePage(page);
            UnityEngine.Object.Destroy(NestedPart);
            UnityEngine.Object.Destroy(backButton);
        }

        internal void OpenMe()
        {
            QuickMenuTools.ShowQuickmenuPage(menuName);
        }
    }
}