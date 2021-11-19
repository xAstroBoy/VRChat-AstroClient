namespace AstroClient.xAstroBoy.AstroButtonAPI
{
    using System;
    using System.Collections.Generic;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;
    using Utility;
    using VRC;
    using VRC.Core;
    using VRC.DataModel;
    using VRC.DataModel.Core;
    using VRC.UI.Core.Styles;
    using VRC.UI.Elements;
    using VRC.UI.Elements.Menus;
    using VRC.UI.Elements.Tooltips;
    using xAstroBoy.Extensions;
    using Object = Il2CppSystem.Object;

    internal static class Extensions
    {
        internal static void ToggleScrollRectOnExistingMenu(this GameObject NestedPart, bool active)
        {
            try
            {
                var scrollRect = NestedPart.GetComponentInChildren<ScrollRect>(true);
                var scrollbar = NestedPart.GetComponentInChildren<Scrollbar>(true);
                var layout = NestedPart.GetComponentInChildren<VerticalLayoutGroup>(true);
                if (scrollbar != null && scrollRect != null)
                {
                    scrollbar.enabled = active;
                    scrollbar.gameObject.SetActive(active);
                    scrollRect.enabled = active;
                    scrollRect.gameObject.SetActive(active);

                    //var buttons = NestedPart.FindObject("Buttons");
                    //if (buttons != null)
                    //{
                    //    scrollRect.viewport = buttons.GetComponent<RectTransform>();
                    //}
                    if (layout != null) layout.childControlHeight = true;
                    scrollRect.movementType = ScrollRect.MovementType.Elastic;
                    scrollRect.verticalScrollbar = scrollbar;
                    //scrollRect.horizontalScrollbar = scrollbar;
                }
            }
            catch (Exception e)
            {
                ModConsole.DebugErrorExc(e);
            }
        }

        internal static bool isAstroPage(this UIPage page)
        {
            if (page != null)
            {
                if (page.name.isMatch(BuildInfo.Name)) return true;
                if (page.field_Private_List_1_UIPage_0 != null && page.field_Private_List_1_UIPage_0.Count != 0)
                    foreach (var item in page.field_Private_List_1_UIPage_0)
                        if (item.name.isMatch(BuildInfo.Name))
                            return true;
            }

            return false;
        }


        internal static bool ContainsPage(this UIPage page, List<QMNestedGridMenu> menus)
        {
            if (menus != null)
                if (menus.Count != 0)
                    foreach (var item in menus)
                        if (item != null)
                            if (ContainsPage(page, item.GetPage()))
                                return true;
            return false;
        }

        internal static bool ContainsPage(this UIPage page, UIPage TargetPage)
        {
            if (page != null)
            {
                if (page.name.Equals(TargetPage.name)) return true;
                if (page.field_Private_List_1_UIPage_0 != null && page.field_Private_List_1_UIPage_0.Count != 0)
                    foreach (var item in page.field_Private_List_1_UIPage_0)
                        if (item.name.Equals(TargetPage.name))
                            return true;
            }

            return false;
        }

        internal static void LoadSprite(this GameObject Parent, Sprite sprite, string name)
        {
            if (sprite == null) return;
            foreach (var image in Parent.GetComponentsInChildren<Image>(true))
                if (image.name == name) // allows background image change
                {
                    image.gameObject.SetActive(true);
                    image.overrideSprite = sprite;
                }
        }


        //public void LoadSprite(byte[] data)
        //{
        //    var image = GetIcon().GetComponent<Image>();
        //    var texture = CheetoUtils.LoadPNG(data);
        //    image.sprite = Sprite.CreateSprite(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), 100 * 1000, 1000, SpriteMeshType.FullRect, Vector4.zero, false);
        //    image.color = Color.white;
        //}

        public static IUser ToIUser(this APIUser value)
        {
            return ((Object)UiMethods._apiUserToIUser.Invoke(DataModelManager.field_Private_Static_DataModelManager_0.field_Private_DataModelCache_0, new object[3] { value.id, value, false })).Cast<IUser>();
        }

        /// <summary>
        ///     Converts the given IUser to an APIUser.
        ///     Thanks knah for providing this.
        /// </summary>
        /// <param name="value">The IUser to convert to APIUser</param>
        /// <returns></returns>
        public static APIUser ToAPIUser(this IUser value)
        {
            return value.Cast<DataModel<APIUser>>().field_Protected_TYPE_0;
        }

        internal static void ShowQuickmenuPage(this QuickMenu instance, string pagename)
        {
            instance.field_Protected_MenuStateController_0.PushPage(pagename);
        }

        internal static void ShowQuickmenuPage(this Wing instance, string pagename)
        {
            instance.field_Private_MenuStateController_0.PushPage(pagename);
        }

        internal static Player GetSelectedPlayer(this SelectedUserMenuQM instance)
        {
            return instance.field_Private_IUser_0.ToAPIUser().GetPlayer();
            //return instance.field_Private_Player_0;
        }

        internal static APIUser GetSelectedApiUser(this SelectedUserMenuQM instance)
        {
            return instance.field_Private_IUser_0.ToAPIUser();
            //return instance.field_Private_Player_0;
        }

        public static Player GetPlayer(this IUser Instance)
        {
            foreach (var player in PlayerManager.field_Private_Static_PlayerManager_0.GetAllPlayers())
                if (player.GetAPIUser().id == Instance.prop_String_0)
                    return player;
            return null;
        }

        internal static bool ContainsPage(this List<QMNestedGridMenu> menus, UIPage page)
        {
            if (page != null && menus != null)
                if (menus.Count != 0)
                    foreach (var item in menus)
                        if (item.page.Equals(page))
                            return true;
            return false;
        }

        public static GameObject FindObject(this GameObject parent, string name)
        {
            if (parent == null) return null;
            Transform[] trs = parent.GetComponentsInChildren<Transform>(true);
            foreach (var t in trs)
                if (t.name == name)
                    return t.gameObject;
            return null;
        }

        public static void EnableComponents(this GameObject parent)
        {
            parent.GetComponent<Button>().enabled = true;
            parent.GetComponent<LayoutElement>().enabled = true;
            parent.GetComponent<StyleElement>().enabled = true;
            parent.GetComponentInChildren<StyleElement>(true).enabled = true;
            parent.GetComponent<CanvasGroup>().enabled = true;
            parent.GetComponentInChildren<Image>().enabled = true;
            parent.GetComponentInChildren<TextMeshProUGUI>(true).enabled = true;
            parent.GetComponent<UiTooltip>().enabled = true;
            UnityEngine.Object.Destroy(parent.GetComponent<MonoBehaviourPublic38Bu12Vo37Vo12St37VoUnique>());
        }

        public static TextMeshProUGUI NewText(this GameObject Parent, string search)
        {
            var text = new TextMeshProUGUI();

            var TextTop = Parent.GetComponentsInChildren<TextMeshProUGUI>();
            foreach (var texto in TextTop)
                if (texto.name == search)
                    text = texto;

            return text;
        }

        public static void CleanButtonsQuickActions(this GameObject Parent)
        {
            var text = new TextMeshProUGUI();

            var Buttons = Parent.GetComponentsInChildren<Transform>(true);
            foreach (var button in Buttons)
                if (button.name.Contains("Button_") || button.name == "SitStandCalibrateButton" || button.name == "Buttons_AvatarDetails"
                    || button.name == "Buttons_AvatarAuthor")
                    UnityEngine.Object.Destroy(button.gameObject);
        }

        public static void CleanButtonsNestedMenu(this GameObject Parent)
        {
            var ButtonToDelete = Parent.GetComponentsInChildren<Button>(true);
            foreach (var Button in ButtonToDelete)
                if (Button.name.Contains("Camera") || Button.name == "Button_Panorama" || Button.name == "Button_Screenshot"
                    || Button.name == "Button_VrChivePano" || Button.name == "Button_DynamicLight")
                    UnityEngine.Object.Destroy(Button.gameObject);

            var ButtonToDelete2 = Parent.GetComponentsInChildren<Toggle>(true);
            foreach (var Button in ButtonToDelete2)
                if (Button.name == "Button_Steadycam")
                    UnityEngine.Object.Destroy(Button.gameObject);
        }

        public static void CleanButtonsWingMenu(this GameObject Parent)
        {
            var ButtonToDelete = Parent.GetComponentsInChildren<Transform>(true);
            //foreach (var Button in ButtonToDelete)
            //{
            //    if ( Button.name == "Cell_Wing_UserCompact(Clone)" || Button.name == "Cell_Wing_UserCompact(Clone)" || Button.name == "Header_Wing_H3"
            //        /*|| Button.name == "AV3_Text" || Button.name == "Button_ActionMenu"*/)
            //        UnityEngine.Object.Destroy(Button.gameObject);
            //}
            //foreach (var Button in ButtonToDelete)
            //{
            //    if (Button.name.Contains("Wing_Button_") || Button.name == "Expressions_SDK3" || Button.name == "Emotes_SDK2"
            //        || Button.name == "AV3_Text" || Button.name == "Button_ActionMenu")
            //        UnityEngine.Object.Destroy(Button.gameObject);
            //}
        }

        internal static void PushPage(this MenuStateController _MenuStateController, string Page)
        {
            _MenuStateController.Method_Public_Void_String_UIContext_Boolean_0(Page);
        }

        internal static void ShowLeftWingPage(this QMWings pagename)
        {
            QuickMenuTools.Wing_Left.ShowQuickmenuPage(pagename.GetMenuName());
        }

        internal static void ShowRightWingPage(this QMWings pagename)
        {
            QuickMenuTools.Wing_Right.ShowQuickmenuPage(pagename.GetMenuName());
        }

        internal static GameObject CreateMainBackButton(this GameObject NestedPart)
        {
            var btn = NestedPart.FindObject("Button_Back");
            btn.SetActive(true);
            btn.GetComponentInChildren<Button>().onClick = new Button.ButtonClickedEvent();
            btn.GetComponentInChildren<Button>().onClick.AddListener(new Action(() =>
            {
                QuickMenuTools.QuickMenuInstance.prop_MenuStateController_0.field_Private_UIPage_0.enabled = true;
                QuickMenuTools.QuickMenuInstance.prop_MenuStateController_0.Method_Public_UIPage_String_0("QuickMenuDashboard");
            }));
            return btn;
        }

        internal static GameObject CreateBackButton(this GameObject NestedPart, string menuName)
        {
            var btn = NestedPart.FindObject("Button_Back");
            btn.SetActive(true);
            btn.GetComponentInChildren<Button>().onClick = new Button.ButtonClickedEvent();
            btn.GetComponentInChildren<Button>().onClick.AddListener(new Action(() =>
            {
                var quickmenu = QuickMenuTools.QuickMenuInstance;
                QuickMenuTools.ShowQuickmenuPage(menuName);
            }));
            return btn;
        }

        internal static void SetBackButtonAction(this GameObject button, Action action)
        {
            button.GetComponentInChildren<Button>().onClick = new Button.ButtonClickedEvent();
            button.GetComponentInChildren<Button>().onClick.AddListener(new Action(() => { action(); }));
        }

        internal static Color HexToColor(this string hex)
        {
            var color = Color.white;

            if (ColorUtility.TryParseHtmlString(hex, out color)) return color;

            return color;
        }
    }
}