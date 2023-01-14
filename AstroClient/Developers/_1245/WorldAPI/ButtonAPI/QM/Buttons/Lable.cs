using System;
using AstroClient.xAstroBoy.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WorldAPI.ButtonAPI.Controls;
using WorldAPI.ButtonAPI.Extras;
using WorldAPI.ButtonAPI.Groups;
using WorldAPI.Buttons;

namespace WorldAPI.ButtonAPI.Buttons
{
    internal class VRCLable : LableControls
    {
        internal readonly VRCButton SButton;
        internal readonly TextMeshProUGUI LowerTextUgui;

        internal VRCLable(Transform menu, string text, string LowerText, Action onClick = null, bool Bg = true)
        {
            Text = text;

            if (menu != null)
                APIBase.LastButtonParent = menu;
            else if (menu == null && APIBase.LastButtonParent == null)
                menu = APIBase.Button.parent;
            else if (menu == null && APIBase.LastButtonParent != null)
                menu = APIBase.LastButtonParent;
            SButton = new VRCButton(menu, text, null, onClick);
            SButton.ImgCompnt.gameObject.active = false;
            TMProCompnt = SButton.TMProCompnt;
            SButton.transform.Find("Background").gameObject.active = Bg;
            gameObject = SButton.gameObject;
            //SButton.transform.Find("Background").GetComponent<Image>().color = new Color(0f, 0f, 0f, 0f);
            var Text2 = UnityEngine.Object.Instantiate(SButton.transform.Find("Text_H4").gameObject, new Vector3(0, -54.75f, 0), Quaternion.Euler(0, 0, 0), SButton.transform);
            Text2.GetComponent<TextMeshProUGUI>().text = LowerText;
            LowerTextUgui = Text2.GetComponent<TextMeshProUGUI>();
            SButton.TMProCompnt.transform.localPosition = new Vector3(0f, 2f, 0f);
            SButton.TMProCompnt.fontSize = 38f;
            SButton.TMProCompnt.enableAutoSizing = true;
            ButtonCompnt = SButton.gameObject.GetOrAddComponent<Button>();
            if (onClick == null)
            {
                ButtonCompnt.enabled = false;
                SButton.gameObject.GetOrAddComponent<VRC.UI.Core.Styles.StyleElement>().enabled = false;
            }
            Text2.transform.localPosition = new Vector3(0, -54.75f, 0);
            Text2.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }

        internal VRCLable(ButtonGroup grp, string text, string LowerText, Action onClick = null, bool Bg = false)
            : this(grp.gameObject.transform, text, LowerText, onClick, Bg)
        {
        }

        internal VRCLable(CollapsibleButtonGroup grp, string text, string LowerText, Action onClick = null, bool Bg = false)
            : this(grp.buttonGroup.gameObject.transform, text, LowerText, onClick, Bg)
        {
        }
    }
}
