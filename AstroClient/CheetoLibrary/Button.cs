namespace CheetoLibrary
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

    public class Button : UIElement
    {
        public Button(Transform parent, string label, Action action, bool jump = false) : base(GameObject.Find(UIPaths.WorldButton), parent)
        {
            SetName($"{CheetoButtonAPI.Indentifier}-{CheetoButtonAPI.UIElements.Count}-CL(Button):{label}");
            var text = RectTransform.GetComponentInChildren<TextMeshProUGUI>();
            text.text = label; text.richText = true; text.autoSizeTextContainer = true;
            SetAction(action);
            LoadSprite(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.planet.png"));
            if (!jump) { RectTransform.Find("Badge_MMJump").gameObject.SetActive(false); }
        }
    }
}