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
        public WingButton(string label, string tooltip, Action action, byte[] image = null) : base(GameObject.Find(UIPaths.ProfileButton), GameObject.Find(UIPaths.LeftWingContainer).transform)
        {
            SetName($"{CheetoButtonAPI.Indentifier}-{CheetoButtonAPI.UIElements.Count}-CL(WingButton):{label}");
            RectTransform.GetComponentInChildren<TextMeshProUGUI>().text = label;
            SetAction(action);
            SetTooltip(tooltip);
            if (image != null)
            {
                LoadSprite(image);
            }
        }
    }
}