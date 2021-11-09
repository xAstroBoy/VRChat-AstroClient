namespace QuickMenuAPI
{
    using UnityEngine;

    internal class QMButtonBase
    {
        protected GameObject button;
        protected string btnQMLoc;
        protected string btnType;
        protected string btnTag;
        protected int[] initShift = { 0, 0 };
        protected Color OrigBackground;
        protected Color OrigText;

        internal GameObject GetGameObject()
        {
            return button;
        }

        internal void SetActive(bool state)
        {
            button.gameObject.SetActive(state);
        }

        internal void SetLocation(float buttonXLoc, float buttonYLoc)
        {
            button.GetComponent<RectTransform>().anchoredPosition += Vector2.right * (420 / 2 * (buttonXLoc + initShift[0]));
            button.GetComponent<RectTransform>().anchoredPosition += Vector2.down * (420 / 2 * (buttonYLoc + initShift[1]));

            //btnTag = "(" + buttonXLoc + "," + buttonYLoc + ")";
            //button.name = btnQMLoc + "/" + btnType + btnTag;
            //button.GetComponent<Button>().name = btnType + btnTag;
        }

        internal void setToolTip(string buttonToolTip)
        {
            button.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = buttonToolTip;
        }

        internal virtual void setBackgroundColor(Color buttonBackgroundColor, bool save = true) { }
        internal virtual void setTextColor(Color buttonTextColor) { }

        internal void DestroyMe()
        {
            if (button != null)
            {
                UnityEngine.Object.Destroy(button);
            }
        }

    }
}