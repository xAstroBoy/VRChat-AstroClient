namespace CheetoLibrary.ButtonAPI
{
    using System;
    using TMPro;
    using UnityEngine;

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
}