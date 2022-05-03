namespace CheetoLibrary.ButtonAPI
{
    using UnityEngine;
    using UnityEngine.UI;
    using VRC.UI.Elements;

    public class DashMenuPage : UIElement
    {
        public string MenuName { get;private set; }

        public DashMenuPage(string name) : base(UIUtils.NestedMenuTemplate, UIUtils.NestedMenuTemplate.transform.parent)
        {
            SetName($"{CheetoButtonAPI.Indentifier}-{CheetoButtonAPI.UIElements.Count}-CL({GetType()}):{name}");
            MenuName = name;

            UnityEngine.GameObject.Destroy(Self.GetComponentInChildren<CameraMenu>());
            UnityEngine.GameObject.Destroy(Self.FindObject("Buttons").GetComponentInChildren<GridLayoutGroup>());

            var backButton = Self.FindObject("Button_Back");
            backButton.SetActive(true);

            var expandButton = Self.FindObject("Button_QM_Expand");
            expandButton.SetActive(false);

            var page = Self.AddComponent<UIPage>();
            page.name = MenuName;
            page.SetName(MenuName);
            page._inited = true;
            page._menuStateController = QMUtils.QuickMenuController;
            page._pageStack = new Il2CppSystem.Collections.Generic.List<UIPage>();
            page._pageStack.Add(page);

            Self.NewText("Text_Title").text = name;
            Self.SetActive(false);
            Self.CleanButtonsNestedMenu();

            QMUtils.QuickMenuController._uiPages.Add(MenuName, page);

            CopyOriginalTransform();
            ResetRect();
            Self.SetActive(false);
        }
    }
}