using System;

namespace AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI
{
    using AstroClient.Tools.Extensions;
    using PageGenerators;
    using Tools;
    using UnityEngine;
    using UnityEngine.UI;
    using VRC.UI.Elements;
    using CameraMenu = MonoBehaviour1PublicBuToBuGaTMBuGaBuGaBuUnique;

    internal class QMTabMenu
    {
        internal string btnQMLoc { get; set; }
        internal string btnType { get; set; }
        internal GameObject ButtonsMenu { get; set; }
        internal QMTabButton mainButton { get; set; }
        internal string menuName { get; set; }
        internal UIPage page { get; set; }
        internal GameObject NestedPart { get; set; }
        internal GameObject backButton { get; set; }
        internal Action OnCloseAction { get; set; }
        internal Action OnOpenAction { get; set; }

        internal QMTabMenu(int index, string btnToolTip, Color? btnBackgroundColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, Sprite icon = null)
        {
            InitButton(index, btnToolTip, btnBackgroundColor, backbtnBackgroundColor, backbtnTextColor, icon);
        }

        internal void InitButton(int index, string btnToolTip, Color? btnBackgroundColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, Sprite icon = null)
        {
            btnType = "QMTabMenu";
            menuName = QMButtonAPI.identifier + btnQMLoc + "_" + index + "_" + btnToolTip;

            NestedPart = Object.Instantiate(QuickMenuTools.NestedMenuTemplate.gameObject, QuickMenuTools.NestedPages, true);
            ButtonsMenu = NestedPart.FindUIObject("Buttons");
            NestedPart.ToggleScrollRectOnExistingMenu(true);
            Object.Destroy(ButtonsMenu.GetComponentInChildren<GridLayoutGroup>());
            Object.Destroy(NestedPart.GetComponentInChildren<CameraMenu>());
            Object.Destroy(NestedPart.FindUIObject("Panel_Info"));
            Object.Destroy(NestedPart.FindUIObject("Button_PhotosFolder"));
            System.Collections.Generic.List<Transform> list = ButtonsMenu.transform.Get_Childs();
            for (int i = 0; i < list.Count; i++)
            {
                Transform item = list[i];
                item.DestroyMeLocal(true);
            }
            page = NestedPart.GenerateQuickMenuPage(menuName);
            NestedPart.name = menuName;
            NestedPart.NewText("Text_Title").text = btnToolTip;
            NestedPart.SetActive(false);
            NestedPart.CleanButtonsNestedMenu();
            mainButton = new QMTabButton(index, () =>
            {
                QuickMenuTools.ShowQuickmenuPage(menuName);
                if (OnOpenAction != null) OnOpenAction();
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
                if (OnCloseAction != null) OnCloseAction();
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
            ButtonsMenu.DestroyMeLocal(true);
            NestedPart.DestroyMeLocal(true);
            backButton.DestroyMeLocal(true);
            mainButton.DestroyMe();
        }

    }
}