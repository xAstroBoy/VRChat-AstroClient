namespace CheetoLibrary.ButtonAPI
{
    using System;
    using UnityEngine;
    using VRC.UI.Elements.Controls;

    public class TabButton : UIElement
    {
        public TabButton(string label, Action action, byte[] image = null) : base(GameObject.Find(UIPaths.LaunchPadTab), GameObject.Find(UIPaths.TabsGroup).transform)
        {
            SetName($"{CheetoButtonAPI.Indentifier}-{CheetoButtonAPI.UIElements.Count}-CL(TabButton):{label}");
            SetAction(action);
            if (image != null) LoadSprite(image);
            RectTransform.GetComponentInChildren<MenuTab>().pageName = $"QuickMenuAstroClient-{CheetoButtonAPI.UIElements.Count}:{label}";
        }
    }
}