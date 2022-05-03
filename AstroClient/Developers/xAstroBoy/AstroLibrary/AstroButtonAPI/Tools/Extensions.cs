using System.Linq;

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
    using VRC.DataModel.Core;
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


        internal static void ShowWingPage(this Wing instance, string pagename)
        {
            instance.field_Private_MenuStateController_0.ShowTabContent(pagename);
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

        private static List<string> ComponentsToNotDelete { get; } = new List<string>()
        {
            typeof(Button).FullName,
            typeof(LayoutElement).FullName,
            typeof(CanvasGroup).FullName,
            typeof(Image).FullName,
            typeof(TextMeshProUGUI).FullName,
            typeof(RectTransform).FullName,
            typeof(CanvasRenderer).FullName,
            typeof(VRC.UI.Core.Styles.StyleElement).FullName,
            typeof(VRC.UI.Elements.Tooltips.UiToggleTooltip).FullName,
            typeof(VRC.UI.Elements.Tooltips.UiTooltip).FullName,
            typeof(UnityEngine.UI.Toggle).FullName,
            typeof(UIInvisibleGraphic).FullName,

        };

        public static void EnableComponents(this GameObject parent)
        {
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





            var parentcomps = parent.GetComponents<Component>();
            for (int i = 0; i < parentcomps.Count; i++)
            {
                var name = parentcomps[i].GetIl2CppType().FullName;
                //Log.Debug($"Found {name}");
                if (!ComponentsToNotDelete.Contains(name))
                {
                    UnityEngine.Object.DestroyImmediate(parentcomps[i]);
                }
            }


            var childs = parent.GetComponentsInChildren<Component>(true);
            for (int i = 0; i < childs.Count; i++)
            {
                var name = childs[i].GetIl2CppType().FullName;
                //Log.Debug($"Found {name}");
                if (!ComponentsToNotDelete.Contains(name))
                {
                    UnityEngine.Object.DestroyImmediate(childs[i]);
                }
            }
        }

        public static TextMeshProUGUI NewText(this GameObject Parent, string search)
        {
            var text = new TextMeshProUGUI();

            var TextTop = Parent.GetComponentsInChildren<TextMeshProUGUI>();
            for (int i = 0; i < TextTop.Count; i++)
            {
                TextMeshProUGUI texto = TextTop[i];
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

        public static void CleanButtonsNestedMenu(this GameObject Parent)
        {
            var ButtonToDelete = Parent.GetComponentsInChildren<Button>(true);
            for (int i = 0; i < ButtonToDelete.Count; i++)
            {
                Button Button = ButtonToDelete[i];
                if (Button.name.Contains("Camera") || Button.name == "Button_Panorama" || Button.name == "Button_Screenshot"
                    || Button.name == "Button_VrChivePano" || Button.name == "Button_DynamicLight")
                    UnityEngine.Object.Destroy(Button.gameObject);
            }

            var ButtonToDelete2 = Parent.GetComponentsInChildren<Toggle>(true);
            for (int i1 = 0; i1 < ButtonToDelete2.Count; i1++)
            {
                Toggle Button = ButtonToDelete2[i1];
                if (Button.name == "Button_Steadycam")
                    UnityEngine.Object.Destroy(Button.gameObject);
            }
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
                                    MenuController.ShowTabContent(i, false);
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
                QuickMenuTools.Wing_Left.ShowWingPage(pagename.GetMenuName());
            }
            else
            {
                QuickMenuTools.Wing_Right.ShowWingPage(pagename.GetMenuName());
            }
        }

        internal static void ShowWingsPage(this QMWings page, string Page)
        {
            if (page.isLeftWing)
            {
                QuickMenuTools.Wing_Left.ShowWingPage(Page);
            }
            else
            {
                QuickMenuTools.Wing_Right.ShowWingPage(Page);
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