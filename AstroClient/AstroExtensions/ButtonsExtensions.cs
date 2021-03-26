using UnityEngine;

#region AstroClient Imports

using RubyButtonAPI;
using UnityEngine.UI;
using DayClientML2.Utility.Extensions;

#endregion AstroClient Imports

namespace AstroClient.extensions
{
    public static class ButtonsExtensions
    {
        public static void SetButtonToArrow(this QMSingleButton button)
        {
            button.getGameObject().GetComponent<Image>().sprite = Utils.QuickMenu.transform.Find("QuickMenu_NewElements/_CONTEXT/QM_Context_User_Selected/NextArrow_Button").GetComponent<Image>().sprite;
        }

        public static void RotateButton(this QMSingleButton button, float rotation)
        {
            button.getGameObject().transform.Rotate(new Vector3(0f, 0f, rotation));
        }
    }
}