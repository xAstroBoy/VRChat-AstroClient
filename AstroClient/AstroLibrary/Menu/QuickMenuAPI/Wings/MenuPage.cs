using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Core;
using VRC.UI.Elements;
using VRC.UI.Elements.Menus;
using Object = UnityEngine.Object;
using QuickMenuContext = QuickMenuContextualDisplay.EnumNPublicSealedvaUnNoToUs7vUsNoUnique;

namespace QuickMenuAPI.RinAPI
{
    internal class MenuPage : UIElement
    {
        private static GameObject _menuPrefab;

        private static GameObject MenuPrefab
        {
            get
            {
                if (_menuPrefab == null)
                {
                    _menuPrefab = ExtendedQuickMenu.Instance.container.Find("Window/QMParent/Menu_DevTools").gameObject;
                }
                return _menuPrefab;
            }
        }

        private static int SiblingIndex => ExtendedQuickMenu.Instance.container.Find("Window/QMParent/Modal_AddMessage").GetSiblingIndex();

        private readonly List<MenuPage> _subMenus = new List<MenuPage>();

        public event Action OnOpen;
        private readonly string _menuName;
        private readonly bool _isRoot;

        private readonly Transform _container;

        public MenuPage(string name, string text, bool isRoot = false) : base(MenuPrefab, MenuPrefab.transform.parent, $"Menu_{name}", false)
        {
            Object.DestroyImmediate(GameObject.GetComponent<DevMenu>());

            RectTransform.SetSiblingIndex(SiblingIndex);

            _menuName = name;
            _isRoot = isRoot;
            var headerTransform = RectTransform.GetChild(0);
            var titleText = headerTransform.GetComponentInChildren<TextMeshProUGUI>();
            titleText.text = text;
            titleText.richText = true;

            var backButton = headerTransform.GetComponentInChildren<Button>(true);
            backButton.gameObject.SetActive(true);

            var buttonContainer = RectTransform.Find("Scrollrect/Viewport/VerticalLayoutGroup/Buttons");
            foreach (var obj in buttonContainer)
            {
                var control = obj.Cast<Transform>();
                if (control == null)
                {
                    continue;
                }
                Object.Destroy(control.gameObject);
            }

            // Set up UIPage
            var uiPage = GameObject.AddComponent<UIPage>();
            uiPage.name = $"QuickMenu{name}";
            uiPage.Name = $"QuickMenu{name}";
            uiPage._inited = true;
            uiPage._menuStateController = ExtendedQuickMenu.MenuStateCtrl;
            uiPage._pageStack = new Il2CppSystem.Collections.Generic.List<UIPage>();
            uiPage._pageStack.Add(uiPage);

            // Get scroll stuff
            var scrollRect = RectTransform.Find("Scrollrect").GetComponent<ScrollRect>();
            _container = scrollRect.content;

            // copy properties of old grid layout
            var gridLayoutGroup = _container.Find("Buttons").GetComponent<GridLayoutGroup>();

            Object.DestroyImmediate(_container.GetComponent<VerticalLayoutGroup>());
            var glp = _container.gameObject.AddComponent<GridLayoutGroup>();
            glp.spacing = gridLayoutGroup.spacing;
            glp.cellSize = gridLayoutGroup.cellSize;
            glp.constraint = gridLayoutGroup.constraint;
            glp.constraintCount = gridLayoutGroup.constraintCount;
            glp.startAxis = gridLayoutGroup.startAxis;
            glp.startCorner = gridLayoutGroup.startCorner;
            glp.childAlignment = gridLayoutGroup.childAlignment;
            glp.padding = gridLayoutGroup.padding;
            glp.padding.top = 8;

            // delete components we're not using
            Object.DestroyImmediate(_container.Find("Buttons").gameObject);
            Object.DestroyImmediate(_container.Find("Spacer_8pt").gameObject);

            // Fix scrolling
            var scrollbar = scrollRect.transform.Find("Scrollbar");
            scrollbar.gameObject.SetActive(true);

            scrollRect.enabled = true;
            scrollRect.verticalScrollbar = scrollbar.GetComponent<Scrollbar>();
            scrollRect.verticalScrollbarVisibility = ScrollRect.ScrollbarVisibility.Permanent;
            scrollRect.viewport.GetComponent<RectMask2D>().enabled = true;
            backButton.onClick = new Button.ButtonClickedEvent();
            backButton.onClick.AddListener(new Action(() =>
            {
                Console.WriteLine("Cummies");
                ExtendedQuickMenu.MenuStateCtrl._currentRootPage.enabled = true;
                ExtendedQuickMenu.MenuStateCtrl.PushPage(ExtendedQuickMenu.MenuStateCtrl._currentRootPage);

            }));
            ExtendedQuickMenu.MenuStateCtrl._uiPages.Add(uiPage.Name, uiPage);

            if (isRoot)
            {
                var rootPages = ExtendedQuickMenu.MenuStateCtrl.menuRootPages.ToList();
                rootPages.Add(uiPage);
                ExtendedQuickMenu.MenuStateCtrl.menuRootPages = rootPages.ToArray();
            }
        }

        public void Open()
        {
            if (_isRoot)
            {
                ExtendedQuickMenu.MenuStateCtrl.SwitchToRootPage($"QuickMenu{_menuName}");
            }
            else
            {
                ExtendedQuickMenu.MenuStateCtrl.PushPage($"QuickMenu{_menuName}");
            }


            // Active = true;
            OnOpen?.Invoke();
        }

        public MenuButton AddButton(string name, string text, string tooltip, Action onClick)
        {
            return new MenuButton(name, text, tooltip, onClick, _container);
        }

        public MenuToggle AddToggle(string name, string text, string tooltip, Action<bool> onToggle, bool defaultValue = false)
        {
            return new MenuToggle(name, text, tooltip, onToggle, _container, defaultValue);
        }

        public MenuPage AddSubMenu(string name, string text, string tooltip)
        {
            var menu = new MenuPage(name, text);
            AddButton($"{name}Menu", text, tooltip, menu.Open);
            _subMenus.Add(menu);
            return menu;
        }

        public MenuPage GetSubMenu(string name)
        {
            return _subMenus.FirstOrDefault(m => m.Name == $"Menu_{name}");
        }
    }
}
