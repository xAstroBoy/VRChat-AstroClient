using System;
using AstroClient.Tools.Extensions;
using AstroClient.xAstroBoy.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WorldAPI.ButtonAPI.Controls;
using WorldAPI.ButtonAPI.MM;
using WorldAPI.ButtonAPI.Extras;
using Object = UnityEngine.Object;

namespace WorldAPI.ButtonAPI.Groups;

internal class ButtonGroup : ButtonGrp
{
    internal Transform transform { get; set; }
    private GridLayoutGroup Layout { get; set; }

    internal ButtonGroup(Transform parent, string text, bool NoText = false, TextAnchor ButtonAlignment = TextAnchor.UpperCenter) {
        if (!APIBase.IsReady()) throw new Exception();

        WasNoText = NoText;

        if (!NoText) {
            headerGameObject = Object.Instantiate(APIBase.ButtonGrpText, parent);
            TMProCompnt = headerGameObject.GetComponentInChildren<TextMeshProUGUI>(true);
            TMProCompnt.text = text;
            Text = text;
        }

        gameObject = Object.Instantiate(APIBase.ButtonGrp, parent);
        gameObject.name = text;
        gameObject.transform.DestroyChildren();
        transform = gameObject.transform;

        Layout = gameObject.GetOrAddComponent<GridLayoutGroup>();
        Layout.childAlignment = ButtonAlignment;

        parentMenuMask = parent.parent.GetOrAddComponent<RectMask2D>();
    }

    internal void ChangeChildAlignment(TextAnchor ButtonAlignment = TextAnchor.UpperCenter) => Layout.childAlignment = ButtonAlignment;

    internal ButtonGroup(VRCPage page, string text, bool NoText = false, TextAnchor ButtonAlignment = TextAnchor.UpperCenter) : this(page.menuContents, text, NoText, ButtonAlignment) { }
    internal ButtonGroup(MMPage page, string text, bool NoText = false, TextAnchor ButtonAlignment = TextAnchor.UpperCenter) : this(page.menuContents, text, NoText, ButtonAlignment) { }
}
