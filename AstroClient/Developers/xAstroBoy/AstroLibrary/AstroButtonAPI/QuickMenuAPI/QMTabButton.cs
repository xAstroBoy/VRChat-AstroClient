using VRC.UI.Elements;

namespace AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI
{
    using System;
    using AstroClient.Tools.Extensions;
    using Extensions;
    using Tools;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;
    using Object = UnityEngine.Object;

    internal class QMTabButton
    {
        internal string btnQMLoc { get; set; }
        internal string btnTag { get; set; }
        internal string btnType { get; set; }
        internal GameObject ButtonObject { get; set; }
        private VRC.UI.Elements.Tooltips.UiTooltip _ButtonToolTip;
        private VRC.UI.Elements.Controls.MenuTab _MenuTab { get; set; }
        internal VRC.UI.Elements.Tooltips.UiTooltip ButtonToolTip
        {
            get
            {
                if (_ButtonToolTip == null)
                {
                    var attempt1 = ButtonObject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>();
                    if (attempt1 == null)
                    {
                        attempt1 = ButtonObject.GetComponentInChildren<VRC.UI.Elements.Tooltips.UiTooltip>(true);
                    }
                    if (attempt1 != null)
                    {
                        return _ButtonToolTip = attempt1;
                    }
                }

                return _ButtonToolTip;
            }
        }

        internal string ToolTipText { get; set; }

        internal QMTabButton(int Index, Action btnAction, string btnToolTip, Color? btnBackgroundColor = null, Sprite LoadSprite = null)
        {
            initButton(Index, btnAction, btnToolTip, btnBackgroundColor, LoadSprite);
        }

        internal void initButton(int Index, Action btnAction, string btnToolTip, Color? btnBackgroundColor = null, Sprite LoadSprite = null)
        {
            btnType = "_QMTabButton_";
            ButtonObject = Object.Instantiate(QuickMenuTools.TabButtonTemplate.gameObject, QuickMenuTools.TabButtonTemplate.parent, true);
            var pagename = QMButtonAPI.identifier + btnType + Index;
            ButtonObject.name = pagename;
            _MenuTab = ButtonObject.GetComponent<VRC.UI.Elements.Controls.MenuTab>();
            if(_MenuTab != null)
            {
                _MenuTab.field_Public_String_0 = string.Empty; // Separate it from glowing along with the template tab 
            }
            

            SetToolTip(btnToolTip);
            SetAction(btnAction);
            ButtonObject.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index);

            if (LoadSprite != null)
                ButtonObject.LoadSprite(LoadSprite, "Icon");

            SetActive(true);
        }

        internal void SetGlowEffect(UIPage page)
        {
            if (_MenuTab != null)
            {
                _MenuTab.field_Public_String_0 = page.GetName(); // Separate it from glowing along with the settings 
            }
        }
        internal void SetGlowEffect(string pagename)
        {
            if (_MenuTab != null)
            {
                _MenuTab.field_Public_String_0 = pagename; // Separate it from glowing along with the settings 
            }
        }


        internal void SetActive(bool isActive)
        {
            ButtonObject.gameObject.SetActive(isActive);
        }

        internal void DestroyMe()
        {
            UnityEngine.Object.Destroy(ButtonObject);
        }

        internal void SetToolTip(string text)
        {
            ToolTipText = text;
            ButtonToolTip.SetButtonToolTip(text);
        }

        internal void SetAction(Action buttonAction)
        {
            ButtonObject.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            if (buttonAction != null)
                ButtonObject.GetComponent<Button>().onClick.AddListener(DelegateSupport.ConvertDelegate<UnityAction>(buttonAction));
        }
    }
}