namespace AstroButtonAPI
{
    using UnityEngine;
    using VRC.UI.Elements;

    internal class QMGridTab
    {
        protected QMTabButton mainButton;
        protected QMSingleButton backButton;
        protected GameObject ButtonsMenu;
        protected string menuName;
        protected string btnQMLoc;
        protected string btnType;
        protected UIPage page;

        internal QMGridTab(int index, string btnToolTip, Color? btnBackgroundColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, byte[] ImageData = null)
        {
            InitButton(index, btnToolTip, btnBackgroundColor, backbtnBackgroundColor, backbtnTextColor, ImageData);
        }

        internal QMGridTab(int index, string btnToolTip, Color? btnBackgroundColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, string ImageData = null)
        {
            InitButton(index, btnToolTip, btnBackgroundColor, backbtnBackgroundColor, backbtnTextColor, ImageData);
        }

        internal void InitButton(int index, string btnToolTip, Color? btnBackgroundColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, string ImageURL = null)
        {
            btnType = "QMGridTabMenu";
            menuName = QMButtonAPI.identifier + btnQMLoc + "_" + index + "_" + btnToolTip;

            GameObject NestedPart = UnityEngine.Object.Instantiate(QuickMenuTools.NestedMenuTemplate.gameObject, QuickMenuTools.NestedPages, true);
            ButtonsMenu = NestedPart.FindObject("Buttons");
            NestedPart.ToggleScrollRectOnExistingMenu(true);
            UnityEngine.GameObject.Destroy(NestedPart.GetComponentInChildren<CameraMenu>());
            page = NestedPart.AddComponent<UIPage>();
            page.name = menuName;
            page.field_Public_String_0 = menuName;
            page.field_Public_Boolean_0 = true;
            page.field_Private_MenuStateController_0 = QuickMenuTools.QuickMenuController();
            page.field_Private_List_1_UIPage_0 = new Il2CppSystem.Collections.Generic.List<UIPage>();
            page.field_Private_List_1_UIPage_0.Add(page);
            NestedPart.name = menuName;
            NestedPart.NewText("Text_Title").text = btnToolTip;
            NestedPart.SetActive(false);
            NestedPart.CleanButtonsNestedMenu();
            QuickMenuTools.QuickMenuController().field_Private_Dictionary_2_String_UIPage_0.Add(menuName, page);
            mainButton = new QMTabButton(index, () => { QuickMenuTools.ShowQuickmenuPage(menuName); }, btnToolTip, btnBackgroundColor, ImageURL);
        }

        internal void InitButton(int index, string btnToolTip, Color? btnBackgroundColor = null, Color? backbtnBackgroundColor = null, Color? backbtnTextColor = null, byte[] ImageData = null)
        {
            btnType = "QMTabMenu";
            menuName = QMButtonAPI.identifier + btnQMLoc + "_" + index + "_" + btnToolTip;

            GameObject NestedPart = UnityEngine.Object.Instantiate(QuickMenuTools.NestedMenuTemplate.gameObject, QuickMenuTools.NestedPages, true);
            ButtonsMenu = NestedPart.FindObject("Buttons");
            NestedPart.ToggleScrollRectOnExistingMenu(true);
            UnityEngine.GameObject.Destroy(NestedPart.GetComponentInChildren<CameraMenu>());
            page = NestedPart.AddComponent<UIPage>();
            page.name = menuName;
            page.field_Public_String_0 = menuName;
            page.field_Public_Boolean_0 = true;
            page.field_Private_MenuStateController_0 = QuickMenuTools.QuickMenuController();
            page.field_Private_List_1_UIPage_0 = new Il2CppSystem.Collections.Generic.List<UIPage>();
            page.field_Private_List_1_UIPage_0.Add(page);
            NestedPart.name = menuName;
            NestedPart.NewText("Text_Title").text = btnToolTip;
            NestedPart.SetActive(false);
            NestedPart.CleanButtonsNestedMenu();
            QuickMenuTools.QuickMenuController().field_Private_Dictionary_2_String_UIPage_0.Add(menuName, page);
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
            backButton.DestroyMe();
        }

        internal void OpenMe()
        {
            QuickMenuTools.ShowQuickmenuPage(menuName);
        }
    }
}