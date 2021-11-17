namespace CheetoLibrary.ButtonAPI
{
    using System;
    using UnityEngine;

    public class TabButton : UIElement
    {
        public TabButton(string label, string tooltip, Action action, byte[] icon = null) : base(GameObject.Find(UIUtils.LaunchPadTab), GameObject.Find(UIUtils.TabsGroup).transform)
        {
            SetName($"{CheetoButtonAPI.Indentifier}-{CheetoButtonAPI.UIElements.Count}-CL(TabButton):{label}");
            SetAction(action);
            SetTooltip(tooltip);
            if (icon != null) SetIcon(icon);
            //RectTransform.GetComponentInChildren<MenuTab>().pageName = $"QuickMenuAstroClient-{CheetoButtonAPI.UIElements.Count}:{label}";
        }
    }
}