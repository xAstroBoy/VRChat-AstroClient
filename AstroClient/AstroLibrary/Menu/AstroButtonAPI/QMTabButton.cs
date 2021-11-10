namespace AstroButtonAPI
{
    using System;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    internal class QMTabButton : QMButtonBase
    {
        internal QMTabButton(int Index, System.Action btnAction, string btnToolTip, Color? btnBackgroundColor = null, string LoadSprite = "")
        {
            initButton(Index, btnAction, btnToolTip, btnBackgroundColor, LoadSprite);
        }
        internal QMTabButton(int Index, System.Action btnAction, string btnToolTip, Color? btnBackgroundColor = null, byte[] LoadSprite = null)
        {
            initButton(Index, btnAction, btnToolTip, btnBackgroundColor, LoadSprite);
        }

        internal void initButton(int Index, System.Action btnAction, string btnToolTip, Color? btnBackgroundColor = null, byte[] LoadSprite = null)
        {
            btnType = "_QMTabButton_";
            button = UnityEngine.Object.Instantiate(QuickMenuTools.TabButtonTemplate().gameObject, QuickMenuTools.TabButtonTemplate().parent, true);
            button.name = QMButtonAPI.identifier + btnType + Index;
            SetToolTip(btnToolTip);
            setAction(btnAction);
            button.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index);

            if (LoadSprite != null)
                button.LoadSprite(LoadSprite, "Icon");

            SetActive(true);
        }
        internal void initButton(int Index, System.Action btnAction, string btnToolTip, Color? btnBackgroundColor = null, string LoadSprite = "")
        {
            btnType = "_QMTabButton_";
            button = UnityEngine.Object.Instantiate(QuickMenuTools.TabButtonTemplate().gameObject, QuickMenuTools.TabButtonTemplate().parent, true);
            button.name = QMButtonAPI.identifier + btnType + Index;
            SetToolTip(btnToolTip);
            setAction(btnAction);
            button.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index);

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