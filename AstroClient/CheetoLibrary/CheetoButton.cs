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

    public class CheetoButton : CheetoElement
    {
        public CheetoButton(Transform parent, string label, Action action, bool jump = false) : base(GameObject.Find(UIPaths.WorldButton), parent)
        {
            SetName($"CL-{CheetoButtonAPI.UIElements.Count}-CheetoButton:{label}");
            Self.transform.GetComponentInChildren<TextMeshProUGUI>().text = label;
            SetAction(action);
            LoadSprite(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.planet.png"));
            if (!jump) { Self.transform.Find("Badge_MMJump").gameObject.SetActive(false); }
        }
    }
}