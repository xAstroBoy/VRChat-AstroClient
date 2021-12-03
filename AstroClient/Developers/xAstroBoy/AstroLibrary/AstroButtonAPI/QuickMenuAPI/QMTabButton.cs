namespace AstroClient.xAstroBoy.AstroButtonAPI.QuickMenuAPI
{
    using System;
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
        internal UiTooltip ButtonToolTip { get; set; }


        internal QMTabButton(int Index, Action btnAction, string btnToolTip, Color? btnBackgroundColor = null, Sprite LoadSprite = null)
        {
            initButton(Index, btnAction, btnToolTip, btnBackgroundColor, LoadSprite);
        }

        internal void initButton(int Index, Action btnAction, string btnToolTip, Color? btnBackgroundColor = null, Sprite LoadSprite = null)
        {
            btnType = "_QMTabButton_";
            ButtonObject = Object.Instantiate(QuickMenuTools.TabButtonTemplate.gameObject, QuickMenuTools.TabButtonTemplate.parent, true);
            ButtonObject.name = QMButtonAPI.identifier + btnType + Index;
            ButtonToolTip = ButtonObject.GetComponentInChildren<UiTooltip>(true);
            SetToolTip(btnToolTip);
            setAction(btnAction);
            ButtonObject.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index);

            if (LoadSprite != null)
                ButtonObject.LoadSprite(LoadSprite, "Icon");

            SetActive(true);
        }
        internal void SetActive(bool isActive)
        {
            ButtonObject.gameObject.SetActive(isActive);
        }

        internal void DestroyMe()
        {
            try
            {
                Object.Destroy(ButtonObject);
            }
            catch
            {
            }
        }
        internal void SetToolTip(string text)
        {
            ButtonToolTip.SetButtonToolTip(text);
        }

        internal void setAction(Action buttonAction)
        {
            ButtonObject.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            if (buttonAction != null)
                ButtonObject.GetComponent<Button>().onClick.AddListener(DelegateSupport.ConvertDelegate<UnityAction>(buttonAction));
        }
    }
}