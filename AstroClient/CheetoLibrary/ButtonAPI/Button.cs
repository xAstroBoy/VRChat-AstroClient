namespace CheetoLibrary.ButtonAPI
{
    using AstroLibrary.Console;
    using AstroLibrary.Utility;
    using MelonLoader;
    using System;
    using System.Reflection;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;
    using VRC.UI.Core.Styles;
    using VRC.UI.Elements;

    public class ButtonBase : UIElement
    {
        public ButtonBase(Transform parent, string label, string tooltip, byte[] icon, Action action = null, bool jump = false) : base(GameObject.Find(UIUtils.WorldButton), parent)
        {
            SetName($"{CheetoButtonAPI.Indentifier}-{CheetoButtonAPI.UIElements.Count}-CL({GetType()}):{label}");
            var text = RectTransform.GetComponentInChildren<TextMeshProUGUI>();
            text.text = label; text.richText = true; text.autoSizeTextContainer = true;
            if (icon != null) SetIcon(icon);
            if (action != null) SetAction(action);
            if (!jump) RectTransform.Find("Badge_MMJump").gameObject.SetActive(false);
            SetTooltip(tooltip);
        }
    }

    public class NestedButton : ButtonBase
    {
        internal string MenuName { get; }

        public NestedButton(Transform parent, string menu_name, string title, string tooltip, byte[] icon = null, bool jump = false) : base(parent, label, tooltip, icon, null, true)
        {
            MenuName = menu_name;
            var nestedPart = UnityEngine.Object.Instantiate(UIUtils.NestedMenuTemplate, UIUtils.NestedMenuTemplate.transform.parent);
            UnityEngine.GameObject.Destroy(nestedPart.GetComponentInChildren<CameraMenu>());
            UnityEngine.GameObject.Destroy(nestedPart.FindObject("Buttons").GetComponentInChildren<GridLayoutGroup>());

            var backButton = nestedPart.FindObject("Button_Back");
            backButton.SetActive(true);

            var expandButton = nestedPart.FindObject("Button_QM_Expand");
            expandButton.SetActive(false);

            var page = nestedPart.AddComponent<UIPage>();
            page.name = MenuName;
            page.Name = MenuName;
            page._inited = true;
            page._menuStateController = QMUtils.QuickMenuController;
            page._pageStack = new Il2CppSystem.Collections.Generic.List<UIPage>();
            page._pageStack.Add(page);
            nestedPart.name = MenuName;
            nestedPart.NewText("Text_Title").text = title;
            nestedPart.SetActive(false);
            nestedPart.CleanButtonsNestedMenu();
            QMUtils.QuickMenuController._uiPages.Add(MenuName, page);
            SetAction(() => QMUtils.ShowQuickmenuPage(MenuName));
        }
    }

    public class Button : ButtonBase
    {
        public Button(Transform parent, string label, string tooltip, Action action, byte[] icon = null, bool jump = false) : base(parent, label, tooltip, icon, action, jump)
        {
        }
    }
}