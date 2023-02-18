﻿using UiTooltip = VRC.UI.Elements.Tooltips.UiTooltip;

namespace AstroClient.xAstroBoy.Extensions
{
    using AstroButtonAPI;
    using AstroButtonAPI.QuickMenuAPI;
    using UnityEngine;
    using UnityEngine.UI;
    using Utility;
    using VRC.UI.Elements.Tooltips;

    internal static class ButtonExtensions
    {
        internal static void SetButtonToArrow(this QMSingleButton button) => button.GetGameObject().GetComponentInChildren<Image>(true).sprite = QuickMenuUtils.QuickMenu.transform.Find("QuickMenu_NewElements/_CONTEXT/QM_Context_User_Selected/NextArrow_Button").GetComponent<Image>().sprite;

        internal static void RotateButton(this QMSingleButton button, float rotation) => button.GetGameObject().transform.Rotate(new Vector3(0f, 0f, rotation));

        internal static void ToggleBtnImage(this QMSingleButton btn, bool enabled) => btn.GetGameObject().GetComponentInChildren<Image>(true).enabled = enabled;

        internal static void SetButtonToolTip(this VRC.UI.Elements.Tooltips.UiTooltip tooltip, string text)
        {
            if (tooltip != null)
            {
                tooltip.field_Public_String_0 = text;
                tooltip.field_Public_String_1 = text;
            }
        }
        internal static void SetButtonToolTip(this UIToggleTooltip tooltip, string text)
        {
            if (tooltip != null)
            {
                tooltip.field_Public_String_0 = text;
                //tooltip.field_Public_String_1 = text;
            }
        }

    }
}