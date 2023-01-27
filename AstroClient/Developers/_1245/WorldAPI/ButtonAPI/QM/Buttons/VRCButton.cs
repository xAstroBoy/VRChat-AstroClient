using System;
using AstroClient._1245.WorldAPI.ButtonAPI.QM.Buttons.Groups;
using AstroClient._1245.WorldAPI.ButtonAPI.QM.Controls;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Core.Styles;
using Object = UnityEngine.Object;

namespace AstroClient._1245.WorldAPI.ButtonAPI.QM.Buttons
{
    internal class VRCButton : ExtentedControl
    {
        internal Transform transform { get; set; }

        internal VRCButton(Transform menu, string text, string tooltip, Action listener, bool Half = false, bool SubMenuIcon = false, Sprite Icon = null, HalfType Type = HalfType.Normal, bool IsGroup = false) {
            if (!APIBase.IsReady()) { Log.Error("Error, Something Was Missing!"); return; }

            if (Icon == null)
                Icon = APIBase.DefaultButtonSprite;
            if (menu != null)
                APIBase.LastButtonParent = menu;
            else if (menu == null && APIBase.LastButtonParent == null)
                menu = APIBase.Button.parent;
            else if (menu == null && APIBase.LastButtonParent != null)
                menu = APIBase.LastButtonParent;

            transform = Object.Instantiate(APIBase.Button, menu);
            gameObject = transform.gameObject;

            transform.gameObject.SetActive(true);
            TMProCompnt = transform.GetComponentInChildren<TextMeshProUGUI>();
            Text = text;
            TMProCompnt.text = text;
            ButtonCompnt = transform.GetComponent<Button>();
            ButtonCompnt.onClick = new Button.ButtonClickedEvent();
            onClickAction = listener;
            ButtonCompnt.onClick.AddListener(new Action(() => APIBase.SafelyInvoke(onClickAction, Text)));

            ImgCompnt = transform.transform.Find("Icon").GetComponent<Image>();
            ImgCompnt.gameObject.GetComponent<StyleElement>().enabled = false; // Fix the Images from going back to the default

            if (Icon != null)
                ImgCompnt.sprite = Icon;
            else {
                transform.transform.Find("Icon").gameObject.active = false;
                ResetTextPox();
            }
            Object.Destroy(transform.transform.Find("Icon_Secondary").gameObject);
            gameObject.transform.Find("Badge_MMJump").gameObject.SetActive(SubMenuIcon);
            this.SetToolTip(tooltip);
            if (Half) TurnHalf(Type, IsGroup);
            if (!string.IsNullOrEmpty(APIBase.autoColorHex)) RecolorBackGrn(APIBase.autoColorHex);
            transform.name = text;
        }


        internal VRCButton(ButtonGroup buttonGroup, string text, string tooltip, Action click, bool Half = false, bool subMenuIcon = false, Sprite icon = null) 
            : this(buttonGroup.transform, text, tooltip, click, Half, subMenuIcon, icon)
        {
        }

        internal VRCButton(CollapsibleButtonGroup buttonGroup, string text, string tooltip, Action click, bool Half = false, bool subMenuIcon = false, Sprite icon = null)
            : this(buttonGroup.buttonGroup.transform, text, tooltip, click, Half, subMenuIcon, icon)
        {
        }
    }
}
