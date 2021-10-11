namespace CheetoLibrary
{
    using AstroLibrary;
    using MelonLoader;
    using System;
    using System.Reflection;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;
    using VRC.UI.Elements.Controls;

    public class CheetoTab : CheetoElement
    {
        public CheetoTab(string label, Action action) : base(GameObject.Find(UIPaths.LaunchPadTab), GameObject.Find(UIPaths.TabsGroup).transform)
        {
            SetName($"CheetoLibrary-{CheetoButtonAPI.UIElements.Count}-CheetoTab:{label}");
            SetAction(action);
            LoadSprite(CheetoUtils.ExtractResource(Assembly.GetExecutingAssembly(), "AstroClient.Resources.planet.png"));
            Self.transform.GetComponentInChildren<MenuTab>().pageName = $"QuickMenuAstroClient-{CheetoButtonAPI.UIElements.Count}:{label}";
        }
    }
}