using System;
using AstroClient._1245.WorldAPI.ButtonAPI.QM.Buttons.Groups;
using AstroClient._1245.WorldAPI.ButtonAPI.QM.Controls;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace AstroClient._1245.WorldAPI.ButtonAPI.QM.Buttons
{
    internal class VRCToggle : ToggleControl
    {

        internal VRCToggle(Transform menu, string text, Action<bool> listener, bool DefaultState = false,
            string OffTooltip = null, string OnToolTip = null,
            Sprite onimage = null, Sprite offimage = null, bool half = false)
        {
            if (!APIBase.IsReady()) throw new Exception();

            if(menu != null)
                APIBase.LastButtonParent = menu;
            else if (menu == null && APIBase.LastButtonParent == null)
                menu = APIBase.Button.parent;
            else if (menu == null && APIBase.LastButtonParent != null)
                menu = APIBase.LastButtonParent;
            if (OffTooltip == null) OffTooltip = $"Turn On {text.Replace("\n", string.Empty)}";
            if (OnToolTip == null) OnToolTip = $"Turn Off {text.Replace("\n", string.Empty)}";

            Transform transform = Object.Instantiate(APIBase.Toggle, menu);
            gameObject = transform.gameObject;

            transform.gameObject.SetActive(true);

            TMProCompnt = transform.GetComponentInChildren<TextMeshProUGUI>();
            Text = text;
            TMProCompnt.text = text;
            ToggleCompnt = transform.GetComponent<Toggle>();
            ToggleCompnt.onValueChanged = new Toggle.ToggleEvent();
            State = DefaultState;
            Listener = listener;
            ToggleCompnt.onValueChanged.AddListener(new Action<bool>((val) => APIBase.SafelyInvoke(val, Listener, Text)));

            OnImage = gameObject.transform.Find("Icon_On").GetComponent<Image>();
            OffImage = gameObject.transform.Find("Icon_Off").GetComponent<Image>();

            SetImages(true, onimage, offimage);
            SetToolTip(OffTooltip, OnToolTip);
            if (half) TurnHalf();
            transform.name = text;
        }


        internal VRCToggle(ButtonGroup buttonGroup, string text, Action<bool> stateChanged, bool DefaultState = false, string OffTooltip = "Off", string OnToolTip = "On")
            : this(buttonGroup.transform, text, stateChanged, DefaultState, OffTooltip, OnToolTip)
        {
        }

        internal VRCToggle(CollapsibleButtonGroup buttonGroup, string text, Action<bool> stateChanged, bool DefaultState = false, string OffTooltip = "Off", string OnToolTip = "On")
            : this(buttonGroup.buttonGroup.transform, text, stateChanged, DefaultState, OffTooltip, OnToolTip)
        {
        }
    }
}
