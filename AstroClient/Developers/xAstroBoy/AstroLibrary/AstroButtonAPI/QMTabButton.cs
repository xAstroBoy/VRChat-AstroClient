namespace AstroClient.xAstroBoy.AstroButtonAPI
{
    using System;
    using UnhollowerRuntimeLib;
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;
    using Object = UnityEngine.Object;

    internal class QMTabButton : QMButtonBase
    {
        internal QMTabButton(int Index, Action btnAction, string btnToolTip, Color? btnBackgroundColor = null, Sprite LoadSprite = null)
        {
            initButton(Index, btnAction, btnToolTip, btnBackgroundColor, LoadSprite);
        }

        internal void initButton(int Index, Action btnAction, string btnToolTip, Color? btnBackgroundColor = null, Sprite LoadSprite = null)
        {
            btnType = "_QMTabButton_";
            button = Object.Instantiate(QuickMenuTools.TabButtonTemplate.gameObject, QuickMenuTools.TabButtonTemplate.parent, true);
            button.name = QMButtonAPI.identifier + btnType + Index;
            SetToolTip(btnToolTip);
            setAction(btnAction);
            button.GetComponentInChildren<RectTransform>().SetSiblingIndex(Index);

            if (LoadSprite != null)
                button.LoadSprite(LoadSprite, "Icon");

            SetActive(true);
        }


        internal void setAction(Action buttonAction)
        {
            button.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            if (buttonAction != null)
                button.GetComponent<Button>().onClick.AddListener(DelegateSupport.ConvertDelegate<UnityAction>(buttonAction));
        }
    }
}