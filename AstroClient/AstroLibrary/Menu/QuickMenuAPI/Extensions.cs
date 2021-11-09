namespace QuickMenuAPI
{
    using System;
    using CheetoLibrary;
    using UnityEngine;
    using UnityEngine.UI;
    using VRC.UI.Elements;

    internal static class Extensions
    {
        internal static void LoadSprite(this GameObject Parent, string LoadSprite, string name)
        {
            foreach (var image in Parent.GetComponentsInChildren<Image>(true))
            {
                if (image.name == name)// allows background image change
                {
                    image.gameObject.SetActive(true);
                    var texture = CheetoUtils.LoadPNG(LoadSprite);
                    image.overrideSprite = Sprite.CreateSprite(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), 100 * 1000, 1000, SpriteMeshType.FullRect, Vector4.zero, false);

                }
            }
        }

        internal static Sprite ToSprite(this Texture2D texture)
        {
            return Sprite.CreateSprite(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), 100 * 1000, 1000, SpriteMeshType.FullRect, Vector4.zero, false);
        }

        //public void LoadSprite(byte[] data)
        //{
        //    var image = GetIcon().GetComponent<Image>();
        //    var texture = CheetoUtils.LoadPNG(data);
        //    image.sprite = Sprite.CreateSprite(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), 100 * 1000, 1000, SpriteMeshType.FullRect, Vector4.zero, false);
        //    image.color = Color.white;
        //}


        public static GameObject FindObject(this GameObject parent, string name)
        {
            Transform[] trs = parent.GetComponentsInChildren<Transform>(true);
            foreach (Transform t in trs)
            {
                if (t.name == name)
                {
                    return t.gameObject;
                }
            }
            return null;
        }

        public static void EnableComponents(this GameObject parent)
        {
            parent.GetComponent<Button>().enabled = true;
            parent.GetComponent<LayoutElement>().enabled = true;
            parent.GetComponent<VRC.UI.Core.Styles.StyleElement>().enabled = true;
            parent.GetComponentInChildren<VRC.UI.Core.Styles.StyleElement>(true).enabled = true;
            parent.GetComponent<CanvasGroup>().enabled = true;
            parent.GetComponentInChildren<Image>().enabled = true;
            parent.GetComponentInChildren<TMPro.TextMeshProUGUI>(true).enabled = true;
            parent.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().enabled = true;
            UnityEngine.GameObject.Destroy(parent.GetComponent<MonoBehaviourPublic38Bu12Vo37Vo12St37VoUnique>());
        }

        public static TMPro.TextMeshProUGUI NewText(this GameObject Parent, string search)
        {
            TMPro.TextMeshProUGUI text = new TMPro.TextMeshProUGUI();

            var TextTop = Parent.GetComponentsInChildren<TMPro.TextMeshProUGUI>();
            foreach (TMPro.TextMeshProUGUI texto in TextTop)
            {
                if (texto.name == search)
                    text = texto;
            }

            return text;
        }

        public static void CleanButtonsQuickActions(this GameObject Parent)
        {
            TMPro.TextMeshProUGUI text = new TMPro.TextMeshProUGUI();

            var Buttons = Parent.GetComponentsInChildren<Transform>(true);
            foreach (var button in Buttons)
            {
                if (button.name.Contains("Button_") || button.name == "SitStandCalibrateButton" || button.name == "Buttons_AvatarDetails"
                    || button.name == "Buttons_AvatarAuthor")
                    UnityEngine.Object.Destroy(button.gameObject);
            }
        }

        public static void CleanButtonsNestedMenu(this GameObject Parent)
        {
            var ButtonToDelete = Parent.GetComponentsInChildren<Button>(true);
            foreach (var Button in ButtonToDelete)
            {
                if (Button.name.Contains("Camera") || Button.name == "Button_Panorama" || Button.name == "Button_Screenshot"
                    || Button.name == "Button_VrChivePano" || Button.name == "Button_DynamicLight")
                    UnityEngine.Object.Destroy(Button.gameObject);
            }

            var ButtonToDelete2 = Parent.GetComponentsInChildren<Toggle>(true);
            foreach (var Button in ButtonToDelete2)
            {
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

        internal static void PushPage(this MenuStateController _MenuStateController, string Page)
        {
            _MenuStateController.Method_Public_Void_String_UIContext_Boolean_0(Page);
        }

        internal static void CreateMainBackButton(this GameObject NestedPart)
        {
            QMNestedButton.backButton = NestedPart.FindObject("Button_Back");
            QMNestedButton.backButton.SetActive(true);
            QMNestedButton.backButton.GetComponentInChildren<Button>().onClick = new Button.ButtonClickedEvent();
            QMNestedButton.backButton.GetComponentInChildren<Button>().onClick.AddListener(new Action(() =>
            {
                QuickMenuStuff.GetQuickMenuInstance().prop_MenuStateController_0.field_Private_UIPage_0.enabled = true;
                QuickMenuStuff.GetQuickMenuInstance().prop_MenuStateController_0.Method_Public_UIPage_String_1("QuickMenuDashboard");
            }));
        }

        internal static void CreateBackButton(this GameObject NestedPart, string menuName)
        {
            QMNestedButton.backButton = NestedPart.FindObject("Button_Back");
            QMNestedButton.backButton.SetActive(true);
            QMNestedButton.backButton.GetComponentInChildren<Button>().onClick = new Button.ButtonClickedEvent();
            QMNestedButton.backButton.GetComponentInChildren<Button>().onClick.AddListener(new Action(() =>
            {
                QuickMenu quickmenu = QuickMenuStuff.GetQuickMenuInstance();
                QuickMenuStuff.ShowQuickmenuPage(menuName);
            }));
        }

        internal static Color HexToColor(this string hex)
        {
            Color color = Color.white;

            if (ColorUtility.TryParseHtmlString(hex, out color))
            {
                return color;
            }

            return color;
        }
    }
}