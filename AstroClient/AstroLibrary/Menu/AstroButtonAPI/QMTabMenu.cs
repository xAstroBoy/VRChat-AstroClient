﻿namespace AstroButtonAPI
{
    using AstroLibrary.Console;
    using UnityEngine;
    using UnityEngine.UI;
    using VRC.UI.Elements;

    internal class QMTabMenu
    {
        protected QMTabButton mainButton;
        protected QMSingleButton backButton;
        protected GameObject ButtonsMenu;
        protected string menuName;
        protected string btnQMLoc;
        protected string btnType;

        internal QMTabMenu(int index, string btnToolTip, Color? btnBackgroundColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, byte[] ImageData = null)
        {
            InitButton(index, btnToolTip, btnBackgroundColor, backbtnBackgroundColor, backbtnTextColor, ImageData);
        }
        internal QMTabMenu(int index, string btnToolTip, Color? btnBackgroundColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, string ImageData = null)
        {
            InitButton(index, btnToolTip, btnBackgroundColor, backbtnBackgroundColor, backbtnTextColor, ImageData);
        }
        internal void InitButton(int index, string btnToolTip, Color? btnBackgroundColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, string ImageURL = null)
        {
            btnType = "QMTabMenu";
            menuName = QMButtonAPI.identifier + btnQMLoc + "_" + index + "_" + btnToolTip;

            GameObject NestedPart = UnityEngine.Object.Instantiate(QuickMenuTools.NestedMenuTemplate.gameObject, QuickMenuTools.NestedPages, true);
            ButtonsMenu = NestedPart.FindObject("Buttons");
            NestedPart.ToggleScrollRectOnExistingMenu(true);
            //UnityEngine.GameObject.Destroy(ButtonsMenu.GetComponentInChildren<GridLayoutGroup>());
            UnityEngine.GameObject.Destroy(NestedPart.GetComponentInChildren<CameraMenu>());

            UIPage Page_UI = NestedPart.AddComponent<UIPage>();
            Page_UI.name = menuName;
            Page_UI.field_Public_String_0 = menuName;
            Page_UI.field_Public_Boolean_0 = true;
            Page_UI.field_Private_MenuStateController_0 = QuickMenuTools.QuickMenuController();
            Page_UI.field_Private_List_1_UIPage_0 = new Il2CppSystem.Collections.Generic.List<UIPage>();
            Page_UI.field_Private_List_1_UIPage_0.Add(Page_UI);
            NestedPart.name = menuName;
            NestedPart.NewText("Text_Title").text = btnToolTip;
            NestedPart.SetActive(false);
            NestedPart.CleanButtonsNestedMenu();
            QuickMenuTools.QuickMenuController().field_Private_Dictionary_2_String_UIPage_0.Add(menuName, Page_UI);
            mainButton = new QMTabButton(index, () => { QuickMenuTools.ShowQuickmenuPage(menuName); }, btnToolTip, btnBackgroundColor, ImageURL);
            // backButton = new QMSingleButton(menuName, 5, 2, "Back", () => { QuickMenuStuff.ShowQuickmenuPage("ShortcutMenu"); }, "Go Back", backbtnBackgroundColor, backbtnTextColor);
        }

        internal void InitButton(int index, string btnToolTip, Color? btnBackgroundColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, byte[] ImageData = null)
        {
            btnType = "QMTabMenu";
            menuName = QMButtonAPI.identifier + btnQMLoc + "_" + index + "_" + btnToolTip;

            GameObject NestedPart = UnityEngine.Object.Instantiate(QuickMenuTools.NestedMenuTemplate.gameObject, QuickMenuTools.NestedPages, true);
            ButtonsMenu = NestedPart.FindObject("Buttons");
            NestedPart.ToggleScrollRectOnExistingMenu(true);
            //UnityEngine.GameObject.Destroy(ButtonsMenu.GetComponentInChildren<GridLayoutGroup>());
            UnityEngine.GameObject.Destroy(NestedPart.GetComponentInChildren<CameraMenu>());

            UIPage Page_UI = NestedPart.AddComponent<UIPage>();
            Page_UI.name = menuName;
            Page_UI.field_Public_String_0 = menuName;
            Page_UI.field_Public_Boolean_0 = true;
            Page_UI.field_Private_MenuStateController_0 = QuickMenuTools.QuickMenuController();
            Page_UI.field_Private_List_1_UIPage_0 = new Il2CppSystem.Collections.Generic.List<UIPage>();
            Page_UI.field_Private_List_1_UIPage_0.Add(Page_UI);
            NestedPart.name = menuName;
            NestedPart.NewText("Text_Title").text = btnToolTip;
            NestedPart.SetActive(false);
            NestedPart.CleanButtonsNestedMenu();
            QuickMenuTools.QuickMenuController().field_Private_Dictionary_2_String_UIPage_0.Add(menuName, Page_UI);
            mainButton = new QMTabButton(index, () => { QuickMenuTools.ShowQuickmenuPage(menuName); }, btnToolTip, btnBackgroundColor, ImageData);
        }

        internal string GetMenuName()
        {
            return menuName;
        }

        internal QMTabButton GetMainButton()
        {
            return mainButton;
        }

        internal QMSingleButton GetBackButton()
        {
            return backButton;
        }

        internal void DestroyMe()
        {
            mainButton.DestroyMe();
            backButton.DestroyMe();
        }
        internal void OpenMe()
        {
            QuickMenuTools.ShowQuickmenuPage(menuName);
        }
    }
}