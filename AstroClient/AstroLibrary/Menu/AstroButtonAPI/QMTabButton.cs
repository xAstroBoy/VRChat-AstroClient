namespace AstroButtonAPI
{
    using System;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    internal class QMTabButton : QMButtonBase
    {
        internal QMTabButton(float Index, System.Action btnAction, String btnToolTip, Color? btnBackgroundColor = null, string LoadSprite = "")
        {
            initButton(Index, btnAction, btnToolTip, btnBackgroundColor, LoadSprite);
        }
        internal QMTabButton(float Index, System.Action btnAction, String btnToolTip, Color? btnBackgroundColor = null, byte[] LoadSprite = null)
        {
            initButton(Index, btnAction, btnToolTip, btnBackgroundColor, LoadSprite);
        }

        internal void initButton(float Index, System.Action btnAction, String btnToolTip, Color? btnBackgroundColor = null, byte[] LoadSprite = null)
        {
            btnType = "_QMTabButton_";
            button = UnityEngine.Object.Instantiate(QuickMenuStuff.TabButtonTemplate(), QuickMenuStuff.TabButtonTemplate().transform.parent, true);
            button.name = QMButtonAPI.identifier + btnType + Index;
            SetToolTip(btnToolTip);
            setAction(btnAction);
            button.GetComponentInChildren<RectTransform>().SetSiblingIndex((int)Index);

            if (LoadSprite != null)
                button.LoadSprite(LoadSprite, "Icon");

            SetActive(true);
        }
        internal void initButton(float Index, System.Action btnAction, String btnToolTip, Color? btnBackgroundColor = null, string LoadSprite = "")
        {
            btnType = "_QMTabButton_";
            button = UnityEngine.Object.Instantiate(QuickMenuStuff.TabButtonTemplate(), QuickMenuStuff.TabButtonTemplate().transform.parent, true);
            button.name = QMButtonAPI.identifier + btnType + Index;
            SetToolTip(btnToolTip);
            setAction(btnAction);
            button.GetComponentInChildren<RectTransform>().SetSiblingIndex((int)Index);

            if (LoadSprite != "")
                button.LoadSprite(LoadSprite, "Icon");

            SetActive(true);
        }

        internal void setAction(System.Action buttonAction)
        {
            button.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            if (buttonAction != null)
                button.GetComponent<Button>().onClick.AddListener(UnhollowerRuntimeLib.DelegateSupport.ConvertDelegate<UnityAction>(buttonAction));
        }
    }
}