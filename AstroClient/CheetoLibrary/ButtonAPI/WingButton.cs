namespace CheetoLibrary.ButtonAPI
{
    using MelonLoader;
    using System;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    // TODO: Make it so you can specify which wing
    public class WingButton : UIElement
    {
        public WingButton(string label, string tooltip, Action action, byte[] icon = null) : base(GameObject.Find(UIUtils.ProfileButton), GameObject.Find(UIUtils.LeftWingContainer).transform)
        {
            SetName($"{CheetoButtonAPI.Indentifier}-{CheetoButtonAPI.UIElements.Count}-CL(WingButton):{label}");
            RectTransform.GetComponentInChildren<TextMeshProUGUI>().text = label;
            if (icon != null) SetIcon(icon);
            SetAction(action);
            SetTooltip(tooltip);
        }
    }
}