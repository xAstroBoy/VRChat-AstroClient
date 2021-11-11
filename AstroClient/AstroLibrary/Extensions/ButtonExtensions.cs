namespace AstroLibrary.Extensions
{
    using AstroButtonAPI;
    using UnityEngine;
    using UnityEngine.UI;
    using Utility;

    internal static class ButtonExtensions
    {
        internal static void SetButtonToArrow(this QMSingleButton button) => button.GetGameObject().GetComponentInChildren<Image>(true).sprite = QuickMenuUtils.QuickMenu.transform.Find("QuickMenu_NewElements/_CONTEXT/QM_Context_User_Selected/NextArrow_Button").GetComponent<Image>().sprite;

        internal static void RotateButton(this QMSingleButton button, float rotation) => button.GetGameObject().transform.Rotate(new Vector3(0f, 0f, rotation));

        internal static void ToggleBtnImage(this QMSingleButton btn, bool enabled) => btn.GetGameObject().GetComponentInChildren<Image>(true).enabled = enabled;
    }
}