namespace AstroClient.Extensions
{
	using DayClientML2.Utility.Extensions;
	using RubyButtonAPI;
	using UnityEngine;
	using UnityEngine.UI;

	public static class ButtonsExtensions
	{
		public static void SetButtonToArrow(this QMSingleButton button)
		{
			button.GetGameObject().GetComponent<Image>().sprite = Utils.QuickMenu.transform.Find("QuickMenu_NewElements/_CONTEXT/QM_Context_User_Selected/NextArrow_Button").GetComponent<Image>().sprite;
		}

		public static void RotateButton(this QMSingleButton button, float rotation)
		{
			button.GetGameObject().transform.Rotate(new Vector3(0f, 0f, rotation));
		}
	}
}