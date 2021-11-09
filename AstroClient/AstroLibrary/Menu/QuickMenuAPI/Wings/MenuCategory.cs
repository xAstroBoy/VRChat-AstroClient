
using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace QuickMenuAPI.RinAPI
{
    internal class MenuHeader : UIElement
    {
        private static GameObject _headerPrefab;
        private static GameObject HeaderPrefab
        {
            get
            {
                if (_headerPrefab == null)
                {
                    _headerPrefab = ExtendedQuickMenu.Instance.container
                        .Find("Window/QMParent/Menu_Dashboard/ScrollRect").GetComponent<ScrollRect>().content
                        .Find("Header_QuickActions").gameObject;
                }
                return _headerPrefab;
            }
        }

        public MenuHeader(string name, string title, Transform parent) : base(HeaderPrefab, (parent == null ? HeaderPrefab.transform.parent : parent), $"Header_{name}")
        {
            var tmp = GameObject.GetComponentInChildren<TextMeshProUGUI>();
            tmp.text = title;
            tmp.richText = true;
        }
    }
    internal class MenuButtonContainer : UIElement
    {
        private static GameObject _containerPrefab;
        private static GameObject ContainerPrefab
        {
            get
            {
                if (_containerPrefab == null)
                {
                    _containerPrefab = ExtendedQuickMenu.Instance.container
                        .Find("Window/QMParent/Menu_Dashboard/ScrollRect").GetComponent<ScrollRect>().content
                        .Find("Buttons_QuickActions").gameObject;
                }
                return _containerPrefab;
            }
        }

        public MenuButtonContainer(string name, Transform parent = null) : base(ContainerPrefab, (parent == null ? ContainerPrefab.transform.parent : parent), $"Buttons_{name}")
        {
            foreach (var obj in RectTransform)
            {
                var control = obj.Cast<Transform>();
                if (control == null)
                {
                    continue;
                }
                Object.Destroy(control.gameObject);
            }
        }
    }

    internal class MenuCategory
    {
        public MenuHeader Header;
        private readonly MenuButtonContainer _buttonContainer;

        private readonly List<MenuPage> _menus = new List<MenuPage>();

        public MenuCategory(string name, string title, Transform parent = null)
        {
            Header = new MenuHeader(name, title, parent);
            _buttonContainer = new MenuButtonContainer(name, parent);
        }

        public MenuButton AddButton(string name, string text, string tooltip, Action onClick)
        {
            var button = new MenuButton(name, text, tooltip, onClick, _buttonContainer.RectTransform);
            return button;
        }

        public MenuToggle AddToggle(string name, string text, string tooltip)
        {
            var toggle = new MenuToggle(name, text, tooltip, (b) => {  }, _buttonContainer.RectTransform);
            return toggle;
        }

        public MenuPage AddSubMenu(string name, string text, string tooltip = "")
        {
            var menu = new MenuPage(name, text);
            AddButton(name, text, string.IsNullOrEmpty(tooltip) ? $"Open the {text} menu" : tooltip, menu.Open);
            _menus.Add(menu);
            return menu;
        }

        public MenuPage GetSubMenu(string name)
        {
            return _menus.FirstOrDefault(m => m.Name == $"Menu_{name}");
        }
    }
}
