using System;
using AstroClient._1245.WorldAPI.ButtonAPI.MM;
using AstroClient._1245.WorldAPI.ButtonAPI.QM.Controls;
using AstroClient.xAstroBoy.AstroButtonAPI.Tools;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace AstroClient._1245.WorldAPI.ButtonAPI.QM.Buttons.Groups;

internal class CollapsibleButtonGroup : Root
{
    internal bool IsOpen { get; set; }
    internal GameObject headerObj { get; set; }
    internal Transform InfoButton { get; set; }
    internal ButtonGroup buttonGroup { get; set; }    
    internal static Action ActionButto { get; set; }

    internal CollapsibleButtonGroup(Transform parent, string text, bool openByDefault = false,
        bool MoreActionButton = false, string ActionButtontext = null, Action MoreActionButtonAction = null)
    {
        if (!APIBase.IsReady()) throw new Exception();

        headerObj = Object.Instantiate(APIBase.ColpButtonGrp, parent);
        headerObj.name = $"{text}_CollapsibleButtonGroup";

        TMProCompnt = headerObj.transform.Find("Label").GetComponent<TMPro.TextMeshProUGUI>();
        TMProCompnt.text = text;

        buttonGroup = new(parent, string.Empty, true);
        gameObject = buttonGroup.gameObject;
        var foldout = headerObj.GetComponent<FoldoutToggle>();

        InfoButton = headerObj.transform.Find("InfoButton");
        ActionButto = MoreActionButtonAction;
        MoreActionsButton(MoreActionButton, ActionButtontext, MoreActionButtonAction);
        foldout.field_Private_String_0 = "ButtonGroup";

        foldout.field_Private_Action_1_Boolean_0 = new Action<bool>(val =>
        {
            buttonGroup.gameObject.SetActive(val);
            IsOpen = val;
        });
    }

    internal void MoreActionsButton(bool enabled, string text, Action action) {
        if (ActionButto != null && action == null) action = ActionButto;
        ActionButto = action;
        InfoButton.gameObject.active = enabled;
        InfoButton.Find("Text_MM_H3").GetComponent<TMPro.TextMeshProUGUI>().text = text;
        InfoButton.GetComponentInChildren<Button>().onClick = new();
        InfoButton.GetComponentInChildren<Button>().onClick.AddListener(action);
    }


    /// <summary>
    ///  Remove Buttons, Toggles, anything that was put on this ButtnGrp
    /// </summary>
    internal void RemoveAllChildren() =>
        buttonGroup.gameObject.transform.DestroyChildren();


    internal CollapsibleButtonGroup(VRCPage page, string text, bool openByDefault = false) : this(page.menuContents, text, openByDefault) { }
    internal CollapsibleButtonGroup(MMPage page, string text, bool openByDefault = false) : this(page.menuContents, text, openByDefault) { }
}