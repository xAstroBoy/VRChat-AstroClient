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

        public void LoadSprite(byte[] data)
        {
            var image = Self.transform.FindChild("Icon").GetComponent<Image>();
            var texture = CheetoUtils.LoadPNG(data);
            image.sprite = Sprite.CreateSprite(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), 100 * 1000, 1000, SpriteMeshType.FullRect, Vector4.zero, false);
            image.color = Color.white;
        }
    }
}