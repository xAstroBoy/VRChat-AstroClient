using System.Linq;
using MelonLoader;
using VRC.UI.Elements.Analytics;
using VRC.UI.Elements.Controls;
using VRC.UI.Elements.Wings;

namespace AstroClient.xAstroBoy.AstroButtonAPI.Tools
{
    using System;
    using System.Collections.Generic;
    using AstroClient.Tools.Extensions;
    using OVR.OpenVR;
    using QuickMenuAPI;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;
    using Utility;
    using VRC;
    using VRC.Core;
    using VRC.DataModel;
    using VRC.UI.Core.Styles;
    using VRC.UI.Elements;
    using VRC.UI.Elements.Buttons;
    using VRC.UI.Elements.Menus;
    using VRC.UI.Elements.Tooltips;
    using WingsAPI;
    using xAstroBoy.Extensions;
    using Object = Il2CppSystem.Object;

    internal static class Extensions
    {
        public static void DestroyChildren(this Transform transform, Func<Transform, bool> exclude)
        {
            for (var childcount = transform.childCount - 1; childcount >= 0; childcount--)
                if (exclude == null || exclude(transform.GetChild(childcount)))
                    UnityEngine.Object.DestroyImmediate(transform.GetChild(childcount).gameObject);
        }

        public static void DestroyChildren(this Transform transform) =>
            transform.DestroyChildren(null);

        public static void DestroyChildren(this GameObject gameObj) =>
            gameObj.transform.DestroyChildren(null);


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
                Log.Exception(e);
            }
        }




        internal static bool isPage(this UIPage page, UIPage TargetPage)
        {
            if (page != null)
            {
                if (TargetPage != null)
                {
                    var PageName = page.GetName();
                    var TargetName = TargetPage.GetName();
                    if (TargetName == PageName)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }

        internal static void LoadSprite(this GameObject Parent, Sprite sprite, string name)
        {
            var list = Parent.GetComponentsInChildren<Image>(true);
            if (list != null && list.Count != 0)
            {

                for (int i = 0; i < list.Count; i++)
                {
                    Image image = list[i];
                    if (image.name == name) // allows background image change
                    {
                        if (sprite != null)
                        {
                            image.gameObject.SetActive(true);
                            image.overrideSprite = sprite;
                            image.MakeBackgroundMoreSolid();
                        }
                        else
                        {
                            image.gameObject.SetActive(false);
                            image.overrideSprite = null;
                        }
                    }
                }
            }
            var list2 = Parent.GetComponentsInChildren<UIWidgets.ImageAdvanced>(true);
            if (list2 != null && list2.Count != 0)
            {
                for (int i = 0; i < list2.Count; i++)
                {
                    UIWidgets.ImageAdvanced image = list2[i];
                    if (image.name == name) // allows background image change
                    {
                        if (sprite != null)
                        {
                            image.gameObject.SetActive(true);
                            image.overrideSprite = sprite;
                            image.MakeBackgroundMoreSolid();
                        }
                        else
                        {
                            image.gameObject.SetActive(false);
                            image.overrideSprite = null;
                        }
                    }
                }
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
            return ((Object)UiMethods._apiUserToIUser.Invoke(MonoBehaviourPublicObLiOb1AcLi1AcObLiUnique.field_Private_Static_MonoBehaviourPublicObLiOb1AcLi1AcObLiUnique_0.field_Private_ObjectPublicDi2StObUnique_0, new object[3] { value.id, value, false })).Cast<IUser>();
            // return ((Object)UiMethods._apiUserToIUser.Invoke(DataModelManager.field_Private_Static_DataModelManager_0.field_Private_DataModelCache_0, new object[3] { value.id, value, false })).Cast<IUser>();

        }

        /// <summary>
        ///     Converts the given IUser to an APIUser.
        ///     Thanks knah for providing this.
        /// </summary>
        /// <param name="value">The IUser to convert to APIUser</param>
        /// <returns></returns>
        public static APIUser ToAPIUser(this IUser value)
        {
            return value.Cast<APIUser>();
        }

        internal static void ShowWingPage(this WingMenu instance, string pagename)
        {
            instance.field_Private_ObjectPublicSiEaSeReCaGrMeReReUnique_0.field_Private_MenuStateController_0.ShowTabContent(pagename);
            //instance.field_Private_UIMenu_0.prop_MenuStateController_0.ShowTabContent(pagename);
        }
        private static QuickMenu _instance;
        private static Transform _interface;
        internal static QuickMenu Instance
        {
            get
            {
                if (_instance == null)
                {
                    var found = Resources.FindObjectsOfTypeAll<QuickMenu>();
                    if (found != null && found.Any()) _instance = found.First();
                    if (_instance != null)
                    {
                        Log.Write($"Found: QuickMenu -> {_instance.name}");
                    }
                    else
                    {
                        Log.Error("Not Found: QuickMenu");
                    }
                }
                return _instance;
            }
        }

        private static SelectedUserMenuQM _selectedUserMenuQM;
        internal static SelectedUserMenuQM SelectedUserMenuQM
        {
            get
            {
                if (_selectedUserMenuQM == null) _selectedUserMenuQM = Instance.gameObject.FindUIObject("Menu_SelectedUser_Local").GetComponentInChildren<SelectedUserMenuQM>();
                if (_interface != null)
                {
                    Log.Write("Found: QuickMenu SelectedUserMenuQM");
                }
                else
                {
                    _instance = null;
                    Log.Error("Not Found: QuickMenu SelectedUserMenuQM");
                }
                return _selectedUserMenuQM;
            }
        }
        internal static PlayerManager Manager => PlayerManager.field_Private_Static_PlayerManager_0;
        internal static List<Player> CurrentPlayers => Manager.field_Private_List_1_Player_0.ToArray().ToList();
        public static Player SelectedPlayer
        {
            get
            {
                SelectedUserMenuQM selected = Instance.field_Private_UIPage_1.GetComponent<SelectedUserMenuQM>();
                return GetPlayerByUserID(selected.field_Private_InterfacePublicAbstractStCoStBoObSt1BoSi1Unique_0.prop_String_0);
            }
        }
        internal static Player GetPlayerByUserID(string id)
        {
            foreach (var player in CurrentPlayers.Where(player => player.GetAPIUser().GetUserID() == id))
            {
                return player;
            }

            return null;
        }

        internal static bool ContainsPage(this List<QMNestedGridMenu> menus, UIPage page)
        {
            if (page != null && menus != null)
                if (menus.Count != 0)
                    foreach (var item in menus)
                        if (item.GetPage() == page)
                            return true;
            return false;
        }

        internal static string GetName(this UIPage page)
        {
            return page.field_Public_String_0;
        }
        internal static void SetName(this UIPage page, string Name)
        {
            if (page != null)
            {
                page.name = Name;
                page.field_Public_String_0 = Name;
            }
        }

        internal static GameObject FindUIObject(this GameObject parent, string name)
        {
            if (parent == null) return null;
            Transform[] trs = parent.GetComponentsInChildren<Transform>(true);
            foreach (var t in trs)
                if (t.name == name)
                    return t.gameObject;
            return null;
        }

        internal static bool IsObfuscated(this string str)
        {
            foreach (var it in str)
                if (!char.IsDigit(it) && !((it >= 'a' && it <= 'z') || (it >= 'A' && it <= 'Z')) && it != '_' &&
                    it != '`' && it != '.' && it != '<' && it != '>')
                    return true;

            return false;
        }
        public static void EnableUIComponents(this GameObject parent)
        {

            //parent.RemoveComponents<MonoBehaviourPublic28Bu16VoStVo1649Vo49Unique>();
            parent.RemoveComponents<CameraMenu>();
            parent.RemoveComponents<AnalyticsController>();
            parent.RemoveComponents<AvatarClone>();
            parent.RemoveComponents<MenuBackButton>();
            parent.RemoveComponents<WingMenuFriends>();
            parent.RemoveComponents<UiTooltip>(); 
            parent.RemoveComponents<UiToggleTooltip>();


            #region Button

            var Button = parent.GetComponent<Button>();
            if (Button != null)
            {
                Button.enabled = true;
            }

            var Buttons_List = parent.GetComponentsInChildren<Button>(true);
            for (var i = 0; i < Buttons_List.Count; i++)
            {
                var item = Buttons_List[i];
                if (item != null)
                {
                    item.enabled = true;
                }
            }


            #endregion
            #region LayoutElement

            var LayoutElement = parent.GetComponent<LayoutElement>();
            if (LayoutElement != null)
            {
                LayoutElement.enabled = true;
            }

            var LayoutElements_List = parent.GetComponentsInChildren<LayoutElement>(true);
            for (var i = 0; i < LayoutElements_List.Count; i++)
            {
                var item = LayoutElements_List[i];
                if (item != null)
                {
                    item.enabled = true;
                }
            }


            #endregion
            #region CanvasGroup

            var CanvasGroup = parent.GetComponent<CanvasGroup>();
            if (CanvasGroup != null)
            {
                CanvasGroup.enabled = true;
            }

            var CanvasGroups_List = parent.GetComponentsInChildren<CanvasGroup>(true);
            for (var i = 0; i < CanvasGroups_List.Count; i++)
            {
                var item = CanvasGroups_List[i];
                if (item != null)
                {
                    item.enabled = true;
                }
            }


            #endregion
            #region StyleElement

            var StyleElement = parent.GetComponent<StyleElement>();
            if (StyleElement != null)
            {
                StyleElement.enabled = true;
            }

            var StyleElements_List = parent.GetComponentsInChildren<StyleElement>(true);
            for (var i = 0; i < StyleElements_List.Count; i++)
            {
                var item = StyleElements_List[i];
                if (item != null)
                {
                    item.enabled = true;
                }
            }
            #endregion
            #region Image
            var Image = parent.GetComponent<Image>();
            if (Image != null)
            {
                Image.enabled = true;
            }

            var Images_List = parent.GetComponentsInChildren<Image>(true);
            for (var i = 0; i < Images_List.Count; i++)
            {
                var item = Images_List[i];
                if (item != null)
                {
                    item.enabled = true;
                }
            }
            #endregion
            #region TextMeshProUGUI
            var TextMeshProUGUIPublicBoUnique = parent.GetComponent<TextMeshProUGUIEx>();
            if (TextMeshProUGUIPublicBoUnique != null)
            {
                TextMeshProUGUIPublicBoUnique.enabled = true;
            }

            var TextMeshProUGUIPublicBoUnique_List = parent.GetComponentsInChildren<TextMeshProUGUIEx>(true);
            for (var i = 0; i < TextMeshProUGUIPublicBoUnique_List.Count; i++)
            {
                var item = TextMeshProUGUIPublicBoUnique_List[i];
                if (item != null)
                {
                    item.enabled = true;
                }
            }
            #endregion

            #region TextMeshProUGUI
            var TextMeshProUGUI = parent.GetComponent<TextMeshProUGUI>();
            if (TextMeshProUGUI != null)
            {
                TextMeshProUGUI.enabled = true;
            }

            var TextMeshProUGUIs_List = parent.GetComponentsInChildren<TextMeshProUGUI>(true);
            for (var i = 0; i < TextMeshProUGUIs_List.Count; i++)
            {
                var item = TextMeshProUGUIs_List[i];
                if (item != null)
                {
                    item.enabled = true;
                }
            }
            #endregion
            #region UiTooltip

            var UiTooltip = parent.GetComponent<UiTooltip>();
            if (UiTooltip != null)
            {
                UiTooltip.enabled = true;
            }

            var UiTooltips_List = parent.GetComponentsInChildren<UiTooltip>(true);
            for (var i = 0; i < UiTooltips_List.Count; i++)
            {
                var item = UiTooltips_List[i];
                if (item != null)
                {
                    item.enabled = true;
                }
            }


            #endregion
            #region Toggle

            var Toggle = parent.GetComponent<Toggle>();
            if (Toggle != null)
            {
                Toggle.enabled = true;
            }

            var Toggles_List = parent.GetComponentsInChildren<Toggle>(true);
            for (var i = 0; i < Toggles_List.Count; i++)
            {
                var item = Toggles_List[i];
                if (item != null)
                {
                    item.enabled = true;
                }
            }


            #endregion
            #region UIInvisibleGraphic

            var UIInvisibleGraphic = parent.GetComponent<UIInvisibleGraphic>();
            if (UIInvisibleGraphic != null)
            {
                UIInvisibleGraphic.enabled = true;
            }

            var UIInvisibleGraphics_List = parent.GetComponentsInChildren<UIInvisibleGraphic>(true);
            for (var i = 0; i < UIInvisibleGraphics_List.Count; i++)
            {
                var item = UIInvisibleGraphics_List[i];
                if (item != null)
                {
                    item.enabled = true;
                }
            }


            #endregion




            foreach (var item in parent.GetComponentsInChildren<Behaviour>(true))
            {
                
                item.enabled = true;
            }

            
        }


        public static TextMeshProUGUIEx NewText(this GameObject Parent, string search)
        {
            var text = new TextMeshProUGUIEx();

            var TextTop = Parent.GetComponentsInChildren<TextMeshProUGUIEx>();
            for (int i = 0; i < TextTop.Count; i++)
            {
                TextMeshProUGUIEx texto = TextTop[i];
                if (texto.name == search)
                    text = texto;
            }

            return text;
        }

        public static void CleanButtonsQuickActions(this GameObject Parent)
        {
            var Buttons = Parent.GetComponentsInChildren<Transform>(true);
            for (int i = 0; i < Buttons.Count; i++)
            {
                Transform button = Buttons[i];
                if (button.name.Contains("Button_") || button.name == "SitStandCalibrateButton" || button.name == "Buttons_AvatarDetails"
                    || button.name == "Buttons_AvatarAuthor")
                    UnityEngine.Object.Destroy(button.gameObject);
            }
        }

        public static void CleanCameraMenu(this GameObject Parent)
        {
            foreach(var child in Parent.Get_Childs())
            {
                if(child.gameObject.name != "Buttons (1)")
                {
                    UnityEngine.Object.Destroy(child.gameObject);
                }
                else
                {
                    foreach(var child2 in child.Get_Childs())
                    {
                        UnityEngine.Object.Destroy(child2.gameObject);
                    }
                }
            }
        }
        


        internal static void ShowTabContent(this MenuStateController MenuController, string PageName)
        {
            if (MenuController != null)
            {
                UIPage[] Pages = MenuController.field_Public_ArrayOf_UIPage_0;
                if (Pages != null)
                {
                    if (Pages.Length != 0)
                    {
                        for (int i = 0; i < Pages.Length; i++)
                        {
                            var page = Pages[i];
                            if (page != null)
                            {
                                if (page.GetName() == PageName)
                                {
                                    MenuController.ShowTabContent(i);
                                    break;
                                }
                            }

                        }
                    }
                }
            }
        }

        internal static void ShowWingsPage(this QMWings pagename)
        {
            if (pagename.isLeftWing)
            {
                QuickMenuTools.QM_Wing_Left.ShowTabContent(pagename.GetMenuName());
            }
            else
            {
                QuickMenuTools.QM_Wing_Right.ShowTabContent(pagename.GetMenuName());
            }
        }


        internal static GameObject CreateMainBackButton(this GameObject NestedPart)
        {
            var btn = NestedPart.FindUIObject("Button_Back");
            btn.SetActive(true);
            btn.GetComponentInChildren<Button>().onClick = new Button.ButtonClickedEvent();
            btn.GetComponentInChildren<Button>().onClick.AddListener(new Action(() =>
            {
                QuickMenuTools.QuickMenuController.ShowTabContent("QuickMenuDashboard");
                NestedPart.SetActive(false);
            }));
            return btn;
        }

        internal static GameObject CreateBackButton(this GameObject NestedPart, string menuName)
        {
            var btn = NestedPart.FindUIObject("Button_Back");
            btn.SetActive(true);
            btn.GetComponentInChildren<Button>().onClick = new Button.ButtonClickedEvent();
            btn.GetComponentInChildren<Button>().onClick.AddListener(new Action(() =>
            {
                QuickMenuTools.ShowQuickmenuPage(menuName);
                NestedPart.SetActive(false);
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