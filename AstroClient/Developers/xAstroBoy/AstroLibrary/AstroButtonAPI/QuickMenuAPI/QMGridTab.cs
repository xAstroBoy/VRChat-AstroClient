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

    internal class QMGridTab
    {
        internal GameObject NestedPart { get; set; }
        internal GameObject backButton { get; set; }
        internal string btnQMLoc { get; set; }
        internal string btnType { get; set; }
        internal GameObject ButtonsMenu { get; set; }
        internal QMTabButton mainButton { get; set; }
        internal string menuName { get; set; }
        internal UIPage page { get; set; }
        internal Action OnCloseAction { get; set; }
        internal Action OnOpenAction { get; set; }



        internal QMGridTab(int index, string btnToolTip, Color? btnBackgroundColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, Sprite icon = null)
        {
            InitButton(index, btnToolTip, btnBackgroundColor, backbtnBackgroundColor, backbtnTextColor, icon);
            SetBackButtonMenuToDashboard();
        }

        internal void InitButton(int index, string btnToolTip, Color? btnBackgroundColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, Sprite icon = null)
        {
            btnType = "QMTabMenu";
            menuName = QMButtonAPI.identifier + btnQMLoc + "_" + index + "_" + btnToolTip;

            NestedPart = Object.Instantiate(QuickMenuTools.NestedMenuTemplate.gameObject, QuickMenuTools.NestedPages, true);
            ButtonsMenu = NestedPart.FindUIObject("Buttons");
            NestedPart.ToggleScrollRectOnExistingMenu(true);
            Object.Destroy(NestedPart.GetComponentInChildren<CameraMenu>());
            Object.Destroy(NestedPart.FindUIObject("Panel_Info"));
            Object.Destroy(NestedPart.FindUIObject("Button_PhotosFolder"));
            System.Collections.Generic.List<Transform> list = ButtonsMenu.transform.Get_Childs();
            for (int i = 0; i < list.Count; i++)
            {
                list[i].DestroyMeLocal(true);
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
            backButton = NestedPart.CreateBackButton(QMButtonAPI.identifier + "_Nested_GridMenu_" + "Main Menu");
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

            NestedPart.DestroyMeLocal(true);
            backButton.DestroyMeLocal(true);
            ButtonsMenu.DestroyMeLocal(true);
        }

        internal void OpenMe()
        {
            QuickMenuTools.ShowQuickmenuPage(menuName);
        }
    }
}